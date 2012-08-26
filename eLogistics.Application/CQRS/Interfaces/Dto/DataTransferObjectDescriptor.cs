using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace eLogistics.Application.CQRS.Interfaces.Dto
{
    public class DataTransferObjectDescriptor
    {
        public DataTransferObjectDescriptor()
        {
            this.Properties = new Dictionary<string, object>();
        }

        public Guid Id { get; set; }
        public IDictionary<string, object> Properties { get; private set; }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            JsonSerializer serializer = new JsonSerializer();
            TextWriter textWriter = new StringWriter(builder);
            JsonWriter jsonWriter = new JsonTextWriter(textWriter);
            jsonWriter.Formatting = Formatting.Indented;
            jsonWriter.DateFormatHandling = DateFormatHandling.IsoDateFormat;
            serializer.Serialize(jsonWriter, this);

            string result = builder.ToString();

            System.Diagnostics.Debug.WriteLine(result);

            return result;
        }
    }
}
