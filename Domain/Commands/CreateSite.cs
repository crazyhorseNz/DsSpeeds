using System;
using Shared;

namespace Domain.Commands
{
    public class CreateSite : ICommand
    {
        public string SiteName { get; set; }

        public string Location { get; set; }

        public Guid CountryId { get; set; }

    }
}
