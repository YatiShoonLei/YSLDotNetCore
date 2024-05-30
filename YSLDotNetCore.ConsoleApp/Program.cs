using System.Data;
using System.Data.SqlClient;
using YSLDotNetCore.ConsoleApp;

//AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
//adoDotNetExample.Read();
//adoDotNetExample.Create("Title6", "Author6", "Content6");
//adoDotNetExample.Update(7, "Title7", "Author7", "Content7");
//adoDotNetExample.Delete(7);
//adoDotNetExample.Edit(5);

DapperExample dapperExample = new DapperExample();
dapperExample.Run();

Console.ReadLine();


