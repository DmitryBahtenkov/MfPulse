namespace MfPulse.Auth.Contract.Requests
{
    public record CreateUserRequest()
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string RoleId { get; set; }
    }
}