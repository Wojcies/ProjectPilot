namespace ProjectPilot.Api.Entities
{
	public class Employee : Entity
	{
		public string Name { get; private set; }
		public int AssignedProjects { get; set; }
        public int MaxofAssignedProjects { get; private set; }

        public Employee(Guid id, string name, int maxofAssignedProjects) : base(id)
        {
            Name = name;
            AssignedProjects = 0;
            MaxofAssignedProjects = maxofAssignedProjects;
        }
    }
}