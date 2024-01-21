using Store.Domain.Requests.Package;
using Store.Domain.Responses.Package;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Interface
{
    public interface IPackageService
    {
        Task<List<GetPackagesResponse>> GetPackagesAsync(Guid projectUid);

        Task CreatePackageAsync(Guid projectUid, CreatePackageRequest request);

        Task<GetPackagesResponse> GetPackageDetails(Guid projectUid,Guid packageUid);
    }
}
