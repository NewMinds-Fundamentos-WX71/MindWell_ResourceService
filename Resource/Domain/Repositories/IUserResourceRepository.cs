using MindWell_ResourcesServices.Resource.Domain.Models;

namespace MindWell_ResourcesServices.Resource.Domain.Repositories;

public interface IUserResourceRepository
{
    Task<IEnumerable<Domain.Models.UserResource>> ListAsync();
    Task<UserResource> GetByIdAsync(int id);
    Task<IEnumerable<UserResource>> GetAllUserResourcesByUserIdAsync(int id);
    Task<IEnumerable<UserResource>> GetAllUserResourcesByResourceIdAsync(int id);
}