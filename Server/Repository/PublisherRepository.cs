using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Oqtane.Modules;
using Fabletown.Module.Publisher.Models;

namespace Fabletown.Module.Publisher.Repository
{
    public class PublisherRepository : IPublisherRepository, ITransientService
    {
        private readonly PublisherContext _db;

        public PublisherRepository(PublisherContext context)
        {
            _db = context;
        }
        public bool IsPublisher(int userId)
        {
            return _db.Publisher.Any(p => p.UserId == userId);
        }

        public Models.Publisher GetPublisherByUserId(int userId)
        {
            return _db.Publisher.FirstOrDefault(p => p.UserId == userId);
        }


        public IEnumerable<Models.Publisher> GetPublishers(int ModuleId)
        {
            return _db.Publisher.Where(item => item.ModuleId == ModuleId);
        }

        public Models.Publisher GetPublisher(int PublisherId)
        {
            return GetPublisher(PublisherId, true);
        }

        public Models.Publisher GetPublisher(int PublisherId, bool tracking)
        {
            if (tracking)
            {
                return _db.Publisher.Find(PublisherId);
            }
            else
            {
                return _db.Publisher.AsNoTracking().FirstOrDefault(item => item.PublisherId == PublisherId);
            }
        }

        public Models.Publisher AddPublisher(Models.Publisher Publisher)
        {
            if (IsPublisher(Publisher.UserId))
            {
                throw new System.Exception("A publisher with the provided UserId already exists.");
            }
            _db.Publisher.Add(Publisher);
            _db.SaveChanges();
            return Publisher;
        }

        public Models.Publisher UpdatePublisher(Models.Publisher Publisher)
        {
            _db.Entry(Publisher).State = EntityState.Modified;
            _db.SaveChanges();
            return Publisher;
        }

        public void DeletePublisher(int PublisherId)
        {
            Models.Publisher Publisher = _db.Publisher.Find(PublisherId);
            _db.Publisher.Remove(Publisher);
            _db.SaveChanges();
        }
    }
}
