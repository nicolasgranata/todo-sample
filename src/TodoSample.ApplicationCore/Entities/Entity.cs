using System;
using TodoSample.ApplicationCore.Interfaces;

namespace TodoSample.ApplicationCore.Entities
{
    public abstract class Entity
    {
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
