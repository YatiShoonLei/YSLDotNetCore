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
    public class BlogAdoDotNet2Controller : ControllerBase
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
            var item = _adoDotNetService.QueryFirstOrDefault<BlogModel>(query, new AdoDotNetParameter("@BlogID", id));
            if ( item == null)
            {
                return NotFound("No Data Found");
            }
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
            var result = _adoDotNetService.Execute(query, 
                new AdoDotNetParameter("@BlogTitle", model.BlogTitle),
                new AdoDotNetParameter("@BlogAuthor", model.BlogAuthor),
                new AdoDotNetParameter("@BlogContent", model.BlogContent)
                );

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
            var result = _adoDotNetService.Execute(query,
                new AdoDotNetParameter("@BlogID", id),
                new AdoDotNetParameter("@BlogTitle", model.BlogTitle),
                new AdoDotNetParameter("@BlogAuthor", model.BlogAuthor),
                new AdoDotNetParameter("@BlogContent", model.BlogContent)
                );
            string message = result > 0 ? "Updating Successful" : "Updating Failed";
            return Ok(message);
        }

        [HttpPatch("{id}")]
        public IActionResult PatchBlog(int id, BlogModel model)
        
        
        
        
        
        {
            List<AdoDotNetParameter> list = new List<AdoDotNetParameter>();
            string condition = string.Empty;

            list.Add(new AdoDotNetParameter("@BlogID", id));

            if (!string.IsNullOrEmpty(model.BlogTitle))
            {
                condition += " [BlogTitle] = @BlogTitle, ";
                list.Add(new AdoDotNetParameter("@BlogTitle", model.BlogTitle));
            }
            if (!string.IsNullOrEmpty(model.BlogAuthor))
            {
                condition += " [BlogAuthor] = @BlogAuthor, ";
                list.Add(new AdoDotNetParameter("@BlogAuthor", model.BlogAuthor));
            }
            if (!string.IsNullOrEmpty(model.BlogContent))
            {
                condition += " [BlogContent] = @BlogContent, ";
                list.Add(new AdoDotNetParameter("@BlogContent", model.BlogContent));
            }

            if (condition.Length == 0)
            {
                return NotFound("No Data Found");
            }
            condition = condition.Substring(0, condition.Length - 2);

            string query = $@"UPDATE [dbo].[Tbl_Blog]
   SET {condition} WHERE [BlogID] = @BlogID";
            var result = _adoDotNetService.Execute(query, list.ToArray());
            string message = result > 0 ? "Updating Successful" : "Updating Failed";
            return Ok(message);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(int id)
        {
            string query = @"DELETE FROM [dbo].[Tbl_Blog]
      WHERE [BlogID] = @BlogID";
            var result = _adoDotNetService.Execute(query, new AdoDotNetParameter("@BlogID", id));
            string message = result > 0 ? "Deleting Successful" : "Deleting Failed";
            return Ok(message);
        }
    }
}
