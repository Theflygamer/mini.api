using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mini.DAL;
using mini.DAL.Database.Models;

namespace mini.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorRepository repo;
        public AuthorsController(IAuthorRepository a)
        {
            repo = a;
        }

        // GET: api/Authors
        [HttpGet("GetallAuthors")]
        public async Task<IActionResult> getAllauthors()
        {
            try
            {
                List<Author> GetAllAuthors = await repo.getAllAuthors();
                if(GetAllAuthors == null)
                {
                    return Problem("FAIL 500 CANT CONNET TO DATABASE");
                }
                if (GetAllAuthors.Count == 0)
                {
                    return NoContent();
                }
                return Ok(GetAllAuthors); 
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            } 
        }

        [HttpGet("GetoneAuthor")]
        public async Task<ActionResult> getAuthor(int id)
        {
            return  Ok (repo.getAuthor(id));
        }


        [HttpPost]
        public async Task<ActionResult<Author>> createAuthor(Author author)
        {

            try
            {
                var response = await repo.createAuthor(author);
                if (response != 1)
                {
                    return Problem("Du har jokket i spinaten");
                }
                return Ok(response); // Ok kommer fra actionresult
            }
             
            catch (Exception fejl)
            {

                return Problem(fejl.Message + "vores eget...");
            }
        }

        [HttpGet("flødebole")]
        public void getAuthor(int tal, string s)
        {
            int tal1 = 9;

        }

        [HttpDelete]
        public async Task<IActionResult> deleteAuthor(int autorId)
        {
            try
            {
               var respones =  await repo.deleteAuthor(autorId);
                if(respones == null)
                {
                    return NotFound();
                }
                return NoContent();
            }
            catch (Exception error)
            {

                return Problem(error.Message);
            }
        }

        // GET: api/Authors/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Author>> GetAuthor(int id)
        //{
        //    var author = await _context.Author.FindAsync(id);

        //    if (author == null)
        //    {
        //        return NotFound();
        //    }

        //    return author;
        //}

        //// PUT: api/Authors/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutAuthor(int id, Author author)
        //{
        //    if (id != author.AuthorID)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(author).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!AuthorExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Authors
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Author>> PostAuthor(Author author)
        //{
        //    Abcontext _context = new Abcontext();
        //    _context.Author.Add(author);
        //    await _context.SaveChangesAsync();
        //    return CreatedAtAction("GetAuthor", new {id = author.AuthorID},author);
        //}

        //// DELETE: api/Authors/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteAuthor(int id)
        //{
        //    var author = await _context.Author.FindAsync(id);
        //    if (author == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Author.Remove(author);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool AuthorExists(int id)
        //{
        //    return _context.Author.Any(e => e.AuthorID == id);
        //}
    }
}
