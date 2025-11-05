using BookAPI.DTO.Author;
using BookAPI.DTO.Book;
using BookAPI.Models;

namespace BookAPI.Services.Book
{
    public interface IBookService
    {
        Task<ResponseModel<List<BookModel>>> ListAllBooks();
        Task<ResponseModel<BookModel>> GetBookById(int bookId);
        Task<ResponseModel<List<BookModel>>> GetBooksByAuthorId(int authorId);
        Task<ResponseModel<List<BookModel>>> CreateBook(BookCreateDto bookId);
        Task<ResponseModel<List<BookModel>>> UpdateBook(BookUpdateDto authorUpdateDto);
        Task<ResponseModel<List<BookModel>>> DeleteBook(int bookId);
    }
}
