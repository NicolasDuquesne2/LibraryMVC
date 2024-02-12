using LibraryMVC.Data;
using LibraryMVC.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Library.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadersController : ControllerBase
    {

        private readonly LecteurRepository _repository;


        public ReadersController(LecteurRepository repository)
        {
            _repository = repository;
        }


        // GET: api/<ReadersController>
        [HttpGet]
        public async Task<IEnumerable<Lecteur>> Get()
        {
            return await _repository.ListAll();
        }

        // GET api/<ReadersController>/5
        [HttpGet("{id}")]
        public async Task<Lecteur?> Get(int id)
        {
            return await _repository.GetById(id);
        }

        // POST api/<ReadersController>
        [HttpPost]
        [ActionName(nameof(Post))]
        public async Task<ActionResult<Lecteur>> Post([FromBody] Lecteur lecteur)
        {
            await _repository.Insert(lecteur);
            return CreatedAtAction(nameof(Post), new { id = lecteur.Id }, lecteur);
        }

        // PUT api/<ReadersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Lecteur lecteur)
        {
            if(id != lecteur.Id)
            {
                return BadRequest();
            }

            try
            {
                await _repository.Update(lecteur);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return Ok(lecteur);
        }

        // DELETE api/<ReadersController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var lecteur = await _repository.GetById(id);

            if(lecteur != null)
            {
                return NotFound();
            }

            await _repository.Delete(lecteur);

            return NoContent();
        }
    }
}
