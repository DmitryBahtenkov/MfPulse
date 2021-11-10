using System.ComponentModel.DataAnnotations;

namespace MfPulse.Assessment.Contract.Criterions.Models.Requests
{
    public record UpdateCriterionRequest
    {
        [Required(ErrorMessage = "Название критерия обязательно")]
        public string Name { get; set; }
    }
}