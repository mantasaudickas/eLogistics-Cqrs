using System;
using System.Collections.Generic;
using eLogistics.Application.CQRS.Service.Domain.States;
using eLogistics.Application.CQRS.Service.Events;

namespace eLogistics.Application.CQRS.Service.Domain
{
    public interface IAggregateRoot
    {
        void LoadFromHistory(IEnumerable<Event> history);
        IList<Event> GetUncommittedChanges();
        void Commit();

        State CurrentState { get; }
    }

    public class AggregateRoot<T> : IAggregateRoot
        where T : State
    {
        #region Private Fields

        private readonly List<Event> _uncommittedChanges = new List<Event>();

        #endregion

        #region Constructor

        public AggregateRoot()
        {
        }

        #endregion

        #region Domain Properties

        public T State { get; private set; }
        State IAggregateRoot.CurrentState { get { return this.State; } }

        #endregion

        #region Change Handling

        public void LoadFromHistory(IEnumerable<Event> history)
        {
            this.State = (T) Activator.CreateInstance(typeof (T), new object[] {history});
        }

        public IList<Event> GetUncommittedChanges()
        {
            return _uncommittedChanges.AsReadOnly();
        }

        public void Commit()
        {
            _uncommittedChanges.Clear();
        }

        protected void RaiseEvent<TEvent>(TEvent currentEvent)
            where TEvent : Event
        {
            if (this.State == null)
                throw new Exception("Object is not loaded!");

            this.State.Mutate(currentEvent);
            _uncommittedChanges.Add(currentEvent);
        }

        #endregion
    }
}
