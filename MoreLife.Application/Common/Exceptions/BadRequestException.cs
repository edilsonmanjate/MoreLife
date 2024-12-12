namespace MoreLife.Application.Common.Exceptions;

public class BadRequestException : Exception
{
    public BadRequestException(string message) : base("Bad request Error: "+message)
    {
    }

    public BadRequestException(string[] errors) : base("Multiple errors occurred. See error details.")
    {
        Errors = errors;
    }

    public string[] Errors { get; set; }
}