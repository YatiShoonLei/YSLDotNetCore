using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using YSLDotNetCore.RestApi.Models;

namespace YSLDotNetCore.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogDapperController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetBlogs()
        {
            var query = "select * from Tbl_Blog";
            using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            List<BlogModel> list = db.Query<BlogModel>(query).ToList();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public IActionResult GetBlog(int id)
        {
            var query = "select * from Tbl_Blog";
            using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            List<BlogModel> list = db.Query<BlogModel>(query).ToList();
            return Ok(list);
        }

        [HttpPost]
        public IActionResult CreateBlog(BlogModel blog)
        {
            return Ok("Create");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBlog(int id, BlogModel blog)
        {
            return Ok("Update");
        }

        [HttpPatch("{id}")]
        public IActionResult PatchBlog(int id, BlogModel blog)
        {
            return Ok("Patch");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(int id)
        {
            return Ok("Delete");
        }
    }
}
