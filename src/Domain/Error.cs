using System.Collections.Generic;

namespace Domain.Errors

{
    // może sie przydać
    public class ErrorResponse
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public int Status { get; set; }
        public string Detail { get; set; }
        public Dictionary<string, List<string>> Errors { get; set; }
    }

    // record bo w recordzie nie da sie zmienic wartosci pózniej itd
    public record Error
    {
        public static readonly Error None = new(string.Empty, string.Empty, ErrorType.Failure);
        public static readonly Error NullValue = new("Error.NullValue", "Null value was provided", ErrorType.Failure);

        private Error(string code, string description, ErrorType errorType)
        {
            Code = code;
            Description = description;
            Type = errorType;
        }

        public string Code { get; }

        public string Description { get; }

        public ErrorType Type { get; }

        public static Error NotFound(string code, string description) =>
            new(code, description, ErrorType.NotFound);

        public static Error Validation(string code, string description) =>
            new(code, description, ErrorType.Validation);

        public static Error Conflict(string code, string description) =>
            new(code, description, ErrorType.Conflict);

        public static Error Failure(string code, string description) =>
            new(code, description, ErrorType.Failure);
    }

    public enum ErrorType
    {
        Failure = 0,
        Validation = 1,
        NotFound = 2,
        Conflict = 3
    }
}