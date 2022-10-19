using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api_Proj.Helpers
{
    public class responseModel
    {
        [Required] public string RESULT_STATUS { get; set; }
        [Required] public dynamic RESULT_MESSAGE { get; set; }
    }

    /// <summary>
    /// Set response status for responseModel
    /// </summary>
    public static class ResponseHelper
    {
        static responseModel response = new responseModel();

        public static responseModel SetPassStatus(Object Msg)
        {
            response.RESULT_STATUS = "PASS";
            response.RESULT_MESSAGE = Msg;

            return response;
        }
        public static responseModel SetFailStatus(Object Msg)
        {
            response.RESULT_STATUS = "FAIL";
            if (Msg is String && Msg.ToString().Contains("\r"))
            {
                response.RESULT_MESSAGE = Msg.ToString().Substring(0, Msg.ToString().IndexOf("\r"));
            } 
            else
            {
                response.RESULT_MESSAGE = Msg;
            }

            return response;
        }

    }
}
