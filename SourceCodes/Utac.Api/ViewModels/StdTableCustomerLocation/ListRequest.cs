using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Utac.Api.ViewModels.StdTableCustomerLocation
{
    public class SearchOptionModel
    {
        public Guid MasterCountry_Guid { get; set; }
        public Guid? MasterCustomer_Guid { get; set; }
    }
}