using MfPulse.Auth.Contract.Users.Database.Models;
using MfPulse.Auth.Contract.Users.Requests;
using MfPulse.Auth.Static.Rights;
using MfPulse.Mongo.Helpers;

namespace MfPulse.Auth.Static.Defaults
{
    public static class DefaultUsers
    {
        public static UserDocument GetDefaultAdmin(string companyId) => new()
        {
            Id = IdGen.New,
            FirstName = "Административный",
            LastName = "Администратор",
            Login = $"admin-{companyId}",
            Password = PasswordHelper.GeneratePassword("AdminTempPassword123!"),
            CompanyId = companyId,
            RoleId = RoleTags.Admin
        };
        
        public static UserDocument GetDefaultUser(string companyId) => new()
        {
            Id = IdGen.New,
            FirstName = "Пользователь",
            LastName = "Обыкновенный",
            Login = $"default-{companyId}",
            Password = PasswordHelper.GeneratePassword($"UserTempPassword123!"),
            CompanyId = companyId,
            RoleId = RoleTags.Default
        };
    }
}