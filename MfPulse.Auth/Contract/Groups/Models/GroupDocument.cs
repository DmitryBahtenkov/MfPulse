using System;
using MfPulse.Mongo.Document;

namespace MfPulse.Auth.Contract.Groups.Models
{
    public record GroupDocument : IDocumentWithCompanyId
    {
        public string Id { get; set; }
        public bool IsArchived { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// Идентификатор руководителя группы
        /// </summary>
        public string ResponsibleId { get; set; }

        public string CompanyId { get; set; }
    }
}