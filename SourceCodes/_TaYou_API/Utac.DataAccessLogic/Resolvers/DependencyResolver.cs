using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utac.DataAccessLogic.UnitOfWorks;
using Utac.DataAccessLogic.UnitOfWorks.Interfaces;
using Utac.Resolver.Interfaces;
using System.ComponentModel.Composition;

namespace Utac.DataAccessLogic.Resolvers
{
    [Export(typeof(IComponent))]
    public class DependencyResolver : IComponent
    {
        public void SetUp(IRegisterComponent registerComponent)
        {
            registerComponent.RegisterType<IUnitOfWork, UnitOfWork>();
        }
    }
}
