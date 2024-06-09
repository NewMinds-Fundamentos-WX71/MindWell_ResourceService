using MindWell_ResourcesServices.Shared.Domain.Services.Communication;

namespace MindWell_ResourcesServices.Resource.Domain.Communication;

public class ResourceResponse : BaseResponse<Models.Resource>
{
    public ResourceResponse(string message) : base(message)
    {
    }

    public ResourceResponse(Models.Resource resource) : base(resource)
    {
    }
}