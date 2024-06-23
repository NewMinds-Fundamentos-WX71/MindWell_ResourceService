using MindWell_ResourcesServices.Resource.Domain.Models;
using MindWell_ResourcesServices.Shared.Domain.Services.Communication;

namespace MindWell_ResourcesServices.Resource.Domain.Communication;

public class FetchHistoryResponse : BaseResponse<FetchHistory>
{
    public FetchHistoryResponse(string message) : base(message)
    {
    }

    public FetchHistoryResponse(FetchHistory resource) : base(resource)
    {
    }
}