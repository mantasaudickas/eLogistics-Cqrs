using System;
using eLogistics.Application.CQRS.Interfaces.Dto;

namespace eLogistics.Application.CQRS.Interfaces
{
    public interface IDtoDescriptorProvider
    {
        DataTransferObjectDescriptor GetDescriptor();
    }
}
