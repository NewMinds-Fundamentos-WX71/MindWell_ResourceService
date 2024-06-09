using Microsoft.AspNetCore.Http.HttpResults;
using MindWell_ResourcesServices.Resource.Persistence.Repositories;
using MindWell_ResourcesServices.Shared.Persistence.Repositories;
using Newtonsoft.Json.Linq;

namespace MindWell_ResourcesServices.Resource.Services;

public class NhsApiService
{
    private readonly HttpClient _httpClient;
    private readonly ResourceRepository _resourceRepository;
    private readonly IUnitOfWork _unitOfWork;

    public NhsApiService(HttpClient httpClient, ResourceRepository resourceRepository, IUnitOfWork unitOfWork)
    {
        _httpClient = httpClient;
        _resourceRepository = resourceRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task FetchAndStoreResourcesAsync()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "https://api.nhs.uk/mental-health/");
        request.Headers.Add("subscription-key", "bbd3fd823fbe4b29b2a1afc332c2d6af");

        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        var json = JObject.Parse(content);

        var hasParts = json["hasPart"]?.Children();

        if (hasParts != null)
        {
            foreach (var hasPart in hasParts)
            {
                var url = hasPart["url"]?.ToString();
                var nestedHasParts = hasPart["hasPart"]?.Children();

                if (nestedHasParts != null)
                {
                    foreach (var nestedHasPart in nestedHasParts)
                    {
                        var text = nestedHasPart["text"]?.ToString();

                        if (!string.IsNullOrEmpty(url) && !string.IsNullOrEmpty(text) &&
                            (text.Contains("anxiety") || text.Contains("depression")))
                        {
                            var resource = new Domain.Models.Resource()
                            {
                                Link = url,
                                Category = text.Contains("anxiety") ? "anxiety" : "depression"
                            };

                            await _resourceRepository.AddAsync(resource);
                            await _unitOfWork.CompleteAsync();
                        }
                    }
                }
            }
        }
    }

}