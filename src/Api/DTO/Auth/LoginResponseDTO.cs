namespace My_Place_Backend.DTO.Auth
{
    public class LoginResponseDTO
    {
        public string TokenType { get; set; }
        public string AccessToken { get; set; }
        public int ExpiresIn { get; set; }
    }
}