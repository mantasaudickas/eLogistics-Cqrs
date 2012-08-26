using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SimpleCQRSCodeGenerator
{
    public partial class MainForm : Form
    {
        private static readonly IDictionary<string, DateTime> _lastGenerations = new Dictionary<string, DateTime>(StringComparer.InvariantCultureIgnoreCase);
        private FileSystemWatcher _watcher;

        public MainForm()
        {
            InitializeComponent();
            this.notifyIcon.Visible = true;
        }

        public string InitialDirectory { get; set; }

        protected override void OnLoad(EventArgs e)
        {
            this.textFolder.Text = InitialDirectory ?? Environment.CurrentDirectory;
            this.ToggleWatching();

            base.OnLoad(e);
        }

        private void ToggleWatching()
        {
            try
            {
                if (_watcher == null)
                {
                    string currentDirectory = this.textFolder.Text;
                    WriteLine("Current directory: {0}", currentDirectory);

                    _watcher = new FileSystemWatcher(currentDirectory, "*.map");
                    _watcher.Changed += (sender, eventArgs) => OnFileChanged(eventArgs.FullPath);
                    _watcher.IncludeSubdirectories = true;
                    _watcher.NotifyFilter = NotifyFilters.LastWrite;
                    _watcher.EnableRaisingEvents = true;

                    this.textFolder.Text = currentDirectory;
                    this.textFolder.ReadOnly = true;

                    this.buttonToggleWatching.Text = "Stop watching";
                }
                else
                {
                    _watcher.EnableRaisingEvents = false;
                    _watcher.Dispose();
                    _watcher = null;
                    this.textFolder.ReadOnly = false;
                    this.buttonToggleWatching.Text = "Start watching";
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void WriteLine(object message, params object [] arguments)
        {
            if (this.textContent.InvokeRequired)
            {
                this.textContent.Invoke(new MethodInvoker(() => WriteLine(message, arguments)));
                return;
            }

            string text = message.ToString();
            if (arguments != null && arguments.Length > 0)
            {
                text = string.Format(text, arguments);
            }

            this.textContent.AppendText(text + Environment.NewLine);
        }

        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.Visible)
            {
                this.Hide();
            }
            else
            {
                this.Show();
            }
        }

        private void buttonToggleWatching_Click(object sender, EventArgs e)
        {
            ToggleWatching();
        }

        private void OnFileChanged(string fullPath)
        {
            DateTime now = DateTime.UtcNow;

            DateTime last;
            if (_lastGenerations.TryGetValue(fullPath, out last))
            {
                TimeSpan timeSpan = now - last;
                WriteLine(timeSpan);
                if (timeSpan < TimeSpan.FromSeconds(2))
                    return;
            }
            _lastGenerations[fullPath] = now;

            Thread.Sleep(TimeSpan.FromSeconds(1));

            try
            {
                WriteLine("File changed at: {0}", fullPath);

                // define file
                // @Service\Events\AddressEvents:eLogistics.Application.CQRS.Service.Events
                // define event:
                // !StreetChanged(string street, string houseNo)
                // define command:
                // ?ChangeStreet(Guid addressId, string street, string houseNo)

                IDictionary<string, FileToGenerate> files = new Dictionary<string, FileToGenerate>(StringComparer.InvariantCultureIgnoreCase);

                IEnumerable<string> lines = File.ReadLines(fullPath);

                string fileNamespace = string.Empty;
                FileToGenerate currentFile = null;
                foreach (string line in lines)
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        char firstChar = line[0];
                        switch (firstChar)
                        {
                            case '#':
                                {
                                    fileNamespace = line.Substring(1);
                                    break;
                                }
                            case '@':
                                {
                                    FileToGenerate fileToGenerate = new FileToGenerate { Root = fullPath };
                                    string fileName = fileToGenerate.Parse(line);
                                    if (!files.ContainsKey(fileName))
                                    {
                                        files.Add(fileName, fileToGenerate);
                                    }
                                    else
                                    {
                                        fileToGenerate = files[fileName];
                                    }
                                    currentFile = fileToGenerate;
                                }
                                break;
                            case '!':
                            case '?':
                                {
                                    if (currentFile == null)
                                        throw new Exception("File must be defined first!");

                                    ClassToGenerate classToGenerate = new ClassToGenerate();
                                    classToGenerate.Parse(line);

                                    if (classToGenerate.ClassType == ClassType.Command || classToGenerate.ClassType == ClassType.Event)
                                    {
                                        string fileNameLowercase = Char.ToLower(currentFile.FileName[0]) + currentFile.FileName.Substring(1);
                                        classToGenerate.Properties.Insert(0,
                                                                          new PropertyToGenerate
                                                                              {
                                                                                  Name = fileNameLowercase + "Id",
                                                                                  UppercaseName = currentFile.FileName + "Id",
                                                                                  Type = "Guid",
                                                                                  NotIncludedInWhen = true
                                                                              });
                                    }

                                    currentFile.Classes.Add(classToGenerate);
                                }
                                break;
                            default:
                                continue;
                        }
                    }
                }

                foreach (KeyValuePair<string, FileToGenerate> pair in files)
                {
                    pair.Value.Namespace = fileNamespace;
                }

                GenerateFiles(fullPath, files);
            }
            catch (Exception exc)
            {
                WriteLine(exc.Message);
            }
        }

        private void GenerateFiles(string changeFile, IDictionary<string, FileToGenerate> files)
        {
            if (files.Count == 0)
                return;

            List<FileToGenerate> filesWithEvents = new List<FileToGenerate>();
            List<FileToGenerate> filesWithHandlers = new List<FileToGenerate>();
            foreach (var fullPath in files.Keys)
            {
                FileToGenerate currentFile = files[fullPath];

                if (currentFile != null && currentFile.Classes.Count > 0)
                {
                    bool hasEvents = currentFile.Classes.Any(generate => generate.ClassType == ClassType.Event);
                    bool hasCommands = currentFile.Classes.Any(generate => generate.ClassType == ClassType.Command);

                    if (hasEvents)
                    {
                        GenerateEventFile(changeFile, currentFile);
                        filesWithEvents.Add(currentFile);
                    }

                    if (hasCommands)
                    {
                        GenerateCommandFile(changeFile, currentFile);
                        filesWithHandlers.Add(currentFile);
                    }
                }
            }

            GenerateServiceMediatorFile(changeFile, filesWithHandlers);
        }

        private void GenerateEventFile(string changeFile, FileToGenerate currentFile)
        {
            StringBuilder eventFile = CreateStringBuilder(ClassType.Event);
            currentFile.GenerateEvents(eventFile);
            string fileName = Path.Combine(Path.GetDirectoryName(changeFile) ?? Environment.CurrentDirectory, "Service\\Events", currentFile.FileName + "Events.Generated.cs");
            File.WriteAllText(fileName, eventFile.ToString());
            WriteLine("Updated file: {0}", fileName);

            StringBuilder stateFile = CreateStringBuilder(ClassType.State);
            currentFile.GenerateState(stateFile);
            string stateFileName = Path.Combine(Path.GetDirectoryName(changeFile) ?? Environment.CurrentDirectory, "Service\\Domain\\States", currentFile.FileName + "State.Generated.cs");
            File.WriteAllText(stateFileName, stateFile.ToString());
            WriteLine("Updated file: {0}", stateFileName);

            StringBuilder dtoFile = CreateStringBuilder(ClassType.Dto);
            currentFile.GenerateDto(dtoFile);
            string dtoFileName = Path.Combine(Path.GetDirectoryName(changeFile) ?? Environment.CurrentDirectory, "Interfaces\\Dto\\Domain", currentFile.FileName + "Dto.Generated.cs");
            File.WriteAllText(dtoFileName, dtoFile.ToString());
            WriteLine("Updated file: {0}", dtoFileName);

            StringBuilder messageFile = CreateStringBuilder(ClassType.Message);
            currentFile.GenerateMessages(messageFile);
            string messageFileName = Path.Combine(Path.GetDirectoryName(changeFile) ?? Environment.CurrentDirectory, "Interfaces\\Messages\\Domain", currentFile.FileName + "Message.Generated.cs");
            File.WriteAllText(messageFileName, messageFile.ToString());
            WriteLine("Updated file: {0}", messageFileName);

            StringBuilder facadeFile = CreateStringBuilder(ClassType.ReadModelFacade);
            currentFile.GenerateReadModelFacades(facadeFile);
            string facadeFileName = Path.Combine(Path.GetDirectoryName(changeFile) ?? Environment.CurrentDirectory, "Client\\Facades\\Domain", currentFile.FileName + "Facade.Generated.cs");
            File.WriteAllText(facadeFileName, facadeFile.ToString());
            WriteLine("Updated file: {0}", facadeFileName);

            StringBuilder viewBaseFile = CreateStringBuilder(ClassType.ViewBase);
            currentFile.GenerateViewBase(currentFile.FileName, viewBaseFile);
            string viewBaseFileName = Path.Combine(Path.GetDirectoryName(changeFile) ?? Environment.CurrentDirectory, "Client\\Views\\Base", currentFile.FileName + "ViewBase.Generated.cs");
            File.WriteAllText(viewBaseFileName, viewBaseFile.ToString());
            WriteLine("Updated file: {0}", viewBaseFileName);

            string viewFileName = Path.Combine(Path.GetDirectoryName(changeFile) ?? Environment.CurrentDirectory, "Client\\Views", currentFile.FileName + "View.cs");
            if (!File.Exists(viewFileName))
            {
                StringBuilder viewFile = CreateStringBuilder(ClassType.View);
                currentFile.GenerateView(currentFile.FileName, viewFile);
                File.WriteAllText(viewFileName, viewFile.ToString());
                WriteLine("Updated file: {0}", viewFileName);
            }
        }

        private void GenerateCommandFile(string changeFile, FileToGenerate currentFile)
        {
            StringBuilder commandFile = CreateStringBuilder(ClassType.Command);
            currentFile.GenerateCommands(commandFile);

            string fileName = Path.Combine(Path.GetDirectoryName(changeFile) ?? Environment.CurrentDirectory, "Commands", currentFile.FileName + "Commands.Generated.cs");
            File.WriteAllText(fileName, commandFile.ToString());

            WriteLine("Updated file: {0}", fileName);

            StringBuilder handlerFile = CreateStringBuilder(ClassType.Handler);
            currentFile.GenerateHandler(handlerFile);
            string handlerFileName = Path.Combine(Path.GetDirectoryName(changeFile) ?? Environment.CurrentDirectory, "Service\\Handlers", currentFile.FileName + "Handler.Generated.cs");
            File.WriteAllText(handlerFileName, handlerFile.ToString());
            WriteLine("Updated file: {0}", handlerFileName);
        }

        private void GenerateServiceMediatorFile(string changeFile, List<FileToGenerate> fileWithHandlers)
        {
            StringBuilder serviceMediator = new StringBuilder();
            serviceMediator.AppendLine("using eLogistics.Application.CQRS.Commands;");
            serviceMediator.AppendLine("using eLogistics.Application.CQRS.Client.Views;");
            serviceMediator.AppendLine("using eLogistics.Application.CQRS.Service.Domain;");
            serviceMediator.AppendLine("using eLogistics.Application.CQRS.Service.Events;");
            serviceMediator.AppendLine("using eLogistics.Application.CQRS.Service.Handlers;");
            serviceMediator.AppendLine("using eLogistics.Application.CQRS.Service.Storage;");
            serviceMediator.AppendLine();

            serviceMediator.AppendLine("namespace eLogistics.Application.CQRS.Service");
            serviceMediator.AppendLine("{");

            serviceMediator.AppendLine("    public partial class ServiceMediator");
            serviceMediator.AppendLine("    {");

            serviceMediator.AppendLine("        private static readonly IMessageBus _messageBus = ObjectFactory.Create<IMessageBus>();");
            serviceMediator.AppendLine("        private static readonly IEventStore _eventStore = ObjectFactory.Create<IEventStore>();");
            serviceMediator.AppendLine("        private static readonly IReadModelStore _readModelStore = ObjectFactory.Create<IReadModelStore>();");
            serviceMediator.AppendLine();

            foreach (FileToGenerate handler in fileWithHandlers)
            {
                string nameLowerCase = Char.ToLower(handler.FileName[0]) + handler.FileName.Substring(1);

                serviceMediator.AppendFormat("        private static readonly {0}Handler _{1}Handler = new {0}Handler(new Repository<{0}>(_eventStore));", handler.FileName, nameLowerCase);
                serviceMediator.AppendLine();
            }

            serviceMediator.AppendLine();

            foreach (FileToGenerate handler in fileWithHandlers)
            {
                string nameLowerCase = Char.ToLower(handler.FileName[0]) + handler.FileName.Substring(1);

                serviceMediator.AppendFormat("        private static readonly {0}View _{1}View = new {0}View(_readModelStore);", handler.FileName, nameLowerCase);
                serviceMediator.AppendLine();
            }

            serviceMediator.AppendLine();

            serviceMediator.AppendLine("        static ServiceMediator()");
            serviceMediator.AppendLine("        {");
            foreach (FileToGenerate handler in fileWithHandlers)
            {
                string nameLowerCase = Char.ToLower(handler.FileName[0]) + handler.FileName.Substring(1);

                serviceMediator.AppendFormat("            #region {0}", handler.FileName).AppendLine().AppendLine();
                foreach (ClassToGenerate classToGenerate in handler.Classes)
                {
                    if (classToGenerate.ClassType == ClassType.Command)
                    {
                        serviceMediator.AppendFormat("            _messageBus.Register<{0}Commands.{1}>(_{2}Handler.Handle);", handler.FileName, classToGenerate.Name, nameLowerCase);
                        serviceMediator.AppendLine();
                    }
                }
                serviceMediator.AppendLine();
                foreach (ClassToGenerate classToGenerate in handler.Classes)
                {
                    if (classToGenerate.ClassType == ClassType.Event)
                    {
                        serviceMediator.AppendFormat("            _messageBus.Register<{0}Events.{1}>(_{2}View.Handle);", handler.FileName, classToGenerate.Name, nameLowerCase);
                        serviceMediator.AppendLine();
                    }
                }
                serviceMediator.AppendLine().AppendLine("            #endregion");

                serviceMediator.AppendLine();
            }
            serviceMediator.AppendLine("        }");

            serviceMediator.AppendLine();
            serviceMediator.AppendLine("        public static void Register() {}");

            serviceMediator.AppendLine("    }");

            serviceMediator.AppendLine("}");

            string mediatorFileName = Path.Combine(Path.GetDirectoryName(changeFile) ?? Environment.CurrentDirectory, "Service\\ServiceMediator.Generated.cs");
            File.WriteAllText(mediatorFileName, serviceMediator.ToString());
            WriteLine("Updated file: {0}", mediatorFileName);
        }

        private static StringBuilder CreateStringBuilder(ClassType classType)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("using System;");
            stringBuilder.AppendLine("using System.Runtime.Serialization;");

            if (classType == ClassType.Handler)
            {
                stringBuilder.AppendLine("using eLogistics.Application.CQRS.Commands;");
                stringBuilder.AppendLine("using eLogistics.Application.CQRS.Service.Domain;");
                stringBuilder.AppendLine("using eLogistics.Application.CQRS.Service.Storage;");
            }

            if (classType == ClassType.Command)
            {
                stringBuilder.AppendLine("using eLogistics.Application.CQRS.Interfaces;");
            }

            if (classType == ClassType.Event)
            {
                stringBuilder.AppendLine("using eLogistics.Application.CQRS.Interfaces;");
            }

            if (classType == ClassType.ViewBase)
            {
                stringBuilder.AppendLine("using eLogistics.Application.CQRS.Interfaces;");
                stringBuilder.AppendLine("using eLogistics.Application.CQRS.Interfaces.Dto.Domain;");
                stringBuilder.AppendLine("using eLogistics.Application.CQRS.Service.Events;");
                stringBuilder.AppendLine("using eLogistics.Application.CQRS.Service.Storage;");
            }

            if (classType == ClassType.View)
            {
                stringBuilder.AppendLine("using eLogistics.Application.CQRS.Client.Views.Base;");
                stringBuilder.AppendLine("using eLogistics.Application.CQRS.Interfaces;");
                stringBuilder.AppendLine("using eLogistics.Application.CQRS.Interfaces.Dto.Domain;");
                stringBuilder.AppendLine("using eLogistics.Application.CQRS.Service.Events;");
                stringBuilder.AppendLine("using eLogistics.Application.CQRS.Service.Storage;");
            }

            if (classType == ClassType.State)
            {
                stringBuilder.AppendLine("using System.Collections.Generic;");
                stringBuilder.AppendLine("using eLogistics.Application.CQRS.Interfaces;");
                stringBuilder.AppendLine("using eLogistics.Application.CQRS.Service.Events;");
            }

            if (classType == ClassType.Dto)
            {
                stringBuilder.AppendLine("using System.Collections.Generic;");
                stringBuilder.AppendLine("using eLogistics.Application.CQRS.Interfaces;");
            }

            if (classType == ClassType.Message)
            {
                stringBuilder.AppendLine("using System.Collections.Generic;");
                stringBuilder.AppendLine("using eLogistics.Application.CQRS.Interfaces.Dto.Domain;");
            }

            if (classType == ClassType.ReadModelFacade)
            {
                stringBuilder.AppendLine("using System.Collections.Generic;");
                stringBuilder.AppendLine("using eLogistics.Application.CQRS.Client.Views;");
                stringBuilder.AppendLine("using eLogistics.Application.CQRS.Interfaces.Dto.Domain;");
                stringBuilder.AppendLine("using eLogistics.Application.CQRS.Interfaces.Messages.Domain;");
                stringBuilder.AppendLine("using eLogistics.Application.CQRS.Service.Storage;");
            }

            return stringBuilder;
        }

    }
}
