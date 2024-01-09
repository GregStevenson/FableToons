using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Oqtane.Modules;
using Oqtane.Services;
using Oqtane.Shared;
using Fabletown.Module.Publisher.Models;

namespace Fabletown.Module.Publisher.Services
{
    public class PublisherService : ServiceBase, IPublisherService, IService
    {
        public PublisherService(HttpClient http, SiteState siteState) : base(http, siteState) { }

        private string Apiurl => CreateApiUrl("Publisher");

        public async Task<List<Models.Publisher>> GetPublishersAsync(int ModuleId)
        {
            List<Models.Publisher> Publishers = await GetJsonAsync<List<Models.Publisher>>(CreateAuthorizationPolicyUrl($"{Apiurl}?moduleid={ModuleId}", EntityNames.Module, ModuleId), Enumerable.Empty<Models.Publisher>().ToList());
            return Publishers.OrderBy(item => item.Name).ToList();
        }

        public async Task<Models.Publisher> GetUserPublisherAsync(int userId, int moduleId)
        {
            return await GetJsonAsync<Models.Publisher>(CreateAuthorizationPolicyUrl($"{Apiurl}/byuserid/{userId}", EntityNames.Module, moduleId));
        }

        public async Task<bool> IsPublisherAsync(int userId, int moduleId)
        {
            return await GetJsonAsync<bool>(CreateAuthorizationPolicyUrl($"{Apiurl}/ispublisher/{userId}", EntityNames.Module, moduleId));
        }

        public async Task<Models.Publisher> GetPublisherAsync(int PublisherId, int ModuleId)
        {
            return await GetJsonAsync<Models.Publisher>(CreateAuthorizationPolicyUrl($"{Apiurl}/{PublisherId}", EntityNames.Module, ModuleId));
        }

        public async Task<Models.Publisher> AddPublisherAsync(Models.Publisher Publisher)
        {
            return await PostJsonAsync<Models.Publisher>(CreateAuthorizationPolicyUrl($"{Apiurl}", EntityNames.Module, Publisher.ModuleId), Publisher);
        }

        public async Task<Models.Publisher> UpdatePublisherAsync(Models.Publisher Publisher)
        {
            return await PutJsonAsync<Models.Publisher>(CreateAuthorizationPolicyUrl($"{Apiurl}/{Publisher.PublisherId}", EntityNames.Module, Publisher.ModuleId), Publisher);
        }

        public async Task DeletePublisherAsync(int PublisherId, int ModuleId)
        {
            await DeleteAsync(CreateAuthorizationPolicyUrl($"{Apiurl}/{PublisherId}", EntityNames.Module, ModuleId));
        }
    }
}
