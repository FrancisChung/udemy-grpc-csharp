using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Blog;
using Grpc.Core;
using static Blog.BlogService;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core;

namespace MongoDBServer
{
    public class BlogServiceImpl : BlogServiceBase 
    {
        private static MongoClient  _mongoClient = new MongoClient("mongodb://localhost:27017");
        private static IMongoDatabase _mongoDB = _mongoClient.GetDatabase("myBlogDB");
        private static IMongoCollection<BsonDocument> _mongoCollection = _mongoDB.GetCollection<BsonDocument>("Blog");

        public override Task<CreateBlogResponse> CreateBlog(CreateBlogRequest request, ServerCallContext context)
        {
            var blog = request.Blog;
            BsonDocument doc = new BsonDocument("author_id", blog.AuthorId)
                .Add("title", blog.Title)
                .Add("content", blog.Content);
                
            _mongoCollection.InsertOne(doc);
            
            string id = doc.GetValue("_id").ToString();
            blog.Id = id;

            var response = new CreateBlogResponse()
            {
                Blog = blog
            };

            return Task.FromResult(response);

        }
    }
}
