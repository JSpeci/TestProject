using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Specian.Data;
using Specian.Models;

namespace Specian.Controllers
{
    [Produces("application/json")]
    [Route("api/PersonApi")]
    public class PersonApiController : Controller
    {
        private readonly Data.AppContext _context;

        public PersonApiController(Data.AppContext context)
        {
            _context = context;
        }

        // GET: api/PersonApi
        [HttpGet]
        public IEnumerable<Person> GetPersons()
        {

            return _context.Persons.ToList();
        }

        // GET: api/PersonApi/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPerson([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var person = await _context.Persons.SingleOrDefaultAsync(m => m.Id == id);

            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }

        // PUT: api/PersonApi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerson([FromRoute] Guid id, [FromBody] Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != person.Id)
            {
                return BadRequest();
            }

            _context.Entry(person).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PersonApi
        [HttpPost]
        public async Task<IActionResult> PostPerson([FromBody] Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Persons.Add(person);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPerson", new { id = person.Id }, person);
        }

        // DELETE: api/PersonApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var person = await _context.Persons.SingleOrDefaultAsync(m => m.Id == id);
            if (person == null)
            {
                return NotFound();
            }

            _context.Persons.Remove(person);
            await _context.SaveChangesAsync();

            return Ok(person);
        }

        private bool PersonExists(Guid id)
        {
            return _context.Persons.Any(e => e.Id == id);
        }
    }
}