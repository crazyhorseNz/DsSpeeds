using Commands;
using Marten;
using Commands.Site;

namespace DatabaseInitialiser.SeedData
{
    public class Sites : ISeed
    {
        public void Run(IDocumentSession session)
        {
            new CreateSiteCommand(session) { Location = "Wellington", SiteName = "Ngaio" }.Execute();
            new CreateSiteCommand(session) { Location = "Wellington", SiteName = "Long Gully" }.Execute();
        }
    }
}
