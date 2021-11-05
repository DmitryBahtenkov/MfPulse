namespace MfPulse.Auth.Contract.Requests
{
    public record ChangeRoleRequest()
    {
        public string Id { get; set; }
        public string RoleId { get; set; }
    }
}