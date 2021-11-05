namespace MfPulse.Auth.Contract.Requests
{
    public record ChangePasswordRequest()
    {
        public string OldPassword { get; set; }
        public string ConfirmPassword { get; set; }
        public string NewPassword { get; set; }
    }
}