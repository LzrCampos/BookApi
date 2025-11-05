using BookAPI.Data;
using BookAPI.DTO.Author;
using BookAPI.DTO.Book;
using BookAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookAPI.Services.Book
{
    public class BookService : IBookService
    {
        private readonly AppDbContext _context;
        public BookService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<BookModel>>> CreateBook(BookCreateDto bookCreateDto)
        {
            ResponseModel<List<BookModel>> response = new ResponseModel<List<BookModel>>();
            try
            {
                var author = await _context.Authors.FirstOrDefaultAsync(a => a.Id == bookCreateDto.AuthorId);
                if (author == null)
                {
                    response.Message = "Author not found.";
                    response.Status = false;
                    response.Data = null;
                    return response;
                }

                var book = new BookModel
                {
                    Title = bookCreateDto.Title,
                    Author = author
                };

                _context.Books.Add(book);
                await _context.SaveChangesAsync();

                response.Data = await _context.Books.Include(a => a.Author).ToListAsync();
                response.Message = "Book created successfully.";
                response.Status = true;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                response.Data = null;
                return response;
            }
        }

        public async Task<ResponseModel<List<BookModel>>> DeleteBook(int bookId)
        {
            ResponseModel<List<BookModel>> response = new ResponseModel<List<BookModel>>();
            try
            {
                var book = await _context.Books.FirstOrDefaultAsync(a => a.Id == bookId);
                if (book == null)
                {
                    response.Message = "Book not found.";
                    response.Status = false;
                    response.Data = null;
                    return response;
                }
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
                response.Message = "Book deleted successfully.";
                response.Data = await _context.Books.Include(a => a.Author).ToListAsync();
                response.Status = true;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                response.Data = null;
                return response;
            }
        }

        public async Task<ResponseModel<List<BookModel>>> GetBooksByAuthorId(int authorId)
        {
            ResponseModel<List<BookModel>> response = new ResponseModel<List<BookModel>>();
            try
            {
                var books = await _context.Books
                    .Include(a => a.Author)
                    .Where(b => b.Author.Id == authorId)
                    .ToListAsync();

                if (books == null)
                {
                    response.Message = "Book not found.";
                    response.Status = false;
                    response.Data = null;
                    return response;
                }
                response.Message = "Book retrieved successfully.";
                response.Status = true;
                response.Data = books;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                response.Data = null;
                return response;
            }
        }

        public async Task<ResponseModel<BookModel>> GetBookById(int bookId)
        {
            ResponseModel<BookModel> response = new ResponseModel<BookModel>();
            try
            {
                var book = await _context.Books.FirstOrDefaultAsync(a => a.Id == bookId);
                if (book == null)
                {
                    response.Message = "Book not found.";
                    response.Status = false;
                    response.Data = null;
                    return response;
                }
                response.Message = "Book retrieved successfully.";
                response.Status = true;
                response.Data = book;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                response.Data = null;
                return response;
            }
        }

        public async Task<ResponseModel<List<BookModel>>> ListAllBooks()
        {
            ResponseModel<List<BookModel>> response = new ResponseModel<List<BookModel>>();
            try
            {
                var books = await _context.Books.Include(a => a.Author).ToListAsync();

                response.Message = "Books retrieved successfully.";
                response.Status = true;
                response.Data = books;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                response.Data = null;
                return response;
            }
        }

        public async Task<ResponseModel<List<BookModel>>> UpdateBook(BookUpdateDto bookUpdateDto)
        {
            ResponseModel<List<BookModel>> response = new ResponseModel<List<BookModel>>();
            try
            {
                var book = await _context.Books.Include(a => a.Author).FirstOrDefaultAsync(a => a.Id == bookUpdateDto.Id);
                if (book == null)
                {
                    response.Message = "Book not found.";
                    response.Status = false;
                    response.Data = null;
                    return response;
                }

                var author = await _context.Authors.FirstOrDefaultAsync(a => a.Id == bookUpdateDto.AuthorId);
                if (author == null)
                {
                    response.Message = "Book not found.";
                    response.Status = false;
                    response.Data = null;
                    return response;
                }

                book.Title = bookUpdateDto.Title;
                book.Author = author;
                _context.Books.Update(book);
                await _context.SaveChangesAsync();

                response.Data = await _context.Books.ToListAsync();
                response.Message = "Book updated successfully.";
                response.Status = true;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                response.Data = null;
                return response;
            }
        }
    }
}
