using ProjectPilot.Api.Entities;

namespace ProjectPilot.Api.Services
{
	public class ProjectsService
	{
		private int _id = 1;
		private static readonly List<Project> _projects = new(); //static is here temporarily to store the list values during the session

		public IEnumerable<Project> GetAll()
			=> _projects;

		public Project GetById(Guid id)
			=> _projects.SingleOrDefault(x => x.Id == id);

		public Guid? Create(Project project)
		{
			if (_projects.Any(x => x.Name == project.Name))
			{
				return default;
			}

			_projects.Add(project);

			return project.Id;
		}

		public bool Update(Project project)
		{
			var existingProject = _projects.SingleOrDefault(x => x.Id == project.Id);
			if (existingProject is null)
			{
				return false;
			}

			existingProject.ChangeDeadline(project.Deadline);
			
			foreach(var employee in project.AssignedEmployees)
			{
				existingProject.AddEmployee(employee);
			}

			return true;
		}

		public bool Delete(Guid id)
		{
			var existingProject = _projects.SingleOrDefault(x => x.Id == id);
			if (existingProject is null)
			{
				return false;
			}

			_projects.Remove(existingProject);
			return true;
		}
	}
}
