using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utac.BusinessLogic.Services;
using System.ComponentModel.Composition;
using Utac.Resolver.Interfaces;
using AutoMapper;
using Utac.DataAccessLogic.Models;
using Utac.BusinessLogic.Models;

namespace Utac.BusinessLogic.Resolvers
{
    [Export(typeof(Resolver.Interfaces.IComponent))]
    public class DependencyResolver : Resolver.Interfaces.IComponent
    {
        public void SetUp(IRegisterComponent registerComponent)
        {
            // Data Service
            //registerComponent.RegisterType<ITransferFileService, TransferFileService>();
            //registerComponent.RegisterType<IFTPServices, FTPServices>();
            registerComponent.RegisterType<IUsersServices, UsersServices>();

            //Extension


            // Utility Service

            InitializeEntity();

        }

        private void InitializeEntity()
        {
            Mapper.Initialize(cfg =>
            {
                // Table  
                //cfg.CreateMap<Tbl_OrderDetail, OrderDetailModel>();
                


                // Model


                // Stored Procedure Extension

            });
        }

    }
}
