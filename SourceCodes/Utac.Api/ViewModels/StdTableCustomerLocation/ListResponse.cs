using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Utac.Api.ViewModels.StdTableCustomerLocation
{
    public class SearchOptionCountryModel
    {
        public Guid MasterCountry_Guid { get; set; }
        public string MasterCountryName { get; set; }
    }
    public class SearchOptionCustomerModel
    {
        public Guid MasterCustomer_Guid { get; set; }
        public string CustomerFullName { get; set; }
    }
}