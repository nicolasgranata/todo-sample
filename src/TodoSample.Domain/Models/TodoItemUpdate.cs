namespace TodoSample.Domain.Models
{
    public class TodoItemUpdate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsCompleted { get; set; }
    }
}
