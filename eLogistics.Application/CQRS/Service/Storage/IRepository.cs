using System;
using eLogistics.Application.CQRS.Service.Domain;

namespace eLogistics.Application.CQRS.Service.Storage
{
    public interface IRepository<TDomain>
        where TDomain : IAggregateRoot
    {
        TDomain GetById(Guid id);
        void Save(TDomain domain);
    }
}
