using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using eLogistics.Application.CQRS.Commands;
using eLogistics.Application.CQRS.Interfaces;
using eLogistics.Application.CQRS.Interfaces.Dto.Domain;

namespace eLogistics.Application.UI.Domain
{
    public class SupplierEditModel : EditModel<SupplierDto>
    {
        private readonly ObservableCollection<BankAccount> _bankAccounts;

        public SupplierEditModel() : this(null)
        {
        }

        public SupplierEditModel(SupplierDto dto) : base(dto)
        {
            if (this.CreatedNew)
            {
                Dto.SupplierId = Guid.NewGuid();
                this.Send(new SupplierCommands.Create(Dto.SupplierId));
            }

            if (Dto.BankAccountList == null)
                Dto.BankAccountList = new List<BankAccount>();

            _bankAccounts = new ObservableCollection<BankAccount>(Dto.BankAccountList);
            _bankAccounts.CollectionChanged += BankAccountsOnCollectionChanged;
        }

        public string Name
        {
            get { return Dto.Name; }
            set
            {
                if (Dto.Name != value)
                {
                    Dto.Name = value;
                    this.Send(new SupplierCommands.ChangeName(Dto.SupplierId, value));
                    this.RaisePropertyChanged();
                }
            }
        }

        public Guid CompanyId
        {
            get { return Dto.CompanyId; }
            set
            {
                if (Dto.CompanyId != value)
                {
                    Dto.CompanyId = value;
                    this.Send(new SupplierCommands.ChangeCompany(Dto.SupplierId, value));
                    this.RaisePropertyChanged();
                }
            }
        }

        public string Note
        {
            get { return Dto.Note; }
            set
            {
                if (value != Dto.Note)
                {
                    Dto.Note = value;
                    this.Send(new SupplierCommands.ChangeNote(Dto.CompanyId, value));
                    this.RaisePropertyChanged();
                }
            }
        }

        public IList<BankAccount> BankAccounts { get { return _bankAccounts; }}

        private void BankAccountsOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs args)
        {
            switch (args.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    this.Send(new SupplierCommands.AddBankAccount(Dto.SupplierId, (BankAccount) args.NewItems[0]));
                    break;
                case NotifyCollectionChangedAction.Remove:
                    this.Send(new SupplierCommands.RemoveBankAccount(Dto.SupplierId, (BankAccount)args.OldItems[0]));
                    break;
                case NotifyCollectionChangedAction.Replace:
                    this.Send(new SupplierCommands.RemoveBankAccount(Dto.SupplierId, (BankAccount)args.OldItems[0]));
                    this.Send(new SupplierCommands.AddBankAccount(Dto.SupplierId, (BankAccount) args.NewItems[0]));
                    break;
            }
        }

    }
}
