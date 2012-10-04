using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using eLogistics.Application.CQRS;
using eLogistics.Application.CQRS.Commands;
using eLogistics.Application.CQRS.Interfaces.Dto;
using eLogistics.Application.CQRS.Service;

namespace eLogistics.Application.UI.Domain
{
    public abstract class EditModel<TDto> : INotifyPropertyChanged
        where TDto : DataTransferObject, new()
    {
        private readonly List<Command> _changeCommands = new List<Command>();
        private readonly TDto _dto;

        protected EditModel(TDto dto)
        {
            _dto = dto ;
            if (_dto == null)
            {
                _dto = new TDto();
                this.CreatedNew = true;
            }
        }

        public TDto Dto { get { return _dto; } }
        protected bool CreatedNew { get; private set; }
        private IMessageBus Bus { get { return ServiceMediator.Bus; } }

        protected void Send<T>(T command)
            where T : Command
        {
            _changeCommands.Add(command);
        }

        protected void ClearChanges()
        {
            _changeCommands.Clear();
        }

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

    }
}
