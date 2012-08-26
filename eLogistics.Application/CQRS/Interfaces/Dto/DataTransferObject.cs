using System;
using System.Runtime.Serialization;

namespace eLogistics.Application.CQRS.Interfaces.Dto
{
    [DataContract]
    public abstract class DataTransferObject : IDtoDescriptorProvider
    {
        public virtual DataTransferObjectDescriptor GetDescriptor()
        {
            return null;
        }
    }
}
