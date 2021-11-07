using System.ComponentModel.DataAnnotations;

namespace MfPulse.Assessment.Contract.Questionaires.Models.Requests
{
    public record CreateQuestionaireRequest()
    {
        [Required(ErrorMessage = "Название опроса обязательно")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Компания обязательна")]
        public string CompanyId { get; set; }
        [Required(ErrorMessage = "Группа для опроса обязательна")]
        public string GroupId { get; set; }
    }
}