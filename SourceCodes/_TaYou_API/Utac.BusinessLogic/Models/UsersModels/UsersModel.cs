using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utac.DataAccessLogic.Models;

namespace Utac.BusinessLogic.Models.UsersModels
{

    public static class UserConstant
    {
        public static string LOGIN { get { return "LOGIN"; } }
        public static string CREATE { get { return "CREATE"; } }
        public static string CHANGE_PASSWORD { get { return "CHANGE_PASSWORD"; } }
        public static string GENERATE_TOKEN { get { return "GENERATE_TOKEN"; } }
        public static string VALIDATE_TOKEN { get { return "VALIDATE_TOKEN"; } }
        public static string GLITCH { get { return "GLITCH"; } }
        public static string UPDATE_USER_PROFILE { get { return "UPDATE_USER_PROFILE"; } }
        public static string UPDATE_POINT { get { return "UPDATE_POINT"; } }

    }
    public class UsersModel : RetInsertOrUpdateDataModel
    {
        public Tbl_Users tblUser { get;  set; }
        public bool isFirstLogin { get; set; } = false;
    }
    public class StatusAppModel
    {
        public string AppVersion { get; set; }
        public string System { get; set; }
        public Guid? UserGuid { get; set; }
        public bool? isUpdated { get; set; }
    }
}
