namespace MfPulse.Auth.Contract.Requests
{
    public record ChangeRoleRequest()
    {
        public string RoleId { get; set; }
    }
}