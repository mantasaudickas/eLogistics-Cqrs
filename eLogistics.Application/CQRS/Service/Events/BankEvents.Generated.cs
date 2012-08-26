using System;
using System.Runtime.Serialization;
using eLogistics.Application.CQRS.Interfaces;
namespace eLogistics.Application.CQRS.Service.Events
{
    public partial class BankEvents
    {
        [DataContract]
        public class Created : Event
        {
            [DataMember] public Guid BankId { get; private set; }

            public Created(Guid bankId) : base(bankId)
            {
                BankId = bankId;
            }
        }

        [DataContract]
        public class NameChanged : Event
        {
            [DataMember] public Guid BankId { get; private set; }
            [DataMember] public string Name { get; private set; }

            public NameChanged(Guid bankId, string name) : base(bankId)
            {
                BankId = bankId;
                Name = name;
            }
        }

        [DataContract]
        public class BankCodeChanged : Event
        {
            [DataMember] public Guid BankId { get; private set; }
            [DataMember] public string Code { get; private set; }

            public BankCodeChanged(Guid bankId, string code) : base(bankId)
            {
                BankId = bankId;
                Code = code;
            }
        }

        [DataContract]
        public class BankSwiftCodeChanged : Event
        {
            [DataMember] public Guid BankId { get; private set; }
            [DataMember] public string SwiftCode { get; private set; }

            public BankSwiftCodeChanged(Guid bankId, string swiftCode) : base(bankId)
            {
                BankId = bankId;
                SwiftCode = swiftCode;
            }
        }

        [DataContract]
        public class NoteChanged : Event
        {
            [DataMember] public Guid BankId { get; private set; }
            [DataMember] public string Note { get; private set; }

            public NoteChanged(Guid bankId, string note) : base(bankId)
            {
                BankId = bankId;
                Note = note;
            }
        }

    }
}
