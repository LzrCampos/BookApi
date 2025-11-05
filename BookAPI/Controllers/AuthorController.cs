using BookAPI.DTO.Author;
using BookAPI.Models;
using BookAPI.Services.Author;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet("ListAllAuthors")]
        public async Task<ActionResult<ResponseModel<List<AuthorModel>>>> ListAllAuthors()
        {
            var response = await _authorService.ListAllAuthors();
            if (response.Status)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("GetAuthorById/{authorId}")]
        public async Task<ActionResult<ResponseModel<AuthorModel>>> GetAuthorById(int authorId)
        {
            var response = await _authorService.GetAuthorById(authorId);
            if (response.Status)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("GetAuthorByBookId/{bookId}")]
        public async Task<ActionResult<ResponseModel<AuthorModel>>> GetAuthorByBookId(int bookId)
        {
            var response = await _authorService.GetAuthorByBookId(bookId);
            if (response.Status)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPost("CreateAuthor")]
        public async Task<ActionResult<ResponseModel<List<AuthorModel>>>> CreateAuthor([FromBody] AuthorCreateDto authorCreateDto)
        {
            var response = await _authorService.CreateAuthor(authorCreateDto);
            if (response.Status)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut("UpdateAuthor")]
        public async Task<ActionResult<ResponseModel<List<AuthorModel>>>> UpdateAuthor([FromBody] AuthorUpdateDto authorUpdateDto)
        {
            var response = await _authorService.UpdateAuthor(authorUpdateDto);
            if (response.Status)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("DeleteAuthor/{authorId}")]
        public async Task<ActionResult<ResponseModel<List<AuthorModel>>>> DeleteAuthor(int authorId)
        {
            var response = await _authorService.DeleteAuthor(authorId);
            if (response.Status)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}
