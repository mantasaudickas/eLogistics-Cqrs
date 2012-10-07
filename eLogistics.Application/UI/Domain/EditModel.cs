using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using eLogistics.Application.CQRS;
using eLogistics.Application.CQRS.Commands;
using eLogistics.Application.CQRS.Interfaces.Dto;
using eLogistics.Application.CQRS.Service;

namespace eLogistics.Application.UI.Domain
{
    public abstract class EditModel<TDto> : INotifyPropertyChanged
        where TDto : DataTransferObject, new()
    {
        #region Fields

        private readonly List<Command> _changeCommands = new List<Command>();
        private readonly TDto _dto;

        #endregion

        #region Constructor

        protected EditModel() : this(null)
        {
        }

        protected EditModel(TDto dto)
        {
            _dto = dto;
            if (_dto == null)
            {
                _dto = new TDto();
                this.CreatedNew = true;
            }
        }

        #endregion

        #region Properties

        public TDto Dto
        {
            get { return _dto; }
        }

        public bool HasChanges { get { return _changeCommands.Count > 0; } }

        protected bool CreatedNew { get; private set; }

        private IMessageBus Bus
        {
            get { return ServiceMediator.Bus; }
        }

        #endregion

        #region Send

        protected void Send<T>(T command)
            where T : Command
        {
            _changeCommands.Add(command);
        }

        #endregion

        #region Delete Model

        public void Delete()
        {
            this.ClearChanges();
            this.OnDelete();
        }

        private void ClearChanges()
        {
            _changeCommands.Clear();
        }

        protected virtual void OnDelete()
        {
        }

        #endregion

        #region Commit Model

        public void Commit()
        {
            MinimizeCommands();

            foreach (Command changeCommand in _changeCommands)
            {
                this.Bus.Send(changeCommand);
            }

            this.ClearChanges();
        }

        private void MinimizeCommands()
        {
            if (_changeCommands.Count > 1)
            {
                // minimize commands
                IDictionary<Guid, HashSet<Type>> usedCommands = new Dictionary<Guid, HashSet<Type>>();
                for (int i = _changeCommands.Count - 1; i >= 0; i--)
                {
                    Command command = _changeCommands[i];
                    HashSet<Type> commandSet;
                    if (!usedCommands.TryGetValue(command.Id, out commandSet))
                    {
                        commandSet = new HashSet<Type>();
                        usedCommands.Add(command.Id, commandSet);
                    }

                    Type commandType = command.GetType();
                    if (!commandSet.Contains(commandType))
                    {
                        commandSet.Add(commandType);
                    }
                    else
                    {
                        _changeCommands.RemoveAt(i);
                    }
                }
            }
        }

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            this.OnPropertyChanged(propertyName);
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        public TDto CloneDto()
        {
            TDto clone;
            using (MemoryStream stream = new MemoryStream())
            {
                DataContractSerializer serializer = new DataContractSerializer(_dto.GetType());
                serializer.WriteObject(stream, _dto);
                stream.Position = 0;
                clone = (TDto) serializer.ReadObject(stream);
            }
            return clone;
        }
    }
}
