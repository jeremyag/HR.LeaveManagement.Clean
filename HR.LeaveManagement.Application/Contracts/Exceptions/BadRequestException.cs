namespace HR.LeaveManagement.Application.Contracts.Exceptions;

public class BadRequestException : Exception
{
    public BadRequestException(string message) : base(message)
    {

    }
}