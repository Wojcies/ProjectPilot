namespace ProjectPilot.Api.Models
{
	public class Project
	{
        public int Id { get; set; }
        public string Name{ get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime Deadline { get; set; }
        public string Description { get; set; }
    }
}
