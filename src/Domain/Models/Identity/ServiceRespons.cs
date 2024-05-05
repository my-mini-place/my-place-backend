namespace Domain.Models.Auth;

public class ServiceResponses
{
    public record class GeneralResponse(bool Flag, string Message);
    public record class LoginResponse(bool Flag, string Token, string Message);
}

public record UserSession(string? Id, string? Name, string? Email, string? Role);