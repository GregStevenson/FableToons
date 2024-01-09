using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Oqtane.Modules;
using Oqtane.Models;
using Oqtane.Infrastructure;
using Oqtane.Enums;
using Oqtane.Repository;
using Fabletown.Module.Publisher.Repository;
using System;

namespace Fabletown.Module.Publisher.Manager
{


    public class PublisherManager : MigratableModuleBase, IInstallable, IPortable
    {
        private readonly IPublisherRepository _PublisherRepository;
        private readonly IDBContextDependencies _DBContextDependencies;

        public PublisherManager(IPublisherRepository PublisherRepository, IDBContextDependencies DBContextDependencies)
        {
            _PublisherRepository = PublisherRepository;
            _DBContextDependencies = DBContextDependencies;
        }

        public bool Install(Tenant tenant, string version)
        {
            return Migrate(new PublisherContext(_DBContextDependencies), tenant, MigrationType.Up);
        }

        public bool Uninstall(Tenant tenant)
        {
            return Migrate(new PublisherContext(_DBContextDependencies), tenant, MigrationType.Down);
        }

        public string ExportModule(Oqtane.Models.Module module)
        {
            string content = "";
            List<Models.Publisher> Publishers = _PublisherRepository.GetPublishers(module.ModuleId).ToList();
            if (Publishers != null)
            {
                content = JsonSerializer.Serialize(Publishers);
            }
            return content;
        }

        public void ImportModule(Oqtane.Models.Module module, string content, string version)
        {
            List<Models.Publisher> Publishers = null;
            if (!string.IsNullOrEmpty(content))
            {
                Publishers = JsonSerializer.Deserialize<List<Models.Publisher>>(content);
            }
            if (Publishers != null)
            {
                foreach(var Publisher in Publishers)
                {
                    _PublisherRepository.AddPublisher(new Models.Publisher { ModuleId = module.ModuleId, Name = Publisher.Name });
                }
            }
        }

    }
}
