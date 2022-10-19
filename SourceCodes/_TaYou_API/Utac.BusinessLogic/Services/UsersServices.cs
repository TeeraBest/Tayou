using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Utac.BusinessLogic.Helpers;
using Utac.BusinessLogic.Models;
using Utac.BusinessLogic.Models.UsersModels;
using Utac.DataAccessLogic.Models;
using Utac.DataAccessLogic.UnitOfWorks;

namespace Utac.BusinessLogic.Services
{
    public interface IUsersServices
    {
        StatusAppModel GetStatusApp(StatusAppModel statusAppModel);
        RetInsertOrUpdateDataModel RegisterUser(Tbl_Users tbl_User);
        UsersModel LoginByEmail(Tbl_Users tbl_User);
        RetInsertOrUpdateDataModel UpdateUserProfile(Tbl_Users tbl_User, string newHashPassword = null);
        string GenerateToken(Tbl_Users tbl_User, string opretaionStr);
        RetInsertOrUpdateDataModel ValidateToken(Tbl_Users tbl_User, string token);
    }
    public class UsersServices : IUsersServices
    {
        private readonly UnitOfWork _unitOfWork;
        public UsersServices(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public StatusAppModel GetStatusApp(StatusAppModel statusAppModel)
        {
            try
            {
                statusAppModel.isUpdated = false;
            }
            catch (Exception ex)
            {

                _unitOfWork.Dispose();
                string msgEx = "Message : " + ex.Message + Environment.NewLine
                                          + "Source : " + ex.Source + Environment.NewLine
                                          + "StackTrace : " + ex.StackTrace + Environment.NewLine
                                          + "TargetSite : " + ex.TargetSite + Environment.NewLine
                                          + "InnerException : " + ex.InnerException + Environment.NewLine;

                new _LogDataServices().CreateLog($"{this.GetType().Name}_{MethodBase.GetCurrentMethod().Name}", $"{MethodBase.GetCurrentMethod().Name}_Error", msgEx);
            }
            return statusAppModel;
        }

        public bool InsertUserTransaction(Tbl_Users user, string type, string DataJson)
        {
            bool retData = false;
            try
            {
                if (_unitOfWork.Tbl_UsersRepository.FindByGuid(user.Guid) != null)
                {
                    Tbl_UserTransaction tbl_UserTransaction = new Tbl_UserTransaction()
                    {
                        Guid = Guid.NewGuid(),
                        User_Guid = user.Guid,
                        Create_Date = DateTime.Now,
                        Type = type,
                        DataJson = DataJson,
                    };
                    _unitOfWork.Tbl_UserTransactionRepository.Insert(tbl_UserTransaction);
                    _unitOfWork.Commit();
                    retData = true;
                }
                else
                {
                    string dataLog = "TblUser : " + JsonConvert.SerializeObject(user) + Environment.NewLine
                                              + "type : " + type + Environment.NewLine
                                              + "DataJson : " + DataJson + Environment.NewLine;

                    new _LogDataServices().CreateLog($"{this.GetType().Name}_{MethodBase.GetCurrentMethod().Name}", UserConstant.GLITCH, dataLog);
                }



            }
            catch (Exception ex)
            {
                retData = false;
                _unitOfWork.Dispose();
                string msgEx = "Message : " + ex.Message + Environment.NewLine
                                          + "Source : " + ex.Source + Environment.NewLine
                                          + "StackTrace : " + ex.StackTrace + Environment.NewLine
                                          + "TargetSite : " + ex.TargetSite + Environment.NewLine
                                          + "InnerException : " + ex.InnerException + Environment.NewLine;

                new _LogDataServices().CreateLog($"{this.GetType().Name}_{MethodBase.GetCurrentMethod().Name}", $"{MethodBase.GetCurrentMethod().Name}_Error", msgEx);
            }
            return retData;
        }
        public RetInsertOrUpdateDataModel RegisterUser(Tbl_Users tbl_User)
        {
            RetInsertOrUpdateDataModel retInsData = new RetInsertOrUpdateDataModel();
            try
            {
                retInsData.FlagSaveSuccess = true;
                var validateEmail = _unitOfWork.Tbl_UsersRepository.FindAllWithExpression(f => f.Email == tbl_User.Email);
                var validatePhone = _unitOfWork.Tbl_UsersRepository.FindAllWithExpression(f => f.PhoneNo == tbl_User.PhoneNo);
                if (validateEmail.Any())
                {
                    retInsData.FlagSaveSuccess = false;
                    retInsData.ErrorMsg = "Email is already existed";
                }

                if (validatePhone.Any())
                {
                    retInsData.FlagSaveSuccess = false;
                    retInsData.ErrorMsg = "PhoneNo is already existed";
                }

                if (retInsData.FlagSaveSuccess)
                {
                    tbl_User.Guid = Guid.NewGuid();
                    tbl_User.Create_Date = DateTime.Now;

                    _unitOfWork.Tbl_UsersRepository.InsertOrUpdate(tbl_User);
                    _unitOfWork.Commit();
                }

            }
            catch (Exception ex)
            {

                _unitOfWork.Dispose();
                string msgEx = "Message : " + ex.Message + Environment.NewLine
                                          + "Source : " + ex.Source + Environment.NewLine
                                          + "StackTrace : " + ex.StackTrace + Environment.NewLine
                                          + "TargetSite : " + ex.TargetSite + Environment.NewLine
                                          + "InnerException : " + ex.InnerException + Environment.NewLine;

                new _LogDataServices().CreateLog($"{this.GetType().Name}_{MethodBase.GetCurrentMethod().Name}", $"{MethodBase.GetCurrentMethod().Name}_Error", msgEx);

                retInsData.FlagSaveSuccess = false;
                retInsData.exception = ex;
                retInsData.ErrorMsg = ex.Message.ToString();
            }
            return retInsData;
        }

        public UsersModel LoginByEmail(Tbl_Users tbl_User)
        {
            UsersModel userModel = new UsersModel();
            try
            {
                _LogDataServices loginService = new _LogDataServices();

                //string passwordMD5 = CryptoHelper.GetHashMD5(tbl_User.Password);
                string passwordMD5 = tbl_User.Password;
                var validateLogin = _unitOfWork.Tbl_UsersRepository.FindAllWithExpression(f => f.Email == tbl_User.Email && f.Password == passwordMD5);
                if (validateLogin.Any())
                {
                    userModel.FlagSaveSuccess = true;

                    userModel.tblUser = validateLogin.FirstOrDefault();

                    var userTransaction = _unitOfWork.View_Tbl_UserTransactionRepository.FindWithExpression(f => f.User_Guid == userModel.tblUser.Guid && (f.Type == UserConstant.LOGIN || f.Type == UserConstant.CHANGE_PASSWORD));
                    if (userTransaction == null)
                    {
                        //User never login ,Do not insert the transaction. Wait for user to change password successfully
                        userModel.isFirstLogin = true;
                    }
                    else
                    {
                        InsertUserTransaction(userModel.tblUser, "Login", "");
                    }


                }

            }
            catch (Exception ex)
            {

                _unitOfWork.Dispose();
                string msgEx = "Message : " + ex.Message + Environment.NewLine
                                          + "Source : " + ex.Source + Environment.NewLine
                                          + "StackTrace : " + ex.StackTrace + Environment.NewLine
                                          + "TargetSite : " + ex.TargetSite + Environment.NewLine
                                          + "InnerException : " + ex.InnerException + Environment.NewLine;

                new _LogDataServices().CreateLog($"{this.GetType().Name}_{MethodBase.GetCurrentMethod().Name}", $"{MethodBase.GetCurrentMethod().Name}_Error", msgEx);

                userModel.FlagSaveSuccess = false;
                userModel.exception = ex;
                userModel.ErrorMsg = ex.Message.ToString();
            }
            return userModel;
        }
        public RetInsertOrUpdateDataModel ValidateToken(Tbl_Users tbl_User, string token)
        {
            RetInsertOrUpdateDataModel retInsData = new RetInsertOrUpdateDataModel();

            try
            {
                string Type = UserConstant.VALIDATE_TOKEN;
                string DataJson = "";
                var tokenData = _unitOfWork.Tbl_TokenRepository.FindByGuid(new Guid(token));
                DateTime dateLimit = DateTime.Now.AddMinutes(-30);
                if (tokenData != null && tokenData.Create_Date <= dateLimit && tokenData.User_Guid == tbl_User.Guid)
                {
                    retInsData.FlagSaveSuccess = true;

                }
                else
                {
                    retInsData.FlagSaveSuccess = false;
                    retInsData.ErrorMsg = "Token  is expired";
                    Type = UserConstant.GLITCH;
                    DataJson = $"{{Data:\"{JsonConvert.SerializeObject(tbl_User)}\",Msg:\"GLITCH\"}}";
                }

                InsertUserTransaction(tbl_User, Type, DataJson);


            }
            catch (Exception ex)
            {

                _unitOfWork.Dispose();
                string msgEx = "Message : " + ex.Message + Environment.NewLine
                                          + "Source : " + ex.Source + Environment.NewLine
                                          + "StackTrace : " + ex.StackTrace + Environment.NewLine
                                          + "TargetSite : " + ex.TargetSite + Environment.NewLine
                                          + "InnerException : " + ex.InnerException + Environment.NewLine;

                new _LogDataServices().CreateLog($"{this.GetType().Name}_{MethodBase.GetCurrentMethod().Name}", $"{MethodBase.GetCurrentMethod().Name}_Error", msgEx);

                retInsData.FlagSaveSuccess = false;
                retInsData.exception = ex;
                retInsData.ErrorMsg = ex.Message.ToString();
            }
            return retInsData;
        }
        public RetInsertOrUpdateDataModel UpdateUserProfile(Tbl_Users tbl_User, string newHashPassword = null)
        {
            RetInsertOrUpdateDataModel retInsData = new RetInsertOrUpdateDataModel();
           
            try
            {
                string Type = UserConstant.CHANGE_PASSWORD;
                string DataJson = "";
                var user = _unitOfWork.Tbl_UsersRepository.FindByGuid(tbl_User);
                if (user != null)
                {
                    //there is user in system
                    Type = UserConstant.CHANGE_PASSWORD;
                    if (user.Password == tbl_User.Password)
                    {
                        if (string.IsNullOrEmpty(newHashPassword))
                        {
                            //update User Profile
                            Type = UserConstant.UPDATE_USER_PROFILE;
                        }
                        else
                        {
                            Type = UserConstant.CHANGE_PASSWORD;
                            tbl_User.Password = newHashPassword;
                        }
                        tbl_User.Update_Date = DateTime.Now;
                        _unitOfWork.Tbl_UsersRepository.Update(tbl_User);
                    }
                    else
                    {
                        //wrong password
                        DataJson = $"{{Data:\"{newHashPassword}\",Msg:\"Wrong Password\"}}";
                    }
                }
                else 
                {
                    Type = UserConstant.GLITCH;
                    DataJson = $"{{Data:\"{JsonConvert.SerializeObject(tbl_User)}\",Msg:\"GLITCH\"}}";
                }

                InsertUserTransaction(tbl_User, Type, DataJson);


            }
            catch (Exception ex)
            {

                _unitOfWork.Dispose();
                string msgEx = "Message : " + ex.Message + Environment.NewLine
                                          + "Source : " + ex.Source + Environment.NewLine
                                          + "StackTrace : " + ex.StackTrace + Environment.NewLine
                                          + "TargetSite : " + ex.TargetSite + Environment.NewLine
                                          + "InnerException : " + ex.InnerException + Environment.NewLine;

                new _LogDataServices().CreateLog($"{this.GetType().Name}_{MethodBase.GetCurrentMethod().Name}", $"{MethodBase.GetCurrentMethod().Name}_Error", msgEx);

                retInsData.FlagSaveSuccess = false;
                retInsData.exception = ex;
                retInsData.ErrorMsg = ex.Message.ToString();
            }
            return retInsData;
        }

        public string GenerateToken(Tbl_Users tbl_User,string opretaionStr)
        {
            string token = "";

            try
            {
                string Type = UserConstant.GENERATE_TOKEN;
                string DataJson = "";
                var user = _unitOfWork.Tbl_UsersRepository.FindByGuid(tbl_User);
                if (user != null)
                {
                    var operationData = _unitOfWork.Tbl_Token_OperationRepository.FindWithExpression(f => f.Operation == opretaionStr);
                    if (operationData != null)
                    {
                        Tbl_Token tbl_Token = new Tbl_Token()
                        {
                            Guid = Guid.NewGuid(),
                            Operation = operationData.Guid,
                            User_Guid = user.Guid,
                            Create_Date = DateTime.Now
                        };
                        _unitOfWork.Tbl_TokenRepository.Insert(tbl_Token);
                        _unitOfWork.Commit();
                        token = tbl_Token.Guid.ToString();
                    }
                    else {
                        Type = UserConstant.GLITCH;
                        DataJson = $"{{Data:\"{JsonConvert.SerializeObject(tbl_User)}\",Msg:\"No Operation _ {opretaionStr}\"}}";
                    }

                }
                else
                {
                    Type = UserConstant.GLITCH;
                    DataJson = $"{{Data:\"{JsonConvert.SerializeObject(tbl_User)}\",Msg:\"GLITCH\"}}";
                }

                InsertUserTransaction(tbl_User, Type, DataJson);


            }
            catch (Exception ex)
            {

                _unitOfWork.Dispose();
                string msgEx = "Message : " + ex.Message + Environment.NewLine
                                          + "Source : " + ex.Source + Environment.NewLine
                                          + "StackTrace : " + ex.StackTrace + Environment.NewLine
                                          + "TargetSite : " + ex.TargetSite + Environment.NewLine
                                          + "InnerException : " + ex.InnerException + Environment.NewLine;

                new _LogDataServices().CreateLog($"{this.GetType().Name}_{MethodBase.GetCurrentMethod().Name}", $"{MethodBase.GetCurrentMethod().Name}_Error", msgEx);
            }
            return token;
        }


    }
}
