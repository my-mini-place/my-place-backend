namespace Api.DTO.Blocks
{
    public class BlockDTO
    {
        public string BlockId { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? PostalCode { get; set; } = null!;
        public int? Floors { get; set; }

        public string? Number { get; set; } = null!;
        public string? Street { get; set; } = null!;

    }
}