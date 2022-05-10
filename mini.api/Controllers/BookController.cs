using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mini.DAL;
using mini.DAL.Database.Models;
using System.Threading.Tasks;

namespace mini.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IAuthorRepository context;
        public BookController (IAuthorRepository a)
        {
            context = a;
        }
        [HttpGet]
        public async Task<ActionResult<book>> GetBook(int bookid)
        {
            return await context.getBook(bookid);
        }
        [HttpPost]
        public async Task<ActionResult<book>> CreateBook(book book)
        {
            Abcontext _context = new Abcontext();

            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return CreatedAtAction("Getbook", new { id = book.BookID }, book);
        }
        [HttpDelete]
        public async Task<ActionResult<book>> DeleteBook(int bookid)
        {
            return await context.getBook(bookid);
        }
    }
}
