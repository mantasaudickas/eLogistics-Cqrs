using System;
using System.Runtime.Serialization;
using eLogistics.Application.CQRS.Client.Views.Base;
using eLogistics.Application.CQRS.Interfaces;
using eLogistics.Application.CQRS.Interfaces.Dto.Domain;
using eLogistics.Application.CQRS.Service.Events;
using eLogistics.Application.CQRS.Service.Storage;
namespace eLogistics.Application.CQRS.Client.Views
{
    public class BankView : BankViewBase
    {
        public BankView(IReadModelStore readModelStore) : base(readModelStore)
        {
        }

        public override void Handle(BankEvents.Created message)
        {
            BankDto dto = this.Load(message.BankId);
            if (dto != null) throw new Exception("Item with the same Id already created!");
            dto = new BankDto();
            dto.BankId = message.BankId;
            this.Save(dto);
        }

        public override void Handle(BankEvents.NameChanged message)
        {
            BankDto dto = this.Load(message.BankId);
            dto.Name = message.Name;
            this.Save(dto);
        }

        public override void Handle(BankEvents.BankCodeChanged message)
        {
            BankDto dto = this.Load(message.BankId);
            dto.Code = message.Code;
            this.Save(dto);
        }

        public override void Handle(BankEvents.BankSwiftCodeChanged message)
        {
            BankDto dto = this.Load(message.BankId);
            dto.SwiftCode = message.SwiftCode;
            this.Save(dto);
        }

        public override void Handle(BankEvents.NoteChanged message)
        {
            BankDto dto = this.Load(message.BankId);
            dto.Note = message.Note;
            this.Save(dto);
        }

    }
}
