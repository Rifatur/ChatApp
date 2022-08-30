using ChatApp.Application.DTOs;

namespace ChatApp.Application.services.interfaces
{
    public interface IAuthService
    {
        Task<Response> RegisterUserAsync(RegisterAppViewDTOs model);
        Task<Response> LoginUserAsync(LoginAppDTOs model);
    }
}
