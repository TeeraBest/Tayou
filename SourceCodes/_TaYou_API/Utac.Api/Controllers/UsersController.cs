using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Utac.BusinessLogic.Models;
using Utac.BusinessLogic.Models.UsersModels;
using Utac.BusinessLogic.Services;
using Utac.DataAccessLogic.Models;

namespace Utac.Api.Controllers
{
    /// <summary>
    /// Cabinet Controller
    /// </summary>
    [RoutePrefix("api/v1/UsersController")]
    public class UsersController : ApiControllerBase
    {
        private readonly IUsersServices _usersServices;
        /// <summary>
        /// Cabinet Method
        /// </summary>
        public UsersController(IUsersServices usersServices) {
            _usersServices = usersServices;
        }

        /// <summary>
        /// Get GetStatusApp Method
        /// GetStatusApp check Version, To force download New Version or Etc
        /// </summary>
        [HttpPost]
        [Route("GetStatusApp")]
        public HttpResponseMessage GetStatusApp(StatusAppModel usersModel)
        {
            var retValue = _usersServices.GetStatusApp(usersModel);

            return Request.CreateResponse(HttpStatusCode.OK, retValue);
        }


        /// <summary>
        /// RegisterUser Method
        /// Register from backOfficeOnly
        /// Password must be has MD5 before passing only
        /// </summary>
        [HttpPost]
        [Route("RegisterUser")]
        public HttpResponseMessage RegisterUser(Tbl_Users Data)
        {
            var retValue = _usersServices.RegisterUser(Data);

            return Request.CreateResponse(HttpStatusCode.OK, retValue);
        }

        /// <summary>
        /// UpdateUserProfile Method
        /// UpdateUserProfile Passing only User_Guid to be Key. This method won't update password.
        /// </summary>
        [HttpPost]
        [Route("UpdateUserProfile")]
        public HttpResponseMessage UpdateUserProfile(Tbl_Users Data)
        {
            var retValue = _usersServices.UpdateUserProfile(Data);

            return Request.CreateResponse(HttpStatusCode.OK, retValue);
        }

        /// <summary>
        /// UpdatUserPassword Method
        /// UpdatUserPassword Passing only User_Guid to be Key and also passing PasswordMD5.
        /// </summary>
        [HttpPost]
        [Route("UpdatUserPassword")]
        public HttpResponseMessage UpdatUserPassword(Tbl_Users Data,string passwordMD5,string Token)
        {
            RetInsertOrUpdateDataModel retData = new RetInsertOrUpdateDataModel();
            HttpStatusCode httpStatus = HttpStatusCode.OK;
            var validateToken = _usersServices.ValidateToken(Data, Token);
            if (validateToken.FlagSaveSuccess)
            {
                retData = _usersServices.UpdateUserProfile(Data, passwordMD5);
            }
            else 
            {
                httpStatus = HttpStatusCode.BadRequest;
                retData = validateToken;
            }

            return Request.CreateResponse(httpStatus, retData);
        }

        /// <summary>
        /// GenerateToken Method
        /// </summary>
        [HttpPost]
        [Route("GenerateToken")]
        public HttpResponseMessage GenerateToken(Tbl_Users user,string Operation)
        {
            var retValue = _usersServices.GenerateToken(user, Operation);

            return Request.CreateResponse(HttpStatusCode.OK, retValue);
        }

        /// <summary>
        /// LoginByEmail Method
        /// </summary>
        [HttpPost]
        [Route("LoginByEmail")]
        public HttpResponseMessage LoginByEmail(Tbl_Users user)
        {
            var retValue = _usersServices.LoginByEmail(user);

            return Request.CreateResponse(HttpStatusCode.OK,retValue);
        }

    }
}