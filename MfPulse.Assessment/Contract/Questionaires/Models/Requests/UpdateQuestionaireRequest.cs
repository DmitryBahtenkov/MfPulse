namespace MfPulse.Assessment.Contract.Questionaires.Models.Requests
{
    public record UpdateQuestionaireRequest()
    {
        public string Name { get; set; }
        public string CompanyId { get; set; }
        public string GroupId { get; set; }
    }
}