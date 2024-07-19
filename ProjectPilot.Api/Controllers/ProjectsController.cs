using Microsoft.AspNetCore.Mvc;
using ProjectPilot.Api.Models;

namespace ProjectPilot.Api.Controllers
{
	[ApiController]
	[Route(template: "[controller]")]
	public class ProjectsController : ControllerBase
	{
		private int _id = 1;
		private static readonly List<Project> _projects = new(); //static is here temporarily to store the list values during the session

		[HttpGet]
		public ActionResult<IEnumerable<Project>> Get()
		{
			return Ok(_projects);
		}

		[HttpGet(template: "{id:int}")]
		public ActionResult<Project> Get(int id)
		{
			var project = _projects.SingleOrDefault(x => x.Id == id);
			if(project is null)
			{
				return NotFound();
			}

			return Ok(project);
		}

		[HttpPost]
		public ActionResult Post(Project project)
		{
			if(_projects.Any(x => x.Name == project.Name))
			{
				return BadRequest();
			}

			project.Id = _id;
			project.CreatedAt = DateTime.UtcNow.Date;
			_id++;

			_projects.Add(project);

			return CreatedAtAction(nameof(Get), new { id = project.Id }, null);
		}

		[HttpPut(template: "{id:int}")]
		public ActionResult Put(int id, Project project)
		{
			var existingProject = _projects.SingleOrDefault(x => x.Id == id);
			if (existingProject is null)
			{
				return NotFound();
			}

			existingProject.Deadline = project.Deadline;
			return NoContent();
		}

		[HttpDelete(template: "{id:int}")]
		public ActionResult Delete(int id)
		{
			var existingProject = _projects.SingleOrDefault(x => x.Id == id);
			if (existingProject is null)
			{
				return NotFound();
			}

			_projects.Remove(existingProject);
			return NoContent();
		}
	}
}
