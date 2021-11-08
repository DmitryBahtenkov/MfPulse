using MfPulse.Auth.Contract.Groups.Models;
using MfPulse.Auth.Contract.Groups.Models.Requests;
using MfPulse.Mongo.Helpers;

namespace MfPulse.Auth.Static.Defaults
{
    public static class DefaultGroups
    {
        public static GroupDocument GetDefault(string companyId, string responsibleId) => new()
        {
            Id = IdGen.New,
            Name = "Общая группа",
            ResponsibleId = responsibleId,
            CompanyId = companyId
        };
    }
}