﻿using System;
using Shared;

namespace Domain.Events
{
    public class SiteCreated : IDomainEvent
    {
        public string SiteName { get; set; }

        public string Location { get; set; }

        //public Guid CountryId { get; set; }

    }
}