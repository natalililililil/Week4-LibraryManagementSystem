namespace Week3_LibraryManagementSystem.Models.DTOs
{
    public class BookDto
    {
        public required string Title { get; set; }
        public int PublishedYear { get; set; }
        public int AuthorId { get; set; }
    }
}
