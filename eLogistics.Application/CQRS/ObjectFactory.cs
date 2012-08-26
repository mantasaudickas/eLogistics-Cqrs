using System;
using System.Collections.Generic;
using eLogistics.Application.CQRS.Service.Storage;

namespace eLogistics.Application.CQRS
{
    public class ObjectFactory
    {
        private static readonly IDictionary<Type, ObjectCreationInfo> _objectMap = new Dictionary<Type, ObjectCreationInfo>();

        static ObjectFactory()
        {
            //Register<IEventStore, MemoryEventStore>(true);
            //Register<IReadModelStore, MemoryReadModelStore>(true);
            Register<IEventStore, FileEventStore>(true);
            Register<IReadModelStore, FileReadModelStore>(true);
            Register<IMessageBus, MessageBus>(true);
        }

        private static void Register<TInterface, TObjectType>(bool isSingletone = false)
            where TObjectType : class, TInterface, new()
        {
            ObjectCreationInfo creationInfo = new ObjectCreationInfo {ObjectType = typeof (TObjectType), IsSingletone = isSingletone};
            _objectMap[typeof (TInterface)] = creationInfo;
        }

        public static T Create<T>()
        {
            Type interfaceType = typeof (T);
            ObjectCreationInfo creationInfo;

            if (!_objectMap.TryGetValue(interfaceType, out creationInfo))
                throw new Exception(string.Format("Object not found by interface: {0}", interfaceType));

            object objectToReturn = creationInfo.SingletoneInstance;

            if (objectToReturn == null)
            {
                objectToReturn = Activator.CreateInstance(creationInfo.ObjectType);
                if (creationInfo.IsSingletone)
                    creationInfo.SingletoneInstance = objectToReturn;
            }

            return (T) objectToReturn;
        }

        private class ObjectCreationInfo
        {
            public Type ObjectType { get; set; }
            public bool IsSingletone { get; set; }

            public object SingletoneInstance { get; set; }
        }
    }
}
