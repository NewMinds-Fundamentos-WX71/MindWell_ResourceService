using MindWell_ResourcesServices.Resource.Domain.Repositories;
using MindWell_ResourcesServices.Resource.Domain.Services;
using MindWell_ResourcesServices.Shared.Persistence.Repositories;

namespace MindWell_ResourcesServices.Resource.Services;

public class ResourceService : IResourceService
{
    private readonly IResourceRepository _resourceRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ResourceService(IResourceRepository resourceRepository, IUnitOfWork unitOfWork)
    {
        _resourceRepository = resourceRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Models.Resource>> ListAsync()
    {
        return await _resourceRepository.ListAsync();
    }

    public async Task<Domain.Models.Resource> GetResourceById(int id)
    {
        return await _resourceRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Domain.Models.Resource>> ListAllResourcesByCategoryAsync(string category)
    {
        return await _resourceRepository.ListAllResourcesByCategoryAsync(category);
    }
}