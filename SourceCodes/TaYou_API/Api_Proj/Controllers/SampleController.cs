using Api_Proj.Helpers;
using ExecuteDatabase;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services_Proj.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Proj.Controllers
{
    /// <summary>
    /// Webservice for SampleController
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class SampleController : ControllerB
    {
        private readonly ISampleService _Services;
        private OutputOnDbProperty serviceResult = new OutputOnDbProperty();

        public SampleController(ISampleService TestServices)
        {
            _Services = TestServices;
        }

        /// <summary>
        /// CheckConnection Method
        /// </summary>
        [HttpGet]
        [Route("CheckConnection")]
        public IActionResult CheckConnection()
        {

            serviceResult = _Services.CheckDBConnection();

            if (!serviceResult.StatusOnDb)
            {
                return BadRequest(ResponseHelper.SetFailStatus(serviceResult.MessageOnDb.Substring(0, serviceResult.MessageOnDb.IndexOf("\\"))));
            }

            return Ok(ResponseHelper.SetPassStatus("Connection Success"));

        }

        /// <summary>
        /// GetData Method
        /// </summary>
        [HttpGet(nameof(GetData))]
        public async Task<IActionResult> GetData()
        {
            var data = await _Services.GetData();

            return Ok(data);
        }

    }
}
