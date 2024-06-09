using Microsoft.EntityFrameworkCore;
using MindWell_ResourcesServices.Resource.Domain.Models;
using MindWell_ResourcesServices.Resource.Domain.Repositories;
using MindWell_ResourcesServices.Shared.Persistence.Contexts;
using MindWell_ResourcesServices.Shared.Persistence.Repositories;

namespace MindWell_ResourcesServices.Resource.Persistence.Repositories;

public class UserResourceRepository : BaseRepository, IUserResourceRepository
{
    public UserResourceRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<UserResource>> ListAsync()
    {
        return await _context.UserResources.ToListAsync();
    }

    public async Task<UserResource> GetByIdAsync(int id)
    {
        return await _context.UserResources.FindAsync(id);
    }

    public async Task<IEnumerable<UserResource>> GetAllUserResourcesByUserIdAsync(int id)
    {
        return await _context.UserResources
            .Where(userResource => userResource.User_Id == id)
            .ToListAsync();
    }

    public async Task<IEnumerable<UserResource>> GetAllUserResourcesByResourceIdAsync(int id)
    {
        return await _context.UserResources
            .Where(userResource => userResource.Resource_Id == id)
            .ToListAsync();
    }
}