using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using eLogistics.Application.CQRS.Interfaces.Dto.Domain;
namespace eLogistics.Application.CQRS.Interfaces.Messages.Domain
{
    [DataContract]
    public partial class GetCustomerListRequest : RequestMessage
    {
        [DataMember] public string Filter { get; set; }
    }

    [DataContract]
    public partial class GetCustomerListResponse : ResponseMessage
    {
        [DataMember] public List<CustomerDto> CustomerList { get; set; }
    }

    [DataContract]
    public partial class GetCustomerRequest : RequestMessage
    {
        [DataMember] public Guid CustomerId;
    }

    [DataContract]
    public partial class GetCustomerResponse : ResponseMessage
    {
        [DataMember] public CustomerDto Customer;
    }

}
