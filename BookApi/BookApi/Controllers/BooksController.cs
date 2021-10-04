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
    public class BooksController : ControllerBase
    {
        public BookService _bookService;

        public BooksController(BookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost("add-book-with-author")]
        public IActionResult AddBook([FromBody] BookVM book)
        {
            _bookService.AddBookWithAuthor(book);
            return Ok();
        }

        [HttpGet("get-all-book")]
        public IActionResult GetAllBook()
        {
            var books = _bookService.GetAllBooks();
            return Ok(books);
        }

        [HttpGet("get-book-by-id/{bookid}")]
        public IActionResult GetBookById(int bookid)
        {
            var book = _bookService.GetBookById(bookid);
            return Ok(book);
        }

        [HttpPut("update-book-by-id/{bookid}")]
        public IActionResult UpdateBookById(int bookid, [FromBody] BookVM book)
        {
            var updateBook = _bookService.UpdateBookById(bookid, book);
            return Ok(updateBook);
        }

        [HttpDelete("delete-book-by-id/{bookid}")]
        public IActionResult DeleteBookById(int bookid)
        {
            _bookService.DeleteBookById(bookid);
            return Ok();
        }
    }
}
