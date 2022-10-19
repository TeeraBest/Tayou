using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utac.DataAccessLogic.DataModel
{
    public class CashTransferListExtenstionModel
    {
        public Nullable<System.Guid> Guid { get; set; }
        public Nullable<System.DateTime> DatetimeCreated { get; set; }
        public string StrTimeRequest { get; set; }
        public string Process_Type { get; set; }
        public string From_To { get; set; }
        public Nullable<int> BulkStatusID { get; set; }
        public string TransferUserType { get; set; }
        public Nullable<bool> FlagRequireApproval { get; set; }
    }

    public partial class InventoryDenomModel
    {
        public string DenominationUnit { get; set; }
        public Nullable<double> DenominationValue { get; set; }
        public string DenominationTypeName { get; set; }
        public string NoteQualityTypeName { get; set; }
        public string BankNoteIssueName { get; set; }
        public Nullable<int> Count { get; set; }
        public Nullable<decimal> Value { get; set; }
        public System.Guid MasterCurrency_Guid { get; set; }
        public string MasterCurrencyAbbreviation { get; set; }
        public Nullable<System.Guid> InventoryType_Guid { get; set; }
        public string InventoryType_Name { get; set; }
        public Nullable<System.Guid> MasterCustomer_Guid { get; set; }
        public Nullable<System.Guid> MasterSafe_Guid { get; set; }
        public Nullable<System.Guid> InternalDepartment_Guid { get; set; }
        public Nullable<decimal> UnitValue { get; set; }
        public Nullable<System.Guid> MasterCustomerLocation_Guid { get; set; }
        public System.Guid MasterCommodity_Guid { get; set; }
        public Nullable<System.Guid> SystemDenominationUnit_Guid { get; set; }
        public Nullable<System.Guid> MasterDenomination_Guid { get; set; }
        public Nullable<System.Guid> SystemDenominationType_Guid { get; set; }
        public Nullable<System.Guid> SystemNoteQuality_Guid { get; set; }
        public Nullable<System.Guid> MasterBankNoteIssue_Guid { get; set; }
        public Nullable<System.Guid> MasterContainer_Guid { get; set; }
        public string CustomerFullName { get; set; }
        public string BranchName { get; set; }
        public string SealNumber { get; set; }
        public System.Guid Guid { get; set; }
        public Nullable<bool> FlagDisable { get; set; }
        public Nullable<System.Guid> MasterBankNoteSeries_Guid { get; set; }
        public string SeriesName { get; set; }
        public string StrDenomination { get; set; }

    }
}
