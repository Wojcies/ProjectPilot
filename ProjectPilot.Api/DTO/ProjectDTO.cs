namespace ProjectPilot.Api.DTO
{
	public class ProjectDTO
	{
		public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public DateTime Deadline { get; set; }
		public string Description { get; set; }
		public int TeamSize { get; set; }
		public bool Completed { get; set; }
	}
}
