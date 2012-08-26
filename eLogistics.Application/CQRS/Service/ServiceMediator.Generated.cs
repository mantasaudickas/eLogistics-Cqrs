using eLogistics.Application.CQRS.Commands;
using eLogistics.Application.CQRS.Client.Views;
using eLogistics.Application.CQRS.Service.Domain;
using eLogistics.Application.CQRS.Service.Events;
using eLogistics.Application.CQRS.Service.Handlers;
using eLogistics.Application.CQRS.Service.Storage;

namespace eLogistics.Application.CQRS.Service
{
    public partial class ServiceMediator
    {
        private static readonly IMessageBus _messageBus = ObjectFactory.Create<IMessageBus>();
        private static readonly IEventStore _eventStore = ObjectFactory.Create<IEventStore>();
        private static readonly IReadModelStore _readModelStore = ObjectFactory.Create<IReadModelStore>();

        private static readonly AddressHandler _addressHandler = new AddressHandler(new Repository<Address>(_eventStore));
        private static readonly PaymentTypeHandler _paymentTypeHandler = new PaymentTypeHandler(new Repository<PaymentType>(_eventStore));
        private static readonly CommunicationHandler _communicationHandler = new CommunicationHandler(new Repository<Communication>(_eventStore));
        private static readonly CountryHandler _countryHandler = new CountryHandler(new Repository<Country>(_eventStore));
        private static readonly BankHandler _bankHandler = new BankHandler(new Repository<Bank>(_eventStore));
        private static readonly CompanyHandler _companyHandler = new CompanyHandler(new Repository<Company>(_eventStore));
        private static readonly SupplierHandler _supplierHandler = new SupplierHandler(new Repository<Supplier>(_eventStore));
        private static readonly CustomerHandler _customerHandler = new CustomerHandler(new Repository<Customer>(_eventStore));
        private static readonly ArticleGroupHandler _articleGroupHandler = new ArticleGroupHandler(new Repository<ArticleGroup>(_eventStore));
        private static readonly ArticleHandler _articleHandler = new ArticleHandler(new Repository<Article>(_eventStore));
        private static readonly ArticleVariantHandler _articleVariantHandler = new ArticleVariantHandler(new Repository<ArticleVariant>(_eventStore));
        private static readonly SupplierInvoiceHandler _supplierInvoiceHandler = new SupplierInvoiceHandler(new Repository<SupplierInvoice>(_eventStore));
        private static readonly SalesArticleHandler _salesArticleHandler = new SalesArticleHandler(new Repository<SalesArticle>(_eventStore));
        private static readonly OrderHandler _orderHandler = new OrderHandler(new Repository<Order>(_eventStore));
        private static readonly OrderItemHandler _orderItemHandler = new OrderItemHandler(new Repository<OrderItem>(_eventStore));

        private static readonly AddressView _addressView = new AddressView(_readModelStore);
        private static readonly PaymentTypeView _paymentTypeView = new PaymentTypeView(_readModelStore);
        private static readonly CommunicationView _communicationView = new CommunicationView(_readModelStore);
        private static readonly CountryView _countryView = new CountryView(_readModelStore);
        private static readonly BankView _bankView = new BankView(_readModelStore);
        private static readonly CompanyView _companyView = new CompanyView(_readModelStore);
        private static readonly SupplierView _supplierView = new SupplierView(_readModelStore);
        private static readonly CustomerView _customerView = new CustomerView(_readModelStore);
        private static readonly ArticleGroupView _articleGroupView = new ArticleGroupView(_readModelStore);
        private static readonly ArticleView _articleView = new ArticleView(_readModelStore);
        private static readonly ArticleVariantView _articleVariantView = new ArticleVariantView(_readModelStore);
        private static readonly SupplierInvoiceView _supplierInvoiceView = new SupplierInvoiceView(_readModelStore);
        private static readonly SalesArticleView _salesArticleView = new SalesArticleView(_readModelStore);
        private static readonly OrderView _orderView = new OrderView(_readModelStore);
        private static readonly OrderItemView _orderItemView = new OrderItemView(_readModelStore);

        static ServiceMediator()
        {
            #region Address

            _messageBus.Register<AddressCommands.Create>(_addressHandler.Handle);
            _messageBus.Register<AddressCommands.ChangeCountry>(_addressHandler.Handle);
            _messageBus.Register<AddressCommands.ChangeCity>(_addressHandler.Handle);
            _messageBus.Register<AddressCommands.ChangeStreet>(_addressHandler.Handle);
            _messageBus.Register<AddressCommands.ChangePostalCode>(_addressHandler.Handle);
            _messageBus.Register<AddressCommands.ChangeNote>(_addressHandler.Handle);

            _messageBus.Register<AddressEvents.Created>(_addressView.Handle);
            _messageBus.Register<AddressEvents.CountryChanged>(_addressView.Handle);
            _messageBus.Register<AddressEvents.CityChanged>(_addressView.Handle);
            _messageBus.Register<AddressEvents.StreetChanged>(_addressView.Handle);
            _messageBus.Register<AddressEvents.PostalCodeChanged>(_addressView.Handle);
            _messageBus.Register<AddressEvents.NoteChanged>(_addressView.Handle);

            #endregion

            #region PaymentType

            _messageBus.Register<PaymentTypeCommands.Create>(_paymentTypeHandler.Handle);
            _messageBus.Register<PaymentTypeCommands.ChangeName>(_paymentTypeHandler.Handle);
            _messageBus.Register<PaymentTypeCommands.ChangeIsCredit>(_paymentTypeHandler.Handle);
            _messageBus.Register<PaymentTypeCommands.Delete>(_paymentTypeHandler.Handle);

            _messageBus.Register<PaymentTypeEvents.Created>(_paymentTypeView.Handle);
            _messageBus.Register<PaymentTypeEvents.NameChanged>(_paymentTypeView.Handle);
            _messageBus.Register<PaymentTypeEvents.IsCreditChanged>(_paymentTypeView.Handle);
            _messageBus.Register<PaymentTypeEvents.Deleted>(_paymentTypeView.Handle);

            #endregion

            #region Communication

            _messageBus.Register<CommunicationCommands.Create>(_communicationHandler.Handle);
            _messageBus.Register<CommunicationCommands.ChangeValue>(_communicationHandler.Handle);
            _messageBus.Register<CommunicationCommands.ChangeNote>(_communicationHandler.Handle);

            _messageBus.Register<CommunicationEvents.Created>(_communicationView.Handle);
            _messageBus.Register<CommunicationEvents.ValueChanged>(_communicationView.Handle);
            _messageBus.Register<CommunicationEvents.NoteChanged>(_communicationView.Handle);

            #endregion

            #region Country

            _messageBus.Register<CountryCommands.Create>(_countryHandler.Handle);
            _messageBus.Register<CountryCommands.ChangeName>(_countryHandler.Handle);

            _messageBus.Register<CountryEvents.Created>(_countryView.Handle);
            _messageBus.Register<CountryEvents.NameChanged>(_countryView.Handle);

            #endregion

            #region Bank

            _messageBus.Register<BankCommands.Create>(_bankHandler.Handle);
            _messageBus.Register<BankCommands.ChangeName>(_bankHandler.Handle);
            _messageBus.Register<BankCommands.ChangeBankCode>(_bankHandler.Handle);
            _messageBus.Register<BankCommands.ChangeBankSwiftCode>(_bankHandler.Handle);
            _messageBus.Register<BankCommands.ChangeNote>(_bankHandler.Handle);

            _messageBus.Register<BankEvents.Created>(_bankView.Handle);
            _messageBus.Register<BankEvents.NameChanged>(_bankView.Handle);
            _messageBus.Register<BankEvents.BankCodeChanged>(_bankView.Handle);
            _messageBus.Register<BankEvents.BankSwiftCodeChanged>(_bankView.Handle);
            _messageBus.Register<BankEvents.NoteChanged>(_bankView.Handle);

            #endregion

            #region Company

            _messageBus.Register<CompanyCommands.Create>(_companyHandler.Handle);
            _messageBus.Register<CompanyCommands.ChangeName>(_companyHandler.Handle);
            _messageBus.Register<CompanyCommands.ChangeCompanyCode>(_companyHandler.Handle);
            _messageBus.Register<CompanyCommands.ChangeContactPerson>(_companyHandler.Handle);
            _messageBus.Register<CompanyCommands.ChangeNote>(_companyHandler.Handle);
            _messageBus.Register<CompanyCommands.AddAddress>(_companyHandler.Handle);
            _messageBus.Register<CompanyCommands.RemoveAddress>(_companyHandler.Handle);
            _messageBus.Register<CompanyCommands.AddCommunication>(_companyHandler.Handle);
            _messageBus.Register<CompanyCommands.RemoveCommunication>(_companyHandler.Handle);

            _messageBus.Register<CompanyEvents.Created>(_companyView.Handle);
            _messageBus.Register<CompanyEvents.NameChanged>(_companyView.Handle);
            _messageBus.Register<CompanyEvents.CompanyCodeChanged>(_companyView.Handle);
            _messageBus.Register<CompanyEvents.ContactPersonChanged>(_companyView.Handle);
            _messageBus.Register<CompanyEvents.NoteChanged>(_companyView.Handle);
            _messageBus.Register<CompanyEvents.AddressAdded>(_companyView.Handle);
            _messageBus.Register<CompanyEvents.AddressRemoved>(_companyView.Handle);
            _messageBus.Register<CompanyEvents.CommunicationAdded>(_companyView.Handle);
            _messageBus.Register<CompanyEvents.CommunicationRemoved>(_companyView.Handle);

            #endregion

            #region Supplier

            _messageBus.Register<SupplierCommands.Create>(_supplierHandler.Handle);
            _messageBus.Register<SupplierCommands.ChangeName>(_supplierHandler.Handle);
            _messageBus.Register<SupplierCommands.AddCompany>(_supplierHandler.Handle);
            _messageBus.Register<SupplierCommands.RemoveCompany>(_supplierHandler.Handle);
            _messageBus.Register<SupplierCommands.ChangeNote>(_supplierHandler.Handle);
            _messageBus.Register<SupplierCommands.AddBankAccount>(_supplierHandler.Handle);
            _messageBus.Register<SupplierCommands.RemoveBankAccount>(_supplierHandler.Handle);

            _messageBus.Register<SupplierEvents.Created>(_supplierView.Handle);
            _messageBus.Register<SupplierEvents.NameChanged>(_supplierView.Handle);
            _messageBus.Register<SupplierEvents.CompanyAdded>(_supplierView.Handle);
            _messageBus.Register<SupplierEvents.CompanyRemoved>(_supplierView.Handle);
            _messageBus.Register<SupplierEvents.NoteChanged>(_supplierView.Handle);
            _messageBus.Register<SupplierEvents.BankAccountAdded>(_supplierView.Handle);
            _messageBus.Register<SupplierEvents.BankAccountRemoved>(_supplierView.Handle);

            #endregion

            #region Customer

            _messageBus.Register<CustomerCommands.Create>(_customerHandler.Handle);
            _messageBus.Register<CustomerCommands.ChangeName>(_customerHandler.Handle);
            _messageBus.Register<CustomerCommands.AddCompany>(_customerHandler.Handle);
            _messageBus.Register<CustomerCommands.RemoveCompany>(_customerHandler.Handle);
            _messageBus.Register<CustomerCommands.ChangeNote>(_customerHandler.Handle);
            _messageBus.Register<CustomerCommands.AddBankAccount>(_customerHandler.Handle);
            _messageBus.Register<CustomerCommands.RemoveBankAccount>(_customerHandler.Handle);
            _messageBus.Register<CustomerCommands.AddPaymentType>(_customerHandler.Handle);
            _messageBus.Register<CustomerCommands.RemovePaymentType>(_customerHandler.Handle);

            _messageBus.Register<CustomerEvents.Created>(_customerView.Handle);
            _messageBus.Register<CustomerEvents.NameChanged>(_customerView.Handle);
            _messageBus.Register<CustomerEvents.CompanyAdded>(_customerView.Handle);
            _messageBus.Register<CustomerEvents.CompanyRemoved>(_customerView.Handle);
            _messageBus.Register<CustomerEvents.NoteChanged>(_customerView.Handle);
            _messageBus.Register<CustomerEvents.BankAccountAdded>(_customerView.Handle);
            _messageBus.Register<CustomerEvents.BankAccountRemoved>(_customerView.Handle);
            _messageBus.Register<CustomerEvents.PaymentTypeAdded>(_customerView.Handle);
            _messageBus.Register<CustomerEvents.PaymentTypeRemoved>(_customerView.Handle);

            #endregion

            #region ArticleGroup

            _messageBus.Register<ArticleGroupCommands.Create>(_articleGroupHandler.Handle);
            _messageBus.Register<ArticleGroupCommands.ChangeName>(_articleGroupHandler.Handle);
            _messageBus.Register<ArticleGroupCommands.ChangeNote>(_articleGroupHandler.Handle);

            _messageBus.Register<ArticleGroupEvents.Created>(_articleGroupView.Handle);
            _messageBus.Register<ArticleGroupEvents.NameChanged>(_articleGroupView.Handle);
            _messageBus.Register<ArticleGroupEvents.NoteChanged>(_articleGroupView.Handle);

            #endregion

            #region Article

            _messageBus.Register<ArticleCommands.Create>(_articleHandler.Handle);
            _messageBus.Register<ArticleCommands.ChangeArticleGroup>(_articleHandler.Handle);
            _messageBus.Register<ArticleCommands.ChangeName>(_articleHandler.Handle);
            _messageBus.Register<ArticleCommands.ChangeManufacturer>(_articleHandler.Handle);
            _messageBus.Register<ArticleCommands.ChangeModelName>(_articleHandler.Handle);
            _messageBus.Register<ArticleCommands.ChangeQuantityUnitName>(_articleHandler.Handle);
            _messageBus.Register<ArticleCommands.MarkArticleAsInternal>(_articleHandler.Handle);
            _messageBus.Register<ArticleCommands.UnmarkArticleAsInternal>(_articleHandler.Handle);
            _messageBus.Register<ArticleCommands.ChangeNote>(_articleHandler.Handle);

            _messageBus.Register<ArticleEvents.Created>(_articleView.Handle);
            _messageBus.Register<ArticleEvents.ArticleGroupChanged>(_articleView.Handle);
            _messageBus.Register<ArticleEvents.NameChanged>(_articleView.Handle);
            _messageBus.Register<ArticleEvents.ManufacturerChanged>(_articleView.Handle);
            _messageBus.Register<ArticleEvents.ModelNameChanged>(_articleView.Handle);
            _messageBus.Register<ArticleEvents.QuantityUnitNameChanged>(_articleView.Handle);
            _messageBus.Register<ArticleEvents.ArticleMarkedAsInternal>(_articleView.Handle);
            _messageBus.Register<ArticleEvents.ArticleUnmarkedAsInternal>(_articleView.Handle);
            _messageBus.Register<ArticleEvents.NoteChanged>(_articleView.Handle);

            #endregion

            #region ArticleVariant

            _messageBus.Register<ArticleVariantCommands.Create>(_articleVariantHandler.Handle);
            _messageBus.Register<ArticleVariantCommands.ChangePrice>(_articleVariantHandler.Handle);
            _messageBus.Register<ArticleVariantCommands.AddBarcode>(_articleVariantHandler.Handle);
            _messageBus.Register<ArticleVariantCommands.RemoveBarcode>(_articleVariantHandler.Handle);
            _messageBus.Register<ArticleVariantCommands.AddArticleAttribute>(_articleVariantHandler.Handle);
            _messageBus.Register<ArticleVariantCommands.RemoveArticleAttribute>(_articleVariantHandler.Handle);

            _messageBus.Register<ArticleVariantEvents.Created>(_articleVariantView.Handle);
            _messageBus.Register<ArticleVariantEvents.PriceChanged>(_articleVariantView.Handle);
            _messageBus.Register<ArticleVariantEvents.BarcodeAdded>(_articleVariantView.Handle);
            _messageBus.Register<ArticleVariantEvents.BarcodeRemoved>(_articleVariantView.Handle);
            _messageBus.Register<ArticleVariantEvents.ArticleAttributeAdded>(_articleVariantView.Handle);
            _messageBus.Register<ArticleVariantEvents.ArticleAttributeRemoved>(_articleVariantView.Handle);

            #endregion

            #region SupplierInvoice

            _messageBus.Register<SupplierInvoiceCommands.Create>(_supplierInvoiceHandler.Handle);
            _messageBus.Register<SupplierInvoiceCommands.ChangeInvoiceNo>(_supplierInvoiceHandler.Handle);
            _messageBus.Register<SupplierInvoiceCommands.ChangeInvoiceDate>(_supplierInvoiceHandler.Handle);
            _messageBus.Register<SupplierInvoiceCommands.ChangeInvoicePaymentDate>(_supplierInvoiceHandler.Handle);
            _messageBus.Register<SupplierInvoiceCommands.ChangeNote>(_supplierInvoiceHandler.Handle);

            _messageBus.Register<SupplierInvoiceEvents.Created>(_supplierInvoiceView.Handle);
            _messageBus.Register<SupplierInvoiceEvents.InvoiceNoChanged>(_supplierInvoiceView.Handle);
            _messageBus.Register<SupplierInvoiceEvents.InvoiceDateChanged>(_supplierInvoiceView.Handle);
            _messageBus.Register<SupplierInvoiceEvents.InvoicePaymentDateChanged>(_supplierInvoiceView.Handle);
            _messageBus.Register<SupplierInvoiceEvents.NoteChanged>(_supplierInvoiceView.Handle);

            #endregion

            #region SalesArticle

            _messageBus.Register<SalesArticleCommands.Create>(_salesArticleHandler.Handle);
            _messageBus.Register<SalesArticleCommands.ChangeSupplierInvoice>(_salesArticleHandler.Handle);
            _messageBus.Register<SalesArticleCommands.ChangeArticleVariant>(_salesArticleHandler.Handle);
            _messageBus.Register<SalesArticleCommands.ChangeQuantity>(_salesArticleHandler.Handle);
            _messageBus.Register<SalesArticleCommands.ChangePrice>(_salesArticleHandler.Handle);

            _messageBus.Register<SalesArticleEvents.Created>(_salesArticleView.Handle);
            _messageBus.Register<SalesArticleEvents.SupplierInvoiceChanged>(_salesArticleView.Handle);
            _messageBus.Register<SalesArticleEvents.ArticleVariantChanged>(_salesArticleView.Handle);
            _messageBus.Register<SalesArticleEvents.QuantityChanged>(_salesArticleView.Handle);
            _messageBus.Register<SalesArticleEvents.PriceChanged>(_salesArticleView.Handle);

            #endregion

            #region Order

            _messageBus.Register<OrderCommands.Create>(_orderHandler.Handle);
            _messageBus.Register<OrderCommands.ChangeCustomer>(_orderHandler.Handle);

            _messageBus.Register<OrderEvents.Created>(_orderView.Handle);
            _messageBus.Register<OrderEvents.CustomerChanged>(_orderView.Handle);

            #endregion

            #region OrderItem

            _messageBus.Register<OrderItemCommands.Create>(_orderItemHandler.Handle);
            _messageBus.Register<OrderItemCommands.ChangeSalesArticle>(_orderItemHandler.Handle);
            _messageBus.Register<OrderItemCommands.ChangeQuantity>(_orderItemHandler.Handle);
            _messageBus.Register<OrderItemCommands.ChangePrice>(_orderItemHandler.Handle);
            _messageBus.Register<OrderItemCommands.ChangeDiscount>(_orderItemHandler.Handle);
            _messageBus.Register<OrderItemCommands.ChangeName>(_orderItemHandler.Handle);
            _messageBus.Register<OrderItemCommands.MarkItemAsService>(_orderItemHandler.Handle);
            _messageBus.Register<OrderItemCommands.UnmarkItemAsService>(_orderItemHandler.Handle);

            _messageBus.Register<OrderItemEvents.Created>(_orderItemView.Handle);
            _messageBus.Register<OrderItemEvents.SalesArticleChanged>(_orderItemView.Handle);
            _messageBus.Register<OrderItemEvents.QuantityChanged>(_orderItemView.Handle);
            _messageBus.Register<OrderItemEvents.PriceChanged>(_orderItemView.Handle);
            _messageBus.Register<OrderItemEvents.DiscountChanged>(_orderItemView.Handle);
            _messageBus.Register<OrderItemEvents.NameChanged>(_orderItemView.Handle);
            _messageBus.Register<OrderItemEvents.ItemMarkedAsService>(_orderItemView.Handle);
            _messageBus.Register<OrderItemEvents.ItemUnmarkedAsService>(_orderItemView.Handle);

            #endregion

        }

        public static void Register() {}
    }
}
