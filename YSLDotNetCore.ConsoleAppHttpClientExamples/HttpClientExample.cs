using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace YSLDotNetCore.ConsoleAppHttpClientExamples
{
    internal class HttpClientExample
    {
        private readonly HttpClient _client = new HttpClient() { BaseAddress = new Uri("https://localhost:7113") };
        private readonly string _endpoint = "api/blog";
        public async Task RunAsync()
        {
            //await ReadAsync();
            //await EditAsync(21);
            //await EditAsync(100);
            //await DeleteAsync(4);
            //await DeleteAsync(7);
            //await CreateAsync("Title21", "Author21", "Content21");
            //await UpdateAsync(21,"Title21", "Author21", "Content21");
        }

        private async Task ReadAsync()
        {
            var response = await _client.GetAsync(_endpoint);
            if (response.IsSuccessStatusCode)
            {
                var jsonStr = await response.Content.ReadAsStringAsync();
                List<BlogDto> list = JsonConvert.DeserializeObject<List<BlogDto>>(jsonStr);
                foreach (var item in list)
                {
                    Console.WriteLine(JsonConvert.SerializeObject(item));
                    Console.WriteLine($"Title => {item.BlogTitle}");
                    Console.WriteLine($"Author => {item.BlogAuthor}");
                    Console.WriteLine($"Content => {item.BlogContent}");
                }
            }
            var message = await response.Content.ReadAsStringAsync();
            Console.WriteLine(message);
        }

        private async Task EditAsync(int id)
        {
            var response = await _client.GetAsync($"{_endpoint}/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonStr = await response.Content.ReadAsStringAsync();
                var item = JsonConvert.DeserializeObject<BlogDto>(jsonStr);
                Console.WriteLine(JsonConvert.SerializeObject(item));
                Console.WriteLine($"Title => {item.BlogTitle}");
                Console.WriteLine($"Author => {item.BlogAuthor}");
                Console.WriteLine($"Content => {item.BlogContent}");
            }
            else
            {
                var message = await response.Content.ReadAsStringAsync();
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
            var blogJson = JsonConvert.SerializeObject(blogDto);
            HttpContent httpContent = new StringContent(blogJson, Encoding.UTF8, Application.Json);
            var response = await _client.PostAsync(_endpoint,httpContent);
            if (response.IsSuccessStatusCode)
            {
                var message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }
            else
            {
                var message = await response.Content.ReadAsStringAsync();
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
            var blogJson = JsonConvert.SerializeObject(blogDto);
            HttpContent httpContent = new StringContent(blogJson, Encoding.UTF8, Application.Json);
            var response = await _client.PutAsync($"{_endpoint}/{id}", httpContent);
            if (response.IsSuccessStatusCode)
            {
                var message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }
            else
            {
                var message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }
        }

        private async Task DeleteAsync(int id)
        {
            var response = await _client.DeleteAsync($"{_endpoint}/{id}");
            if (response.IsSuccessStatusCode)
            {
                var message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }
            else
            {
                var message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }
        }
    }
}
