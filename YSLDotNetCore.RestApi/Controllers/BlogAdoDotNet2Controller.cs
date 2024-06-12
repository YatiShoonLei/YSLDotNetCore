using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Reflection.Metadata;
using YSLDotNetCore.RestApi.Models;
using YSLDotNetCore.Shared;

namespace YSLDotNetCore.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogAdoDotNe2tController : ControllerBase
    {
        private readonly AdoDotNetService _adoDotNetService = new AdoDotNetService(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);

        [HttpGet]
        public IActionResult GetBlogs()
        {
            string query = "select * from Tbl_Blog";
            var list = _adoDotNetService.Query<BlogModel>(query);
            return Ok(list);
        }

        [HttpGet("{id}")]
        public IActionResult GetBlog(int id)
        {
            string query = "select * from Tbl_blog where BlogID = @BlogID";
            SqlConnection connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query,connection);
            cmd.Parameters.AddWithValue("@BlogID", id);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            connection.Close();
            
            if(dt.Rows.Count == 0)
            {
                return NotFound("No Data Found");
            }
            DataRow dr = dt.Rows[0];
            var item = new BlogModel
            {
                BlogID = Convert.ToInt32(dr["BlogID"]),
                BlogTitle = Convert.ToString(dr["BlogTitle"]),
                BlogAuthor = Convert.ToString(dr["BlogAuthor"]),
                BlogContent = Convert.ToString(dr["BlogContent"])
            };
            return Ok(item);
        }

        [HttpPost]
        public IActionResult CreateBlog(BlogModel model)
        {
            string query = @"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent)";
            SqlConnection connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);

            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogTitle", model.BlogTitle);
            cmd.Parameters.AddWithValue("@BlogAuthor", model.BlogAuthor);
            cmd.Parameters.AddWithValue("@BlogContent", model.BlogContent);
            int result = cmd.ExecuteNonQuery();
            connection.Close();

            string message = result > 0 ? "Saving Successful" : "Saving Failed";
            return Ok(message);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBlog(int id, BlogModel model) 
        {
            string query = @"UPDATE [dbo].[Tbl_Blog]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent
 WHERE [BlogID] = @BlogID";
            SqlConnection connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);

            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogID", id );
            cmd.Parameters.AddWithValue("@BlogTitle", model.BlogTitle);
            cmd.Parameters.AddWithValue("@BlogAuthor", model.BlogAuthor);
            cmd.Parameters.AddWithValue("@BlogContent", model.BlogContent);
            int result = cmd.ExecuteNonQuery();
            connection.Close();

            string message = result > 0 ? "Updating Successful" : "Updating Failed";
            return Ok(message);
        }

        [HttpPatch("{id}")]
        public IActionResult PatchBlog(int id, BlogModel model)
        {
            string condition = string.Empty;

            if (!string.IsNullOrEmpty(model.BlogTitle))
            {
                condition += " [BlogTitle] = @BlogTitle, ";
            }
            if (!string.IsNullOrEmpty(model.BlogAuthor))
            {
                condition += " [BlogAuthor] = @BlogAuthor, ";
            }
            if (!string.IsNullOrEmpty(model.BlogContent))
            {
                condition += " [BlogContent] = @BlogContent, ";
            }

            if (condition.Length == 0)
            {
                return NotFound("No Data Found");
            }
            condition = condition.Substring(0, condition.Length - 2);

            string query = $@"UPDATE [dbo].[Tbl_Blog]
   SET {condition} WHERE [BlogID] = @BlogID";
            SqlConnection connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);

            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@BlogID", id);
            if (model.BlogTitle != null)
            {
                cmd.Parameters.AddWithValue("@BlogTitle", model.BlogTitle);
            }
            if (model.BlogAuthor != null)
            {
                cmd.Parameters.AddWithValue("@BlogAuthor", model.BlogAuthor);
            }
            if (model.BlogContent != null)
            {
                cmd.Parameters.AddWithValue("@BlogContent", model.BlogContent);
            }
            int result = cmd.ExecuteNonQuery();
            connection.Close();

            string message = result > 0 ? "Updating Successful" : "Updating Failed";
            return Ok(message);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(int id)
        {
            string query = @"DELETE FROM [dbo].[Tbl_Blog]
      WHERE [BlogID] = @BlogID";
            SqlConnection connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);

            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogID", id);
            int result = cmd.ExecuteNonQuery();
            connection.Close();

            string message = result > 0 ? "Deleting Successful" : "Deleting Failed";
            return Ok(message);
        }
    }
}
