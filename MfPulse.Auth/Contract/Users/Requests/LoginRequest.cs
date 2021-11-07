using System.ComponentModel.DataAnnotations;

namespace MfPulse.Auth.Contract.Users.Requests
{
    public record LoginRequest
    {
        [Required(ErrorMessage = "Введите логин")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Введите пароль")]
        public string Password { get; set; }
    }
}