using System.Linq;
using Commands;
using Marten;
using Commands.Site;
using Domain.Model;

namespace DatabaseInitialiser.SeedData
{
    public class Sites : ISeed
    {
        public void Run(IDocumentSession session)
        {
            var nz = session.Query<Country>().Single(c => c.CountryName == "New Zealand");

            new CreateSiteCommand(session) { Location = "Wellington", SiteName = "Ngaio", CountryId = nz.Id}.Execute();
            new CreateSiteCommand(session) { Location = "Wellington", SiteName = "Long Gully", CountryId = nz.Id }.Execute();
        }
    }
}
