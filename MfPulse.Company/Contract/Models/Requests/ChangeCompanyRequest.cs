using System.ComponentModel.DataAnnotations;

namespace MfPulse.Company.Contract.Models.Requests
{
    public record ChangeCompanyRequest
    {
        [Required(ErrorMessage = "Название компании обязательно")]
        public string Name { get; set; }
    }
}