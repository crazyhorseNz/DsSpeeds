using System;
using Domain.Model;
using Shared;

namespace Domain.Events
{
    public class PersonCreated : IDomainEvent
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
