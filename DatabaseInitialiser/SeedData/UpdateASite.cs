using System.Linq;
using Marten;
using Commands.Site;
using Domain.Model;

namespace DatabaseInitialiser.SeedData
{
    public class UpdateASite : ISeed
    {
        public void Run(IDocumentSession session)
        {
            var usa = session.Query<Country>().Single(c => c.CountryName == "USA");
            var ngaio = session.Query<Site>().Single(s => s.SiteName == "Ngaio");

            new EditSiteCommand(session) { Id = ngaio.Id, Location = "Lake Isabella", SiteName = "Weldon", CountryId = usa.Id}.Execute();
        }
    }
}
