using System;
using MfPulse.Mongo.Document;

namespace MfPulse.Assessment.Contract.Criterions.Models
{
    public class CriterionDocument : IDocumentWithCompanyId
    {
        public string Id { get; set; }
        public bool IsArchived { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CompanyId { get; set; }
        public string Name { get; set; }
        public string GroupId { get; set; }
    }
}