using System.Linq;
using Read.Models;

namespace DsSpeeds.Models.Site
{
    public class SiteModel
    {
        public SiteModel(SiteReadModel readModel)
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
                        SiteName = readModel.SiteName,
                        SiteLocation = readModel.Location,
                        SiteCountryName = readModel.CountryName,
                        IsVerified = true
                    }).ToList()
            };
        }

        public SpeedListModel SpeedList { get; set; }
        public SiteReadModel ReadModel { get; set; }
    }
}
