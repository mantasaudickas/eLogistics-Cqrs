using System;
using eLogistics.Application.CQRS.Service.Events;

namespace eLogistics.Application.CQRS.Client
{
    public interface IHandler<in TEvent>
        where TEvent : Event
    {
        void Handle(TEvent eventToHandle);
    }
}
