using Commands;
using Marten;

namespace DatabaseInitialiser.SeedData
{
    public class Sites : ISeed
    {
        public void Run(IDocumentSession session)
        {
            new CreateSiteCommand(session) { Location = "Wellington", SiteName = "Ngaio" }.Execute(session);
            new CreateSiteCommand(session) { Location = "Wellington", SiteName = "Long Gully" }.Execute(session);
        }
    }
}
