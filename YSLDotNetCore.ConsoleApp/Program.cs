using System.Data;
using System.Data.SqlClient;

Console.WriteLine("Hello, World!");

SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder();
connectionStringBuilder.DataSource = "DESKTOP-U6LKCT1";
connectionStringBuilder.InitialCatalog = "YSLDotNetCore";
connectionStringBuilder.UserID = "sa";
connectionStringBuilder.Password = "sasa@123";

SqlConnection connection = new SqlConnection(connectionStringBuilder.ConnectionString);
connection.Open();
Console.WriteLine("Connection Open");

string query = "select * from Tbl_Blog";
SqlCommand cmd = new SqlCommand(query, connection);
SqlDataAdapter adapter = new SqlDataAdapter(cmd);
DataTable dt = new DataTable();
adapter.Fill(dt);

connection.Close();
Console.WriteLine("Connection Close");

foreach(DataRow dr in dt.Rows)
{
    Console.WriteLine("Blog ID => "+ dr["BlogID"]);
    Console.WriteLine("Blog Title => "+ dr["BlogTitle"]);
    Console.WriteLine("Blog Author => "+ dr["BlogAuthor"]);
    Console.WriteLine("Blog Content => "+ dr["BlogContent"]);
    Console.WriteLine("-------------------------------------------------");
}


Console.ReadKey();
