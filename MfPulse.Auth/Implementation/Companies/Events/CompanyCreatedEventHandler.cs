using System.Threading.Tasks;
using MfPulse.Auth.Contract.Companies.Models;
using MfPulse.Auth.Contract.Groups.Operations;
using MfPulse.Auth.Contract.Groups.Services;
using MfPulse.Auth.Contract.Users.Database.Operations;
using MfPulse.Auth.Contract.Users.Services;
using MfPulse.Auth.Static.Defaults;
using MfPulse.EventBus.Events;

namespace MfPulse.Auth.Implementation.Companies.Events
{
    public class CompanyCreatedEventHandler
    {
        private readonly IGroupWriteOperations _groupWriteOperations;
        private readonly IUserWriteOperations _userWriteOperations;
        
        public CompanyCreatedEventHandler(IGroupWriteOperations groupWriteOperations, IUserWriteOperations userWriteOperations)
        {
            _groupWriteOperations = groupWriteOperations;
            _userWriteOperations = userWriteOperations;
        }

        public async Task OnCompanyCreated(DocumentCreatedEvent<CompanyDocument> @event)
        {
            var company = @event.NewDocument;
            var admin = DefaultUsers.GetDefaultAdmin(company.Id);
            var user = DefaultUsers.GetDefaultUser(company.Id);
            var group = DefaultGroups.GetDefault(company.Id, admin.Id);

            admin.GroupId = group.Id;
            user.GroupId = group.Id;

            await _groupWriteOperations.Insert(group);
            await _userWriteOperations.Insert(admin);
            await _userWriteOperations.Insert(user);
        }
    }
}