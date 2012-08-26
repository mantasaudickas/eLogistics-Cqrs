using System;
using eLogistics.Application.CQRS.Service.Storage;

namespace eLogistics.Application.CQRS.Client.Facades
{
    public class ReadModelFacade
    {
        private readonly IReadModelStore _readModelStore;

        public ReadModelFacade(IReadModelStore readModelStore)
        {
            _readModelStore = readModelStore;
        }

        public IReadModelStore Store
        {
            get { return _readModelStore; }
        }
    }
}
