using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using mini.DAL.Database.Models;
namespace mini.DAL
{

    public interface IAuthorRepository
    {
        Task<List<Author>> getAllAuthors();
        Author getAuthor(int authorId);
        Task<int>createAuthor(Author author);
        Task<Author> deleteAuthor(int authorId);
        //BOOK interface
        Task<book> getBook(int bookId);
        Task<int> Createbook(int bookId);
        Task<book> Bookdelete(int bookId);
    }


    public class AuthorRepository : IAuthorRepository
    {
         
         private readonly Abcontext context;
         public AuthorRepository(Abcontext context)
         { 
         this.context = context;
         }
        public async Task<List<Author>> getAllAuthors()
        {
            return await context.Author.ToListAsync();
        }
        public Author getAuthor(int authorId) 
        {
            return context.Author.FirstOrDefault((authorObj) => authorObj.AuthorID ==authorId);
        }
        
        public async Task<int>createAuthor(Author author)
        {
            var temp = context.Author.Add(author);
            int t = await context.SaveChangesAsync();
            return t;
        }
        public void delete(int authorId) { }

        
        public async Task<Author> deleteAuthor(int authorId)
        {
            //authorExists = context.Author.FirstOrDefaultAsync(græsk)
            var authorExists = getAuthor(authorId);
            if (authorExists != null)
            {
                context.Author.Remove(authorExists);
                await context.SaveChangesAsync();    
            }
            return authorExists;
        }
        //BOOK CODE
        public async Task<book> getBook(int bookId)
        {
            return await context.Books.FirstOrDefaultAsync(x => x.BookID == bookId);
        }
        public async Task Bookdelete(int bookId)
        {
            book book = await getBook(bookId);
            context.Books.Remove(book);
        }
        public async Task<int>CreateBook(book bookId)
        {
            var temp = context.Books.Add(bookId);
            var t = await context.SaveChangesAsync();
            return t;
        }

        //TEMP FIX
        public Task<int> Createbook(int bookId)
        {
            throw new NotImplementedException();
        }

        Task<book> IAuthorRepository.Bookdelete(int bookId)
        {
            throw new NotImplementedException();
        }

    }
}
