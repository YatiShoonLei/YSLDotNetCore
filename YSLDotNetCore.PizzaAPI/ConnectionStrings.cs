﻿using System.Data.SqlClient;

namespace YSLDotNetCore.PizzaAPI;

internal static class ConnectionStrings
{
    public static SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
    {
        DataSource = "YATISHOONLEI",
        InitialCatalog = "YSLDotNetCore",
        UserID = "sa",
        Password = "sasa@123",
        TrustServerCertificate = true
    };
}
