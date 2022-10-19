using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utac.DataAccessLogic.Models;
using Utac.DataAccessLogic.UnitOfWorks;

namespace Utac.BusinessLogic.Services
{
    public class _LogDataServices
    {
        private readonly UnitOfWork _unitOfWork;
        public _LogDataServices()
        {
            _unitOfWork = new UnitOfWork();
            ClearLog(6);
        }
        #region ClearLog
        public bool ClearLog(int month)
        {
            DateTime dateToClear = DateTime.Now.AddMonths(-month);
            try
            {
                var logDataList = _unitOfWork.TBL_Data_LogRepository.FindAllWithExpression(f => f.Create_date < dateToClear).ToList();
                foreach (var logData in logDataList)
                {
                    _unitOfWork.TBL_Data_LogRepository.Delete(logData);
                }
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                _unitOfWork.Dispose();
                //Log
                return false;
            }
            return true;
        }
        #endregion

        public void CreateLog(string operation, string type, string logData)
        {

            UnitOfWork _unitOfWork_Ex = new UnitOfWork();
            TBL_Data_Log tbl_Data_Log = new TBL_Data_Log()
            {
                Operation = operation,
                Type = type,
                Data_Log = logData,
                Create_date = DateTime.Now
            };
            _unitOfWork_Ex.TBL_Data_LogRepository.Insert(tbl_Data_Log);
            _unitOfWork_Ex.Commit();
        }
    }
}
