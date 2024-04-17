using finally_dbcore.Dto;
using finally_dbcore.Models.test;
using finally_dbcore.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace finally_dbcore.Controllers
{
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly Todologic _TodoService;
        public ValuesController(Todologic TodoService)
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


        [HttpPost("fa/insert")]
        public IActionResult Post([FromBody] Line value)
        {
            try
            {
                _TodoService.新增資料(value);
                return Ok();    
            }
            catch (Exception ex)
            {
                var error = new
                {
                    message = "An error",
                    reason = ex.Message,
                    line = ex.StackTrace.Substring(ex.StackTrace.LastIndexOf(":line ") + 6)
                };
                return StatusCode(500, error);
            }
        }


        [HttpPut("fa/update")]
        public void Put( [FromBody] _3_line value)
        {
            _TodoService.修改資料(value);

        }

        // DELETE api/<ValuesController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
