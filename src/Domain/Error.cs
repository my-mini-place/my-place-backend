using System.Collections.Generic;

namespace Domain.Errors

{
    // moze sie przydac
    public class ErrorResponse
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public int Status { get; set; }
        public string Detail { get; set; }
        public Dictionary<string, List<string>> Errors { get; set; }
    }

    // record bo w recordzie nie da sie zmienic wartosci pózniej itd
    public record Error(string Code, string Description)
    {
        public static readonly Error None = new(string.Empty, string.Empty);
        public static readonly Error NullValue = new("Error.NullValue", "Null value was provided");

        public static implicit operator Result(Error error) => Result.Failure(error);

        public Result ToResult() => Result.Failure(this);
    }
}