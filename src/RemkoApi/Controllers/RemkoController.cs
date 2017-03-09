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

        /// <summary>
        /// I WAS TRYING THIS BUT IT DOES NOT WORK. YOU DON'T NEED THIS GUY
        /// </summary>
        /// <param name="value"></param>
        // POST api/values
        [HttpPost]
        public void Post([FromBody]Person value)
        {
            //var bodyStream = this.Request.Body;

            //var requestBody = new StreamReader(bodyStream).ReadToEnd();

            //Console.WriteLine(value.ToString());

            if (ModelState.IsValid) {
                value.Id++;
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
