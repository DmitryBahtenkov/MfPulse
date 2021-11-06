using System.ComponentModel.DataAnnotations;

namespace MfPulse.Auth.Contract.Users.Requests
{
    public record CreateUserRequest
    {
        [Required(ErrorMessage = "Фимилия обязательна")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Имя обязательно")]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "Логин обязателен")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Пароль обязателен")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Подтвердите пароль")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Выберите роль")]
        public string RoleId { get; set; }
        [Required(ErrorMessage = "Выберите группу")]
        public string GroupId { get; set; }
    }
}