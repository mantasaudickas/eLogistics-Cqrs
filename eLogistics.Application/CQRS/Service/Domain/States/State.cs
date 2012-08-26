using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using eLogistics.Application.CQRS.Service.Events;

namespace eLogistics.Application.CQRS.Service.Domain.States
{
    public abstract class State
    {
        protected State(IEnumerable<Event> events)
        {
            foreach (Event currentEvent in events)
            {
                this.Mutate(currentEvent);
            }
        }

        public abstract Guid Id { get; }

        //[DebuggerNonUserCode]
        public void Mutate(Event e)
        {
            MethodInfo info;
            var type = e.GetType();
            if (!GetCache(this.GetType()).Dict.TryGetValue(type, out info))
            {
                // we don't care if state does not consume events
                // they are persisted anyway
                return;
            }
            try
            {
                info.Invoke(this, new[] { e });
            }
            catch (TargetInvocationException ex)
            {
                if (null != InternalPreserveStackTraceMethod)
                    InternalPreserveStackTraceMethod.Invoke(ex.InnerException, new object[0]);
                throw ex.InnerException;
            }
        }


        static readonly MethodInfo InternalPreserveStackTraceMethod =
            typeof(Exception).GetMethod("InternalPreserveStackTrace", BindingFlags.Instance | BindingFlags.NonPublic);

        private Cache GetCache(Type currentType)
        {
            Cache cache;

            if (!caches.TryGetValue(currentType, out cache))
            {
                cache = new Cache(currentType);
                caches.Add(currentType, cache);
            }

            return cache;
        }

        private static readonly IDictionary<Type, Cache> caches = new Dictionary<Type,Cache>();

        private class Cache
        {
            public readonly IDictionary<Type, MethodInfo> Dict;

            public Cache(Type currentType)
            {
                Dict = currentType
                                .GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                                .Where(m => m.Name == "When")
                                .Where(m => m.GetParameters().Length == 1)
                                .ToDictionary(m => m.GetParameters().First().ParameterType, m => m);
            }
        }

    }
}
