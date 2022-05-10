using Microsoft.AspNetCore.Mvc.Infrastructure;
using mini.api.Controllers;
using mini.DAL;
using mini.DAL.Database.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace mini.test
{
    /// <summary>
    /// jeg vil gerne kunne teste dal layer og kun det
    /// DSV vi kommer ikke til at benytte databse mm.
    /// DSV vi kan ikke teste det vu gerne vil...
    /// AAA
    /// ARRANGE  - DEFINITON (VARIABLER MM)
    /// ACT      - RESULT (INVOKE VORES METODER MM)
    /// ASSERT   - SAMMENLIGNE 2 VÆRDIER
    ///          - RETUNERE JEG DET RIGTIGE OSV...
    ///          
    /// 
    /// </summary>

    public class AuthorControllerTest
    {
        //System under test
        private readonly AuthorsController _sut;
        private readonly Mock<IAuthorRepository> _authorRepo = new();
        public AuthorControllerTest()
        {
            //_sut = new AuthorsController(NormalizationForm vil jeg have  IAuthorRepository)
            _sut = new AuthorsController(_authorRepo.Object);
        }
        [Fact]
        public async void getAllAuthors_ShouldReturn200()
        {
            List<Author> authorList = new List<Author>
            {
                new Author{AuthorID=1, age=33,isAlive=true,name="Paula",password="12345"},
                new Author{AuthorID=1, age=11,isAlive=true,name="Paula",password="12345"},
                new Author{AuthorID=1, age=22,isAlive=true,name="Paula",password="12345"},
            };
            _authorRepo.Setup((IAuthorRepository objOfRepository) => objOfRepository.getAllAuthors())
                .ReturnsAsync(authorList);
            //_authorRepo.Setup(objOfRepository => objOfRepository.getAllAuthors())
            //    .ReturnsAsync(authorList);

            var result = await _sut.getAllauthors();
            var status = (IStatusCodeActionResult)result;
            Assert.Equal(200, status.StatusCode);

        }
        [Fact]
        public async void getAllAuthors_ShouldReturn204()
        {
            List<Author> authorList = new();

            _authorRepo
            .Setup(x => x.getAllAuthors())
            .ReturnsAsync(authorList);

            var result = await _sut.getAllauthors();

            var status = (IStatusCodeActionResult)result;
            Assert.Equal(204, status.StatusCode);
            
        }
        [Fact]
        public async void GetAllAuthors_ShouldReturn500()
        {
            _authorRepo
            .Setup(x =>x.getAllAuthors())
            .ReturnsAsync(() => null);
            
            var result = await _sut.getAllauthors();

            var status = (IStatusCodeActionResult)result;
            Assert.Equal(500, status.StatusCode);
        }

    }
}
