using BookAPI.DTO.Book;
using BookAPI.Models;
using BookAPI.Services.Book;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("ListAllBooks")]
        public async Task<ActionResult<ResponseModel<List<BookModel>>>> ListAllBooks()
        {
            var response = await _bookService.ListAllBooks();
            if (response.Status)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("GetBookById/{bookId}")]
        public async Task<ActionResult<ResponseModel<BookModel>>> GetBookById(int bookId)
        {
            var response = await _bookService.GetBookById(bookId);
            if (response.Status)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("GetBooksByAuthor/{authorId}")]
        public async Task<ActionResult<ResponseModel<List<BookModel>>>> GetBooksByAuthor(int authorId)
        {
            var response = await _bookService.GetBooksByAuthorId(authorId);
            if (response.Status)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPost("CreateBook")]
        public async Task<ActionResult<ResponseModel<List<BookModel>>>> CreateBook([FromBody] BookCreateDto bookCreateDto)
        {
            var response = await _bookService.CreateBook(bookCreateDto);
            if (response.Status)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut("UpdateBook")]
        public async Task<ActionResult<ResponseModel<List<BookModel>>>> UpdateBook([FromBody] BookUpdateDto bookUpdateDto)
        {
            var response = await _bookService.UpdateBook(bookUpdateDto);
            if (response.Status)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("DeleteBook/{bookId}")]
        public async Task<ActionResult<ResponseModel<List<BookModel>>>> DeleteBook(int bookId)
        {
            var response = await _bookService.DeleteBook(bookId);
            if (response.Status)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

    }
}
