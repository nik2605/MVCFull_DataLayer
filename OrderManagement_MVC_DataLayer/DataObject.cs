using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OrderManagement_MVC_DataLayer
{
    public class DataObject
    {
        private string _ConnectionString { get; set; }
        private SqlTransaction _transaction { get; set; }

        public DataObject()
        {
            _ConnectionString = ConfigurationManager.ConnectionStrings["OrdernDSN"].ConnectionString;
        }
        public DataObject(SqlTransaction trans)
        {
            _ConnectionString = ConfigurationManager.ConnectionStrings["OrdernDSN"].ConnectionString;
            _transaction = trans;
        }

        public string ConnectionString => _ConnectionString;
        public SqlTransaction Transaction => _transaction;

    }
}