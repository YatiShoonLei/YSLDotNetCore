using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

Console.WriteLine("Hello, World!");

HttpClient client = new HttpClient();
var response = await client.GetAsync("https://localhost:7113/api/blog/Read");
if (response.IsSuccessStatusCode)
{
    var jsonStr = await response.Content.ReadAsStringAsync();
    //Console.WriteLine(jsonStr);
    List<BlogDto> list = JsonConvert.DeserializeObject<List<BlogDto>>(jsonStr);
    foreach (var item in list)
    {
        Console.WriteLine(JsonConvert.SerializeObject(item));
        Console.WriteLine($"Title => {item.BlogTitle}");
        Console.WriteLine($"Author => {item.BlogAuthor}");
        Console.WriteLine($"Content => {item.BlogContent}");
    }
}

public class BlogDto
{
    public int BlogID { get; set; }
    public string? BlogTitle { get; set; }
    public string? BlogAuthor { get; set; }
    public string? BlogContent { get; set; }
}
