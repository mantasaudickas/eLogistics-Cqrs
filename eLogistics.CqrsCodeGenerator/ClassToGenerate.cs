using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCQRSCodeGenerator
{
    public class ClassToGenerate
    {
        public ClassToGenerate()
        {
            this.Properties = new List<PropertyToGenerate>();
        }

        public string Name { get; set; }
        public List<PropertyToGenerate> Properties { get; set; }

        public ClassType ClassType{ get; set; }

        // define event:
        // !StreetChanged(string street, string houseNo)
        // define command:
        // ?ChangeStreet(Guid addressId, string street, string houseNo)
        public void Parse(string line)
        {
            switch (line[0])
            {
                case '?': this.ClassType = ClassType.Event; break;
                case '!': this.ClassType = ClassType.Command; break;
                case '#': this.ClassType = ClassType.Handler; break;
                default: throw new NotSupportedException(string.Format("Line start [{0}] is not supported.", line[0]));
            }

            line = line.Substring(1);

            int index = line.IndexOf('(');
            this.Name = line.Substring(0, index);
            line = line.Substring(index + 1).Trim(new[] {'(', ')'});

            while (line.Length > 0)
            {
                index = line.IndexOf(',');
                if (index < 0)
                {
                    index = line.Length;
                }

                string prop = line.Substring(0, index).Trim();
                PropertyToGenerate propertyToGenerate = new PropertyToGenerate();
                propertyToGenerate.Parse(prop);
                this.Properties.Add(propertyToGenerate);

                if (index + 1 < line.Length)
                    line = line.Substring(index + 1);
                else
                    break;
            }
        }

        public void Generate(StringBuilder builder)
        {
            builder.AppendLine("        [DataContract]");
            builder.AppendFormat("        public class {0} : {1}", this.Name, this.ClassType.ToString()).AppendLine();
            builder.AppendLine("        {");

            HashSet<string> generatedProperties = new HashSet<string>();
            foreach (PropertyToGenerate property in Properties)
            {
                if (!generatedProperties.Contains(property.UppercaseName) && !property.IsOnlyForState)
                {
                    generatedProperties.Add(property.UppercaseName);
                    property.Generate(builder, true, false);
                }
            }

            if (this.Properties.Count > 0)
                builder.AppendLine();

            // constructor
            builder.AppendFormat("            public {0}(", this.Name);

            bool first = true;

            generatedProperties.Clear();
            foreach (PropertyToGenerate property in Properties)
            {
                if (!generatedProperties.Contains(property.UppercaseName) && !property.IsOnlyForState)
                {
                    generatedProperties.Add(property.UppercaseName);
                    if (!first)
                        builder.Append(", ");

                    property.GenerateConstructorArguments(builder);
                    first = false;
                }
            }
            builder.Append(")");

            if ((this.ClassType == ClassType.Command || this.ClassType == ClassType.Event) && this.Properties.Count > 0)
                builder.AppendFormat(" : base({0})", this.Properties[0].Name);

            if (this.ClassType == ClassType.Handler)
                builder.AppendFormat(" : base(repository)");

            builder.AppendLine();

            builder.AppendLine("            {");
            generatedProperties.Clear();
            foreach (PropertyToGenerate property in Properties)
            {
                if (!generatedProperties.Contains(property.UppercaseName) && !property.IsOnlyForState)
                {
                    generatedProperties.Add(property.UppercaseName);
                    property.GenerateConstructorBody(builder);
                }
            }

            builder.AppendLine("            }");
            builder.AppendLine("        }");
        }
    }
}
