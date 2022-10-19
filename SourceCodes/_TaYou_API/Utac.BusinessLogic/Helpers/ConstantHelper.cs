using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Utac.BusinessLogic.Helpers
{
    public static class ConstantHelper
    {
        private static string _appUser { get; set; }
        private static string _appPass { get; set; }
        private static string _oceanAPI { get; set; }
        private static int _applicationID { get; set; }
        private static void FetchData()
        {
            _appUser = ConfigurationManager.AppSettings["APIAppUser"];
            _appPass = ConfigurationManager.AppSettings["APIAppPass"];
            _oceanAPI = ConfigurationManager.AppSettings["OceanOnlineAPIURL"];
            _applicationID = Int32.Parse(ConfigurationManager.AppSettings["ApplicationID"]);
        }

        public static readonly Guid NautilusApplicationToken = Guid.Parse("0E56D0D6-6D45-4FA3-904F-EF770B519322");
        public static readonly Guid CommodityGuid = Guid.Parse("88428BA0-3E63-4C21-8E7D-03C32BCC3163");

        public static string AppUser
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_appUser)) FetchData();
                return _appUser;
            }
        }

        /// <summary>
        /// API application password
        /// </summary>
        public static string AppPass
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_appPass)) FetchData();
                return _appPass;
            }
        }

        public static string OceanAPI
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_oceanAPI)) FetchData();
                return _oceanAPI;
            }
        }

        public static int ApplicationID
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_applicationID.ToString())) FetchData();
                return _applicationID;
            }
        }

        public enum RecieveDuffelBagStatus
        {
            Notfound = 1,
            Duplicate = 2
        }

        public enum ChangeStatusHeaderCardType
        {
            Disable = 1,
            Enable = 2,
            Reuse = 3,
        }

        public enum SearchBarcodeType
        {
            DuffelBag = 1,
            TEBag = 2,
            HeaderCard = 3,
        }

        public enum HeaderCardStatus
        {
            Available = 1,
            Prepared = 2,
            Counted = 3,
            Reject_Entered = 4
        }

        public enum FitnessSortingStatus
        {
            Transit = 1,
            Processing = 2,
            Delivery_In = 3
        }

        public enum UserInventoryType
        {
            Deposit = 1,
            Order = 2,
            FinessSorting = 3
        }

        public enum ImportExportJobType
        {
            Deposit = 1,
            Order = 2
        }
        public enum DepositRuleType {
            DuffleBag = 1,
            SingleBag = 2,
            MultiBag = 3
        }

        public static class CountryConfigAppKey
        {
            public static string RequireSupervisorVerify => "RequireSupervisorVerify";
        }

        public class ImportExportCurrencyList
        {
            public string CurrencyCode { get; set; }
            public string CurrencyFull { get; set; }

        }
        public class ImportExportType
        {
            public string TypeFull { get; set; }
            public int Type { get; set; }
        }
        public static class ImportExportCurrency
        {
            public static List<ImportExportCurrencyList> CurrencyList = new List<ImportExportCurrencyList>() {
                new ImportExportCurrencyList () { CurrencyCode = "SGD",CurrencyFull = "SINGAPORE $"},
                new ImportExportCurrencyList () { CurrencyCode = "BND",CurrencyFull = "BRUNEI $"}
            };
            public static List<ImportExportType> TypeList = new List<ImportExportType>() {
                new ImportExportType () { TypeFull = "MUTILATED/OLD SERIES",Type = 1},
                new ImportExportType () { TypeFull = "CURRENT SERIES (\"000)",Type = 1},
                new ImportExportType () { TypeFull = "SOUVENIR COINS",Type = 2}
            };
        }
    }
}
