using RichLife.IUserServices.Models.Request;
using RichLife.IUserServices.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RIchLife.Utilites.Page;

namespace RichLife.IUserServices
{
    public interface IUserService
    {
        Task<RegisterResponse> RegisterAsync(RegisterRequest request);
        Task<LoginResponse> LoginAsync(LoginRequest request);
        Task<PageResponse<UserResponse>> ListOfUsersAsync(ListOfUsersRequest request);
        Task<bool> UpdateUserAsync(UpdateUserRequest request);
        bool UpdateUser(UpdateUserRequest request);
        Task<bool> DeleteUserAsync(long UserId);
        bool DeleteUser(long UserId);
        Task<bool> ChangePassword(ChangePasswordRequest request, long userId);
        Task<CurrentUserResponse> GetCurrentUserAsync(string id);
        Task<Guid> ForgotPassword(ForgotPasswordRequest request);
        Task<LoginResponse> ForgotPasswordConfirm(ForgotPasswordConfirmRequest request);
    }
}
