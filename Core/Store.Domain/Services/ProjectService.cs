using Microsoft.EntityFrameworkCore;
using Store.Domain.Interface;
using Store.Domain.Requests.Project;
using Store.Domain.Responses.Project;
using Store.Persistance.Entities;
using Store.Persistance.Interfaces;

namespace Store.Domain.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProjectService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateProjectAsync(Guid userUid, CreateProjectRequest request)
        {
            User user = await _unitOfWork.Users.GetByUidAsync(userUid);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            Project project = new Project(default, Guid.NewGuid(), null, request.Name, request.Address, request.InternalNumber, user.Id);

            _unitOfWork.Projects.Insert(project);

            await _unitOfWork.SaveAsync();
        }

        public async Task<List<GetProjectsResponse>> GetProjectsAsync(Guid userUid)
        {
            User user = await _unitOfWork.Users.GetByUidAsync(userUid);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            return await _unitOfWork.Projects.All().Where(x => x.UserFK == user.Id).Select(x => new GetProjectsResponse(x.Uid, x.Name, x.Address, x.InternalNumber, x.UserFK)).ToListAsync();
        }

        public async Task<GetProjectsResponse> GetProjectDetails(Guid userUid, Guid projectUid)
        {
            User user = await _unitOfWork.Users.GetByUidAsync(userUid);

            if (user == null)
            {
                throw new Exception("User not found");
            }
            
            Project? projectDetails = await _unitOfWork.Projects.All().FirstOrDefaultAsync(x => x.UserFK == user.Id && x.Uid == projectUid);
            
            if (projectDetails == null)
            {
                throw new Exception("Project not found");
            }

            return new GetProjectsResponse(projectDetails.Uid, projectDetails.Name, projectDetails.Address, projectDetails.InternalNumber, projectDetails.UserFK);
        }
    }
}
