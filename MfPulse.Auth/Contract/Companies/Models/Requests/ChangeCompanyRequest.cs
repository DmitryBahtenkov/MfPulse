using System.ComponentModel.DataAnnotations;

namespace MfPulse.Auth.Contract.Companies.Models.Requests
{
    public record ChangeCompanyRequest
    {
        [Required(ErrorMessage = "Идентификатор компании обязателен")]
        public string Id { get; set; }
        [Required(ErrorMessage = "Название компании обязательно")]
        public string Name { get; set; }
    }
}