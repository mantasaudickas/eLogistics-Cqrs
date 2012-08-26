using System;
using System.Runtime.Serialization;
using eLogistics.Application.CQRS.Interfaces.Dto;

namespace eLogistics.Application.CQRS.Interfaces
{
    [DataContract]
    public class BankAccount : IDtoDescriptorProvider
    {
        [DataMember]
        public Guid BankId { get; set; }
        [DataMember]
        public string AccountNo { get; set; }

        #region Equality members

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BankAccount) obj);
        }
        
        protected bool Equals(BankAccount other)
        {
            return BankId.Equals(other.BankId) && string.Equals(AccountNo, other.AccountNo);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (BankId.GetHashCode() * 397) ^ (AccountNo != null ? AccountNo.GetHashCode() : 0);
            }
        }

        #endregion

        #region IDtoDescriptorProvider Members

        public DataTransferObjectDescriptor GetDescriptor()
        {
            DataTransferObjectDescriptor descriptor = new DataTransferObjectDescriptor();
            descriptor.Id = BankId;
            descriptor.Properties["AccountNo"] = AccountNo;
            return descriptor;
        }

        #endregion
    }
}
