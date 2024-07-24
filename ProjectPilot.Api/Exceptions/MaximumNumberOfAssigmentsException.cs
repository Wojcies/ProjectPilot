namespace ProjectPilot.Api.Exceptions
{
	public sealed class MaximumNumberOfAssigmentsException : CustomException
	{
		public MaximumNumberOfAssigmentsException() 
			: base("This employee has already been assigned to the maximum number of projects.")
		{
		}
	}
}
