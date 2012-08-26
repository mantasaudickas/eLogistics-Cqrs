using System;
using System.Collections.Generic;
using eLogistics.Application.CQRS.Interfaces.Dto;

namespace eLogistics.Application.CQRS.Service.Storage
{
    public interface IReadModelStore
    {
        List<T> GetList<T>(string filter) where T : DataTransferObject;
        T Load<T>(Guid aggregateId) where T : DataTransferObject;
        void Save<T>(T dto) where T : DataTransferObject;
        void Delete<T>(Guid aggregateId);
    }
}
