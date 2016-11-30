using System.Linq;
using Read.Models;

namespace DsSpeeds.Models.People
{
    public class PersonModel
    {
        public PersonModel(PersonReadModel readModel)
        {
            ReadModel = readModel;

            SpeedList = new SpeedListModel
            {
                SpeedList = readModel.AllVerifiedSpeeds
                    .Select(summary => new SpeedReadModel
                    {
                        Id = summary.SpeedId,
                        Date = summary.Date,
                        SpeedInMilesPerHour = summary.SpeedInMilesPerHour,
                        AircraftName = summary.AircraftName,
                        PilotName = readModel.UserName,
                        SiteName = summary.SiteName,
                        SiteLocation = summary.SiteLocation,
                        SiteCountryName = summary.SiteCountryName,
                        IsVerified = true
                    }).ToList()
            };
        }

        public SpeedListModel SpeedList { get; set; }

        public PersonReadModel ReadModel { get; set; }
    }
}
