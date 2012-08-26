using System;
using System.Collections.Generic;
using eLogistics.Application.CQRS.Interfaces.Dto;
using eLogistics.Application.CQRS.Service.Storage;

namespace eLogistics.Application.CQRS.Client.Views
{
    public abstract class View<TDto>
            where TDto : DataTransferObject
    {
        private readonly IReadModelStore _readModelStore;

        protected View(IReadModelStore readModelStore)
        {
            _readModelStore = readModelStore;
        }

        public List<TDto> GetList(string filter)
        {
            return _readModelStore.GetList<TDto>(filter);
        }

        public TDto Load(Guid aggregateId)
        {
            return _readModelStore.Load<TDto>(aggregateId);
        }

        public void Save(TDto dto)
        {
            _readModelStore.Save(dto);
        }

        public void Delete<T>(Guid aggregateId)
        {
            _readModelStore.Delete<T>(aggregateId);
        }
    }
}
