using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using eLogistics.Application.CQRS.Commands;
using eLogistics.Application.CQRS.Service.Events;

namespace eLogistics.Application.CQRS
{
    public interface IMessageBus
    {
        void Register<T>(Action<T> handler) where T : IMessage;
        void Send<T>(T command) where T : Command;
        void Publish<T>(T eventToPublish) where T : Event;
    }

    public class MessageBus : IMessageBus
    {
        private readonly Dictionary<Type, List<Action<IMessage>>> _routes = new Dictionary<Type, List<Action<IMessage>>>();

        public MessageBus()
        {
        }

        public void Register<T>(Action<T> handler)
            where T : IMessage
        {
            List<Action<IMessage>> handlers;
            if (!_routes.TryGetValue(typeof(T), out handlers))
            {
                handlers = new List<Action<IMessage>>();
                _routes.Add(typeof(T), handlers);
            }
            handlers.Add(CastArgument<IMessage, T>(x => handler(x)));
        }

        public void Send<T>(T command) 
            where T : Command
        {
            List<Action<IMessage>> handlers;
            if (_routes.TryGetValue(command.GetType(), out handlers))
            {
                if (handlers.Count != 1) throw new InvalidOperationException("cannot send to more than one handler");
                handlers[0](command);
            }
            else
            {
                throw new InvalidOperationException("no handler registered");
            }
        }

        public void Publish<T>(T eventToPublish) where T : Event
        {
            List<Action<IMessage>> handlers;
            if (!_routes.TryGetValue(eventToPublish.GetType(), out handlers)) return;
            foreach (var handler in handlers)
            {
                //dispatch on thread pool for added awesomeness
                var action = handler;
                action(eventToPublish);
                //Task.Factory.StartNew(() => action(eventToPublish));
                //ThreadPool.QueueUserWorkItem(x => handler1(@eventToPublish));
            }
        }

        private static Action<BaseT> CastArgument<BaseT, DerivedT>(Expression<Action<DerivedT>> source) where DerivedT : BaseT
        {
            if (typeof(DerivedT) == typeof(BaseT))
            {
                return (Action<BaseT>)((Delegate)source.Compile());
            }

            ParameterExpression sourceParameter = Expression.Parameter(typeof(BaseT), "source");
            var result = Expression.Lambda<Action<BaseT>>(
                Expression.Invoke(
                    source,
                    Expression.Convert(sourceParameter, typeof(DerivedT))),
                sourceParameter);
            return result.Compile();
        }
    }
}
