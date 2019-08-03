using System;

namespace Entities.Models
{
    public abstract class Entity<T> where T : IEquatable<T>
    {
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public T Id { get; set; }
    }
}
