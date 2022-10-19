using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Utac.Api.ViewModels.ApiExternal
{
    public class MenuResponse
    {
        public Nullable<int> MasterMenuDetailIndex { get; set; }
        public string MasterMenuDetailName { get; set; }
        public string MasterMenuDetailParentMenu { get; set; }
        public string MasterMenuDetailLinkToPage { get; set; }
        public string MasterMenuDetailImage { get; set; }
        public Nullable<bool> FlagNotProperlyMobile { get; set; }
        public string CssClass { get; set; }
        public Nullable<int> MenuIndexOrder { get; set; }
        public string ControllerName { get; set; }
        public string Url { get; set; }
        public string UrlPath { get; set; }
        public Nullable<int> ApplicationID { get; set; }
    }
}