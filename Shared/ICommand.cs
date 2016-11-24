using Marten;
using System;

namespace Shared
{
    public interface ICommand
    {
        Guid? Execute(IDocumentSession session);

        void Validate(IDocumentSession session);
    }
}
