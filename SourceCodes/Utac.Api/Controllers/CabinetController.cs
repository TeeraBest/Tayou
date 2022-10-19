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
    /// Cabinet Controller
    /// </summary>
    [RoutePrefix("api/v1/CabinetController")]
    public class CabinetController : ApiControllerBase
    {
        private readonly ICabinetServices _cabinetServices;
        /// <summary>
        /// Cabinet Method
        /// </summary>
        public CabinetController(ICabinetServices cabinetServices) {
            _cabinetServices = cabinetServices;
        }

        /// <summary>
        /// Get Cabinet Display Method
        /// Select Cabinet_Master join with Cabinet_Layer_Master
        /// </summary>
        [HttpGet]
        [Route("GetCabinetDisplay")]
        public HttpResponseMessage GetCabinetDisplay()
        {
            var retValue = _cabinetServices.SelectCabinetDisplayList();

            return Request.CreateResponse(HttpStatusCode.OK, retValue);
        }
        /// <summary>
        /// GetLayerListByCabinetName Method
        /// </summary>
        [HttpPost]
        [Route("GetLayerListByCabinetName")]
        public HttpResponseMessage GetLayerListByCabinetName(CabinetGetModel cabinetGetData)
        {
            var retValue = _cabinetServices.GetLayerListByCabinetName(cabinetGetData);

            return Request.CreateResponse(HttpStatusCode.OK, retValue);
        }
        /// <summary>
        /// GetCabinetSetup Method
        /// </summary>
        [HttpPost]
        [Route("GetCabinetSetup")]
        public HttpResponseMessage GetCabinetSetup(CabinetGetModel cabinetGetData)
        {
            var retValue = _cabinetServices.GetCabinetSetup(cabinetGetData);

            return Request.CreateResponse(HttpStatusCode.OK, retValue);
        }
        /// <summary>
        /// GetCabinetSetupDetail Method
        /// </summary>
        [HttpPost]
        [Route("GetCabinetSetupDetail")]
        public HttpResponseMessage GetCabinetSetupDetail(CabinetGetModel cabinetGetData)
        {
            var retValue = _cabinetServices.GetCabinetSetupDetail(cabinetGetData);

            return Request.CreateResponse(HttpStatusCode.OK, retValue);
        }
        
        /// <summary>
        /// GetOperationList Method
        /// </summary>
        [HttpPost]
        [Route("GetOperationList")]
        public HttpResponseMessage GetOperationList()
        {
            var retValue = _cabinetServices.GetOperationList();

            return Request.CreateResponse(HttpStatusCode.OK, retValue);
        }
        /// <summary>
        /// GetCabinetTypeList Method
        /// </summary>
        [HttpPost]
        [Route("GetCabinetTypeList")]
        public HttpResponseMessage GetCabinetTypeList()
        {
            var retValue = _cabinetServices.GetCabinetTypeList();

            return Request.CreateResponse(HttpStatusCode.OK, retValue);
        }
        
        /// <summary>
        /// GetCabinetList Method
        /// </summary>
        [HttpPost]
        [Route("GetCabinetList")]
        public HttpResponseMessage GetCabinetList()
        {
            var retValue = _cabinetServices.GetCabinetList();

            return Request.CreateResponse(HttpStatusCode.OK, retValue);
        }

        /// <summary>
        /// SaveCreateCabinet Method
        /// </summary>
        [HttpPost]
        [Route("SaveCreateCabinet")]
        public HttpResponseMessage SaveCreateCabinet(CabinetCreateModel cabinetCreatedata)
        {
            var retValue = _cabinetServices.SaveCreateCabinet(cabinetCreatedata);

            return Request.CreateResponse(HttpStatusCode.OK, retValue);
        }
        
    }
}