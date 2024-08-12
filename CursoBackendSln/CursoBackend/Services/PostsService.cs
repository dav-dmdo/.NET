using System.Text.Json;
using CursoBackend.DTOs;
using CursoBackend.Services.Interfaces;

namespace CursoBackend.Services
{
    public class PostsService : IPostsService
    {
        public HttpClient _client;

        public PostsService(HttpClient client)
        {
            _client = client;
        }
        public async Task<IEnumerable<PostDTO>> Get()
        {
            var url = _client.BaseAddress;
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