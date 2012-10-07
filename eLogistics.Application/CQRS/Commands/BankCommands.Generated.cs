using System;
using System.Runtime.Serialization;
using eLogistics.Application.CQRS.Interfaces;
namespace eLogistics.Application.CQRS.Commands
{
    public partial class BankCommands
    {
        [DataContract]
        public class Create : Command
        {
            [DataMember] public Guid BankId { get; private set; }

            public Create(Guid bankId) : base(bankId)
            {
                BankId = bankId;
            }
        }

        [DataContract]
        public class ChangeCountry : Command
        {
            [DataMember] public Guid BankId { get; private set; }
            [DataMember] public Guid CountryId { get; private set; }

            public ChangeCountry(Guid bankId, Guid countryId) : base(bankId)
            {
                BankId = bankId;
                CountryId = countryId;
            }
        }

        [DataContract]
        public class ChangeName : Command
        {
            [DataMember] public Guid BankId { get; private set; }
            [DataMember] public string Name { get; private set; }

            public ChangeName(Guid bankId, string name) : base(bankId)
            {
                BankId = bankId;
                Name = name;
            }
        }

        [DataContract]
        public class ChangeBankCode : Command
        {
            [DataMember] public Guid BankId { get; private set; }
            [DataMember] public string Code { get; private set; }

            public ChangeBankCode(Guid bankId, string code) : base(bankId)
            {
                BankId = bankId;
                Code = code;
            }
        }

        [DataContract]
        public class ChangeBankSwiftCode : Command
        {
            [DataMember] public Guid BankId { get; private set; }
            [DataMember] public string SwiftCode { get; private set; }

            public ChangeBankSwiftCode(Guid bankId, string swiftCode) : base(bankId)
            {
                BankId = bankId;
                SwiftCode = swiftCode;
            }
        }

        [DataContract]
        public class ChangeNote : Command
        {
            [DataMember] public Guid BankId { get; private set; }
            [DataMember] public string Note { get; private set; }

            public ChangeNote(Guid bankId, string note) : base(bankId)
            {
                BankId = bankId;
                Note = note;
            }
        }

    }
}
