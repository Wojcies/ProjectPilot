using ProjectPilot.Api.Exceptions;

namespace ProjectPilot.Api.Entities
{
	public class Project : Entity
	{
		private readonly HashSet<Employee> _assignedEmployees;
        public string Name { get; }
		public DateTime CreatedAt { get; }
		public DateTime Deadline { get; protected set; }
		public string Description { get; protected set; }
        public int TeamSize { get; protected set; }
        public bool Completed { get; protected set; }
        public IEnumerable<Employee> AssignedEmployees => _assignedEmployees;

        public Project(Guid id, string name, DateTime deadline, string description, int teamSize) : base(id)
        {
			Name = name;
			CreatedAt = DateTime.UtcNow.Date;
			ChangeDeadline(deadline);
			Description = description;
			TeamSize = teamSize;
			Completed = false;
        }

        public void AddEmployee(Employee employee)
		{
			if(employee.AssignedProjects >= employee.MaxofAssignedProjects)
			{
				throw new MaximumNumberOfAssigmentsException();
			}

			if(_assignedEmployees.Count() >= TeamSize)
			{
				throw new TeamSizeExceededException();
			}

			employee.AssignedProjects++;
			_assignedEmployees.Add(employee);
		}

		public void ChangeDeadline(DateTime deadline)
		{
			if(deadline < DateTime.UtcNow)
			{
				throw new InvalidDeadlineDateException();
			}

			Deadline = deadline;
		}
	}
}
