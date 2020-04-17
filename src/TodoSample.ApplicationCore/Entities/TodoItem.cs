namespace TodoSample.ApplicationCore.Entities
{
    public class TodoItem : Entity<int>
    {
        public string Name { get; set; }
        public bool IsCompleted { get; set; }
    }
}
