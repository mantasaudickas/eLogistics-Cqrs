using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCQRSCodeGenerator
{
    public class FileToGenerate
    {
        public FileToGenerate()
        {
            this.Classes = new List<ClassToGenerate>();
        }

        public string Root { get; set; }
        public string FileName { get; set; }
        public string Namespace { get; set; }
        public List<ClassToGenerate> Classes { get; set; }

        // define file
        // @Address
        public string Parse(string line)
        {
            this.FileName = line.Substring(1);   // remove @
            return this.FileName;
        }

        public void GenerateEvents(StringBuilder builder)
        {
            IEnumerable<ClassToGenerate> events = Classes.Where(generate => generate.ClassType == ClassType.Event);

            GenerateEvents(builder, events);
        }

        public void GenerateCommands(StringBuilder builder)
        {
            IEnumerable<ClassToGenerate> commands = Classes.Where(generate => generate.ClassType == ClassType.Command);

            GenerateCommands(builder, commands);
        }

        public void GenerateHandler(StringBuilder builder)
        {
            IEnumerable<ClassToGenerate> commands = Classes.Where(generate => generate.ClassType == ClassType.Command);

            GenerateHandler(builder, commands);
        }

        public void GenerateViewBase(string fileName, StringBuilder builder)
        {
            IEnumerable<ClassToGenerate> events = Classes.Where(generate => generate.ClassType == ClassType.Event);

            GenerateViewBase(builder, events);
        }

        public void GenerateView(string fileName, StringBuilder builder)
        {
            IEnumerable<ClassToGenerate> events = Classes.Where(generate => generate.ClassType == ClassType.Event);

            GenerateView(builder, events);
        }

        public void GenerateState(StringBuilder builder)
        {
            IEnumerable<ClassToGenerate> events = Classes.Where(generate => generate.ClassType == ClassType.Event);

            GenerateState(builder, events);
        }

        public void GenerateDto(StringBuilder builder)
        {
            IEnumerable<ClassToGenerate> events = Classes.Where(generate => generate.ClassType == ClassType.Event);

            GenerateDto(builder, events);
        }

        public void GenerateMessages(StringBuilder builder)
        {
            GenerateMessageClasses(builder);
        }

        public void GenerateReadModelFacades(StringBuilder builder)
        {
            GenerateFacadeClasses(builder);
        }

        private void GenerateEvents(StringBuilder builder, IEnumerable<ClassToGenerate> events)
        {
            builder.AppendFormat("namespace {0}.Service.Events", this.Namespace).AppendLine();
            builder.AppendLine("{");

            builder.Append("    ").AppendFormat("public partial class {0}Events", this.FileName).AppendLine();
            builder.AppendLine("    {");

            foreach (ClassToGenerate eventToGenerate in events)
            {
                eventToGenerate.Generate(builder);
                builder.AppendLine();
            }

            builder.AppendLine("    }"); // end of public static class

            builder.AppendLine("}"); // end of namespace
        }

        private void GenerateCommands(StringBuilder builder, IEnumerable<ClassToGenerate> commands)
        {
            builder.AppendFormat("namespace {0}.Commands", this.Namespace).AppendLine();
            builder.AppendLine("{");

            builder.Append("    ").AppendFormat("public partial class {0}Commands", this.FileName).AppendLine();
            builder.AppendLine("    {");

            foreach (ClassToGenerate commandToGenerate in commands)
            {
                commandToGenerate.Generate(builder);
                builder.AppendLine();
            }

            builder.AppendLine("    }"); // end of public static class

            builder.AppendLine("}"); // end of namespace
        }

        private void GenerateHandler(StringBuilder builder, IEnumerable<ClassToGenerate> commands)
        {
            builder.AppendFormat("namespace {0}.Service.Handlers", this.Namespace).AppendLine();
            builder.AppendLine("{");

            builder.Append("    ").AppendFormat("public partial class {0}Handler : CommandHandler<{0}>", this.FileName).AppendLine();
            builder.AppendLine("    {");

            builder.AppendFormat("        public {0}Handler(IRepository<{0}> repository) : base(repository)", this.FileName).AppendLine();
            builder.AppendLine("        {");
            builder.AppendLine("        }");
            builder.AppendLine();

            foreach (ClassToGenerate classToGenerate in commands)
            {
                builder.AppendFormat("        public void Handle({0}Commands.{1} message)", this.FileName, classToGenerate.Name).AppendLine();
                builder.AppendLine("        {");

                builder.AppendFormat("            {0} item = this.Repository.GetById(message.Id);", this.FileName).AppendLine();
                builder.AppendFormat("            item.{0}(", classToGenerate.Name);

                bool appended = false;
                for (int i = 1; i < classToGenerate.Properties.Count; ++i)
                {
                    PropertyToGenerate property = classToGenerate.Properties[i];

                    if (!property.IsOnlyForState)
                    {
                        if (appended)
                            builder.Append(",");

                        builder.AppendFormat("message.{0}", property.UppercaseName);
                        appended = true;
                    }
                }

                builder.AppendLine(");");

                builder.AppendFormat("            this.Repository.Save(item);").AppendLine();
                builder.AppendLine("        }");
                builder.AppendLine();
            }

            builder.AppendLine("    }"); // end of public static class

            builder.AppendLine("}"); // end of namespace
        }

        private void GenerateViewBase(StringBuilder builder, IEnumerable<ClassToGenerate> events)
        {
            builder.AppendFormat("namespace {0}.Client.Views.Base", this.Namespace).AppendLine();
            builder.AppendLine("{");

            builder.Append("    ").AppendFormat("public abstract class {0}ViewBase : View<{0}Dto>", this.FileName).AppendLine();

            foreach (ClassToGenerate eventToGenerate in events)
            {
                builder.Append("        , ");

                builder.AppendFormat("IHandler<{0}Events.{1}>", this.FileName, eventToGenerate.Name).AppendLine();
            }

            builder.AppendLine();
            builder.AppendLine("    {");

            builder.AppendFormat("        protected {0}ViewBase(IReadModelStore readModelStore) : base(readModelStore)", this.FileName).AppendLine();
            builder.AppendLine("        {");
            builder.AppendLine("        }");
            builder.AppendLine();

            foreach (ClassToGenerate classToGenerate in events)
            {
                builder.AppendFormat("        public abstract void Handle({0}Events.{1} message);", this.FileName, classToGenerate.Name).AppendLine();
            }

            builder.AppendLine("    }"); // end of public static class

            builder.AppendLine("}"); // end of namespace
        }

        private void GenerateView(StringBuilder builder, IEnumerable<ClassToGenerate> events)
        {
            builder.AppendFormat("namespace {0}.Client.Views", this.Namespace).AppendLine();
            builder.AppendLine("{");

            builder.Append("    ").AppendFormat("public class {0}View : {0}ViewBase", this.FileName).AppendLine();

            builder.AppendLine("    {");

            builder.AppendFormat("        public {0}View(IReadModelStore readModelStore) : base(readModelStore)", this.FileName).AppendLine();
            builder.AppendLine("        {");
            builder.AppendLine("        }");
            builder.AppendLine();

            foreach (ClassToGenerate classToGenerate in events)
            {
                builder.AppendFormat("        public override void Handle({0}Events.{1} message)", this.FileName, classToGenerate.Name).AppendLine();
                builder.AppendLine("        {");

                builder.AppendFormat("            {0}Dto dto = this.Load(message.{0}Id);", this.FileName).AppendLine();

                if (classToGenerate.Name.EndsWith("Created"))
                {
                    builder.AppendFormat("            if (dto != null) throw new Exception(\"Item with the same Id already created!\");").AppendLine();
                    builder.AppendFormat("            dto = new {0}Dto();", this.FileName).AppendLine();
                }

                foreach (var prop in classToGenerate.Properties)
                {
                    if (prop.NotIncludedInWhen)
                        continue;

                    if (prop.IsListInDomain)
                    {
                        if (classToGenerate.Name.EndsWith("Added"))
                            builder.AppendFormat("            dto.{0}List.Add(message.{0});", prop.UppercaseName).AppendLine();
                        else if (classToGenerate.Name.EndsWith("Removed"))
                            builder.AppendFormat("            dto.{0}List.Remove(message.{0});", prop.UppercaseName).AppendLine();
                        else
                            throw new Exception("List method name should end with Added or Removed");
                    }
                    else
                    {
                        if (!prop.IsOnlyForState)
                            builder.AppendFormat("            dto.{0} = message.{0};", prop.UppercaseName).AppendLine();
                        else
                            builder.AppendFormat("            dto.{0} = {1};", prop.UppercaseName, prop.OnlyForStateValue).AppendLine();
                    }
                }

                builder.AppendLine("            this.Save(dto);");
                
                builder.AppendLine("        }").AppendLine();
            }

            builder.AppendLine("    }"); // end of public static class

            builder.AppendLine("}"); // end of namespace
        }

        private void GenerateState(StringBuilder builder, IEnumerable<ClassToGenerate> events)
        {
            builder.AppendFormat("namespace {0}.Service.Domain.States", this.Namespace).AppendLine();
            builder.AppendLine("{");

            builder.Append("    ").AppendFormat("public partial class {0}State : State", this.FileName).AppendLine();
            builder.AppendLine("    {");

            builder.AppendFormat("        public {0}State(IEnumerable<Event> events) : base(events)", this.FileName).AppendLine();
            builder.AppendLine("        {");
            builder.AppendLine("        }");
            builder.AppendLine();

            builder.AppendFormat("        public override Guid Id {{ get {{ return {0}Id; }} }}", this.FileName).AppendLine();

            IDictionary<string, PropertyToGenerate> usedProperties = new Dictionary<string, PropertyToGenerate>();
            foreach (ClassToGenerate classToGenerate in events)
            {
                classToGenerate.Properties.ForEach(prop => usedProperties[prop.UppercaseName] = prop);
            }

            foreach (PropertyToGenerate propertyToGenerate in usedProperties.Values)
            {
                propertyToGenerate.Generate(builder, false, false);
            }
            builder.AppendLine();

            foreach (ClassToGenerate classToGenerate in events)
            {
                builder.AppendFormat("        public void When({0}Events.{1} e)", this.FileName, classToGenerate.Name).AppendLine();
                builder.AppendLine("        {");

                foreach (var prop in classToGenerate.Properties)
                {
                    if (prop.NotIncludedInWhen)
                        continue;

                    if (prop.IsListInDomain)
                    {
                        if (classToGenerate.Name.EndsWith("Added"))
                            builder.AppendFormat("            this.{0}List.Add(e.{0});", prop.UppercaseName).AppendLine();
                        else if (classToGenerate.Name.EndsWith("Removed"))
                            builder.AppendFormat("            this.{0}List.Remove(e.{0});", prop.UppercaseName).AppendLine();
                        else
                            throw new Exception("List method name should end with Added or Removed");
                    }
                    else
                    {
                        if (!prop.IsOnlyForState)
                            builder.AppendFormat("            this.{0} = e.{0};", prop.UppercaseName).AppendLine();
                        else
                            builder.AppendFormat("            this.{0} = {1};", prop.UppercaseName, prop.OnlyForStateValue).AppendLine();
                    }
                }

                builder.AppendLine("        }").AppendLine();
            }

            builder.AppendLine("    }"); // end of public static class

            builder.AppendLine("}"); // end of namespace
        }

        private void GenerateDto(StringBuilder builder, IEnumerable<ClassToGenerate> events)
        {
            builder.AppendFormat("namespace {0}.Interfaces.Dto.Domain", this.Namespace).AppendLine();
            builder.AppendLine("{");

            builder.Append("    ").AppendLine("[DataContract]");
            builder.Append("    ").AppendFormat("public partial class {0}Dto : DataTransferObject", this.FileName).AppendLine();
            builder.AppendLine("    {");

            builder.AppendFormat("        public {0}Dto()", this.FileName).AppendLine();
            builder.AppendLine("        {");
            builder.AppendLine("        }");
            builder.AppendLine();

            IDictionary<string, PropertyToGenerate> usedProperties = new Dictionary<string, PropertyToGenerate>();
            foreach (ClassToGenerate classToGenerate in events)
            {
                classToGenerate.Properties.ForEach(prop => usedProperties[prop.UppercaseName] = prop);
            }

            foreach (PropertyToGenerate propertyToGenerate in usedProperties.Values)
            {
                propertyToGenerate.Generate(builder, true, true);
            }
            builder.AppendLine();

            builder.AppendLine("        public override DataTransferObjectDescriptor GetDescriptor()");
            builder.AppendLine("        {");
            builder.AppendLine("            DataTransferObjectDescriptor descr = new DataTransferObjectDescriptor();");
            builder.AppendFormat("            descr.Id = {0}Id;", this.FileName).AppendLine();
            foreach (PropertyToGenerate propertyToGenerate in usedProperties.Values)
            {
                if (propertyToGenerate.IsListInDomain)
                    builder.AppendFormat("            descr.Properties[\"{0}\"] = {0}List;", propertyToGenerate.UppercaseName).AppendLine();
                else
                    builder.AppendFormat("            descr.Properties[\"{0}\"] = {0};", propertyToGenerate.UppercaseName).AppendLine();
            }
            builder.AppendLine("            return descr;");
            builder.AppendLine("        }");


            builder.AppendLine("    }"); // end of public static class
            builder.AppendLine("}"); // end of namespace
        }

        private void GenerateMessageClasses(StringBuilder builder)
        {
            builder.AppendFormat("namespace {0}.Interfaces.Messages.Domain", this.Namespace).AppendLine();
            builder.AppendLine("{");

            builder.Append("    ").AppendLine("[DataContract]");
            builder.Append("    ").AppendFormat("public partial class Get{0}ListRequest : RequestMessage",
                                                this.FileName).AppendLine();
            builder.AppendLine("    {");
            builder.AppendFormat("        [DataMember] public string Filter {{ get; set; }}").AppendLine();
            builder.AppendLine("    }");
            builder.AppendLine();

            builder.Append("    ").AppendLine("[DataContract]");
            builder.Append("    ").AppendFormat("public partial class Get{0}ListResponse : ResponseMessage",
                                                this.FileName).AppendLine();
            builder.AppendLine("    {");
            builder.AppendFormat("        [DataMember] public List<{0}Dto> {0}List {{ get; set; }}", this.FileName).AppendLine();
            builder.AppendLine("    }");
            builder.AppendLine();


            builder.Append("    ").AppendLine("[DataContract]");
            builder.Append("    ").AppendFormat("public partial class Get{0}Request : RequestMessage", this.FileName).AppendLine();
            builder.AppendLine("    {");
            builder.AppendFormat("        [DataMember] public Guid {0}Id;", this.FileName).AppendLine();
            builder.AppendLine("    }");
            builder.AppendLine();

            builder.Append("    ").AppendLine("[DataContract]");
            builder.Append("    ").AppendFormat("public partial class Get{0}Response : ResponseMessage",
                                                this.FileName).AppendLine();
            builder.AppendLine("    {");
            builder.AppendFormat("        [DataMember] public {0}Dto {0};", this.FileName).AppendLine();
            builder.AppendLine("    }");
            builder.AppendLine();

            builder.AppendLine("}"); // end of namespace
        }

        private void GenerateFacadeClasses(StringBuilder builder)
        {
            builder.AppendFormat("namespace {0}.Client.Facades.Domain", this.Namespace).AppendLine();
            builder.AppendLine("{");

            builder.Append("    ").AppendFormat("public partial interface I{0}Facade", this.FileName).AppendLine();
            builder.AppendLine("    {");

            builder.AppendFormat("        Get{0}ListResponse Get{0}List(Get{0}ListRequest request);", this.FileName).AppendLine();
            builder.AppendFormat("        Get{0}Response Get{0}(Get{0}Request request);", this.FileName).AppendLine();

            builder.AppendLine("    }");
            builder.AppendLine();

            builder.Append("    ").AppendFormat("public partial class {0}Facade : ReadModelFacade, I{0}Facade", this.FileName).AppendLine();
            builder.AppendLine("    {");

            builder.AppendFormat("    public {0}Facade(IReadModelStore readModelStore) : base(readModelStore) {{}}", this.FileName);

            builder.AppendFormat("        public Get{0}ListResponse Get{0}List(Get{0}ListRequest request)", this.FileName).AppendLine();
            builder.AppendLine("        {");
            builder.AppendFormat("            {0}View view = new {0}View(ObjectFactory.Create<IReadModelStore>());", this.FileName).AppendLine();
            builder.AppendFormat("            List<{0}Dto> list = view.GetList(request.Filter);", this.FileName).AppendLine();
            builder.AppendFormat("            Get{0}ListResponse response = new Get{0}ListResponse();", this.FileName).AppendLine();
            builder.AppendFormat("            response.{0}List = list;", this.FileName).AppendLine();
            builder.AppendLine("            return response;").AppendLine();
            builder.AppendLine("        }");
            builder.AppendLine();

            builder.AppendFormat("        public Get{0}Response Get{0}(Get{0}Request request)", this.FileName).AppendLine();
            builder.AppendLine("        {");
            builder.AppendFormat("            {0}View view = new {0}View(ObjectFactory.Create<IReadModelStore>());", this.FileName).AppendLine();
            builder.AppendFormat("            {0}Dto dto = view.Load(request.{0}Id);", this.FileName).AppendLine();
            builder.AppendFormat("            Get{0}Response response = new Get{0}Response();", this.FileName).AppendLine();
            builder.AppendFormat("            response.{0} = dto;", this.FileName).AppendLine();
            builder.AppendLine("            return response;").AppendLine();
            builder.AppendLine("        }");
            builder.AppendLine();

            builder.AppendLine("    }");
            builder.AppendLine("}"); // end of namespace
        }

    }
}
