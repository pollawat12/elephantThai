using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using mudhithaverse_api.Models;

namespace SbAdmin.Controllers
{
  //  [Route("api/[controller]")]
   [ApiController]
   [Route("CarController")]
    public class SimpleController : ControllerBase
    {
        public SimpleController()
        {
        }

        [HttpGet("")]
       // [Route("api/mm")]
        public ActionResult<IEnumerable<string>> Gets()
        {
            return new string[] { "v1", "v2" };

        }

        [HttpGet("{id}")]
        public ActionResult<string> GetTModelById(int id)
        {
            return "value" + id;
        }

        // [HttpPost("")]
        // public void Post([FromBody] string value) { }


        // [HttpPut("{id}")]
        // public void Put(int id ,[FromBody] string value) { }

        // [HttpDelete("{id}")]
        // public void Delete(int id ,[FromBody] string value){}
    }
}