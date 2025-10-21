namespace Week3_LibraryManagementSystem.Models
{
    public class Author : IEntity
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
