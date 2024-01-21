using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Store.Domain.Interface;
using Store.Domain.Requests.Package;
using Store.Domain.Responses.Package;
using Store.Persistance.Entities;
using Store.Persistance.Interfaces;

namespace Store.Domain.Services
{
    public class PackageService : IPackageService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PackageService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreatePackageAsync(Guid projectUid, CreatePackageRequest request)
        {
            Project project = await _unitOfWork.Projects.GetByUidAsync(projectUid);
            if (project == null)
            {
                throw new Exception("Project not found");
            }
            
            Package package = new Package(default, Guid.NewGuid(), null, request.Name, project.Id);

            _unitOfWork.Packages.Insert(package);

            await _unitOfWork.SaveAsync();
        }

        public async Task<List<GetPackagesResponse>> GetPackagesAsync(Guid projectUid)
        {
            Project project = await _unitOfWork.Projects.GetByUidAsync(projectUid);
            if (project == null)
            {
                throw new Exception("Project not found");
            }
            return await _unitOfWork.Packages.All().Where(x => x.ProjectFK == project.Id).Select(x => new GetPackagesResponse(
                x.Uid, x.Name, x.ProjectFK)).ToListAsync();
        }

        public async Task<GetPackagesResponse> GetPackageDetails(Guid projectUid, Guid packageUid)
        {
            Project project = await _unitOfWork.Projects.GetByUidAsync(projectUid);
            if (project == null)
            {
                throw new Exception("Project not found");
            }

            Package? packageDetails = await _unitOfWork.Packages.All().FirstOrDefaultAsync(x=>x.ProjectFK == project.Id && x.Uid == packageUid);
            if (packageDetails == null)
            {
                throw new Exception("Package not found");
            }

            return new GetPackagesResponse(packageDetails.Uid, packageDetails.Name, packageDetails.ProjectFK);
        }
    }
}
