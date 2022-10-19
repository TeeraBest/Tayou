using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Utac.BusinessLogic.Models;
using Utac.BusinessLogic.Services.Interfaces;

namespace Utac.Api.Controllers
{
    /// <summary>
    /// KeepStripTransaction Controller
    /// </summary>
    [RoutePrefix("api/v1/KeepStripTransactionController")]
    public class KeepStripTransactionController : ApiControllerBase
    {
        private readonly ICabinetKeepTransactionServices _cabinetKeepTransactionServices;
        /// <summary>
        /// KeepStripTransactionController
        /// </summary>
        public KeepStripTransactionController(ICabinetKeepTransactionServices cabinetKeepTransactionServices) {
            _cabinetKeepTransactionServices = cabinetKeepTransactionServices;
        }

        /// <summary>
        /// InsertUpdateKeepStripTransaction Method
        /// </summary>
        [HttpPost]
        [Route("InsertUpdateKeepStripTransaction")]
        public HttpResponseMessage InsertUpdateKeepStripTransaction(KeepStripTransactionModel keepStripTransaction)
        {
            var retValue = _cabinetKeepTransactionServices.SaveUpdateKeepStripTransaction(keepStripTransaction);
            
            return Request.CreateResponse(HttpStatusCode.OK, retValue);

        }

        /// <summary>
        /// SelectKeepStripTransaction Method
        /// </summary>
        [HttpPost]
        [Route("SelectKeepStripTransaction")]
        public HttpResponseMessage SelectKeepStripTransaction(CabinetGetModel cabinetGetData)
        {
            var retValue = _cabinetKeepTransactionServices.SelectKeepStripTransaction(cabinetGetData);

            return Request.CreateResponse(HttpStatusCode.OK, retValue);

        }
    }
}