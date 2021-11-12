using System;

namespace TodoSample.Domain.Common
{
    public abstract class Entity
    {
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
