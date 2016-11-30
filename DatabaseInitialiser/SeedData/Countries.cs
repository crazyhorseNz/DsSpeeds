using Commands;
using Commands.Country;
using Marten;

namespace DatabaseInitialiser.SeedData
{
    public class Countries : ISeed
    {
        public void Run(IDocumentSession session)
        {
            new CreateCountryCommand(session) { CountryName = "New Zealand" }.Execute();
            new CreateCountryCommand(session) { CountryName = "Australia" }.Execute();
            new CreateCountryCommand(session) { CountryName = "USA" }.Execute();
            new CreateCountryCommand(session) { CountryName = "Germany" }.Execute();
            new CreateCountryCommand(session) { CountryName = "Japan" }.Execute();
            new CreateCountryCommand(session) { CountryName = "England" }.Execute();
        }
    }
}
