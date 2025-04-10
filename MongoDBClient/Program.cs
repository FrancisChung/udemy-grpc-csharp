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

            var client = new BlogService.BlogServiceClient(channel);
            //ListBlog(client);

            //ReadBlog(client);

            var blog = CreateTestBlog(client, 1);
            CreateTestBlog(client, 2);
            CreateTestBlog(client, 3);
            CreateTestBlog(client, 4);
            CreateTestBlog(client, 5);
            CreateTestBlog(client, 6);
            CreateTestBlog(client, 7);
            CreateTestBlog(client, 8);

            //DeleteBlog(client, blog);

            //UpdateBlog(client, blog);
            // Console.WriteLine($"The Blog ${response.Blog.Id} was created! ");

            channel.ShutdownAsync().Wait();
            Console.ReadKey();
        }

        private static void ReadBlog(BlogService.BlogServiceClient client)
        {
            try
            {
                var response = client.ReadBlog(new ReadBlogRequest()
                {
                    BlogId = "67f59c9d3c574a85bbae39e4"
                });
                Console.WriteLine(response.Blog.ToString());
            }
            catch (RpcException ex)
            {
                Console.WriteLine(ex.Status.Detail);
            }
        }

        private static Blog.Blog CreateTestBlog(BlogService.BlogServiceClient client, int index)
        {
            var response = client.CreateBlog(new CreateBlogRequest()
            {
                Blog = new Blog.Blog()
                {
                    AuthorId = "Francis Chung",
                    Title = $"New Blog Entry {index}",
                    Content = "Hello Blog, this is a new blog entry."

                }
            });
            return response.Blog;
        }

        private static void UpdateBlog(BlogService.BlogServiceClient client, Blog.Blog blog)
        {
            try
            {
                blog.Title = "Udemy Update Test";
                blog.Content = "This is the updated content of the blog.";

                var response = client.UpdateBlog(new UpdateBlogRequest()
                {
                    Blog = blog
                });

                Console.Write(response.Blog.ToString());
            }
            catch (RpcException ex)
            {
                Console.WriteLine(ex.Status.Detail);
            }
        }

        private static void DeleteBlog(BlogService.BlogServiceClient client, Blog.Blog blog)
        {
            try
            {
                var blogId = blog.Id;
                var response = client.DeleteBlog(new DeleteBlogRequest()
                {
                    BlogId = blogId
                });
                Console.WriteLine($"The Blog with ID {blogId} was deleted.");
            }
            catch (RpcException ex)
            {
                Console.WriteLine(ex.Status.Detail);
            }
        }

        private static async Task ListBlog(BlogService.BlogServiceClient client)
        {
            var response = client.ListBlog(new ListBlogRequest() { });
            while (await response.ResponseStream.MoveNext())
            {
                var blog = response.ResponseStream.Current.Blog;
                Console.WriteLine($"Blog: {blog.ToString()} ");
            }
        }
    }
}