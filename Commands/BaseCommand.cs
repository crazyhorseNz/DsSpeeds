using Marten;

namespace Commands
{
    public abstract class BaseCommand
    {
        protected BaseCommand()
        {
        }

        protected BaseCommand(IDocumentSession docSession)
        {
            DocumentSession = docSession;
        }

        protected IDocumentSession DocumentSession { get; set; }
    }
}
