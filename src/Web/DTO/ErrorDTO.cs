using System.Collections.Generic;

namespace My_Place_Backend.DTO
{
    public class ErrorResponseDTO
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public int Status { get; set; }
        public string Detail { get; set; }
        public Dictionary<string, List<string>> Errors { get; set; }
    }
}