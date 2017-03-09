using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using RemkoApi.Models;
using RemkoApi.Data;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace RemkoApi.Controllers
{
    [Route("api/[controller]")]
    public class RemkoController : Controller
    {
        private IPeopleRepository _rep;
        public RemkoController(IPeopleRepository rep) {
            _rep = rep;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return _rep.GetPeople();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Person p = _rep.GetPersonById(id);

            return (p == null) ? NotFound() as IActionResult : Ok(p);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Person item)
        {
            //var bodyStream = this.Request.Body;

            //var requestBody = new StreamReader(bodyStream).ReadToEnd();

            //Console.WriteLine(value.ToString());

            if (!ModelState.IsValid) {
                return BadRequest(ModelState);

            }
            
            _rep.AddPerson(item);
            return CreatedAtRoute(new { id = item.Id }, item);

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Person item)
        {
            if (id != item.Id) {
                return BadRequest();
            }
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            _rep.UpdatePerson(item);
            return NoContent();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var person = _rep.DeletePerson(id);
            if (person == null) {
                return NotFound();
            }
            return Ok(person);
        }
    }
}
