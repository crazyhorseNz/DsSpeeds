using Marten;
using System;
using System.Linq;
using Commands.Speed;

namespace DatabaseInitialiser.SeedData
{
    public class VerifyAndRejectSpeedClaims : ISeed
    {
        public void Run(IDocumentSession session)
        {
            var papaSmurfId = session.Query<Domain.Model.Person>().Single(p => p.UserName == "psmurf").Id;

            var rejectSpeedId =
                session.Query<Domain.Model.Speed>().Single(rs => rs.SpeedInMilesPerHour == 111999).Id;

            var verifiedSpeedId =
                session.Query<Domain.Model.Speed>().Single(rs => rs.SpeedInMilesPerHour == 99).Id;

            new VerifySpeedClaimCommand(session){Id = verifiedSpeedId}.Execute();

            new DeleteRecordedSpeedCommand(session)
            {
                Id = rejectSpeedId,
                SpeedDeletionDate = DateTime.Now,
                DeletedById = papaSmurfId
            }.Execute();
        }
    }
}
