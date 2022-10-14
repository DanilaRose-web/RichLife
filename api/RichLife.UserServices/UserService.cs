using RichLife.IUserServices;
using RichLife.IUserServices.Models.Request;
using RichLife.IUserServices.Models.Response;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.IdentityModel.Tokens;
using Npgsql.Replication;
using RichLife.Data;
using RichLife.Data.Config;
using RichLife.Data.models;
using RichLife.Enum;
using RichLife.UserServices.Token;
using RIchLife.Utilites;
using RIchLife.Utilites.Page;
using Smtp.Mailer;
using Smtp.Mailer.Request;

namespace RichLife.UserServices
{
    public class UserService : IUserService
    {
        private DataContext _db = new();
        private MailService _mail = new MailService(); 
        public async Task<PageResponse<UserResponse>> ListOfUsersAsync(ListOfUsersRequest request)
        {
            return await _db.Users
                .SearchString(request.Search)
                .Where(x => !x.IsDelete)
                .OrderBy(x=>x.Id)
                .GetPageAsync(request, x => new UserResponse
                {
                    Email = x.Email,
                    Id = x.Id,
                    Name = x.Name,
                    TookTheProgram = x.TookTheProgram,
                    RefferalLink = x.TookTheProgram? x.RefferalKey:"",
                    PhoneNumber = x.PhoneNumber,
                    IsAdmin = x.Role == UserRole.Admin,
                    CodeNumber = x.CodeNumber
                });
        }
        /// <summary>
        /// Авторизация пользователя
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<LoginResponse> LoginAsync(LoginRequest request)
        {
            var user = await _db.Users.WhereEmail(request.Email.Trim()).FirstOrDefaultAsync();
            if (user is null)
                throw new Exception("User Not Found");
            if (GenHashPassword(request.Password, user.PasswordKey) != user.Password)
                throw new Exception("Пароль не верный");
            return new LoginResponse(await GenerateToken(user.Id));
        }
        public async Task<RegisterResponse> RegisterAsync(RegisterRequest request)
        {
            if (await _db.Users.AnyAsync(x => !x.IsDelete && x.Email == request.Email))
                throw new Exception("User exist");
            var add = new User
            {
                Email = request.Email.Trim().ToLower(),
                Name = request.Name,
                PasswordKey = Guid.NewGuid().ToString("N"),
                TookTheProgram = false,
                Role = UserRole.User,
                Gender = request.Gender,
                CodeNumber = request.CodeNumber
            };
            add.Password = this.GenHashPassword(request.Password, add.PasswordKey);
            await _db.Users.AddAsync(add);
            await _db.SaveChangesAsync();
            await _mail.WelcomeMail(new WelcomeEmail
            {
                Email = request.Email,
                Password = request.Password
            });
            return new RegisterResponse(await GenerateToken(add.Id));
        }
        public async Task<bool> UpdateUserAsync(UpdateUserRequest request)
        {
            var user = await _db.Users.FindAsync(request.UserId);
            if (user is null)
                throw new Exception("User Not Found");
            UpdateUser(ref user, request);
            await _db.SaveChangesAsync();
            return true;
        }
        public bool UpdateUser(UpdateUserRequest request)
        {
            var user = _db.Users.Find(request.UserId);
            if (user is null)
                throw new Exception("User Not Found");
            UpdateUser(ref user, request);
            _db.SaveChanges();
            return true;
        }

        private void UpdateUser(ref User user, UpdateUserRequest request)
        {
            user.UpdateTookTheProgram(request.TookTheProgram);
            user.UpdateUserRole(request.IsAdmin);
            user.UpdateName(request.Name);
            user.UpdateEmail(request.Email);
            user.UpdatePhoneNumber(request.PhoneNumber);
            user.UpdateCodeNumber(request.CodeNumber);
        }
        public async Task<bool> DeleteUserAsync(long UserId)
        {
            var user = await _db.Users.FindAsync(UserId);
            if (user is null)
                throw new Exception("User Not Found");
            user.IsDelete = true;
            await _db.SaveChangesAsync();
            return true;
        }
        public bool DeleteUser(long UserId)
        {
            var user = _db.Users.Find(UserId);
            if (user is null)
                throw new Exception("User Not Found");
            user.IsDelete = true;
            _db.SaveChanges();
            return true;
        }
        public async Task<CurrentUserResponse> GetCurrentUserAsync(string id)
        {
            if (long.TryParse(id, out var Id))
            {
                var user = await _db.Users.FindAsync(Id);
                return new CurrentUserResponse
                {
                    Email = user.Email,
                    Gender = user.Gender,
                    Id = user.Id,
                    Name = user.Name,
                    PhoneNumber = user.PhoneNumber,
                    RefferalKey = user.RefferalKey,
                    TookTheProgram = user.TookTheProgram,
                    CodeNumber = user.CodeNumber,
                    IsAdmin = user.Role == UserRole.Admin
                };
            }
            else
            {
                throw new Exception("Не верный токен");
            }
        }
        public async Task<Guid> ForgotPassword(ForgotPasswordRequest request)
        {
            var user = await _db.Users.WhereEmail(request.Email).FirstOrDefaultAsync();
            if (user is null)
                throw new Exception("User Not Found");
            var generateToke = new UserToken
            {
                Code = new Random().Next(100000, 999999).ToString(),
                Id = Guid.NewGuid(),
                Type = TokenType.ForgotPassword,
                UserId = user.Id
            };
            await _db.AddAsync(generateToke);
            await _db.SaveChangesAsync();
            await _mail.ForgotPasswordMail(new ForgotPasswordMail
            {
                Code = generateToke.Code,
                Email = user.Email,
                Toke = generateToke.Id
            });
            return generateToke.Id;
        }
        public async Task<bool> ChangePassword(ChangePasswordRequest request, long userId)
        {
            var user = await _db.Users.FindAsync(userId);
            if (user is not null 
                && this.GenHashPassword(request.Password, user.PasswordKey) == user.Password)
            {
                user.Password = this.GenHashPassword(request.Password, user.PasswordKey);
                await _db.SaveChangesAsync();
            }
            return true;
        }
        public async Task<LoginResponse> ForgotPasswordConfirm(ForgotPasswordConfirmRequest request)
        {
            if (new ActivateUser().SetToken(request.Toke, request.Code))
            {
                var user = await _db.Users
                    .FirstOrDefaultAsync(x => 
                        x.UserTokens.Any(z => z.Id == request.Toke));
                if (user is null)
                    throw new Exception("User not found");
                user.Password = this.GenHashPassword(request.NewPassword, user.PasswordKey);
                await _db.SaveChangesAsync();
                return new LoginResponse(await GenerateToken(user.Id));
            }
            else
            {
                throw new Exception("Token Not Valid");
            }
        }
        private async Task<TokenResponse> GenerateToken(long id)
        {
            (User user, ClaimsIdentity claim) identity;
            identity = await GetIdentity(id);
            if (identity.user is null)
                throw new Exception("User Not Found");
            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                notBefore: now,
                claims: identity.claim.Claims,
                expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            return new TokenResponse
            {
                Token = encodedJwt,
                Name = identity.claim.Name,
                IsAdmin = identity.user.Role == UserRole.Admin,
                RefferalLink = identity.user.RefferalKey,
                TookTheProgram = identity.user.TookTheProgram,
                UserId = identity.user.Id,
            };
        }
        private string GenHashPassword(string password, string passwordKey)
            => BitConverter.ToString(
                SHA256.Create().ComputeHash(
                        Encoding.UTF8.GetBytes(password + passwordKey)));
        private string GetRefferalLink()
        {
            Crc32 crc32 = new Crc32();
            var t = Encoding.UTF8.GetBytes(Guid.NewGuid().ToString("P"));
            var t2 = crc32.ComputeHash(t);
            return string.Join("", t2.Select(z => z.ToString("x2").ToLower()).ToList());
        }
        private async Task<(User,ClaimsIdentity)> GetIdentity(long Id)
        {
            var person = await _db.Users.FindAsync(Id);
            if (person is null || person.IsDelete) return (null, null);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, person.Name),
                new Claim(ClaimTypes.Email, person.Email),
                new Claim(ClaimTypes.Role, person.Role.ToString("G")),
                new Claim(ClaimTypes.NameIdentifier, person.Id.ToString("D")),

            };
            ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
            return (person,claimsIdentity);
            // если пользователя не найдено
        }
    }
}
