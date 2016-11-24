using Commands;
using Marten;

namespace DatabaseInitialiser.SeedData
{
    public class Sites : ISeed
    {
        public void Run(IDocumentSession session)
        {
            new CreateSiteCommand { Location = "Wellington", SiteName = "Ngaio" }.Execute(session);
            new CreateSiteCommand { Location = "Wellington", SiteName = "Long Gully" }.Execute(session);
        }
    }
}
