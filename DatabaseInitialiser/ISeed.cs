using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marten;

namespace DatabaseInitialiser
{
    public interface ISeed
    {
        void Run(IDocumentSession session);
    }
}
