using Commands;
using Marten;

namespace DatabaseInitialiser.SeedData
{
    public class People : ISeed
    {
        public void Run(IDocumentSession session)
        {
            new CreatePersonCommand() { Email = "peteg@hotmail.co.nz", FirstName = "Pete", LastName = "Glassey", UserName = "peteg" }.Execute(session);
            new CreatePersonCommand() { Email = "papa@smurfvillage.com", FirstName = "Papa", LastName = "Smurf", UserName = "psmurf" }.Execute(session);
        }
    }
}
