using Microsoft.AspNetCore.Mvc;
using Store.Domain.Interface;
using Store.Domain.Requests.Package;
using Store.Domain.Responses.Package;
using Store.Persistance.Entities;

namespace Store.Controllers
{
    [Route("api/users/{userUid:guid}/projects/{projectUid:guid}/packages")]
    [ApiController]
    public class PackagesController : ControllerBase
    {
        private readonly IPackageService _packageService;
        public PackagesController(IPackageService packageService)
        {
            _packageService = packageService;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetPackagesResponse>>> GetPackagesAsync([FromRoute] Guid projectUid)
        {
            List<GetPackagesResponse> packages = await _packageService.GetPackagesAsync(projectUid);
            return Ok(packages);
        }

        [HttpPost]
        public async Task<ActionResult> CreatePackageAsync([FromRoute] Guid projectUid, [FromBody] CreatePackageRequest request)
        {
            await _packageService.CreatePackageAsync(projectUid, request);
            return Ok();
        }

        [HttpGet("{packageUid:guid}")]
        public async Task<ActionResult<GetPackagesResponse>> GetPackageDetails([FromRoute] Guid projectUid, Guid packageUid)
        {
            GetPackagesResponse packageDetails = await _packageService.GetPackageDetails(projectUid, packageUid);
            return Ok(packageDetails);
        }
    }
}
