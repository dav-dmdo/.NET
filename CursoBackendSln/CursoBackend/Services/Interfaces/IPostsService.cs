using CursoBackend.DTOs;

namespace CursoBackend.Services.Interfaces
{
    public interface IPostsService
    {
        public Task<IEnumerable<PostDTO>> Get();
    }
}