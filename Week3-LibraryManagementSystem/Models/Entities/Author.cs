namespace Week3_LibraryManagementSystem.Models.Entities
{
    public class Author : IEntity
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ICollection<Book>? Books { get; set; }
    }
}
