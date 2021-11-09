using System;
using System.Linq;
using System.Threading.Tasks;
using MfPulse.Auth.Contract;
using MfPulse.Auth.Contract.Companies.Operations;
using MfPulse.Auth.Contract.Companies.Services;
using MfPulse.Auth.Contract.Groups.Operations;
using MfPulse.Auth.Contract.Users.Database.Models;
using MfPulse.Auth.Contract.Users.Database.Operations;
using MfPulse.Auth.Contract.Users.Requests;
using MfPulse.Auth.Contract.Users.Responses;
using MfPulse.Auth.Contract.Users.Services;
using MfPulse.Auth.Static;
using MfPulse.Auth.Static.Rights;
using MfPulse.CrossCutting.Exceptions;
using MfPulse.EventBus;
using MfPulse.EventBus.Events;
using MfPulse.Mongo.Helpers;

namespace MfPulse.Auth.Implementation.Users.Services
{
    public class UserService : IUserService
    {
        private readonly IUserGetOperations _userGetOperations;
        private readonly IUserWriteOperations _userWriteOperations;
        private readonly IGroupGetOperations _groupGetOperations;
        private readonly IUserIdentity _userIdentity;
        private readonly IServiceProvider _serviceProvider;
        private readonly EventInvoker<UserDocument> _eventInvoker;

        public UserService(IUserGetOperations userGetOperations,
            IUserWriteOperations userWriteOperations,
            IGroupGetOperations groupGetOperations, IUserIdentity userIdentity, 
            IServiceProvider serviceProvider, 
            EventInvoker<UserDocument> eventInvoker)
        {
            _userGetOperations = userGetOperations;
            _userWriteOperations = userWriteOperations;
            _groupGetOperations = groupGetOperations;
            _userIdentity = userIdentity;
            _serviceProvider = serviceProvider;
            _eventInvoker = eventInvoker;
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
                GroupId = request.GroupId,
                CompanyId = _userIdentity.CompanyId
            };

            var user = await _userWriteOperations.Insert(doc);

            await _eventInvoker.OnDocumentCreated(
                new DocumentCreatedEvent<UserDocument>(_serviceProvider, user)
                );
            
            return FromDocument(user);
        }
        
        private async Task ValidateRequest(CreateUserRequest request)
        {
            if (!RoleTags.GetAll().Contains(request.RoleId))
            {
                throw new BusinessException("Такой роли не существует");
            }

            if (!await _groupGetOperations.ExistById(request.GroupId))
            {
                throw new BusinessException("Такой группы не существует");
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