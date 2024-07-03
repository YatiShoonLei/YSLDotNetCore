﻿using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace YSLDotNetCore.Shared
{
    public class DapperService
    {
        private readonly string _connectionString;

        public DapperService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DapperService()
        {
        }

        public List<M> Query<M>(string query,object? param = null)
        {
            using IDbConnection db = new SqlConnection(_connectionString);

            //if (param != null)
            //{
            //    var list = db.Query<M>(query, param).ToList();
            //}
            //else
            //{
            //    var list = db.Query(query).ToList();
            //}

            var list = db.Query<M>(query, param).ToList();
            return list;
        }

        public M QueryFirstOrDefault<M>(string query, object? param = null)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            var item = db.Query<M>(query, param).FirstOrDefault();
            return item!;
        }

        public int Execute(string query,object? param = null)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            var result = db.Execute(query, param);
            return result;
        }
    }
}
