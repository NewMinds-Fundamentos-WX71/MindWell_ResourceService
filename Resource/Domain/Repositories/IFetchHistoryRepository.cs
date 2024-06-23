using MindWell_ResourcesServices.Resource.Domain.Models;

namespace MindWell_ResourcesServices.Resource.Domain.Repositories;

public interface IFetchHistoryRepository
{
    Task<FetchHistory> GetFetchHistory();
    Task<FetchHistory> FindByIdAsync(int id);
    Task Update(FetchHistory fetchHistory);
}