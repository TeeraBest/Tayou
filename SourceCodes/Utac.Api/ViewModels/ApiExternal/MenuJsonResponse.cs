using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Utac.Api.ViewModels.ApiExternal
{
    public class MenuJsonResponse
    {
        public Nullable<int> masterMenuDetailIndex { get; set; }
        public string masterMenuDetailName { get; set; }
        public string masterMenuDetailParentMenu { get; set; }
        public string masterMenuDetailLinkToPage { get; set; }
        public string cssClass { get; set; }
        public Nullable<int> menuIndexOrder { get; set; }

        public string hotKey { get; set; }
}
}