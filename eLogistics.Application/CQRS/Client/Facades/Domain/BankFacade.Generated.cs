using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using eLogistics.Application.CQRS.Client.Views;
using eLogistics.Application.CQRS.Interfaces.Dto.Domain;
using eLogistics.Application.CQRS.Interfaces.Messages.Domain;
using eLogistics.Application.CQRS.Service.Storage;
namespace eLogistics.Application.CQRS.Client.Facades.Domain
{
    public partial interface IBankFacade
    {
        GetBankListResponse GetBankList(GetBankListRequest request);
        GetBankResponse GetBank(GetBankRequest request);
    }

    public partial class BankFacade : ReadModelFacade, IBankFacade
    {
    public BankFacade(IReadModelStore readModelStore) : base(readModelStore) {}        public GetBankListResponse GetBankList(GetBankListRequest request)
        {
            BankView view = new BankView(ObjectFactory.Create<IReadModelStore>());
            List<BankDto> list = view.GetList(request.Filter);
            GetBankListResponse response = new GetBankListResponse();
            response.BankList = list;
            return response;

        }

        public GetBankResponse GetBank(GetBankRequest request)
        {
            BankView view = new BankView(ObjectFactory.Create<IReadModelStore>());
            BankDto dto = view.Load(request.BankId);
            GetBankResponse response = new GetBankResponse();
            response.Bank = dto;
            return response;

        }

    }
}
