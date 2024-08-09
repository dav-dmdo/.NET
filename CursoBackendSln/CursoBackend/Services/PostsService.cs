using System.Text.Json;
using CursoBackend.DTOs;
using CursoBackend.Services.Interfaces;

namespace CursoBackend.Services
{
    public class PostsService : IPostsService
    {
        public HttpClient _client;

        public PostsService()
        {
            _client = new HttpClient();
        }
        public async Task<IEnumerable<PostDTO>> Get()
        {
            string url = "https://jsonplaceholder.typicode.com/posts";
            var response = await _client.GetAsync(url);
            var body = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions 
            {
                PropertyNameCaseInsensitive = true
            };

            var post = JsonSerializer.Deserialize<IEnumerable<PostDTO>>(body, options);
            return post;
        }
    }
}