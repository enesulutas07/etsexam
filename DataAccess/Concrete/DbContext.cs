using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Dapper.Oracle;
using Oracle.ManagedDataAccess;
using Oracle.ManagedDataAccess.Client;

namespace DataAccess.Concrete
{
    class DbContext<T> where T : class
    {
        public IDbConnection OpenConnection()
        {
            //local database
            //"Host=localhost;Port=5432;Username=postgres;Password=enes543321;Database=EtsExam";

            //oracle connectionstringi yazılacak
            IDbConnection connection = new OracleConnection("Host=hattie.db.elephantsql.com;Port=5432;Username=mrfdflph;Password=v9CJEVXhUrg2ySsU0DBmCy192sMr5K8i;Database=mrfdflph");

            //IDbConnection connection = new NpgsqlConnection("Host=hattie.db.elephantsql.com;Port=5432;Username=mrfdflph;Password=v9CJEVXhUrg2ySsU0DBmCy192sMr5K8i;Database=mrfdflph");
            connection.Open();
            return connection;
        }


        public bool HasConnection()
        {
            using (var conn = OpenConnection()) 
            {
                if (conn == null)
                    return false;
                else
                    return true;
            }
        }

        public IEnumerable<T> GetList(string _query, T entity = null)
        {
            using (IDbConnection _conn = OpenConnection())
            {
                if (entity == null)
                    return _conn.Query<T>(_query);
                else
                    return _conn.Query<T>(_query, entity);
            }
        }

        public IEnumerable<T> GetListByProcudure(string _procedureName,OracleDynamicParameters parameters, T entity = null)
        {
            using (IDbConnection _conn = OpenConnection())
            {
                if (entity == null)
                    return _conn.Query<T>(_procedureName,param:parameters,commandType:CommandType.StoredProcedure);
                else
                    return _conn.Query<T>(_procedureName, param: parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public bool Insert(string _query, object entity, string resultQuery = "")
        {
            using (IDbConnection _conn = OpenConnection())
            {
                var result = _conn.Execute(_query, entity) > 0;
                if (result)
                {
                    if (resultQuery == "")
                        return true;
                    else
                    {
                        var data = _conn.Query<T>(resultQuery);
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
        }
       
    }
}
