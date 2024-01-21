using Microsoft.EntityFrameworkCore;
using Store.Domain.Interface;
using Store.Domain.Requests.Document;
using Store.Domain.Responses.Document;
using Store.Persistance.Entities;
using Store.Persistance.Interfaces;

namespace Store.Domain.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IUnitOfWork _unitOfWork;
        public DocumentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateDocumentAsync(Guid projectUid, CreateDocumentRequest request)
        {
            Project project = await _unitOfWork.Projects.GetByUidAsync(projectUid);
            if (project == null)
            {
                throw new Exception("Project not found");
            }
            Document document = new Document(default, Guid.NewGuid(), null, request.Name, request.Description, project.Id);

            _unitOfWork.Documents.Insert(document);

            await _unitOfWork.SaveAsync();
        }

        public async Task<List<GetDocumentsResponse>> GetDocumentsAsync(Guid projectUid)
        {
            Project project = await _unitOfWork.Projects.GetByUidAsync(projectUid);

            if (project == null)
            {
                throw new Exception("Project not found");
            }

            return await _unitOfWork.Documents.All().Where(x => x.ProjectFK == project.Id).Select(x => new GetDocumentsResponse(x.Uid, x.Name, x.Description, x.ProjectFK)).ToListAsync();
        }

        public async Task<GetDocumentsResponse> GetDocumentDetails(Guid projectUid, Guid documentUid)
        {
            Project project = await _unitOfWork.Projects.GetByUidAsync(projectUid);

            if (project == null)
            {
                throw new Exception("Project not found");
            }

            Document? documentDetails = await _unitOfWork.Documents.All().FirstOrDefaultAsync(x => x.ProjectFK == project.Id && x.Uid == documentUid);

            if (documentDetails == null)
            {
                throw new Exception("Document not found");
            }

            return new GetDocumentsResponse(documentDetails.Uid, documentDetails.Name,  documentDetails.Description, documentDetails.ProjectFK);
        }
    }
}
