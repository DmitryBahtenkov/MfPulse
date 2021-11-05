using System.Collections.Generic;

namespace MfPulse.Auth.Contract.Groups.Models.Responses
{
    public record AllGroupsResponse
    {
        public List<GroupResponse> Groups { get; set; }
    }
}