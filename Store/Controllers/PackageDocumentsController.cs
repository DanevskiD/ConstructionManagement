using Microsoft.AspNetCore.Mvc;
using Store.Domain.Interface;
using Store.Domain.Requests.PackageDocument;
using Store.Domain.Responses.PackageDocument;
using Store.Domain.Services;
using Store.Persistance.Entities;

namespace Store.Controllers
{
    [Route("api/users/{userUid:guid}/projects/{projectUid:guid}/packages/{packageUid:guid}/packageDocument")]
    [ApiController]
    public class PackageDocumentsController : ControllerBase
    {
        private readonly IPackageDocumentService _packageDocumentService;
        public PackageDocumentsController(IPackageDocumentService packageDocumentService)
        {
            _packageDocumentService = packageDocumentService;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetPackageDocumentsResponse>>> GetPackageDocumentsAsync([FromRoute] Guid packageUid)
        {
            List<GetPackageDocumentsResponse> packageDocuments = await _packageDocumentService.GetPackageDocumentsAsync(packageUid);
            return Ok(packageDocuments);
        }

        [HttpPost]
        public async Task<ActionResult> AllocatePackageDocumentAsync([FromRoute] Guid packageUid, [FromBody] CreatePackageDocumentRequest request)
        {
            await _packageDocumentService.AllocatePackageDocumentAsync(packageUid, request);
            return Ok();
        }

        [HttpPost("documents")]
        public async Task<ActionResult> AllocatePackageDocumentsAsync([FromRoute] Guid packageUid, [FromBody] CreatePackageDocumentsRequest request)
        {
            await _packageDocumentService.AllocatePackageDocumentsAsync(packageUid, request);
            return Ok();
        }

    }
}
