using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utac.DataAccessLogic.UnitOfWorks.Interfaces
{
    public interface IUnitOfWork_Prototype
    {
        /// <summary>
        /// Save method.
        /// </summary>
        void Save();
        void Commit();
    }

    public interface IUnitOfWork
    {
        /// <summary>
        /// Save method.
        /// </summary>
        void Save();
        void Commit();
    }
}
