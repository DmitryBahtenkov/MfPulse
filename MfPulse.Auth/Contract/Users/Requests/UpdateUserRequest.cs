namespace MfPulse.Auth.Contract.Users.Requests
{
    public record UpdateUserRequest()
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
    }
}