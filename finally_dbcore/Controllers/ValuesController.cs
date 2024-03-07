using finally_dbcore.Dto;
using finally_dbcore.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace finally_dbcore.Controllers
{
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly TodoService _TodoService;
        public ValuesController(TodoService TodoService)
        {
            _TodoService = TodoService;
        }

        // GET: api/<ValuesController>
        [HttpGet("fa/get")]
        public IActionResult 多筆資料([FromQuery] TA param)
        {
            var  result =  _TodoService.查詢多筆(null);   //不丟任何東西 可丟null
            return Ok(result);
        }

        // POST api/<ValuesController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        // PUT api/<ValuesController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<ValuesController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
