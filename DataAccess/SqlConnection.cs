using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess
{
    public enum DBType
    {
        MySQL
    }
    public class SqlConnection
    {
        IDbConnection connection;

        public SqlConnection(DBType _dbType, string connectionString)
        {
            InitConnection(_dbType, connectionString);
        }

        private void InitConnection(DBType _dbType, string connectionString)
        {
            try
            {
                if (_dbType == DBType.MySQL)
                {
                    connection = new MySqlConnection(connectionString);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public IDbConnection GetDatabaseHandle()
        {
            return connection;
        }
    }
}
