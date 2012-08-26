using System;
using eLogistics.Application.CQRS.Commands;
using eLogistics.Application.CQRS.Interfaces.Dto.Domain;

namespace eLogistics.Application.UI.Domain
{
    public class PaymentTypeEditModel : EditModel<PaymentTypeDto>
    {
        public PaymentTypeEditModel(PaymentTypeDto paymentTypeDto) : base(paymentTypeDto)
        {
            if (this.CreatedNew)
            {
                Dto.PaymentTypeId = Guid.NewGuid();
                this.Send(new PaymentTypeCommands.Create(Dto.PaymentTypeId));
            }
        }

        public string Name
        {
            get { return Dto.Name; }
            set
            {
                if (Dto.Name != value)
                {
                    Dto.Name = value;
                    this.Send(new PaymentTypeCommands.ChangeName(Dto.PaymentTypeId, value));
                }
            }
        }

        public bool IsCredit
        {
            get { return Dto.IsCredit; }
            set
            {
                if (Dto.IsCredit != value)
                {
                    Dto.IsCredit = value;
                    this.Send(new PaymentTypeCommands.ChangeIsCredit(Dto.PaymentTypeId, value));
                }
            }
        }

        public void Delete()
        {
            this.ClearChanges();

            if (!this.CreatedNew)
                this.Send(new PaymentTypeCommands.Delete(Dto.PaymentTypeId));
        }
    }
}
