namespace Week3_LibraryManagementSystem.Models.Entities
{
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }
}
