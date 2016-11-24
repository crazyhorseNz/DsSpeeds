using Commands;
using Marten;

namespace DatabaseInitialiser.SeedData
{
    public class Countries : ISeed
    {
        public void Run(IDocumentSession session)
        {
            new CreateCountryCommand(session) { CountryName = "New Zealand" }.Execute(session);
            new CreateCountryCommand(session) { CountryName = "USA" }.Execute(session);
            new CreateCountryCommand(session) { CountryName = "Germany" }.Execute(session);
            new CreateCountryCommand(session) { CountryName = "Japan" }.Execute(session);
            new CreateCountryCommand(session) { CountryName = "England" }.Execute(session);
        }
    }
}
