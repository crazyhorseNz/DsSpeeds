using AutoMapper;
using Domain.Events;

namespace Domain.Model
{
    public class Person : Entity
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public void Apply(PersonCreated createdEvent)
        {
            Mapper.Map(createdEvent, this);
        }
    }
}
