using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCQRSCodeGenerator
{
    public class PropertyToGenerate
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string UppercaseName { get; set; }
        public bool IsListInDomain { get; set; }
        public bool IsOnlyForState { get; set; }
        public string OnlyForStateValue { get; set; }
        public bool NotIncludedInWhen { get; set; }

        //string street
        public void Parse(string line)
        {
            int index = line.IndexOf(' ');
            this.Type = line.Substring(0, index).Trim();
            this.Name = line.Substring(index + 1).Trim();
            this.UppercaseName = Char.ToUpper(this.Name[0]) + this.Name.Substring(1);

            if (this.Type.EndsWith("*"))
            {
                this.IsListInDomain = true;
                this.Type = this.Type.Replace("*", string.Empty);
            }

            if (this.Type.EndsWith("%"))
            {
                this.IsOnlyForState = true;
                this.Type = this.Type.Replace("%", string.Empty);

                string[] nodes = this.Name.Split(new[] {'='});
                if (nodes.Length > 1)
                {
                    this.Name = nodes[0].Trim();
                    this.UppercaseName = Char.ToUpper(this.Name[0]) + this.Name.Substring(1);
                    this.OnlyForStateValue = nodes[1].Trim();
                }
            }
        }

        public void Generate(StringBuilder builder, bool includeDataMember, bool checkIsListInDomain)
        {
            if (includeDataMember)
            {
                if (checkIsListInDomain)
                {
                    if (this.IsListInDomain)
                        builder.AppendFormat("        [DataMember] public List<{0}> {1}List {{ get; set; }}", this.Type, this.UppercaseName).AppendLine();
                    else
                        builder.AppendFormat("        [DataMember] public {0} {1} {{ get; set; }}", this.Type, this.UppercaseName).AppendLine();
                }
                else
                {
                    builder.AppendFormat("            [DataMember] public {0} {1} {{ get; private set; }}", this.Type, this.UppercaseName).AppendLine();
                }
            }
            else
            {
                if (this.IsListInDomain)
                    builder.AppendFormat("        public List<{0}> {1}List {{ get; private set; }}", this.Type, this.UppercaseName).AppendLine();
                else
                    builder.AppendFormat("        public {0} {1} {{ get; private set; }}", this.Type, this.UppercaseName).AppendLine();
            }
        }

        public void GenerateConstructorArguments(StringBuilder builder)
        {
            builder.AppendFormat("{0} {1}", this.Type, this.Name);
        }

        public void GenerateConstructorBody(StringBuilder builder)
        {
            builder.AppendFormat("                {0} = {1};", this.UppercaseName, this.Name).AppendLine();
        }
    }
}
