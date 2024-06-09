namespace MindWell_ResourcesServices.Resource.Domain.Repositories;

public interface IResourceRepository
{
    Task<IEnumerable<Domain.Models.Resource>> ListAsync();
    Task<Domain.Models.Resource> GetByIdAsync(int id);
    Task AddAsync(Domain.Models.Resource resource);
    Task<IEnumerable<Domain.Models.Resource>> ListAllResourcesByCategoryAsync(string category);
}