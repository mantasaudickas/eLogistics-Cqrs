using System;
using System.Collections.Generic;
using eLogistics.Application.CQRS.Interfaces.Dto;

namespace eLogistics.Application.CQRS.Service.Storage
{
    public class MemoryReadModelStore : IReadModelStore
    {
        private readonly IDictionary<Type, List<DataTransferObject>> _storage = new Dictionary<Type, List<DataTransferObject>>();

        public List<T> GetList<T>(string filter)
            where T : DataTransferObject
        {
            List<T> result = new List<T>();

            List<DataTransferObject> list = GetList<T>();

            foreach (DataTransferObject dto in list)
            {
                if (string.IsNullOrEmpty(filter))
                {
                    result.Add((T) dto);
                    continue;
                }

                DataTransferObjectDescriptor descriptor = dto.GetDescriptor();
                string serialized = descriptor.ToString();
                if (!string.IsNullOrEmpty(serialized) && serialized.IndexOf(filter, StringComparison.InvariantCultureIgnoreCase) >= 0)
                    result.Add((T) dto);
            }

            return result;
        }

        public T Load<T>(Guid aggregateId)
             where T : DataTransferObject
        {
            T result = null;

            List<DataTransferObject> list = GetList<T>();

            foreach (DataTransferObject dto in list)
            {
                DataTransferObjectDescriptor descriptor = dto.GetDescriptor();
                if (descriptor.Id == aggregateId)
                {
                    result = (T) dto;
                    break;
                }
            }

            return result;
        }

        public void Save<T>(T dto)
            where T : DataTransferObject
        {
            List<DataTransferObject> list = GetList<T>();

            DataTransferObjectDescriptor saveDescriptor = dto.GetDescriptor();

            bool found = false;
            for (int i = 0; i < list.Count; ++i)
            {
                DataTransferObject current = list[i];
                DataTransferObjectDescriptor descriptor = current.GetDescriptor();
                if (descriptor.Id == saveDescriptor.Id)
                {
                    list[i] = dto;
                    found = true;
                    break;
                }
            }

            if (!found)
                list.Add(dto);

            SaveList<T>(list);
        }

        public void Delete<T>(Guid aggregateId)
        {
            System.Diagnostics.Debug.WriteLine("Deleting aggregate Id = " + aggregateId.ToString());

            List<DataTransferObject> list = GetList<T>();

            bool deleted = false;
            for (int i = 0; i < list.Count; ++i)
            {
                DataTransferObject current = list[i];
                DataTransferObjectDescriptor descriptor = current.GetDescriptor();
                if (descriptor.Id == aggregateId)
                {
                    list.RemoveAt(i);
                    deleted = true;
                    --i;
                }
            }
         
            if (deleted)
                SaveList<T>(list);
        }

        private List<DataTransferObject> GetList<T>()
        {
            List<DataTransferObject> list;
            if (!_storage.TryGetValue(typeof(T), out list))
            {
                list = this.LoadList<T>();
                _storage.Add(typeof(T), list);
            }
            return list;
        }

        protected virtual List<DataTransferObject> LoadList<T>()
        {
            return new List<DataTransferObject>();
        }

        protected virtual void SaveList<T>(List<DataTransferObject> list)
        {
        }
    }
}
