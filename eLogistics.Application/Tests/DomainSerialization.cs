using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using NUnit.Framework;
using Newtonsoft.Json;
using eLogistics.Application.CQRS.Commands;
using eLogistics.Application.CQRS.Service.Events;

namespace eLogistics.Application.Tests
{
    [TestFixture]
    public class DomainSerialization
    {
        [Test]
        public void TestEventJsonSerialization()
        {
            AddressEvents.CityChanged cityChanged = new AddressEvents.CityChanged(Guid.NewGuid(), "new city name");
            
            JsonSerializer serializer = new JsonSerializer();
            
            TextWriter textWriter = new StringWriter();
            JsonTextWriter writer = new JsonTextWriter(textWriter);
            serializer.Serialize(writer, cityChanged);

            TextReader textReader = new StringReader(textWriter.ToString());
            JsonReader reader = new JsonTextReader(textReader);
            var deserialized = serializer.Deserialize<AddressEvents.CityChanged>(reader);

            Assert.AreEqual(cityChanged.City, deserialized.City);
        }

        [Test]
        public void TestCommandDataContractSerialization()
        {
            AddressCommands.ChangeCity changeCity = new AddressCommands.ChangeCity(Guid.NewGuid(), "new city name");

            DataContractSerializer serializer = new DataContractSerializer(typeof (AddressCommands.ChangeCity));

            MemoryStream stream = new MemoryStream();
            serializer.WriteObject(stream, changeCity);

            stream.Position = 0;
            AddressCommands.ChangeCity deserialized = (AddressCommands.ChangeCity) serializer.ReadObject(stream);
            Assert.AreEqual(changeCity.Id, deserialized.Id);
            Assert.AreEqual(changeCity.City, deserialized.City);
        }
    }
}
