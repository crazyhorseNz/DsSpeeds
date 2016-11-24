using Marten;
using System;

namespace Read
{
    public class BaseReadModel : IReadModel
    {
        public Guid Id { get; set; } 
    }
}
