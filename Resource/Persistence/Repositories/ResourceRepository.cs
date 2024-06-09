using Microsoft.EntityFrameworkCore;
using MindWell_ResourcesServices.Resource.Domain.Repositories;
using MindWell_ResourcesServices.Shared.Persistence.Contexts;
using MindWell_ResourcesServices.Shared.Persistence.Repositories;

namespace MindWell_ResourcesServices.Resource.Persistence.Repositories;

public class ResourceRepository : BaseRepository, IResourceRepository
{
    public ResourceRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Domain.Models.Resource>> ListAsync()
    {
        return await _context.Resources.ToListAsync();
    }

    public async Task<Domain.Models.Resource> GetByIdAsync(int id)
    {
        return await _context.Resources.FindAsync(id);
    }

    public async Task AddAsync(Domain.Models.Resource resource)
    {
        await _context.Resources.AddAsync(resource);
    }

    public async Task<IEnumerable<Domain.Models.Resource>> ListAllResourcesByCategoryAsync(string category)
    {
        return await _context.Resources
            .Where(resource => resource.Category == category)
            .ToListAsync();
    }
}