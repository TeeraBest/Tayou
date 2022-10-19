using System;
using System.Collections.Generic;
using System.Data;
//using Oracle.ManagedDataAccess.Client;
using Dapper;
using System.Threading.Tasks;
using System.Linq;
using System.Data.SqlClient;

namespace ExecuteDatabase
{
    public class TransMssqlModels
    {
        private SqlConnection conTrans;
        private SqlCommand userCommand = new SqlCommand();
        private SqlTransaction trans;

        public string strConnection = "";
        private OutputOnDbProperty dataOutPut;

        protected TransMssqlModels()
        {
            //  strConnection = ConfigurationManager.ConnectionStrings["ConnectionStrSqlServer"].ConnectionString;
        }

        protected OutputOnDbProperty TransConnection()
        {
        
            try
            {
                conTrans = new SqlConnection(strConnection);
                conTrans.Open();
                trans = conTrans.BeginTransaction(IsolationLevel.ReadCommitted);     //*** Start  
                userCommand.Connection = conTrans;
                userCommand.Transaction = trans;  //*** Command & Transaction ***// 


                dataOutPut = new OutputOnDbProperty
                {
                    StatusOnDb = true,
                    MessageOnDb = "Connect Database Success",
                    ClassOnDb = "Class Name: TransOracleModels",
                    MethodOnDb = "Method Name: TransConnection",
                    ResultOnDb = null
                };
            }
            catch (Exception er)
            {
                dataOutPut = new OutputOnDbProperty
                {
                    StatusOnDb = false,
                    ClassOnDb = "Class Name: TransOracleModels",
                    MethodOnDb = "Method Name: TransConnection",
                    MessageOnDb = "Connect Database Error ==> " + er.ToString(),
                    ResultOnDb = null
                };
            }

            return dataOutPut;
        }
        protected async Task<OutputOnDbProperty> TransConnectionAsync()
        {

            try
            {
                conTrans = new SqlConnection(strConnection);
                conTrans.Open();
                trans = conTrans.BeginTransaction(IsolationLevel.ReadCommitted);     //*** Start  
                userCommand.Connection = conTrans;
                userCommand.Transaction = trans;  //*** Command & Transaction ***// 


                 dataOutPut = new  OutputOnDbProperty
                {
                    StatusOnDb = true,
                    MessageOnDb = "Connect Database Success",
                    ClassOnDb = "Class Name: TransOracleModels",
                    MethodOnDb = "Method Name: TransConnection",
                    ResultOnDb = null
                };
            }
            catch (Exception er)
            {
                dataOutPut = new OutputOnDbProperty
                {
                    StatusOnDb = false,
                    ClassOnDb = "Class Name: TransOracleModels",
                    MethodOnDb = "Method Name: TransConnection",
                    MessageOnDb = "Connect Database Error ==> " + er.ToString(),
                    ResultOnDb = null
                };
            }

            return dataOutPut;
        }

        protected OutputOnDbProperty TransSelectCommand(string sql)
        {
            SqlConnection connecter = new SqlConnection(strConnection);
            DataTable tableResult = new DataTable();

            try
            {
                connecter.Open();

                var dataList = connecter.Query(sql);

                connecter.Close();
                connecter.Dispose();

                dataOutPut = new OutputOnDbProperty
                {
                    StatusOnDb = true,
                    ClassOnDb = "Class Name: TransOracleModels",
                    MethodOnDb = "Method Name: TransSelectCommand",
                    MessageOnDb = "",
                    ResultOnDb = dataList
                };

            }
            catch (Exception er)
            {
                dataOutPut = new OutputOnDbProperty
                {
                    StatusOnDb = false,
                    ClassOnDb = "Class Name: TransOracleModels",
                    MethodOnDb = "Method Name: TransSelectCommand",
                    MessageOnDb = "Select SQL Error ==> " + er.ToString(),
                    ResultOnDb = null
                };
            }

            return dataOutPut;
        }
        protected async Task<IEnumerable<T>> TransSelectCommandAsync<T>(string sql)
        {
            SqlConnection connecter = new SqlConnection(strConnection);
            DataTable tableResult = new DataTable();
            IEnumerable<T> dataList = null;
            try
            {
                connecter.Open();


                dataList = await connecter.QueryAsync<T>(sql);

                connecter.Close();
                connecter.Dispose();


            }
            catch (Exception er)
            {

            }
            return dataList;
        }
        protected async Task<OutputOnDbProperty> TransSelectCommandAsync(string sql)
        {
            SqlConnection connecter = new SqlConnection(strConnection);
            DataTable tableResult = new DataTable();

            try
            {
                connecter.Open();

                //SqlDataAdapter userDataAdaptor = new SqlDataAdapter(sql, connecter);
                //userDataAdaptor.Fill(tableResult);

                var dataList = await connecter.QueryAsync(sql);

                //var json = JsonConvert.SerializeObject(dataList);
                //tableResult = (DataTable)JsonConvert.DeserializeObject(json, (typeof(DataTable)));

                //tableResult = DBHelper.ToDataTable<dynamic>(dataList);

                connecter.Close();
                connecter.Dispose();

                dataOutPut = new OutputOnDbProperty
                {
                    StatusOnDb = true,
                    ClassOnDb = "Class Name: TransOracleModels",
                    MethodOnDb = "Method Name: TransSelectCommand",
                    MessageOnDb = "",
                    ResultOnDb = dataList
                };

            }
            catch (Exception er)
            {
                dataOutPut = new OutputOnDbProperty
                {
                    StatusOnDb = false,
                    ClassOnDb = "Class Name: TransOracleModels",
                    MethodOnDb = "Method Name: TransSelectCommand",
                    MessageOnDb = "Select SQL Error ==> " + er.ToString(),
                    ResultOnDb = null
                };
            }

            return dataOutPut;
        }

        protected async Task<OutputOnDbProperty> TransExecuteCommandAsync(string sql)
        {
            SqlConnection connecter = new SqlConnection(strConnection);
            try
            {
                connecter.Open();
                //userCommand.CommandText = sql;
                //userCommand.CommandType = CommandType.Text;
                //userCommand.ExecuteNonQuery();

                var rowEffect = await connecter.ExecuteAsync(sql);

                connecter.Close();
                connecter.Dispose();

                dataOutPut = new OutputOnDbProperty
                {
                    StatusOnDb = true,
                    ClassOnDb = "Class Name: TransOracleModels",
                    MethodOnDb = "Method Name: TransExecuteCommand",
                    MessageOnDb = "",
                    ResultOnDb = rowEffect > 0
                };
            }
            catch (Exception er)
            {
                dataOutPut = new OutputOnDbProperty
                {
                    StatusOnDb = false,
                    ClassOnDb = "Class Name: TransOracleModels",
                    MethodOnDb = "Method Name: TransExecuteCommand",
                    MessageOnDb = "Execute SQL Command Error ==> " + er.ToString(),
                    ResultOnDb = null
                };
            }

            return dataOutPut;
        }
        protected async Task<OutputOnDbProperty> TransExecuteCommandAsync<T>(string sql,T model)
        {
            SqlConnection connecter = new SqlConnection(strConnection);
            try
            {
                connecter.Open();
                //userCommand.CommandText = sql;
                //userCommand.CommandType = CommandType.Text;
                //userCommand.ExecuteNonQuery();

                var rowEffect = await connecter.ExecuteAsync(sql,model);

                connecter.Close();
                connecter.Dispose();

                dataOutPut = new OutputOnDbProperty
                {
                    StatusOnDb = true,
                    ClassOnDb = "Class Name: TransOracleModels",
                    MethodOnDb = "Method Name: TransExecuteCommand",
                    MessageOnDb = "",
                    ResultOnDb = rowEffect > 0
                };
            }
            catch (Exception er)
            {
                dataOutPut = new OutputOnDbProperty
                {
                    StatusOnDb = false,
                    ClassOnDb = "Class Name: TransOracleModels",
                    MethodOnDb = "Method Name: TransExecuteCommand",
                    MessageOnDb = "Execute SQL Command Error ==> " + er.ToString(),
                    ResultOnDb = null
                };
            }

            return dataOutPut;
        }
        protected OutputOnDbProperty TransExecuteCommand(string sql)
        {
            try
            {
                userCommand.CommandText = sql;
                userCommand.CommandType = CommandType.Text;
                userCommand.ExecuteNonQuery();

                dataOutPut = new OutputOnDbProperty
                {
                    StatusOnDb = true,
                    ClassOnDb = "Class Name: TransOracleModels",
                    MethodOnDb = "Method Name: TransExecuteCommand",
                    MessageOnDb = "",
                    ResultOnDb = null
                };
            }
            catch (Exception er)
            {
                dataOutPut = new OutputOnDbProperty
                {
                    StatusOnDb = false,
                    ClassOnDb = "Class Name: TransOracleModels",
                    MethodOnDb = "Method Name: TransExecuteCommand",
                    MessageOnDb = "Execute SQL Command Error ==> " + er.ToString(),
                    ResultOnDb = null
                };
            }

            return dataOutPut;
        }

        protected async Task<OutputOnDbProperty<T2>> CallStoreProcetureCommandAsync<T1,T2>(string StoreName, T1 model)
        {
            SqlConnection connecter = new SqlConnection(strConnection);
            OutputOnDbProperty<T2> dataOutPut = new OutputOnDbProperty<T2>();

            try
            {
                connecter.Open();
                //userCommand.CommandText = sql;
                //userCommand.CommandType = CommandType.Text;
                //userCommand.ExecuteNonQuery();
                
                var res = connecter.Query<T2>(StoreName, model,
                            commandType: CommandType.StoredProcedure).ToList();

                connecter.Close();
                connecter.Dispose();

                dataOutPut = new OutputOnDbProperty<T2>
                {
                    StatusOnDb = true,
                    ClassOnDb = "Class Name: TransOracleModels",
                    MethodOnDb = "Method Name: TransExecuteCommand",
                    MessageOnDb = "",
                    ResultOnDb = res
                };
            }
            catch (Exception er)
            {
                dataOutPut = new OutputOnDbProperty<T2>
                {
                    StatusOnDb = false,
                    ClassOnDb = "Class Name: TransOracleModels",
                    MethodOnDb = "Method Name: TransExecuteCommand",
                    MessageOnDb = "Execute SQL Command Error ==> " + er.ToString(),
                    ResultOnDb = null
                };
            }

            return dataOutPut;
        }

        protected void TransCommit()
        {
            trans.Commit();
            conTrans.Close();
            conTrans.Dispose();
        }

        protected void TransRolback()
        {
            trans.Rollback();
            conTrans.Close();
            conTrans.Dispose();
        }

        protected void TransClose()
        {
            if (conTrans != null)
            {
                conTrans.Close();
                conTrans.Dispose();
            }
             
        }

        protected string GetDBName()
        {
            string result = "";
            if (conTrans != null)
            {
                result = conTrans.DataSource;
            }
            return result;
        }

    }
}
