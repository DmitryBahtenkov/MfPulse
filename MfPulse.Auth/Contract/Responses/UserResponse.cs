namespace MfPulse.Auth.Contract.Responses
{
    public record UserResponse
    {
        public string Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Login { get; set; }
        public bool IsNew { get; set; }
        public string CurrentToken { get; set; }
        public string RoleId { get; set; }

        public string Fio => $"{LastName} {FirstName} {MiddleName}";
    }
}