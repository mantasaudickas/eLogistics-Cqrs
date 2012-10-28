using System;
using System.Collections.Generic;
using System.Windows.Controls;
using eLogistics.Application.CQRS;
using eLogistics.Application.CQRS.Client.Facades.Domain;
using eLogistics.Application.CQRS.Interfaces.Dto.Domain;
using eLogistics.Application.CQRS.Interfaces.Messages.Domain;
using eLogistics.Application.CQRS.Service.Storage;

namespace eLogistics.Executable.Windows.Controls
{
    public class CompanyComboBox : ComboBox
    {
        public CompanyComboBox()
        {
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            var facade = new CompanyFacade(ObjectFactory.Create<IReadModelStore>());
            var response = facade.GetCompanyList(new GetCompanyListRequest());
            if (response != null && response.CompanyList != null)
            {
                List<CompanyDto> companyList = response.CompanyList;
                companyList.Sort((d1, d2) => String.Compare(d1.Name, d2.Name, StringComparison.Ordinal));
                this.ItemsSource = companyList;
                this.DisplayMemberPath = "Name";
                this.SelectedValuePath = "CompanyId";
            }
        }
    }
}
