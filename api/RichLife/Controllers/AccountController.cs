using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Server.HttpSys;
using RichLife.infrastructure.Models;
using RichLife.IUserServices;
using RichLife.IUserServices.Models.Request;
using RichLife.IUserServices.Models.Response;
using RichLife.models;
using RIchLife.Utilites.Page;
using Smtp.Mailer;
using Smtp.Mailer.Request;

namespace RichLife.Controllers
{
    /// <summary>
    /// Работа с пользователем
    /// </summary>
    [Route("/Account")]
    [Produces("application/json")]

    public class AccountController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IUserService _userService;
        private MailService _mailService => new MailService();
        /// <summary>
        /// Стандартный конструктор
        /// </summary>
        /// <param name="userService"></param>
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Метод для регистрации нового пользователя
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/Account/Register")]
        [ProducesResponseType(200, Type = typeof(BaseResponse<RegisterResponse>))]
        [ProducesResponseType(400, Type = typeof(BaseResponse))]

        public async Task<IActionResult> Register([Required][FromBody] RegisterRequest request)
        {
            try
            {
                return Json(new BaseResponse<RegisterResponse>(await _userService.RegisterAsync(request)));
            }
            catch (Exception e)
            {
                return BadRequest(new BaseResponse(e));
            }
        }

        /// <summary>
        /// Авторизация пользователя
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/Account/Login")]
        [ProducesResponseType(200, Type = typeof(BaseResponse<LoginResponse>))]
        [ProducesResponseType(400, Type = typeof(BaseResponse))]
        public async Task<IActionResult> Login([Required][FromBody]LoginRequest request)
        {
            try
            {
                return Json(new BaseResponse<LoginResponse>(await _userService.LoginAsync(request)));
            }
            catch (Exception e)
            {
                return BadRequest(new BaseResponse(e));
            }
        }

        /// <summary>
        /// Получить список пользователей
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        [Route("/Account/ListOfUsers")]
        [ProducesResponseType(200, Type = typeof(BaseResponse<PageResponse<UserResponse>>))]
        [ProducesResponseType(400, Type = typeof(BaseResponse))]
        public async Task<IActionResult> ListOfUsers(ListOfUsersRequest request)
        {
            try
            {
                return Json(new BaseResponse<PageResponse<UserResponse>>(await _userService.ListOfUsersAsync(request)));
            }
            catch (Exception e)
            {
                return BadRequest(new BaseResponse(e));
            }
        }
        /// <summary>
        /// Обновить пользователя
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        [Route("/Account/UpdateUser")]
        [ProducesResponseType(200, Type = typeof(BaseResponse))]
        [ProducesResponseType(400, Type = typeof(BaseResponse))]
        public async Task<IActionResult> UpdateUser([Required][FromBody]UserUpdateRequest request)
        {
            try
            {
                return Json(new BaseResponse(await _userService.UpdateUserAsync(new UpdateUserRequest
                {
                    Name = request.Name,
                    Email = request.Email,
                    PhoneNumber = request.Phone,
                    UserId = request.UserId,
                    CodeNumber = request.CodeCountry
                })));
            }
            catch (Exception e)
            {
                return BadRequest(new BaseResponse(e));
            }
        }

        /// <summary>
        /// Выдать права админа
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        [Route("/Account/SetUserAdmin")]
        [ProducesResponseType(200, Type = typeof(BaseResponse))]
        [ProducesResponseType(400, Type = typeof(BaseResponse))]
        public async Task<IActionResult> SetUserAdmin([Required][FromBody]List<SetUserAdminRequest> request)
        {
            try
            {
                request.ForEach(x =>
                {
                    _userService.UpdateUser(new UpdateUserRequest
                    {
                        IsAdmin = x.IsAdmin,
                        UserId = x.UserId
                    });
                });
                return Json(new BaseResponse(true));
            }
            catch (Exception e)
            {
                return BadRequest(new BaseResponse(e));
            }
        }

        /// <summary>
        /// Активировать программу
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        [Route("/Account/SetUserRefferalLink")]
        [ProducesResponseType(200, Type = typeof(BaseResponse))]
        [ProducesResponseType(400, Type = typeof(BaseResponse))]
        public async Task<IActionResult> SetUserRefferalLink([Required] [FromBody] List<SetUserRefferalLinkRequest> request)
        {
            try
            {
                request.ForEach(x =>
                {
                    _userService.UpdateUser(new UpdateUserRequest
                    {
                        TookTheProgram = x.TookTheProgram,
                        UserId = x.UserId
                    });
                });
                return Json(new BaseResponse(true));
            }
            catch (Exception e)
            {
                return BadRequest(new BaseResponse(e));
            }
        }
        [HttpPost]
        [Authorize]
        [Route("/Account/DeleteUser")]
        [ProducesResponseType(200, Type = typeof(BaseResponse))]
        [ProducesResponseType(400, Type = typeof(BaseResponse))]
        public async Task<IActionResult> DeleteUser([Required][FromBody] List<DeleteUserRequest> request)
        {
            try
            {
                request.ForEach(x =>
                {
                    _userService.DeleteUser(x.UserId);
                });
                return Json(new BaseResponse());
            }
            catch (Exception e)
            {
                return BadRequest(new BaseResponse(e));
            }
        }
        /// <summary>
        /// Поулчить текушего пользователя
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        [Route("/Account/GetCurrentUser")]
        [ProducesResponseType(200, Type = typeof(BaseResponse<CurrentUserResponse>))]
        [ProducesResponseType(400, Type = typeof(BaseResponse))]
        [ProducesResponseType(404, Type = typeof(BaseResponse))]
        public async Task<IActionResult> GetCurrentUser()
        {
            try
            {
                var userCurrent = this.User.FindFirst(ClaimTypes.NameIdentifier);
                if (userCurrent == null)
                {
                    return NotFound(new BaseResponse("перелогинься)"));
                }

                return Json(new BaseResponse<CurrentUserResponse>(
                    await _userService.GetCurrentUserAsync(userCurrent.Value)));
            }
            catch (Exception e)
            {
                return BadRequest(new BaseResponse(e));
            }
        }

        [HttpPost]
        [Authorize]
        [Route("/Account/ChangePassword")]
        [ProducesResponseType(200, Type = typeof(BaseResponse))]
        [ProducesResponseType(400, Type = typeof(BaseResponse))]
        [ProducesResponseType(404, Type = typeof(BaseResponse))]
        public async Task<IActionResult> ChangePassword(ChangePasswordRequest request)
        {
            try
            {
                var userCurrent = this.User.FindFirst(ClaimTypes.NameIdentifier);
                if (userCurrent == null)
                {
                    return NotFound(new BaseResponse("перелогинься)"));
                }
                var user = await _userService.GetCurrentUserAsync(userCurrent.Value);

                return Json(new BaseResponse(await _userService.ChangePassword(request, user.Id)));
            }
            catch (Exception e)
            {
                return BadRequest(new BaseResponse(e));

            }
        }

        /// <summary>
        /// Отправляет письмо с кодом и урлом в котором токен.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/Account/ForgotPassword")]
        [ProducesResponseType(200, Type = typeof(BaseResponse<Guid>))]
        [ProducesResponseType(400, Type = typeof(BaseResponse))]
        public async Task<IActionResult> ForgotPassword([Required][FromBody] ForgotPasswordRequest request)
        {
            try
            {
                return Json(new BaseResponse<Guid>(await _userService.ForgotPassword(request)));
            }
            catch (Exception e)
            {
                return BadRequest(new BaseResponse(e));
            }
        }
        /// <summary>
        /// Подтверждает смену пароля токен в урл, код в письме)
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/Account/ConfirmForgotPassword")]
        [ProducesResponseType(200, Type = typeof(BaseResponse<LoginResponse>))]
        [ProducesResponseType(400, Type = typeof(BaseResponse))]
        public async Task<IActionResult> ConfirmForgotPassword([Required][FromBody] ForgotPasswordConfirmRequest request)
        {
            try
            {
                return Json(new BaseResponse<LoginResponse>(await _userService.ForgotPasswordConfirm(request)));
            }
            catch (Exception e)
            {
                return BadRequest(new BaseResponse(e));
            }
        }
        /// <summary>
        /// Заглушка
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/Account/GetInTouch")]
        [ProducesResponseType(200, Type = typeof(BaseResponse))]
        [ProducesResponseType(400, Type = typeof(BaseResponse))]
        public async Task<IActionResult> GetInTouch([Required][FromBody] GetInTouchRequest request)
        {
            try
            {
                await _mailService.GetInTouch(request);
                return Json(new BaseResponse(true));
            }
            catch (Exception e)
            {
                return BadRequest(new BaseResponse(e));
            }
        }
        /// <summary>
        /// Заглушка
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/Account/SendMessage")]
        [ProducesResponseType(200, Type = typeof(BaseResponse))]
        [ProducesResponseType(400, Type = typeof(BaseResponse))]
        public async Task<IActionResult> SendMessage([Required][FromBody] SendMessageRequest request)
        {
            try
            {
                await _mailService.SendMessage(request);
                return Json(new BaseResponse(true));
            }
            catch (Exception e)
            {
                return BadRequest(new BaseResponse(e));
            }
        }

        [HttpGet]
        [Route("/SendTest")]
        public async Task<IActionResult> SendTest()
        {
            var mail = new MailService();
            await mail.SendEvent("kovalevakii.oleg@gmail.com", "forgotpassword",new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("code","Test Code")
            });
            return Json(new { result = "збс" });
        }
    }
}
