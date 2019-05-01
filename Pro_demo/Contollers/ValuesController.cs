using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Pro_demo.Contollers
{
    [Route("api/[controller]")]
       public class ValuesController : ControllerBase
   // public class StuffController : ControllerBase
    {
        // GET: api/<controller>
        [HttpGet]
        //[Produces("application/dan+json") ]
        [Produces("application/dan+json")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, string query)
        {
            // return $"value{id} query ={query}";
            return Ok(new Value { Id = id, Text = "value" + id });
        }

        // POST api/<controller>
        [HttpPost]
        //public void Post([FromBody]Value value)
        public IActionResult Post([FromBody]Value value)
        {
           if(!ModelState.IsValid)
            {
                //  throw new InvalidOperationException("Invalid");
                return BadRequest(ModelState);
            }
           //save the value to the DB
            return CreatedAtAction("Get", new { id = value.Id }, value);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
         
        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {  
        }
    }
    public class Value
    {
        public int Id { get; set;}
        [MinLength(3)]
        public string Text { get;set;}
    }
}
