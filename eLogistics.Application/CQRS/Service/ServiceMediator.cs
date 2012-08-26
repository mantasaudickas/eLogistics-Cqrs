using eLogistics.Application.CQRS.Service.Storage;

namespace eLogistics.Application.CQRS.Service
{
    public partial class ServiceMediator
    {
        public static IMessageBus Bus { get { return _messageBus; } }
    }
}
