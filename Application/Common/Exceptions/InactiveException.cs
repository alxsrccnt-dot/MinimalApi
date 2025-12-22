namespace Application.Common.Exceptions;

public class InactiveException : Exception
{
	public InactiveException() { }

	public InactiveException(string message) : base(message) { }
}