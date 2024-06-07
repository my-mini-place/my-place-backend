namespace My_Place_Backend.DTO.Auth
{
    public class RegisterDTO
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;

        // public string Nickname { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
    }
}