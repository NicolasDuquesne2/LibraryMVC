using LibraryMVC.Data;
using LibraryMVC.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Library.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuteursController : ControllerBase
    {
        private readonly AuteurRepository _repository;


        public AuteursController(AuteurRepository repository)
        {
            _repository = repository;
        }

        // GET: api/<AuteursController>
        [HttpGet]
        public async Task<IEnumerable<Auteur>> Get()
        {
            return await _repository.ListAll();
        }

        // GET api/<AuteursController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Auteur>> Get(int id)
        {
            var auteur = await _repository.GetById(id);

            if(auteur == null)
            {
                return NotFound();
            }

            return Ok(auteur);
        }

        // POST api/<AuteursController>
        [HttpPost]
        [ActionName(nameof(Post))]
        public async Task<ActionResult<Auteur>> Post([FromBody] Auteur auteur)
        {
            await _repository.Insert(auteur);
            return CreatedAtAction(nameof(Post), new { id = auteur.Id }, auteur);
        }

        // PUT api/<AuteursController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Auteur auteur)
        {
            if(id != auteur.Id)
            {
                return BadRequest();
            }

            try
            {
                await _repository.Update(auteur);
            }
            catch(DbUpdateConcurrencyException ex) {
                Console.WriteLine(ex.Message);
            }

            return Ok(auteur);
        }

        // DELETE api/<AuteursController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var auteur = await _repository.GetById(id);

            if (auteur == null)
            {
               return NotFound();
            }

            await _repository.Delete(auteur);

            return NoContent();
        }
    }
}
