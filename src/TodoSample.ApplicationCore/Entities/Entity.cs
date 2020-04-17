using System;
using TodoSample.ApplicationCore.Interfaces;

namespace TodoSample.ApplicationCore.Entities
{
    public class Entity<TKey> : IEntity where TKey : IComparable, IFormattable
    {
        public TKey Id { get; set; }
        public long Version { get; set; }
    }
}
