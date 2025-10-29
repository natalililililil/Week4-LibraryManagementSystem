using System.Text.Json.Serialization;

namespace Week3_LibraryManagementSystem.Models.Entities
{
    public class Book : IEntity<int>
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public int PublishedYear { get; set; }
        public int AuthorId { get; set; }
        [JsonIgnore]
        public Author? Author { get; set; }
    }
}
