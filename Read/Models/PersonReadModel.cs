using Domain.Events;
using System;
using System.Collections.Generic;

namespace Read.Models
{
    public class PersonReadModel : BaseReadModel
    {
        public PersonReadModel()
        {
            AllVerifiedSpeeds = new List<PersonSpeedReadModel>();
        }

        public string PersonName { get; set; }

        public List<PersonSpeedReadModel> AllVerifiedSpeeds { get; set; }

        public void Apply(PersonCreated createdEvent)
        {
            PersonName = createdEvent.UserName;
        }


        public class PersonSpeedReadModel
        {
            public Guid SpeedId { get; set; }

            public DateTime Date { get; set; }

            public long SpeedInMilesPerHour { get; set; }

            public string AircraftName { get; set; }

            public string SiteName { get; set; }

            public string SiteLocation { get; set; }

            public string SiteCountryName { get; set; }
        }
    }
}
