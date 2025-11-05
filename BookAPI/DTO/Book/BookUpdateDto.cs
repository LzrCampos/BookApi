namespace BookAPI.DTO.Book
{
    public class BookUpdateDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int AuthorId { get; set; }
    }
}
