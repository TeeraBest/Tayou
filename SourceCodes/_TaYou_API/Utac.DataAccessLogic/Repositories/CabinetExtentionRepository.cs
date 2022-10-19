using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utac.DataAccessLogic.DataModel;
using Utac.DataAccessLogic.Models;

namespace Utac.DataAccessLogic.Repositories
{
    public class CabinetExtentionRepository
    {
        //internal Cabinet_Management_dbEntities Context;

        //public CabinetExtentionRepository(Cabinet_Management_dbEntities context)
        //{
        //    this.Context = context;
        //}
        //public IEnumerable<CabinetDisplayMasterModel> GetCabinetDisplay() {
        //    var query = (from cm in Context.Tbl_Cabinet_Master
        //                 join cl in Context.Tbl_Cabinet_Layer_Master on cm.Guid equals cl.Cabinet_Master_Guid
        //                 select new CabinetDisplayMasterModel()
        //                 {
        //                     Guid = cl.Guid,
        //                     Cabinet_No = cm.Cabinet_No,
        //                     Cabinet_Master_Guid = cl.Cabinet_Master_Guid,
        //                     Layer_Name = cl.Layer_Name,
        //                     Created_By = cl.Created_By,
        //                     Updated_By = cl.Updated_By,
        //                     Created_Date = cl.Created_Date,
        //                     Updated_Date = cl.Updated_Date

        //                 }).ToList();
        //    return query;
        //}
    }
}
