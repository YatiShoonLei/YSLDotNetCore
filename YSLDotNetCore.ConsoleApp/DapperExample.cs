using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YSLDotNetCore.ConsoleApp
{
    internal class DapperExample
    {
        public void Run() 
        {
            //Read();
            //Edit(2);
            //Edit(7);
            //Create("Title9", "Author9", "Content9");
            //Update(11, "Title10", "Author10", "Content10");
            Delete(11);

        }
        private void Read()
        {
            using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            List<BlogDto> list = db.Query<BlogDto>("select * from Tbl_Blog").ToList();
            
            foreach (BlogDto item in list)
            {
                Console.WriteLine(item.BlogID);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
                Console.WriteLine("------------------------------------------------");
            }
        }

        private void Edit(int id)
        {
            using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            var item = db.Query<BlogDto>("select * from Tbl_Blog where BlogID = @BlogID", new BlogDto { BlogID = id }).FirstOrDefault();

            if (item is null)
            {
                Console.WriteLine("Data does not found.");
                return;
            }
            Console.WriteLine(item.BlogID);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogContent);
            Console.WriteLine("------------------------------------------------");
        }

        private void Create(string title, string author, string content)
        {
            BlogDto item = new BlogDto()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };
            string query = @"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent)";
            using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query,item);

            string message = result > 0 ? "Saving Successful" : "Saving Failed";
            Console.WriteLine(message);
        }

        private void Update(int id, string title, string author, string content)
        {
            BlogDto item = new BlogDto()
            {
                BlogID = id,
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };
            string query = @"UPDATE [dbo].[Tbl_Blog]
   SET [BlogTitle] = @BlogTitle 
      ,[BlogAuthor] = @BlogAuthor 
      ,[BlogContent] = @BlogContent 
 WHERE [BlogID] = @BlogID";
            using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query,item);

            string message = result > 0 ? "Updating Successful" : "Updating Failed";
            Console.WriteLine(message);
        }

        private void Delete(int id)
        {
            BlogDto item = new BlogDto() { BlogID = id };
            string query = @"DELETE FROM [dbo].[Tbl_Blog]
      WHERE [BlogID] = @BlogID";
            using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query,item);

            string message = result > 0 ? "Deleting Successful" : "Deleting Failed";
            Console.WriteLine(message);
        }
    }
}
