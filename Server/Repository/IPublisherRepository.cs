using System.Collections.Generic;
using Fabletown.Module.Publisher.Models;

namespace Fabletown.Module.Publisher.Repository
{
    public interface IPublisherRepository
    {
        IEnumerable<Models.Publisher> GetPublishers(int ModuleId);
        bool IsPublisher(int UserId); 
        Models.Publisher GetPublisher(int PublisherId);
        Models.Publisher GetPublisher(int PublisherId, bool tracking);
        Models.Publisher GetPublisherByUserId(int UserId); 
        Models.Publisher AddPublisher(Models.Publisher Publisher);
        Models.Publisher UpdatePublisher(Models.Publisher Publisher);
        void DeletePublisher(int PublisherId); 
    }
}
