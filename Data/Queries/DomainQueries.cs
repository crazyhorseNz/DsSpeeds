using Marten;
using System;
using System.Linq;

namespace Data.Queries
{
    public static class DomainQueries
    {
        public static bool Exists<TDom>(this IDocumentSession session, Guid id)
            where TDom : Domain.Model.Entity
        {
            return session.Query<TDom>().Any(e => e.Id == id);
        }
    }
}
