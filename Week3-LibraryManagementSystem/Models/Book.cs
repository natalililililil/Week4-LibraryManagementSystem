namespace Week3_LibraryManagementSystem.Models
{
    public class Book : IEntity
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public int PublishedYear { get; set; }
        public Guid AuthorId { get; set; }
    }
}
