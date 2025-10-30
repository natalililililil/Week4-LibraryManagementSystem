namespace Week3_LibraryManagementSystem.Models.DTOs
{
    public class AuthorWithBookCountDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int BookCount { get; set; }
    }
}
    