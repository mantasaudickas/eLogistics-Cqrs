using System;
using System.Runtime.Serialization;
using eLogistics.Application.CQRS.Interfaces;
using eLogistics.Application.CQRS.Interfaces.Dto.Domain;
using eLogistics.Application.CQRS.Service.Events;
using eLogistics.Application.CQRS.Service.Storage;
namespace eLogistics.Application.CQRS.Client.Views.Base
{
    public abstract class SupplierViewBase : View<SupplierDto>
        , IHandler<SupplierEvents.Created>
        , IHandler<SupplierEvents.NameChanged>
        , IHandler<SupplierEvents.CompanyAdded>
        , IHandler<SupplierEvents.CompanyRemoved>
        , IHandler<SupplierEvents.NoteChanged>
        , IHandler<SupplierEvents.BankAccountAdded>
        , IHandler<SupplierEvents.BankAccountRemoved>

    {
        protected SupplierViewBase(IReadModelStore readModelStore) : base(readModelStore)
        {
        }

        public abstract void Handle(SupplierEvents.Created message);
        public abstract void Handle(SupplierEvents.NameChanged message);
        public abstract void Handle(SupplierEvents.CompanyAdded message);
        public abstract void Handle(SupplierEvents.CompanyRemoved message);
        public abstract void Handle(SupplierEvents.NoteChanged message);
        public abstract void Handle(SupplierEvents.BankAccountAdded message);
        public abstract void Handle(SupplierEvents.BankAccountRemoved message);
    }
}
