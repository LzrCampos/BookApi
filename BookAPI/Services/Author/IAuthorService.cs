using BookAPI.DTO.Author;
using BookAPI.Models;

namespace BookAPI.Services.Author
{
    public interface IAuthorService
    {
        Task<ResponseModel<List<AuthorModel>>> ListAllAuthors();
        Task<ResponseModel<AuthorModel>> GetAuthorById(int authorId);
        Task<ResponseModel<AuthorModel>> GetAuthorByBookId(int bookId);
        Task<ResponseModel<List<AuthorModel>>> CreateAuthor(AuthorCreateDto authorCreateDto);
        Task<ResponseModel<List<AuthorModel>>> UpdateAuthor(AuthorUpdateDto authorUpdateDto);
        Task<ResponseModel<List<AuthorModel>>> DeleteAuthor(int authorId);
    }
}
