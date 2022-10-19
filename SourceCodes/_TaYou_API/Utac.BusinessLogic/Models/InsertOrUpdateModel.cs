using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utac.BusinessLogic.Models
{
    public class InsertOrUpdateDataModel
    {
        public Guid? MasterUser_Guid { get; set; }
        public string UserID { get; set; }
        public string StrDateTimeCreate { get; set; }
        public int TimeZoneOffSet { get; set; }
        public string FormatDateTime { get; set; }
        public string FormatDate { get; set; }

        public string StrDateTimeCreateWithSS { get; set; }
        public string FormatDateTimeWithSS { get; set; }
    }

    public class RetInsertOrUpdateDataModel : InsertOrUpdateDataModel
    {
        public bool FlagSaveSuccess { get; set; } = false;
        public string ErrorMsg { get; set; }
        public Exception exception { get; set; }
    }
}
