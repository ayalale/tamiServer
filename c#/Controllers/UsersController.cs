using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectChanuka.Classes_and_Interfaces;
using ProjectChanuka.Models;

namespace ProjectChanuka.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUser _Iuser;

        public UsersController(IUser iUser)
        {
            _Iuser = iUser;
        }

        [HttpGet]
        [Route("api/GetUsers")]

        public async Task<ActionResult<List<UserTable>>> GetUsers()
        {
            try
            {
                var res = _Iuser.Get();
            }catch(Exception ex)
            {

            }
            return Ok();
        }

        [HttpPut]
        [Route("api/PutUsers/{id}")]

        public async Task<ActionResult> PutUsers(int id, [FromBody] UserTable t)
        {
            bool isOk = await _Iuser.Put(id, t);
            if(isOk)
            {
                Ok();
            }
            return BadRequest();
        }
        [HttpPost]
        [Route("api/PostUsers")]

        public async Task<ActionResult> PostUsers([FromBody] UserTable t)
        {
            bool isOk = await _Iuser.Post(t);
            if (isOk)
            {
                Ok();
            }
            return BadRequest();
        }
       
        [HttpDelete]
        [Route("api/DeleteUsers/{id}")]
        public async Task<ActionResult> DeleteUsers(int id)
        {
            bool isOk = await _Iuser.Delete(id);
            if (isOk)
            {
                Ok();
            }
            return BadRequest();
        }
 
    }
}
