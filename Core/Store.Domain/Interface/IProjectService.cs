using Store.Domain.Requests.Project;
using Store.Domain.Responses.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Interface
{
    public interface IProjectService
    {
        Task<List<GetProjectsResponse>> GetProjectsAsync(Guid userUid);

        Task CreateProjectAsync(Guid userUid, CreateProjectRequest request);
        Task<GetProjectsResponse> GetProjectDetails(Guid userUid, Guid projectUid); 
    }
}
