using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using MfPulse.Auth.Contract.Users.Database.Models;
using MfPulse.Auth.Contract.Users.Database.Operations;
using MfPulse.Auth.Contract.Users.Requests;
using MfPulse.Auth.Contract.Users.Responses;
using MfPulse.Auth.Contract.Users.Services;
using MfPulse.Auth.Static;
using MfPulse.Auth.Static.Rights;
using MfPulse.CrossCutting.Exceptions;
using Microsoft.IdentityModel.Tokens;

namespace MfPulse.Auth.Implementation.Users.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserWriteOperations _userWriteOperations;
        private readonly IUserGetOperations _userGetOperations;

        public AuthService(IUserWriteOperations userWriteOperations, IUserGetOperations userGetOperations)
        {
            _userWriteOperations = userWriteOperations;
            _userGetOperations = userGetOperations;
        }

        public async Task<UserResponse> Login(LoginRequest request)
        {
            var user = await ValidateLogin(request);

            return await SetToken(user);
        }

        public async Task Logout(string userId)
        {
            var user = await _userGetOperations.ById(userId);
            
            if (user is not null)
            {
                await _userWriteOperations.ClearToken(userId);
            }
            else
            {
                throw new BusinessException("Пользователь не существует");
            }
        }
        
        private async Task<UserDocument> ValidateLogin(LoginRequest request)
        {
            var user = await _userGetOperations.ByLogin(request.Login);
            if (user is null)
            {
                throw new BusinessException("Не найден пользователь");
            }

            if (!PasswordHelper.ComparePassword(user, request.Password))
            {
                throw new BusinessException("Некорректный логин или пароль");
            }

            return user;
        }
        
        private async Task<UserResponse> SetToken(UserDocument document)
        {
            var identity = GetIdentity(document);
            
            var jwt = new JwtSecurityToken(
                AuthOptions.Issuer,
                AuthOptions.Audience,
                notBefore: DateTime.UtcNow,
                claims: identity.Claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(AuthOptions.Lifetime)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            
            var documentWithToken = await _userWriteOperations.UpdateToken(document.Id, encodedJwt);

            return new ()
            {
                FirstName = documentWithToken.FirstName,
                LastName = documentWithToken.LastName,
                MiddleName = documentWithToken.MiddleName,
                RoleId = documentWithToken.RoleId,
                CurrentToken = documentWithToken.CurrentToken,
                Id = documentWithToken.Id,
                Login = documentWithToken.Login
            };
        }
        
        private ClaimsIdentity GetIdentity(UserDocument userDocument)
        {
            var claims = new List<Claim>
            {
                new (ClaimsIdentity.DefaultNameClaimType, userDocument.Login),
                new (ClaimsIdentity.DefaultRoleClaimType, userDocument.RoleId),
                new (Claims.Company, userDocument.CompanyId),
                new (Claims.Group, userDocument.GroupId),
                new (Claims.UserId, userDocument.Id)
            };
            
            ClaimsIdentity claimsIdentity =
                new (
                    claims,
                    "Token",
                    ClaimsIdentity.DefaultNameClaimType, 
                    ClaimsIdentity.DefaultRoleClaimType
                );
            
            return claimsIdentity;
        }
    }
}