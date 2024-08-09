using System.Diagnostics;
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CursoBackend.Services.Interfaces;
using CursoBackend.DTOs;

namespace CursoBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController:ControllerBase
    {

       private readonly IPostsService _postService;

       public PostsController(IPostsService postService)
       {
            _postService = postService;
       }

        [HttpGet]
        public async Task<IEnumerable<PostDTO>> Get() => 
            await _postService.Get();

    }
    
}