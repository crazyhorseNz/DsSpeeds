using System;
using Shared;

namespace Domain.Events
{
    public class CountryCreated : IDomainEvent
    {
        public string CountryName { get; set; }
    }
}
