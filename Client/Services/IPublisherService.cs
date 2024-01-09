using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fabletown.Module.Publisher.Models;

namespace Fabletown.Module.Publisher.Services
{
    public interface IPublisherService 
    {
        Task<List<Models.Publisher>> GetPublishersAsync(int ModuleId);

        Task<Models.Publisher> GetPublisherAsync(int PublisherId, int ModuleId);

        Task<Models.Publisher> GetUserPublisherAsync(int userId, int moduleId);

        Task<Boolean> IsPublisherAsync(int userId, int moduleId);

        Task<Models.Publisher> AddPublisherAsync(Models.Publisher Publisher);

        Task<Models.Publisher> UpdatePublisherAsync(Models.Publisher Publisher);

        Task DeletePublisherAsync(int PublisherId, int ModuleId);
    }
}
