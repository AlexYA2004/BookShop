using System.Security.Claims;
using BookShop.Models;
using BookShop.Domain.Response;

namespace BookShop.Services.Interfaces
{
    public interface IAccountService
    {
        Task<BaseResponse<ClaimsIdentity>> Register(RegisterViewModel model);

        Task<BaseResponse<ClaimsIdentity>> Login(LogInViewModel model);

     
    }
}
