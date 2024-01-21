using Microsoft.AspNetCore.Mvc;
using Store.Domain.Interface;
using Store.Domain.Requests.Document;
using Store.Domain.Responses.Document;
using Store.Domain.Services;
using Store.Persistance.Entities;

namespace Store.Controllers
{
    [Route("api/users/{userUid:guid}/projects/{projectUid:guid}/documents")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        private readonly IDocumentService _documentService;
        public DocumentsController(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetDocumentsResponse>>> GetDocumentsAsync([FromRoute] Guid projectUid)
        {
            List<GetDocumentsResponse> documents = await _documentService.GetDocumentsAsync(projectUid);
            return Ok(documents);
        }

        [HttpPost]
        public async Task<ActionResult> CreateDocumentAsync([FromRoute] Guid projectUid, [FromBody] CreateDocumentRequest request)
        {
            await _documentService.CreateDocumentAsync(projectUid, request);
            return Ok();
        }

        [HttpGet("{documentUid:guid}")]
        public async Task<ActionResult<GetDocumentsResponse>> GetDocumentsDetails([FromRoute] Guid projectUid, Guid documentUid)
        {
            GetDocumentsResponse documentDetails = await _documentService.GetDocumentDetails(projectUid, documentUid);
            return Ok(documentDetails);
        }
    }
}
