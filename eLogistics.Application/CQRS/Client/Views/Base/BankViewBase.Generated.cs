using System;
using System.Runtime.Serialization;
using eLogistics.Application.CQRS.Interfaces;
using eLogistics.Application.CQRS.Interfaces.Dto.Domain;
using eLogistics.Application.CQRS.Service.Events;
using eLogistics.Application.CQRS.Service.Storage;
namespace eLogistics.Application.CQRS.Client.Views.Base
{
    public abstract class BankViewBase : View<BankDto>
        , IHandler<BankEvents.Created>
        , IHandler<BankEvents.NameChanged>
        , IHandler<BankEvents.BankCodeChanged>
        , IHandler<BankEvents.BankSwiftCodeChanged>
        , IHandler<BankEvents.NoteChanged>

    {
        protected BankViewBase(IReadModelStore readModelStore) : base(readModelStore)
        {
        }

        public abstract void Handle(BankEvents.Created message);
        public abstract void Handle(BankEvents.NameChanged message);
        public abstract void Handle(BankEvents.BankCodeChanged message);
        public abstract void Handle(BankEvents.BankSwiftCodeChanged message);
        public abstract void Handle(BankEvents.NoteChanged message);
    }
}
