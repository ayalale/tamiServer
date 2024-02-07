using Microsoft.AspNetCore.Mvc;
using ProjectChanuka.Classes_and_Interfaces;
using ProjectChanuka.Models;

namespace ProjectChanuka.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly ITodo _Itodo;

        public ToDoController(ITodo iTodo)
        {
            _Itodo = iTodo;
        }

        [HttpGet]
        [Route("api/GetTodos")]

        public async Task<ActionResult<List<TodoTable>>> GetTodos()
        {
            //try
            //{
            //    var res = _Itodo.Get();
            //}
            //catch (Exception ex)
            //{
            //}
            //return Ok();
            var res = await _Itodo.Get();
            if (res .Count()==0 ) { return BadRequest(); }
            return Ok(res);
        }

        [HttpPut]
        [Route("api/PutTodos/{id}")]

        public async Task<ActionResult<bool>> PutTodos(int id, [FromBody] TodoTable t)
        {
            bool isOk = await _Itodo.Put(id, t);
            if (isOk)
            {
               return  Ok();
            }
            return BadRequest();
        }
        [HttpPost]
        [Route("api/PostTodos")]

        public async Task<ActionResult<bool >> PostTodos([FromBody] TodoTable t)
        {
            bool isOk = await _Itodo.Post(t);
            if (isOk)
            {
               return  Ok();
            }
            return BadRequest();
        }
        [HttpDelete]
        [Route("api/DeleteTodos/{id}")]

        public async Task<ActionResult<bool >> DeleteTodos(int id)
        {
            bool isOk = await _Itodo.Delete(id);
            if (isOk)
            {
               return  Ok();
            }
            return BadRequest();
        }
    }
}
