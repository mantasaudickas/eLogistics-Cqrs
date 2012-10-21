using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using eLogistics.Application.CQRS.Interfaces.Dto;

namespace eLogistics.Application.UI
{
    public abstract class EditModel<TDto> : EditModelBase, INotifyPropertyChanged
        where TDto : DataTransferObject, new()
    {
        #region Fields

        private readonly TDto _dto;

        #endregion

        #region Constructor

        protected EditModel()
            : this(null)
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
        
        protected bool CreatedNew { get; private set; }

        #endregion

        #region Send

        #endregion

        #region Delete Model

        public void Delete()
        {
            this.ClearChanges();
            this.OnDelete();
        }
        
        protected virtual void OnDelete()
        {
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
