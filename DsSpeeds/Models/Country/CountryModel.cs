using System.Linq;
using Read.Models;

namespace DsSpeeds.Models.Country
{
    public class CountryModel
    {
        public CountryModel(CountryReadModel readModel)
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
                        PilotName = summary.PilotName,
                        SiteName = summary.SiteName,
                        SiteLocation = summary.SiteLocation,
                        SiteCountryName = readModel.CountryName,
                        IsVerified = true
                    }).ToList()
            };
        }

        public SpeedListModel SpeedList { get; set; }

        public CountryReadModel ReadModel { get; set; }
    }
}
