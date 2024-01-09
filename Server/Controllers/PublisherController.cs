using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Oqtane.Shared;
using Oqtane.Enums;
using Oqtane.Infrastructure;
using Fabletown.Module.Publisher.Repository;
using Oqtane.Controllers;
using System.Net;
using Fabletown.Module.Publisher.Manager;
using System;

namespace Fabletown.Module.Publisher.Controllers
{
    [Route(ControllerRoutes.ApiRoute)]
    public class PublisherController : ModuleControllerBase
    {
        private readonly IPublisherRepository _PublisherRepository;

        public PublisherController(IPublisherRepository PublisherRepository, ILogManager logger, IHttpContextAccessor accessor) : base(logger, accessor)
        {
            _PublisherRepository = PublisherRepository;
        }

        // GET: api/<controller>?moduleid=x
        [HttpGet]
        [Authorize(Policy = PolicyNames.ViewModule)]
        public IEnumerable<Models.Publisher> Get(string moduleid)
        {
            int ModuleId;
            if (int.TryParse(moduleid, out ModuleId) && IsAuthorizedEntityId(EntityNames.Module, ModuleId))
            {
                return _PublisherRepository.GetPublishers(ModuleId);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized Publisher Get Attempt {ModuleId}", moduleid);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return null;
            }
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        [Authorize(Policy = PolicyNames.ViewModule)]
        public Models.Publisher Get(int id)
        {
            Models.Publisher Publisher = _PublisherRepository.GetPublisher(id);
            if (Publisher != null && IsAuthorizedEntityId(EntityNames.Module, Publisher.ModuleId))
            {
                return Publisher;
            }
            else
            { 
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized Publisher Get Attempt {PublisherId}", id);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return null;
            }
        }

        // New endpoint: IsPublisher
        [HttpGet("ispublisher/{userId}")]
        [Authorize(Policy = PolicyNames.ViewModule)]
        public bool IsPublisher(int userId)
        {
            bool result = false;
            try
            {
                result = _PublisherRepository.IsPublisher(userId);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Read, ex, "IsPublisher Error {Error}", ex.Message);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                result = false;
            }
            return result;
          
        }

        // New endpoint: GetPublisherByUserId
        [HttpGet("byuserid/{userId}")]
        [Authorize(Policy = PolicyNames.ViewModule)]
        public Models.Publisher GetPublisherByUserId(int userId)
        {
            Models.Publisher Publisher = _PublisherRepository.GetPublisherByUserId(userId);
            if (Publisher != null && IsAuthorizedEntityId(EntityNames.Module, Publisher.ModuleId))
            {
                return Publisher;
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized Publisher Get Attempt {PublisherId}", userId);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return null;
            }
        }

   

        // POST api/<controller>
        [HttpPost]
        [Authorize(Policy = PolicyNames.EditModule)]
        public Models.Publisher Post([FromBody] Models.Publisher Publisher)
        {
            if (ModelState.IsValid && IsAuthorizedEntityId(EntityNames.Module, Publisher.ModuleId))
            {
                Publisher = _PublisherRepository.AddPublisher(Publisher);
                _logger.Log(LogLevel.Information, this, LogFunction.Create, "Publisher Added {Publisher}", Publisher);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized Publisher Post Attempt {Publisher}", Publisher);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                Publisher = null;
            }
            return Publisher;
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize(Policy = PolicyNames.EditModule)]
        public Models.Publisher Put(int id, [FromBody] Models.Publisher Publisher)
        {
            if (ModelState.IsValid && Publisher.PublisherId == id && IsAuthorizedEntityId(EntityNames.Module, Publisher.ModuleId) && _PublisherRepository.GetPublisher(Publisher.PublisherId, false) != null)
            {
                Publisher = _PublisherRepository.UpdatePublisher(Publisher);
                _logger.Log(LogLevel.Information, this, LogFunction.Update, "Publisher Updated {Publisher}", Publisher);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized Publisher Put Attempt {Publisher}", Publisher);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                Publisher = null;
            }
            return Publisher;
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [Authorize(Policy = PolicyNames.EditModule)]
        public void Delete(int id)
        {
            Models.Publisher Publisher = _PublisherRepository.GetPublisher(id);
            if (Publisher != null && IsAuthorizedEntityId(EntityNames.Module, Publisher.ModuleId))
            {
                _PublisherRepository.DeletePublisher(id);
                _logger.Log(LogLevel.Information, this, LogFunction.Delete, "Publisher Deleted {PublisherId}", id);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized Publisher Delete Attempt {PublisherId}", id);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            }
        }
    }
}
