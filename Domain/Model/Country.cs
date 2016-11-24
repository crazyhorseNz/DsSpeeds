using AutoMapper;
using Domain.Events;

namespace Domain.Model
{
    public class Country : Entity
    {
        public string CountryName { get; set; }

        public void Apply(CountryCreated createdEvent)
        {
            Mapper.Map(createdEvent, this);
        }
    }
}
