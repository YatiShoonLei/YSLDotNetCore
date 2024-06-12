using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YSLDotNetCore.RestApi
{
    internal static class ConnectionStrings
    {
        public static SqlConnectionStringBuilder SqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = "YATISHOONLEI",
            InitialCatalog = "YSLDotNetCore",
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate = true
        };
    }
}
