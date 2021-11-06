﻿using System;
using MfPulse.Mongo.Document;

namespace MfPulse.Company.Contract.Models
{
    public record CompanyDocument : IDocument
    {
        public string Id { get; set; }
        public bool IsArchived { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string Name { get; set; }
    }
}