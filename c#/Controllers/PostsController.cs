using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectChanuka.Classes_and_Interfaces;
using ProjectChanuka.Models;

namespace ProjectChanuka.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPost _Ipost;

        public PostsController(IPost iPost)
        {
            _Ipost = iPost;
        }

        [HttpGet]
        [Route("api/GetPosts")]

        public async Task<ActionResult<List<PostTable>>> GetPosts()
        {
            try
            {
                var res = _Ipost.Get();
            }
            catch (Exception ex)
            {
            }
            return Ok();
        }

        [HttpPut]
        [Route("api/PutPosts/{id}")]


        public async Task<ActionResult> PutPosts(int id, [FromBody] PostTable t)
        {
            bool isOk = await _Ipost.Put(id,t);
            if (isOk)
            {
                Ok();
            }
            return BadRequest();
        }
        [HttpPost]
        [Route("api/PostPosts")]

        public async Task<ActionResult> PostPosts([FromBody] PostTable t)
        {
            bool isOk = await _Ipost.Post(t);
            if (isOk)
            {
                Ok();
            }
            return BadRequest();
        }
        [HttpDelete]
        [Route("api/DeletePosts/{id}")]

        public async Task<ActionResult> DeletePosts(int id)
        {
            bool isOk = await _Ipost.Delete(id);
            if (isOk)
            {
                Ok();
            }
            return BadRequest();
        }

    }
}
