using Commands.SpeedClaims;
using Marten;
using System;
using System.Linq;

namespace DatabaseInitialiser.SeedData
{
    public class VerifyAndRejectSpeedClaims : ISeed
    {
        public void Run(IDocumentSession session)
        {
            var papaSmurfId = session.Query<Domain.Model.Person>().Single(p => p.UserName == "psmurf").Id;

            var rejectSpeedId =
                session.Query<Domain.Model.RecordedSpeed>().Single(rs => rs.SpeedInMilesPerHour == 111999).Id;

            var verifiedSpeedId =
                session.Query<Domain.Model.RecordedSpeed>().Single(rs => rs.SpeedInMilesPerHour == 99).Id;

            new VerifySpeedClaimCommand(session)
            {
                Id = verifiedSpeedId,
                SpeedVerifiedDate = DateTime.Now,
                VerifiedById = papaSmurfId
            }.Execute(session);

            new DeleteRecordedSpeedCommand(session)
            {
                Id = rejectSpeedId,
                SpeedDeletionDate = DateTime.Now,
                DeletedById = papaSmurfId
            }.Execute(session);
        }
    }
}
