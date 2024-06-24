using MindWell_ResourcesServices.Resource.Domain.Communication;
using MindWell_ResourcesServices.Resource.Domain.Models;
using MindWell_ResourcesServices.Resource.Domain.Repositories;
using MindWell_ResourcesServices.Resource.Domain.Services;
using MindWell_ResourcesServices.Shared.Persistence.Repositories;

namespace MindWell_ResourcesServices.Resource.Services;

public class UserResourceService : IUserResourceService
{
    private readonly IUserResourceRepository _userResourceRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UserResourceService(IUserResourceRepository userResourceRepository, IUnitOfWork unitOfWork)
    {
        _userResourceRepository = userResourceRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<UserResource>> ListAsync()
    {
        return await _userResourceRepository.ListAsync();
    }

    public async Task<UserResource> GetUserResourceById(int id)
    {
        return await _userResourceRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<UserResource>> ListAllUserResourcesByUserIdAsync(int userId)
    {
        return await _userResourceRepository.GetAllUserResourcesByUserIdAsync(userId);
    }

    public async Task<IEnumerable<UserResource>> ListAllUserResourcesByResourceIdAsync(int resourceId)
    {
        return await _userResourceRepository.GetAllUserResourcesByResourceIdAsync(resourceId);
    }

    public async Task<UserResourceResponse> SaveAsync(UserResource userResource)
    {
        await _userResourceRepository.AddAsync(userResource);
        await _unitOfWork.CompleteAsync();
        return new UserResourceResponse(userResource);
    }
}