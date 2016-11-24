using Marten;

namespace Commands
{
    public abstract class BaseCommand
    {
        public IDocumentStore DocumentStore { get; set; }
    }
}
