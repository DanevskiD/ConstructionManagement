using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Domain.Requests.PackageDocument;
using Store.Domain.Responses.PackageDocument;

namespace Store.Domain.Interface
{
    public interface IPackageDocumentService
    {
        Task<List<GetPackageDocumentsResponse>> GetPackageDocumentsAsync(Guid packageUid);
        Task AllocatePackageDocumentAsync(Guid packageUid, CreatePackageDocumentRequest request);
        Task AllocatePackageDocumentsAsync(Guid packageUid, CreatePackageDocumentsRequest request);
    }
}
