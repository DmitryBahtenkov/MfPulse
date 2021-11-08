namespace MfPulse.Assessment.Contract.Questionaires.Models.Responses
{
    public record QuestionaireResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string GroupId { get; set; }
    }
}