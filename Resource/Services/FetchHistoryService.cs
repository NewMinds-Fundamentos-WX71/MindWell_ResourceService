using MindWell_ResourcesServices.Resource.Domain.Communication;
using MindWell_ResourcesServices.Resource.Domain.Models;
using MindWell_ResourcesServices.Resource.Domain.Repositories;
using MindWell_ResourcesServices.Resource.Domain.Services;
using MindWell_ResourcesServices.Shared.Persistence.Repositories;

namespace MindWell_ResourcesServices.Resource.Services;

public class FetchHistoryService : IFetchHistoryService
{
    private readonly IFetchHistoryRepository _fetchHistoryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public FetchHistoryService(IFetchHistoryRepository fetchHistoryRepository, IUnitOfWork unitOfWork)
    {
        _fetchHistoryRepository = fetchHistoryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<FetchHistory> GetFetchHistory()
    {
        return await _fetchHistoryRepository.GetFetchHistory();
    }

    public async Task<FetchHistoryResponse> UpdateFetchHistory(FetchHistory fetchHistory)
    {
        try
        {
            var existingFetchHistory = await _fetchHistoryRepository.FindByIdAsync(1);

            if (existingFetchHistory == null)
                return new FetchHistoryResponse("FetchHistory not found.");

            existingFetchHistory.IsFetched = fetchHistory.IsFetched;

            _fetchHistoryRepository.Update(existingFetchHistory);
            await _unitOfWork.CompleteAsync();
            return new FetchHistoryResponse(existingFetchHistory);
        }
        catch (Exception e)
        {
            return new FetchHistoryResponse($"An error occurred while updating the fetchHistory: {e.Message}");
        }
    }
}