using ExecuteDatabase;
using Microsoft.Extensions.Configuration;
using Services_Proj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_Proj.Services
{
    public interface ISampleService
    {
        OutputOnDbProperty CheckDBConnection();
        Task<IEnumerable<dynamic>> GetData();
    }
    public class SampleMsSqlService : DatabaseExecuteModelsMssql , ISampleService
    {
        private readonly IConfiguration _config;
        private string Connectionstring = "DefaultConnection";

        public SampleMsSqlService(IConfiguration config)
        {
            _config = config;
        }

        OutputOnDbProperty Result = new OutputOnDbProperty();

        string sql = string.Empty;
        public OutputOnDbProperty CheckDBConnection()
        {
            base.strConnection = Convert.ToString(_config.GetConnectionString(Connectionstring));
            Result = base.TransConnection();
            return Result;
        }

        public async Task<IEnumerable<dynamic>> GetData()
        {
            base.strConnection = Convert.ToString(_config.GetConnectionString(Connectionstring));
            sql = @$"SELECT * FROM    information_schema.tables;";
            var dataRet = await base.SearchBySqlAsync<dynamic>(sql);
            return dataRet;
        }
    }
}
