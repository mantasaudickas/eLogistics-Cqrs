using System;
using System.Collections.Generic;
using eLogistics.Application.CQRS.Commands;

namespace eLogistics.Application.UI
{
    public class EditModelBase
    {
        private readonly List<Command> _changeCommands = new List<Command>();

        public EditModelBase()
        {
        }

        public bool HasChanges { get { return _changeCommands.Count > 0; } }

        protected void Send<T>(T command)
            where T : Command
        {
            _changeCommands.Add(command);
        }

        public void Commit()
        {
            ChangeCommandScope.Add(_changeCommands);
            this.ClearChanges();
        }

        protected void ClearChanges()
        {
            _changeCommands.Clear();
        }
    }
}
