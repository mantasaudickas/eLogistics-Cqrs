using eLogistics.Application.CQRS.Service.Domain;
using eLogistics.Application.CQRS.Service.Storage;

namespace eLogistics.Application.CQRS.Service.Handlers
{
    public abstract class CommandHandler<TAggregateRoot>
        where TAggregateRoot : IAggregateRoot
    {
        protected CommandHandler(IRepository<TAggregateRoot> repository)
        {
            Repository = repository;
        }

        protected IRepository<TAggregateRoot> Repository { get; private set; }
    }
}
