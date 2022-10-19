using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Utac.DataAccessLogic.Models;
using Utac.DataAccessLogic.Repositories;
using Utac.DataAccessLogic.UnitOfWorks.Interfaces;
using System.Configuration;

namespace Utac.DataAccessLogic.UnitOfWorks
{
    /// <summary>
    /// Unit of Work class responsible for DB transactions
    /// </summary>
    //public class UnitOfWork : IDisposable

    public class UnitOfWork : IUnitOfWork
    {
        #region Private member variables
        private readonly TaYou_dbEntities _context;
        #endregion

        #region Table
        private GenericRepository<TBL_Data_Log> _TBL_Data_Log;
        private GenericRepository<Tbl_Users> _Tbl_Users;
        private GenericRepository<Tbl_UserTransaction> _Tbl_UserTransaction;
        private GenericRepository<Tbl_Token> _Tbl_Token;
        private GenericRepository<Tbl_Token_Operation> _Tbl_Token_Operation;


        #endregion

        #region View
        private GenericRepository<View_Tbl_UserTransaction> _View_Tbl_UserTransaction;

        #endregion

        #region Extension
        //private CabinetExtentionRepository _cabinetExtentionRepository;

        #endregion

        public UnitOfWork()
        {
            _context = new TaYou_dbEntities();
        }

        #region Public Repository Creation properties...

        /// <summary>
        /// Get/Set Property for transaction repository.
        /// </summary>
        public GenericRepository<TBL_Data_Log> TBL_Data_LogRepository
        {
            get
            {
                if (this._TBL_Data_Log == null)
                    this._TBL_Data_Log = new GenericRepository<TBL_Data_Log>(_context);
                return _TBL_Data_Log;
            }
        }
        public GenericRepository<Tbl_Users> Tbl_UsersRepository
        {
            get
            {
                if (this._Tbl_Users == null)
                    this._Tbl_Users = new GenericRepository<Tbl_Users>(_context);
                return _Tbl_Users;
            }
        }
        public GenericRepository<Tbl_UserTransaction> Tbl_UserTransactionRepository
        {
            get
            {
                if (this._Tbl_UserTransaction == null)
                    this._Tbl_UserTransaction = new GenericRepository<Tbl_UserTransaction>(_context);
                return _Tbl_UserTransaction;
            }
        }

        public GenericRepository<Tbl_Token> Tbl_TokenRepository
        {
            get
            {
                if (this._Tbl_Token == null)
                    this._Tbl_Token = new GenericRepository<Tbl_Token>(_context);
                return _Tbl_Token;
            }
        }

        public GenericRepository<Tbl_Token_Operation> Tbl_Token_OperationRepository
        {
            get
            {
                if (this._Tbl_Token_Operation == null)
                    this._Tbl_Token_Operation = new GenericRepository<Tbl_Token_Operation>(_context);
                return _Tbl_Token_Operation;
            }
        }



        #endregion

        #region "View_Repo"
        public GenericRepository<View_Tbl_UserTransaction> View_Tbl_UserTransactionRepository
        {
            get
            {
                if (this._View_Tbl_UserTransaction == null)
                    this._View_Tbl_UserTransaction = new GenericRepository<View_Tbl_UserTransaction>(_context);
                return _View_Tbl_UserTransaction;
            }
        }
        
        #endregion
        #region "Extension"
        //public CabinetExtentionRepository CabinetExtentionRepository
        //{
        //    get
        //    {
        //        if (this._cabinetExtentionRepository == null)
        //            this._cabinetExtentionRepository = new CabinetExtentionRepository(_context);
        //        return _cabinetExtentionRepository;
        //    }
        //}


        #endregion "Extension"

        #region Public member methods...
        /// <summary>
        /// Save method.
        /// </summary>
        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {

                var outputLines = new List<string>();
                foreach (var eve in e.EntityValidationErrors)
                {
                    outputLines.Add(string.Format(
                        "{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:", DateTime.Now,
                        eve.Entry.Entity.GetType().Name, eve.Entry.State));
                    foreach (var ve in eve.ValidationErrors)
                    {
                        outputLines.Add(string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage));
                    }
                }

                foreach (var item in outputLines)
                {
                    Console.WriteLine(item);
                }

                //System.IO.File.AppendAllLines(@"C:\errors.txt", outputLines);

                throw e;
            }

        }
        public void Commit()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                //using (var db = new MMT_BackOfficeEntities())
                //{
                //    //TblSystemLog_HistoryError newError = new TblSystemLog_HistoryError();
                //    //newError.Guid = Guid.NewGuid();
                //    //newError.FunctionName = ex.TargetSite.Name;
                //    //newError.ErrorDescription = ex.Message;
                //    //newError.InnerError = ex.InnerException == null ? ex.ToString() : ex.InnerException.ToString();
                //    //newError.DatetimeCreated = DateTime.Now;
                //    //newError.UniversalDatetimeCreated = DateTime.UtcNow;
                //    //db.TblSystemLog_HistoryError.Add(newError);
                //    //db.SaveChanges();
                //}

                throw ex;
            }
        }

        #endregion

        #region Implementing IDiosposable...

        #region private dispose variable declaration...
        private bool disposed = false;
        #endregion

        /// <summary>
        /// Protected Virtual Dispose method
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Debug.WriteLine("UnitOfWork is being disposed");
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        /// <summary>
        /// Dispose method
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
