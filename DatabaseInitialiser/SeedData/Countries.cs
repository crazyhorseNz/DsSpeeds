using Commands;
using Marten;

namespace DatabaseInitialiser.SeedData
{
    public class Countries : ISeed
    {
        public void Run(IDocumentSession session)
        {
            new CreateCountryCommand { CountryName = "New Zealand" }.Execute(session);
            new CreateCountryCommand { CountryName = "USA" }.Execute(session);
            new CreateCountryCommand { CountryName = "Germany" }.Execute(session);
            new CreateCountryCommand { CountryName = "Japan" }.Execute(session);
            new CreateCountryCommand { CountryName = "England" }.Execute(session);
        }
    }
}
