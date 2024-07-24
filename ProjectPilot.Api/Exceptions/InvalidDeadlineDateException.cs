namespace ProjectPilot.Api.Exceptions
{
	public class InvalidDeadlineDateException : CustomException
	{
		public InvalidDeadlineDateException() 
			: base("Te deadline cannot be a past date.")
		{
		}
	}
}
