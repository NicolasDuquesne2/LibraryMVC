using LibraryMVC.Data;
using LibraryMVC.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Library.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly LivreRepository _repository;


        public BooksController(LivreRepository repository)
        {
            _repository = repository;
        }

        // GET: api/<BooksController>
        [HttpGet]
        public async Task<IEnumerable<Livre>> Get()
        {
            return await _repository.ListAll();
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Livre>> Get(int id)
        {
            var book = await _repository.GetById(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        // POST api/<BooksController>
        [HttpPost]
        [ActionName(nameof(Post))]
        public async Task<ActionResult<Livre>> Post( Livre livre)
        {
            await _repository.Insert(livre);
            return CreatedAtAction(nameof(Post), new {id = livre.Id}, livre);
        }

        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id,  Livre livre)
        {
            if(id != livre.Id)
            {
                return BadRequest();
            }

            try
            {
                await _repository.Update(livre);
            }
            catch (DbUpdateConcurrencyException ex) { 
                Console.WriteLine(ex.Message);
            }

            return NoContent();
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var livre = await _repository.GetById(id);

            if(livre == null)
            {
                return NotFound();
            }

            await _repository.Delete(livre);

            return NoContent();
        }
    }
}
