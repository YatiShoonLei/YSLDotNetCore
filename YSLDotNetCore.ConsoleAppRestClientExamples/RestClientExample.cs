using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace YSLDotNetCore.ConsoleAppRestClientExamples;

internal class RestClientExample
{
    private readonly RestClient _client = new RestClient(new Uri("https://localhost:7113"));
    private readonly string _endpoint = "api/blog";
    public async Task RunAsync()
    {
        //await ReadAsync();
        //await EditAsync(21);
        //await EditAsync(100);
        //await DeleteAsync(4);
        //await DeleteAsync(7);
        //await CreateAsync("Title222", "Author222", "Content222");
        await UpdateAsync(22,"Title22", "Author22", "Content22");
    }

    private async Task ReadAsync()
    {
        //RestRequest restRequest = new RestRequest(_endpoint);
        //var response = await _client.GetAsync(restRequest);
        RestRequest restRequest = new RestRequest(_endpoint, Method.Get);
        var response = await _client.ExecuteAsync(restRequest);
        if (response.IsSuccessStatusCode)
        {
            var jsonStr = response.Content;
            List<BlogDto> list = JsonConvert.DeserializeObject<List<BlogDto>>(jsonStr);
            foreach (var item in list)
            {
                Console.WriteLine(JsonConvert.SerializeObject(item));
                Console.WriteLine($"Title => {item.BlogTitle}");
                Console.WriteLine($"Author => {item.BlogAuthor}");
                Console.WriteLine($"Content => {item.BlogContent}");
            }
        }
    }

    private async Task EditAsync(int id)
    {
        RestRequest restRequest = new RestRequest($"{_endpoint}/{id}", Method.Get);
        var response = await _client.ExecuteAsync(restRequest);
        if (response.IsSuccessStatusCode)
        {
            var jsonStr = response.Content;
            var item = JsonConvert.DeserializeObject<BlogDto>(jsonStr);
            Console.WriteLine(JsonConvert.SerializeObject(item));
            Console.WriteLine($"Title => {item.BlogTitle}");
            Console.WriteLine($"Author => {item.BlogAuthor}");
            Console.WriteLine($"Content => {item.BlogContent}");
        }
        else
        {
            var message = response.Content;
            Console.WriteLine(message);
        }
    }

    private async Task CreateAsync(string title, string author, string content)
    {
        BlogDto blogDto = new BlogDto()
        {
            BlogTitle = title,
            BlogAuthor = author,
            BlogContent = content
        };
        RestRequest restRequest = new RestRequest(_endpoint, Method.Post);
        restRequest.AddJsonBody(blogDto);
        var response = await _client.ExecuteAsync(restRequest);
        if (response.IsSuccessStatusCode)
        {
            var message = response.Content;
            Console.WriteLine(message);
        }
        else
        {
            var message = response.Content;
            Console.WriteLine(message);
        }
    }

    private async Task UpdateAsync(int id, string title, string author, string content)
    {
        BlogDto blogDto = new BlogDto()
        {
            BlogTitle = title,
            BlogAuthor = author,
            BlogContent = content
        };
        RestRequest restRequest = new RestRequest($"{_endpoint}/{id}", Method.Put);
        restRequest.AddJsonBody(blogDto);
        var response = await _client.ExecuteAsync(restRequest);
        if (response.IsSuccessStatusCode)
        {
            var message = response.Content;
            Console.WriteLine(message);
        }
        else
        {
            var message = response.Content;
            Console.WriteLine(message);
        }
    }

    private async Task DeleteAsync(int id)
    {
        RestRequest restRequest = new RestRequest($"{_endpoint}/{id}", Method.Delete);
        var response = await _client.ExecuteAsync(restRequest);
        if (response.IsSuccessStatusCode)
        {
            var message = response.Content;
            Console.WriteLine(message);
        }
        else
        {
            var message = response.Content;
            Console.WriteLine(message);
        }
    }
}
