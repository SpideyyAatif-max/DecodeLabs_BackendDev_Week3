using SecureAuthenticationSystem.DTOs;

namespace SecureAuthenticationSystem.Services;

public interface IAuthService
{
    Task<UserProfileResponse> RegisterAsync(RegisterRequest request);
    Task<AuthResponse> LoginAsync(LoginRequest request);
}
