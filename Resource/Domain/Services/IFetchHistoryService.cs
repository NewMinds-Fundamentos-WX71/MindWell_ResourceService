using MindWell_ResourcesServices.Resource.Domain.Communication;
using MindWell_ResourcesServices.Resource.Domain.Models;

namespace MindWell_ResourcesServices.Resource.Domain.Services;

public interface IFetchHistoryService
{
    Task<FetchHistory> GetFetchHistory();
    Task<FetchHistoryResponse> UpdateFetchHistory(FetchHistory fetchHistory);
}