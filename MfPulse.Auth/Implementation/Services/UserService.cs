using System.Linq;
using System.Threading.Tasks;
using MfPulse.Auth.Contract;
using MfPulse.Auth.Contract.Database.Models;
using MfPulse.Auth.Contract.Database.Operations;
using MfPulse.Auth.Contract.Requests;
using MfPulse.Auth.Contract.Responses;
using MfPulse.Auth.Contract.Rights;
using MfPulse.Auth.Contract.Services;
using MfPulse.CrossCutting.Exceptions;
using MfPulse.Mongo.Helpers;

namespace MfPulse.Auth.Implementation.Services
{
    public class UserService : IUserService
    {
        private readonly IUserGetOperations _userGetOperations;
        private readonly IUserWriteOperations _userWriteOperations;

        public UserService(IUserGetOperations userGetOperations, IUserWriteOperations userWriteOperations)
        {
            _userGetOperations = userGetOperations;
            _userWriteOperations = userWriteOperations;
        }

        public async Task<UserResponse> Create(CreateUserRequest request)
        {
            await ValidateRequest(request);

            var password = PasswordHelper.GeneratePassword(request.Password);
            
            var doc = new UserDocument
            {
                Id = IdGen.New,
                Login = request.Login,
                FirstName = request.FirstName,
                LastName = request.LastName,
                MiddleName = request.MiddleName,
                RoleId = request.RoleId,
                Password = password,
                GroupId = request.GroupId
            };

            var user = await _userWriteOperations.Insert(doc);
            return FromDocument(user);
        }
        
        private async Task ValidateRequest(CreateUserRequest request)
        {
            if (!RoleTags.GetAll().Contains(request.RoleId))
            {
                throw new BusinessException("Такой роли не существует");
            }
            
            var user = await _userGetOperations.ByLogin(request.Login);
            if (user is not null)
            {
                var fio = "{user.SurName} {user.Name} {user.Patronymic}";
                throw new BusinessException($"Такой пользователь уже существует: {fio}");
            }
        }

        public async Task<UserResponse> Update(string id, UpdateUserRequest request)
        {
            var document = await _userWriteOperations.UpdateInfo(id,
                request.LastName,
                request.FirstName,
                request.MiddleName);
            
            if (document is null)
            {
                throw new BusinessException("Пользователь не найден");
            }

            return FromDocument(document);
        }
        
        public UserResponse FromDocument(UserDocument document)
        {
            return new()
            {
                Id = document.Id,
                Login = document.Login,
                FirstName = document.FirstName,
                LastName = document.LastName,
                MiddleName = document.MiddleName,
                CurrentToken = document.CurrentToken,
                RoleId = document.RoleId
            };
        }
    }
}