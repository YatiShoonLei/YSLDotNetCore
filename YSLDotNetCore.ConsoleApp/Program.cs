using System.Data;
using System.Data.SqlClient;
using YSLDotNetCore.ConsoleApp;

AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
//adoDotNetExample.Read();
adoDotNetExample.Create("Title6", "Author6", "Content6");

Console.ReadLine();


