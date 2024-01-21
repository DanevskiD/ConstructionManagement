using Microsoft.EntityFrameworkCore;
using Store.Domain.Interface;
using Store.Domain.Requests.PackageDocument;
using Store.Domain.Responses.PackageDocument;
using Store.Persistance.Entities;
using Store.Persistance.Interfaces;

namespace Store.Domain.Services
{
    public class PackageDocumentService : IPackageDocumentService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PackageDocumentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GetPackageDocumentsResponse>> GetPackageDocumentsAsync(Guid packageUid)
            {
            Package package = await _unitOfWork.Packages.GetByUidAsync(packageUid);

            if (package == null)
            {
                throw new Exception("Package not found");
            }

            return await _unitOfWork.PackageDocuments.All().Where(x => x.PackageFK == package.Id).Select(x => new GetPackageDocumentsResponse(x.Uid, x.PackageFK, x.DocumentFK)).ToListAsync();
        }

        
        public async Task AllocatePackageDocumentAsync(Guid packageUid, CreatePackageDocumentRequest request)
        {
            Package package = await _unitOfWork.Packages.GetByUidAsync(packageUid);
            if (package == null)
            {
                throw new Exception("Package not found");
            }
            Document document = await _unitOfWork.Documents.GetByUidAsync(request.DocumentUid);
            if (document == null)
            {
                throw new Exception("Document not found");
            }
            PackageDocument? packageDocument = await _unitOfWork.PackageDocuments.All().FirstOrDefaultAsync(x => x.PackageFK == package.Id && document.Id == x.DocumentFK);

            if (packageDocument != null)
            {
                throw new Exception("Document allready allocated");
            }
            packageDocument = new PackageDocument(default, Guid.NewGuid(), null, package.Id, document.Id);

            _unitOfWork.PackageDocuments.Insert(packageDocument);

            await _unitOfWork.SaveAsync();
        }

        public async Task AllocatePackageDocumentsAsync(Guid packageUid, CreatePackageDocumentsRequest request)
        {
            Package package = await _unitOfWork.Packages.GetByUidAsync(packageUid);
            if (package == null)
            {
                throw new Exception("Package not found");
            }
            List<Document> documents = await _unitOfWork.Documents.All().Where(x => request.DocumentsUids.Contains(x.Uid)).ToListAsync();
            if (!documents.Any() )
            {
                throw new Exception("Document not found");
            }
            List<int> docIds = documents.Select(x => x.Id).ToList();
            PackageDocument? packageDocument = await _unitOfWork.PackageDocuments.All().FirstOrDefaultAsync(x => x.PackageFK == package.Id && docIds.Contains(x.DocumentFK));
            if (packageDocument != null)
            {
                throw new Exception("Document allready allocated");
            }
            foreach (var document in documents)
            {
                PackageDocument packageDocuments = new PackageDocument(default, Guid.NewGuid(), null, package.Id, document.Id);
                _unitOfWork.PackageDocuments.Insert(packageDocuments);
            }

             await _unitOfWork.SaveAsync();
        }

    }
}
