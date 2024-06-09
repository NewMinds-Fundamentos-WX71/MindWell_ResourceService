namespace MindWell_ResourcesServices.Resource.Domain.Services;

public interface IResourceService
{
    Task<IEnumerable<Domain.Models.Resource>> ListAsync();
    Task<Domain.Models.Resource> GetResourceById(int id);
    Task<IEnumerable<Domain.Models.Resource>> ListAllResourcesByCategoryAsync(string category);
}