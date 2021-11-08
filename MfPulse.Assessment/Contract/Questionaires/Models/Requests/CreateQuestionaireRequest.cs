using System.ComponentModel.DataAnnotations;

namespace MfPulse.Assessment.Contract.Questionaires.Models.Requests
{
    public record CreateQuestionaireRequest
    {
        [Required(ErrorMessage = "Название опроса обязательно")]
        public string Name { get; set; }
        public string GroupId { get; set; }
    }
}