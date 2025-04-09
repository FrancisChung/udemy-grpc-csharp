using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog;
using Dummy;
using Grpc.Core;
using Greet;

namespace MongoDBClient
{
    class Program
    {
        private const string Target = "127.0.0.1:50051";
        static void Main(string[] args)
        {
            Thread.Sleep(2000);
            Grpc.Core.Channel channel = new Channel(Target, ChannelCredentials.Insecure);

            channel.ConnectAsync().ContinueWith((task) =>
            {
                if (task.Status == TaskStatus.RanToCompletion)
                    Console.WriteLine("The Client connected successfully");
                else
                    Console.WriteLine($"Client Task Status: {task.ToString()}");
            });

            //var client = new DummyService.DummyServiceClient(channel);
            //var client = new GreetingService.GreetingServiceClient(channel);

            var client = new BlogService.BlogServiceClient(channel);
            //var response = CreateTestBlog(client);

            Console.WriteLine($"The Blog ${response.Blog.Id} was created! ");

            channel.ShutdownAsync().Wait();
            Console.ReadKey();
        }

        private static CreateBlogResponse CreateTestBlog(BlogService.BlogServiceClient client)
        {
            var response = client.CreateBlog(new CreateBlogRequest() 
            {
                Blog = new Blog.Blog()
                {
                    AuthorId = "Francis Chung",
                    Title = "New Blog",
                    Content = "Hello Blog, this is a new blog entry."
                    
                }
            });
            return response;
        }
    }
}