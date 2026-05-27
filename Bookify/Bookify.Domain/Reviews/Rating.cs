using Bookify.Domain.Abstractions;

namespace Bookify.Domain.Reviews;

public sealed record Rating
{
    public static readonly Error Invalid = new("Rating.Invalid", "The rating is invalid");

    public int Value { get; init; }
    
    private Rating(int value) => Value = value;

    public static Result<Rating> Create(int value)
    {
        if (value is < 1 or > 5)
        {
            return Result.Failure<Rating>(Invalid);
        }

        return new Rating(value);
    }
}