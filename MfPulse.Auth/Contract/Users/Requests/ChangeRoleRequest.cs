namespace MfPulse.Auth.Contract.Users.Requests
{
    public record ChangeRoleRequest()
    {
        public string RoleId { get; set; }
    }
}