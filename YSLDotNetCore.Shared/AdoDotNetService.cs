using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.NetworkInformation;
using System.Reflection;

namespace YSLDotNetCore.Shared
{
    public class AdoDotNetService
    {
        private readonly string _connectionString;

        public AdoDotNetService(string connectionString)
        {
            _connectionString = connectionString;
        }

        //public List<T> Query<T>(string query)
        //{
        //    SqlConnection connection = new SqlConnection(_connectionString);
        //    connection.Open();
        //    SqlCommand cmd = new SqlCommand(query, connection);
        //    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();
        //    adapter.Fill(dt);
        //    connection.Close();

        //    string json = JsonConvert.SerializeObject(dt);
        //    List<T> list = JsonConvert.DeserializeObject<List<T>>(json);

        //    return list;
        //}

        public List<T> Query<T>(string query, params AdoDotNetParameter[]? parameter)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);

            if (parameter is not null && parameter.Length > 0)
            {
                //foreach (var param in parameter)
                //{
                //    cmd.Parameters.AddWithValue(param.Name, param.Value);
                //}

                //cmd.Parameters.AddRange(parameter.Select(param => new SqlParameter(param.Name, param.Value)).ToArray());

                var paramArray = parameter.Select(param => new SqlParameter(param.Name, param.Value)).ToArray();
                cmd.Parameters.AddRange(paramArray);
            }

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            connection.Close();

            string json = JsonConvert.SerializeObject(dt);
            List<T> list = JsonConvert.DeserializeObject<List<T>>(json);

            return list;
        }

        public T QueryFirstOrDefault<T>(string query, params AdoDotNetParameter[]? parameter)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);

            if (parameter is not null && parameter.Length > 0)
            {
                //foreach (var param in parameter)
                //{
                //    cmd.Parameters.AddWithValue(param.Name, param.Value);
                //}

                //cmd.Parameters.AddRange(parameter.Select(param => new SqlParameter(param.Name, param.Value)).ToArray());

                var paramArray = parameter.Select(param => new SqlParameter(param.Name, param.Value)).ToArray();
                cmd.Parameters.AddRange(paramArray);
            }

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            connection.Close();

            string json = JsonConvert.SerializeObject(dt);
            List<T> list = JsonConvert.DeserializeObject<List<T>>(json);

            return list[0];
        }

        public int Execute (string query, params AdoDotNetParameter[]? parameter)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);

            if (parameter is not null && parameter.Length > 0)
            {
                cmd.Parameters.AddRange(parameter.Select(param => new SqlParameter(param.Name, param.Value)).ToArray());
            }
            var result = cmd.ExecuteNonQuery();
            connection.Close();
            return result;
        }

    }

    public class AdoDotNetParameter
    {
        public AdoDotNetParameter()
        {

        }
        public AdoDotNetParameter(string name, object value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; set; }    
        public object Value { get; set; }
    }
}
