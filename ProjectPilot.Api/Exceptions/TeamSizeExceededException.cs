namespace ProjectPilot.Api.Exceptions
{
	public sealed class TeamSizeExceededException : CustomException
	{
		public TeamSizeExceededException() 
			: base("A sufficient number of people are already assigned to the project")
		{
		}
	}
}
