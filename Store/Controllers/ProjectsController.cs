using Microsoft.AspNetCore.Mvc;
using Store.Domain.Interface;
using Store.Domain.Requests.Project;
using Store.Domain.Responses.Project;
using Store.Persistance.Entities;

namespace Store.Controllers
{
    [Route("api/users/{userUid:guid}/projects")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;
        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetProjectsResponse>>> GetProjectsAsync(
            [FromRoute] Guid userUid)
        {
            List<GetProjectsResponse> projects = await _projectService.GetProjectsAsync(userUid);
            return Ok(projects);
        }

        [HttpPost]
        public async Task<ActionResult> CreateProjectAsync([FromRoute] Guid userUid, [FromBody] CreateProjectRequest request)
        {
            await _projectService.CreateProjectAsync(userUid, request);
            return Ok();
        }

        [HttpGet("{projectUid:guid}")]
        public async Task<ActionResult<GetProjectsResponse>> GetProjectDetails([FromRoute] Guid userUid, Guid projectUid)
        {
            GetProjectsResponse projectDetails = await _projectService.GetProjectDetails(userUid, projectUid);
            return Ok(projectDetails);
        }
    }
}
