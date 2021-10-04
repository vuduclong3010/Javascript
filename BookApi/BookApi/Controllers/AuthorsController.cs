using BookApi.Data.Service;
using BookApi.Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly AuthorService _authorService;

        public AuthorsController(AuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpPost("add-author")]
        public IActionResult AddAuthor([FromBody] AuthorVM author)
        {
            _authorService.AddAuthor(author);
            return Ok();
        }

        [HttpGet("get-author-with-book")]
        public IActionResult GetAllAuthorWithBook()
        {
            var response = _authorService.GetAllAuthorwithBook();
            return Ok(response);
        }

        [HttpGet("get-author-with-book-by-id/{authorid}")]
        public IActionResult GetAuthorWithBookById(int authorid)
        {
            var response = _authorService.GetAuthorWithBookById(authorid);
            return Ok(response);
        }

        [HttpPut("put-author-by-id/{id}")]
        public IActionResult UpdatePublisherById(int id, [FromBody] AuthorVM author)
        {
            var updateAuthor = _authorService.UpdateAuthorById(id, author);
            return Ok(updateAuthor);
        }

        [HttpDelete("Deleta-author-by-id/{id}")]
        public IActionResult DeleteAuthorById(int id)
        {
            _authorService.DeleteAuthorById(id);
            return Ok();
        }
    }
}
