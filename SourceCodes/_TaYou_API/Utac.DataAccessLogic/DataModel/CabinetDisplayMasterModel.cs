using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utac.DataAccessLogic.DataModel
{
    public class CabinetDisplayMasterModel
    {
        public Guid Guid { get; set; }
        public string Cabinet_No { get; set; }
        public Guid? Cabinet_Master_Guid { get; set; }
        public string Layer_Name { get; set; }
        public DateTime? Created_Date { get; set; }
        public DateTime? Updated_Date { get; set; }
        public string Created_By { get; set; }
        public string Updated_By { get; set; }
    }
}
