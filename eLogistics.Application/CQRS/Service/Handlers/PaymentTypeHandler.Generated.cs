using System;
using System.Runtime.Serialization;
using eLogistics.Application.CQRS.Commands;
using eLogistics.Application.CQRS.Service.Domain;
using eLogistics.Application.CQRS.Service.Storage;
namespace eLogistics.Application.CQRS.Service.Handlers
{
    public partial class PaymentTypeHandler : CommandHandler<PaymentType>
    {
        public PaymentTypeHandler(IRepository<PaymentType> repository) : base(repository)
        {
        }

        public void Handle(PaymentTypeCommands.Create message)
        {
            PaymentType item = this.Repository.GetById(message.Id);
            item.Create(message.PaymentTypeId);
            this.Repository.Save(item);
        }

        public void Handle(PaymentTypeCommands.ChangeName message)
        {
            PaymentType item = this.Repository.GetById(message.Id);
            item.ChangeName(message.Name);
            this.Repository.Save(item);
        }

        public void Handle(PaymentTypeCommands.ChangeIsCredit message)
        {
            PaymentType item = this.Repository.GetById(message.Id);
            item.ChangeIsCredit(message.IsCredit);
            this.Repository.Save(item);
        }

        public void Handle(PaymentTypeCommands.Delete message)
        {
            PaymentType item = this.Repository.GetById(message.Id);
            item.Delete();
            this.Repository.Save(item);
        }

    }
}
