Console.WriteLine("Hello, World!");

HttpClient client = new HttpClient();
var response = await client.GetAsync("https://localhost:7113/api/blog");
if (response.IsSuccessStatusCode)
{
    var jsonStr = await response.Content.ReadAsStringAsync();
    Console.WriteLine(jsonStr);
}