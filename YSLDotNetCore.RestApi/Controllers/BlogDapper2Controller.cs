using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using YSLDotNetCore.RestApi.Models;
using YSLDotNetCore.Shared;

namespace YSLDotNetCore.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogDapper2Controller : ControllerBase
    {
        private readonly DapperService _dapperService = new DapperService(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);

        [HttpGet]
        public IActionResult GetBlogs()
        {
            var query = "select * from Tbl_Blog";
            var list = _dapperService.Query<BlogModel>(query);
            return Ok(list);
        }

        [HttpGet("{id}")]
        public IActionResult GetBlog(int id)
        {
            var item = FindByID(id);
            if (item is null)
            {
                return NotFound("No Data Found");
            }
            return Ok(item);
        }

        [HttpPost]
        public IActionResult CreateBlog(BlogModel blog)
        {
            var query = @"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent)";
            int result = _dapperService.Execute(query, blog);
            string message = result > 0 ? "Saving Successful" : "Saving Failed";
            return Ok(message);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBlog(int id, BlogModel blog)
        {
            var item = FindByID(id);
            if ( item is null )
            {
                return NotFound("No Data Found");
            }
            blog.BlogID = id;
            string query = @"UPDATE [dbo].[Tbl_Blog]
   SET [BlogTitle] = @BlogTitle 
      ,[BlogAuthor] = @BlogAuthor 
      ,[BlogContent] = @BlogContent 
 WHERE [BlogID] = @BlogID";
            int result = _dapperService.Execute(query, blog);
            string message = result > 0 ? "Updating Successful" : "Updating Failed";
            return Ok(message);
        }

        [HttpPatch("{id}")]
        public IActionResult PatchBlog(int id, BlogModel blog)
        {
            var item = FindByID(id);
            if ( item is null )
            {
                return NotFound("No Data Found");
            }

            string condition = string.Empty;

            if (!string.IsNullOrEmpty(blog.BlogTitle))
            {
                condition += " [BlogTitle] = @BlogTitle, ";
            }
            if (!string.IsNullOrEmpty(blog.BlogAuthor))
            {
                condition += " [BlogAuthor] = @BlogAuthor, ";
            }
            if (!string.IsNullOrEmpty(blog.BlogContent))
            {
                condition += " [BlogContent] = @BlogContent, ";
            }

            if (condition.Length == 0)
            {
                return NotFound("No Data to update");
            }
            condition = condition.Substring(0, condition.Length - 2);
            blog.BlogID = id;

            string query = $@"UPDATE [dbo].[Tbl_Blog]
   SET {condition} WHERE [BlogID] = @BlogID";
            int result = _dapperService.Execute(query, blog);
            string message = result > 0 ? "Updating Successful" : "Updatin Failed";
            return Ok(message);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(int id)
        {
            var item = FindByID(id);
            if (item is null )
            {
                return NotFound("No Data Found");
            }
            string query = @"DELETE FROM [dbo].[Tbl_Blog]
      WHERE BlogID = @BlogID";
            int result = _dapperService.Execute(query, item);
            string message = result > 0 ? "Deleting Successful" : "Deleting Failed";
            return Ok(message); 
        }

        private BlogModel FindByID (int id)
        {
            var query = "select * from Tbl_Blog where BlogID = @BlogID";
            var item = _dapperService.QueryFirstOrDefault<BlogModel>(query, new BlogModel { BlogID = id });
            return item!;
        }
    }
}
