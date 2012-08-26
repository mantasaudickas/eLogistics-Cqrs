using System;
using System.Runtime.Serialization;
using eLogistics.Application.CQRS.Interfaces;
using eLogistics.Application.CQRS.Interfaces.Dto.Domain;
using eLogistics.Application.CQRS.Service.Events;
using eLogistics.Application.CQRS.Service.Storage;
namespace eLogistics.Application.CQRS.Client.Views.Base
{
    public abstract class CustomerViewBase : View<CustomerDto>
        , IHandler<CustomerEvents.Created>
        , IHandler<CustomerEvents.NameChanged>
        , IHandler<CustomerEvents.CompanyAdded>
        , IHandler<CustomerEvents.CompanyRemoved>
        , IHandler<CustomerEvents.NoteChanged>
        , IHandler<CustomerEvents.BankAccountAdded>
        , IHandler<CustomerEvents.BankAccountRemoved>
        , IHandler<CustomerEvents.PaymentTypeAdded>
        , IHandler<CustomerEvents.PaymentTypeRemoved>

    {
        protected CustomerViewBase(IReadModelStore readModelStore) : base(readModelStore)
        {
        }

        public abstract void Handle(CustomerEvents.Created message);
        public abstract void Handle(CustomerEvents.NameChanged message);
        public abstract void Handle(CustomerEvents.CompanyAdded message);
        public abstract void Handle(CustomerEvents.CompanyRemoved message);
        public abstract void Handle(CustomerEvents.NoteChanged message);
        public abstract void Handle(CustomerEvents.BankAccountAdded message);
        public abstract void Handle(CustomerEvents.BankAccountRemoved message);
        public abstract void Handle(CustomerEvents.PaymentTypeAdded message);
        public abstract void Handle(CustomerEvents.PaymentTypeRemoved message);
    }
}
