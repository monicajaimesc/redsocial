using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // make context private so we have acces to it in our class
        private readonly DataContext _context;

        // using dependency injection. Inject Datacontext into values controller and then we can 
        // acces the context to make queris to our database via entity framework and return a data from it
        // CONSTRUCTOR
        public ValuesController(DataContext context)
        {
            // now we have acces to the context inside our valuescontroller
            _context = context;
            //rebundante:
            //this._context = context;
        }

        // GET api/values
        [HttpGet]
        // instead of return the values as a string, return them as a list
        // public ActionResult<IEnumerable<string>> Get()
        // {
        //     return new string[] { "value1", "value2" };
        // }
        public async Task<ActionResult<IEnumerable<Value>>> Get()
        {
            var values = await _context.Values.ToListAsync();
            // 200 ok response and parse the values inside
            return Ok(values);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Value>> Get(int id)
        {
            var value = await _context.Values.FindAsync(id);
            return Ok(value);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}