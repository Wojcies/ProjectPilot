﻿using Microsoft.AspNetCore.Mvc;
using ProjectPilot.Api.Entities;
using ProjectPilot.Api.Services;

namespace ProjectPilot.Api.Controllers
{
	[ApiController]
	[Route(template: "[controller]")]
	public class ProjectsController : ControllerBase
	{
		private readonly ProjectsService _projectService = new();

		[HttpGet]
		public ActionResult<IEnumerable<Project>> Get() => Ok(_projectService.GetAll());


		[HttpGet(template: "{id:Guid}")]
		public ActionResult<Project> Get(Guid id)
		{
			var project = _projectService.GetById(id);
			if (project is null)
			{
				return NotFound();
			}

			return Ok(project);
		}


		[HttpPost]
		public ActionResult Post(Project project)
		{
			var id = _projectService.Create(project);
			if (id is null)
			{
				return BadRequest();
			}

			return CreatedAtAction(nameof(Get), new { id = project.Id }, null);
		}


		[HttpPut(template: "{id:guid}")]
		public ActionResult Put(Guid id, Project project)
		{
			project.Id = id;
			var result = _projectService.Update(project);
			if (result)
			{
				return NoContent();
			}

			return NotFound();
		}


		[HttpDelete(template: "{id:guid}")]
		public ActionResult Delete(Guid id)
		{
			var result = _projectService.Delete(id);
			if (result)
			{
				return NoContent();
			}

			return NotFound();
		}
	}
}
