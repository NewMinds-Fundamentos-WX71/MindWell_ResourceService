using Microsoft.EntityFrameworkCore;
using MindWell_ResourcesServices.Resource.Domain.Models;
using MindWell_ResourcesServices.Resource.Domain.Repositories;
using MindWell_ResourcesServices.Shared.Persistence.Contexts;
using MindWell_ResourcesServices.Shared.Persistence.Repositories;

namespace MindWell_ResourcesServices.Resource.Persistence.Repositories;

public class FetchHistoryRepository : BaseRepository, IFetchHistoryRepository
{
    public FetchHistoryRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<FetchHistory> GetFetchHistory()
    {
        return await _context.FetchHistories.FirstOrDefaultAsync();
    }

    public async Task<FetchHistory> FindByIdAsync(int id)
    {
        return await _context.FetchHistories.FindAsync(id);
    }

    public async Task Update(FetchHistory fetchHistory)
    {
        _context.Update(fetchHistory);
    }
}