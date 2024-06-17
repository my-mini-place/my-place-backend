namespace Api.DTO.Blocks
{
    public class BlockCreateDTO
    {
        public string Name { get; set; }
        public string PostalCode { get; set; }
        public int floors { get; set; }
        public string number { get; set; } = null!;
        public string street { get; set; } = null!;
    }
}