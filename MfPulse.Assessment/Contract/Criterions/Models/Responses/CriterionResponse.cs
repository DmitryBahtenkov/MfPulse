namespace MfPulse.Assessment.Contract.Criterions.Models.Responses
{
    public record CriterionResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string GroupId { get; set; }
        public string GroupName { get; set; }
    }
}