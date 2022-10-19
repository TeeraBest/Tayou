using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace ExecuteDatabase
{
    public class OutputOnDbProperty
    {
        public bool StatusOnDb { get; set; }
        public string ClassOnDb { get; set; }
        public string MethodOnDb { get; set; }
        //public DataTable ResultOnDb { get; set; }
        public dynamic ResultOnDb { get; set; }
        public string MessageOnDb { get; set; }
        public string TotalCountOnDb { get; set; }
    }

    public class OutputOnDbProperty<T>
    {
        public bool StatusOnDb { get; set; }
        public string ClassOnDb { get; set; }
        public string MethodOnDb { get; set; }
        //public DataTable ResultOnDb { get; set; }
        public List<T> ResultOnDb { get; set; }
        public string MessageOnDb { get; set; }
        public string TotalCountOnDb { get; set; }
    }

}
