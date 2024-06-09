using MindWell_ResourcesServices.Resource.Domain.Models;
using MindWell_ResourcesServices.Shared.Domain.Services.Communication;

namespace MindWell_ResourcesServices.Resource.Domain.Communication;

public class UserResourceResponse : BaseResponse<UserResource>
{
    public UserResourceResponse(string message) : base(message)
    {
    }

    public UserResourceResponse(UserResource resource) : base(resource)
    {
    }
}