using System.ComponentModel.DataAnnotations;

namespace MfPulse.Assessment.Contract.Criterions.Models.Requests
{
    public record CreateCriterionRequest
    {
        [Required(ErrorMessage = "Название критерия обязательно")]
        public string Name { get; set; }
        public string GroupId { get; set; }
    }
}