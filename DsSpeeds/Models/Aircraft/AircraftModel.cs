using System.Linq;
using Read.Models;

namespace DsSpeeds.Models.Aircraft
{
    public class AircraftModel
    {
        public AircraftModel(AircraftReadModel readModel)
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
                        AircraftName = readModel.AircraftName,
                        PilotName = summary.PilotName,
                        SiteName = summary.SiteName,
                        SiteLocation = summary.SiteLocation,
                        SiteCountryName = summary.SiteCountryName,
                        IsVerified = true
                    }).ToList()
            };
        }

        public SpeedListModel SpeedList { get; set; }

        public AircraftReadModel ReadModel { get; set; }
    }
}
