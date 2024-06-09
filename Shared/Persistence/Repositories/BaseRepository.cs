using MindWell_ResourcesServices.Shared.Persistence.Contexts;

namespace MindWell_ResourcesServices.Shared.Persistence.Repositories;

public class BaseRepository
{
    protected readonly AppDbContext _context;

    public BaseRepository(AppDbContext context)
    {
        _context = context;
    }
}