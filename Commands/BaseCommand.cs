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

        public IDocumentSession DocumentSession { get; set; }
    }
}
