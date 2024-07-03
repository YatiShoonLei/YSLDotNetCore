﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using YSLDotNetCore.NLayer.DataAccess.Models;

namespace YSLDotNetCore.NLayer.DataAccess.Models;

[Table("Tbl_Blog")]
public class BlogModel
{
    [Key]
    public int BlogID { get; set; }
    public string? BlogTitle { get; set; }
    public string? BlogAuthor { get; set; }
    public string? BlogContent { get; set; }
}
