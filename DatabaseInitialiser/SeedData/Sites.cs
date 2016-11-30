using Commands.Site;
using Domain.Model;
using Marten;
using System.Linq;

namespace DatabaseInitialiser.SeedData
{
    public class Sites : ISeed
    {
        public void Run(IDocumentSession session)
        {
            var nz = session.Query<Country>().Single(c => c.CountryName == "New Zealand");
            var aus = session.Query<Country>().Single(c => c.CountryName == "Australia");
            var usa = session.Query<Country>().Single(c => c.CountryName == "USA");

            new CreateSiteCommand(session) { Location = "Wellington", SiteName = "Ngaio", CountryId = nz.Id}.Execute();
            new CreateSiteCommand(session) { Location = "Wellington", SiteName = "Long Gully", CountryId = nz.Id }.Execute();
            new CreateSiteCommand(session) { Location = "Tekapo", SiteName = "Tekapo", CountryId = nz.Id }.Execute();
            new CreateSiteCommand(session) { Location = "Queensland", SiteName = "Cactus Ridge", CountryId = aus.Id }.Execute();
            new CreateSiteCommand(session) { Location = "Lake Isabella", SiteName = "Mars", CountryId = usa.Id }.Execute();
        }
    }
}
