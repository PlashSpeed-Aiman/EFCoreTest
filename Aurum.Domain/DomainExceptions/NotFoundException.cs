namespace Aurum.Domain.DomainExceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string message) : base(message) { }
}