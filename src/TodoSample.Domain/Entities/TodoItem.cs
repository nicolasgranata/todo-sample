using TodoSample.Domain.Common;

namespace TodoSample.Domain.Entities
{
    public class TodoItem : Entity
    {
        public string Name { get; set; }
        public bool IsCompleted { get; set; }
    }
}
