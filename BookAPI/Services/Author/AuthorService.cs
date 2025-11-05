using Azure;
using BookAPI.Data;
using BookAPI.DTO.Author;
using BookAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookAPI.Services.Author
{
    public class AuthorService : IAuthorService
    {
        private readonly AppDbContext _context;
        public AuthorService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<AuthorModel>>> CreateAuthor(AuthorCreateDto authorCreateDto)
        {
            ResponseModel<List<AuthorModel>> response = new ResponseModel<List<AuthorModel>>();
            try
            {
                var author = new AuthorModel
                {
                    Name = authorCreateDto.Name,
                    LastName = authorCreateDto.LastName
                };

                _context.Authors.Add(author);
                await _context.SaveChangesAsync();

                response.Data = await _context.Authors.ToListAsync();
                response.Message = "Author created successfully.";
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

        public async Task<ResponseModel<List<AuthorModel>>> DeleteAuthor(int authorId)
        {
            ResponseModel<List<AuthorModel>> response = new ResponseModel<List<AuthorModel>>();
            try
            {
                var author = await _context.Authors.FirstOrDefaultAsync(a => a.Id == authorId);
                if (author == null)
                {
                    response.Message = "Author not found.";
                    response.Status = false;
                    response.Data = null;
                    return response;
                }
                _context.Authors.Remove(author);
                await _context.SaveChangesAsync();
                response.Message = "Author deleted successfully.";
                response.Data = await _context.Authors.ToListAsync();
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

        public async Task<ResponseModel<AuthorModel>> GetAuthorByBookId(int bookId)
        {
            ResponseModel<AuthorModel> response = new ResponseModel<AuthorModel>();
            try
            {
                var book = await _context.Books
                    .Include(a => a.Author)
                    .FirstOrDefaultAsync(b => b.Id == bookId);

                if (book == null)
                {
                    response.Message = "Author not found.";
                    response.Status = false;
                    response.Data = null;
                    return response;
                }
                response.Message = "Author retrieved successfully.";
                response.Status = true;
                response.Data = book.Author;
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

        public async Task<ResponseModel<AuthorModel>> GetAuthorById(int authorId)
        {
            ResponseModel<AuthorModel> response = new ResponseModel<AuthorModel>();
            try
            {
                var author = await _context.Authors.FirstOrDefaultAsync(a => a.Id == authorId);
                if (author == null)
                {
                    response.Message = "Author not found.";
                    response.Status = false;
                    response.Data = null;
                    return response;
                }
                response.Message = "Author retrieved successfully.";
                response.Status = true;
                response.Data = author;
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

        public async Task<ResponseModel<List<AuthorModel>>> ListAllAuthors()
        {
            ResponseModel<List<AuthorModel>> response = new ResponseModel<List<AuthorModel>>();
            try
            {
                var authors = await _context.Authors.ToListAsync();

                response.Message = "Authors retrieved successfully.";
                response.Status = true;
                response.Data = authors;
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

        public async Task<ResponseModel<List<AuthorModel>>> UpdateAuthor(AuthorUpdateDto authorUpdateDto)
        {
            ResponseModel<List<AuthorModel>> response = new ResponseModel<List<AuthorModel>>();
            try
            {
                var author = await _context.Authors.FirstOrDefaultAsync(a => a.Id == authorUpdateDto.Id);
                if (author == null)
                {
                    response.Message = "Author not found.";
                    response.Status = false;
                    response.Data = null;
                    return response;
                }

                author.Name = authorUpdateDto.Name;
                author.LastName = authorUpdateDto.LastName;
                _context.Authors.Update(author);
                await _context.SaveChangesAsync();

                response.Data = await _context.Authors.ToListAsync();
                response.Message = "Author updated successfully.";
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
