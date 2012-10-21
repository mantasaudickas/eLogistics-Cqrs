using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using eLogistics.Application.CQRS;
using eLogistics.Application.CQRS.Commands;
using eLogistics.Application.CQRS.Service;

namespace eLogistics.Application.UI
{
    public class ChangeCommandScope : IDisposable
    {
        private readonly bool _isParentScope;
        private readonly List<Command> _globalCommands;

        public ChangeCommandScope()
        {
            _globalCommands = (List<Command>)CallContext.LogicalGetData("changeCommands");
            if (_globalCommands == null)       // parent scope!
            {
                _globalCommands = new List<Command>();
                CallContext.LogicalSetData("changeCommands", _globalCommands);
                _isParentScope = true;
            }
        }

        public static void Add(List<Command> commandList)
        {
            List<Command> commands = (List<Command>)CallContext.LogicalGetData("changeCommands");
            if (commands == null)
                throw new NotSupportedException("Please create ChangeCommandScope before sending commands.");

            MinimizeCommands(commandList);
            commands.AddRange(commandList);
        }

        public void Dispose()
        {
            if (_isParentScope)
            {
                foreach (Command changeCommand in _globalCommands)
                {
                    this.Bus.Send(changeCommand);
                }

                _globalCommands.Clear();
                CallContext.FreeNamedDataSlot("changeCommands");
            }
        }

        private IMessageBus Bus
        {
            get { return ServiceMediator.Bus; }
        }

        private static void MinimizeCommands(List<Command> changeCommands)
        {
            if (changeCommands.Count > 1)
            {
                // minimize commands
                IDictionary<Guid, HashSet<Type>> usedCommands = new Dictionary<Guid, HashSet<Type>>();
                for (int i = changeCommands.Count - 1; i >= 0; i--)
                {
                    Command command = changeCommands[i];
                    HashSet<Type> commandSet;
                    if (!usedCommands.TryGetValue(command.Id, out commandSet))
                    {
                        commandSet = new HashSet<Type>();
                        usedCommands.Add(command.Id, commandSet);
                    }

                    Type commandType = command.GetType();
                    if (!commandSet.Contains(commandType))
                    {
                        commandSet.Add(commandType);
                    }
                    else
                    {
                        changeCommands.RemoveAt(i);
                    }
                }
            }
        }

    }
}
