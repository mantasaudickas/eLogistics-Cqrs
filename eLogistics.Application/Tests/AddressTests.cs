using System;
using System.Collections.Generic;
using NUnit.Framework;
using eLogistics.Application.CQRS;
using eLogistics.Application.CQRS.Client.Facades.Domain;
using eLogistics.Application.CQRS.Commands;
using eLogistics.Application.CQRS.Interfaces;
using eLogistics.Application.CQRS.Interfaces.Messages.Domain;
using eLogistics.Application.CQRS.Service;
using eLogistics.Application.CQRS.Service.Domain;
using eLogistics.Application.CQRS.Service.Events;
using eLogistics.Application.CQRS.Service.Storage;

namespace eLogistics.Application.Tests
{
    [TestFixture]
    public class AddressTests
    {
        [Test]
        public void TestChangeCity()
        {
            Guid id = Guid.NewGuid();
            Guid companyId = Guid.NewGuid();
            Guid countryId = Guid.NewGuid();
            Guid cityId = Guid.NewGuid();

            Repository<Address> repository = new Repository<Address>(ObjectFactory.Create<IEventStore>());

            Address address = repository.GetById(id);

            address.Create(id, Owner.Company, companyId);
            address.ChangeCountry(countryId);
            address.ChangeCity(cityId);

            Assert.AreEqual(Owner.Company, address.State.Owner);
            Assert.AreEqual(countryId, address.State.CountryId);
            Assert.AreEqual(cityId, address.State.CityId);
            Assert.AreEqual(3, address.GetUncommittedChanges().Count);

            address.Commit();
            Assert.AreEqual(0, address.GetUncommittedChanges().Count);

            address.LoadFromHistory(new List<Event> {new AddressEvents.NoteChanged(id, "this note should be applied to aggregate")});
            Assert.AreEqual("this note should be applied to aggregate", address.State.Note);
        }

        [Test]
        public void TestAddressHandler()
        {
            Guid id = Guid.NewGuid();
            Guid companyId = Guid.NewGuid();
            Guid countryId = Guid.NewGuid();
            Guid cityId = Guid.NewGuid();

            IMessageBus messageBus = ServiceMediator.Bus;
            messageBus.Send(new AddressCommands.Create(id, Owner.Company, companyId));
            messageBus.Send(new AddressCommands.ChangeCountry(id, countryId));
            messageBus.Send(new AddressCommands.ChangeCity(id, cityId));

            Repository<Address> repository = new Repository<Address>(ObjectFactory.Create<IEventStore>());
            Address address = repository.GetById(id);

            Assert.AreEqual(Owner.Company, address.State.Owner);
            Assert.AreEqual(countryId, address.State.CountryId);
            Assert.AreEqual(cityId, address.State.CityId);

            AddressFacade facade = new AddressFacade(ObjectFactory.Create<IReadModelStore>());
            GetAddressResponse response = facade.GetAddress(new GetAddressRequest {AddressId = id});
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Address);
            Assert.AreEqual(id, response.Address.AddressId);

            GetAddressListResponse searchResponse = facade.GetAddressList(new GetAddressListRequest {Filter = "qwerty"});
            Assert.IsNotNull(searchResponse);
            Assert.IsTrue(searchResponse.AddressList == null || searchResponse.AddressList.Count == 0);

            searchResponse = facade.GetAddressList(new GetAddressListRequest { Filter = "auna" });
            Assert.IsNotNull(searchResponse);
            Assert.IsTrue(searchResponse.AddressList != null && searchResponse.AddressList.Count == 1);
        }
    }
}
