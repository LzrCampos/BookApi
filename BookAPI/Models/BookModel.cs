using System.Text.Json.Serialization;

namespace BookAPI.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public AuthorModel Author { get; set; }
        public string Image { get; set; }
    }
}
