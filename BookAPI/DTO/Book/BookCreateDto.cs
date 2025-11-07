namespace BookAPI.DTO.Book
{
    public class BookCreateDto
    {
        public string? Title { get; set; }
        public int AuthorId { get; set; }
        public string Image { get; set; }
    }
}
