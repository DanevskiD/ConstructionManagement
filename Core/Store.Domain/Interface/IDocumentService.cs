using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Domain.Requests.Document;
using Store.Domain.Responses.Document;

namespace Store.Domain.Interface
{
    public interface IDocumentService
    {
        Task<List<GetDocumentsResponse>> GetDocumentsAsync(Guid projectUid);
        Task CreateDocumentAsync(Guid projectUid, CreateDocumentRequest request);
        Task<GetDocumentsResponse> GetDocumentDetails(Guid projectUid, Guid documentUid);
    }
}
