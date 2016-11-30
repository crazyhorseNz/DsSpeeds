using Commands;
using Commands.People;
using Marten;

namespace DatabaseInitialiser.SeedData
{
    public class People : ISeed
    {
        public void Run(IDocumentSession session)
        {
            new CreatePersonCommand(session) { Email = "peteg@hotmail.co.nz", FirstName = "Pete", LastName = "Glassey", UserName = "peteg" }.Execute();
            new CreatePersonCommand(session) { Email = "peewee@hotmail.co.nz", FirstName = "Pete", LastName = "Williams", UserName = "peewee" }.Execute();
            new CreatePersonCommand(session) { Email = "jono@jonoindustries.com", FirstName = "Jono", LastName = "Ashton", UserName = "jono" }.Execute();
            new CreatePersonCommand(session) { Email = "papa@smurfvillage.com", FirstName = "Papa", LastName = "Smurf", UserName = "psmurf" }.Execute();
        }
    }
}
