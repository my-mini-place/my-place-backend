namespace My_Place_Backend.DTO.Auth
{
    public class ResetPasswordDTO
    {
        public string Email { get; set; } = null!;
        public string ResetCode { get; set; } = null!;
        public string NewPassword { get; set; } = null!;
    }
}