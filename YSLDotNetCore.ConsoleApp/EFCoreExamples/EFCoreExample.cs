using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YSLDotNetCore.ConsoleApp.EFCoreExamples
{
    internal class EFCoreExample
    {
        private readonly AppDbContext db = new AppDbContext();
        public void Run()
        {
            //Read();
            //Edit(8);
            //Edit(7);
            //Create("Title13", "Author13", "Content13");
            //Update(12, "Title12", "Author12", "Content12");
            //Delete(9);
        }

        private void Read()
        {
            var list = db.Blogs.ToList();

            foreach (var item in list)
            {
                Console.WriteLine(item.BlogID);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
                Console.WriteLine("--------------------------------------");
            }
        }

        private void Edit(int id)
        {
            var item = db.Blogs.FirstOrDefault(x => x.BlogID == id);

            if (item is null)
            {
                Console.WriteLine("Data does not found.");
                return;
            }
            Console.WriteLine(item.BlogID);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogContent);
            Console.WriteLine("--------------------------------------");
        }

        private void Create(string title, string author, string content)
        {
            var item = new BlogDto
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };
            db.Blogs.Add(item);
            int result = db.SaveChanges();
            string message = result > 0 ? "Saving Successful" : "Saving Failed";
            Console.WriteLine(message);
        }

        //private void Update(int id, string title, string author, string content) 
        //{
        //    var item = new BlogDto
        //    {
        //        BlogID = id,
        //        BlogTitle = title,
        //        BlogAuthor = author,
        //        BlogContent = content
        //    };
        //    db.Blogs.Update(item);
        //    int result = db.SaveChanges();
        //    string message = result > 0 ? "Updating Successful" : "Updating Failed";
        //    Console.WriteLine(message);
        //} 

        private void Update(int id, string title, string author, string content)
        {
            var item = db.Blogs.First(x => x.BlogID == id);
            if (item is null)
            {
                Console.WriteLine("Data does not exist");
                return;
            }
            item.BlogTitle = title;
            item.BlogAuthor = author;
            item.BlogContent = content;
            int result = db.SaveChanges();
            string message = result > 0 ? "Updating Successful" : "Updating Failed";
            Console.WriteLine(message);
        }


        private void Delete(int id)
        {
            var item = db.Blogs.FirstOrDefault(x => x.BlogID == id);
            if (item is null)
            {
                Console.WriteLine("Data doesn't found.");
                return;
            }
            db.Blogs.Remove(item);
            int result = db.SaveChanges();
            string message = result > 0 ? "Deleting Successful" : "Deleting Failed";
            Console.WriteLine(message);
        }
    }
}
