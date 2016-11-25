using Marten;
using System;

namespace Shared
{
    public interface ICommand
    {
        Guid? Execute();

        void Validate();
    }
}
