namespace MindWell_ResourcesServices.Resource.Domain.Services;

public interface IUserResourceService
{
    Task<IEnumerable<Domain.Models.UserResource>> ListAsync();
    Task<Domain.Models.UserResource> GetUserResourceById(int id);
    Task<IEnumerable<Domain.Models.UserResource>> ListAllUserResourcesByUserIdAsync(int userId);
    Task<IEnumerable<Domain.Models.UserResource>> ListAllUserResourcesByResourceIdAsync(int resourceId);
}