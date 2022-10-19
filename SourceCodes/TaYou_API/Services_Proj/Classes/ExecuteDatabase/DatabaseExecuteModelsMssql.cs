using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;

namespace ExecuteDatabase
{
    public class DatabaseExecuteModelsMssql : TransMssqlModels, IDisposable
    {
        public string sUserPlant = string.Empty;
        //public string strConnection = "";
        OutputOnDbProperty resultData = new OutputOnDbProperty();



        protected OutputOnDbProperty SearchBySqlList(List<string> sqlList)
        {
            try
            {
              

                resultData = base.TransConnection();

                if (resultData.StatusOnDb == true)
                {
                    resultData = base.TransSelectCommand(sqlList[0]);

                    string totalCount = resultData.ResultOnDb.Rows[0]["TOTAL_COUNT"].ToString();

                    resultData = base.TransSelectCommand(sqlList[1]);

                    resultData.TotalCountOnDb = totalCount;
                }
            }
            finally
            {
                base.TransClose();
            }

            return resultData;
        }

        protected OutputOnDbProperty SearchBySql(string sql)
        {
            try
            {

                resultData = base.TransConnection();

                if (resultData.StatusOnDb == true)
                {
                    resultData = base.TransSelectCommand(sql);
                }
            }
            finally
            {
                base.TransClose();
            }

            return resultData;
        }
        protected async Task<OutputOnDbProperty> SearchBySqlAsync(string sql)
        {
            try
            {

                resultData = await base.TransConnectionAsync();

                if (resultData.StatusOnDb == true)
                {
                    resultData = await base.TransSelectCommandAsync(sql);
                }
            }
            finally
            {
                base.TransClose();
            }

            return resultData;
        }

        protected async Task<IEnumerable<T>> SearchBySqlAsync<T>(string sql)
        {
            IEnumerable<T> dataList = null;
            try
            {

                resultData = await base.TransConnectionAsync();

                if (resultData.StatusOnDb == true)
                {
                    dataList= await base.TransSelectCommandAsync<T>(sql);
                }
            }
            finally
            {
                base.TransClose();
            }
            return dataList;

        }

        protected async Task<OutputOnDbProperty> ExecBySqlAsync(string sql)
        {
            try
            {


                resultData = await base.TransConnectionAsync();

                if (resultData.StatusOnDb == true)
                {

                    resultData = await base.TransExecuteCommandAsync(sql);

                    if (resultData.StatusOnDb == true)
                    {
                        //base.TransCommit();
                        resultData.MessageOnDb = "Save Data Success";
                    }
                }
            }
            finally
            {
                base.TransClose();
            }

            return resultData;
        }

        protected async Task<OutputOnDbProperty> ExecBySqlAsync<T>(string sql,T model)
        {
            try
            {


                resultData = await base.TransConnectionAsync();

                if (resultData.StatusOnDb == true)
                {

                    resultData = await base.TransExecuteCommandAsync<T>(sql, model);

                    if (resultData.StatusOnDb == true)
                    {
                        //base.TransCommit();
                        resultData.MessageOnDb = "Save Data Success";
                    }
                }
            }
            catch (Exception ex)
            { 

            }
            finally
            {
                base.TransClose();
            }

            return resultData;
        }

        protected async Task<OutputOnDbProperty<T2>> CallStoreProceture<T1,T2>(string sql, T1 model)
        {
            OutputOnDbProperty<T2> resultDataT = new OutputOnDbProperty<T2>();

            try
            {


                resultData = await base.TransConnectionAsync();

                if (resultData.StatusOnDb == true)
                {

                    resultDataT = await base.CallStoreProcetureCommandAsync<T1, T2>(sql, model);

                    if (resultDataT.StatusOnDb == true)
                    {
                        //base.TransCommit();
                        resultDataT.MessageOnDb = "Save Data Success";
                    }
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                base.TransClose();
            }

            return resultDataT;
        }

        protected OutputOnDbProperty InsertBySql(string sql)
        {
            try
            {
              

                resultData = base.TransConnection();

                if (resultData.StatusOnDb == true)
                {

                    resultData = base.TransExecuteCommand(sql);

                    if (resultData.StatusOnDb == true)
                    {
                        base.TransCommit();
                        resultData.MessageOnDb = "Save Data Success";
                    }
                    else
                    {
                        base.TransRolback();
                    }
                }
            }
            finally
            {
                base.TransClose();
            }

            return resultData;
        }

        protected OutputOnDbProperty UpdateBySql(string sql)
        {
            try
            {
           

                resultData = base.TransConnection();

                if (resultData.StatusOnDb == true)
                {
                    resultData = base.TransExecuteCommand(sql);

                    if (resultData.StatusOnDb == true)
                    {
                        base.TransCommit();
                        resultData.MessageOnDb = "Update Data Success";
                    }
                    else
                    {
                        base.TransRolback();
                    }
                }
            }
            finally
            {
                base.TransClose();
            }

            return resultData;
        }

        protected OutputOnDbProperty DeleteBySql(string sql)
        {
            try
            {
               

                resultData = base.TransConnection();

                if (resultData.StatusOnDb == true)
                {
                    resultData = base.TransExecuteCommand(sql);

                    if (resultData.StatusOnDb == true)
                    {
                        base.TransCommit();
                        resultData.MessageOnDb = "Delete Data Success";
                    }
                    else
                    {
                        base.TransRolback();
                    }
                }
            }
            finally
            {
                base.TransClose();
            }

            return resultData;
        }

        # region  Dispose Object

        public void Dispose()
        {
            try
            {
                base.TransClose();
            }
            finally
            {
                GC.SuppressFinalize(this);
            }

        }

        #endregion

        //public byte[] sfilePictureTopView1 { get; set; }
    }
}
