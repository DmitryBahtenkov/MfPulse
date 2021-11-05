using System.ComponentModel.DataAnnotations;

namespace MfPulse.Auth.Contract.Groups.Models.Requests
{
    public record CreateGroupRequest
    {
        [Required(ErrorMessage = "Название группы обязательно")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Ответственный для группы обязателен")]
        public string ResponsibleId { get; set; }
    }
}