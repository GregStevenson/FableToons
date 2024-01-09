using Oqtane.Models;
using Oqtane.Modules;

namespace Fabletown.Module.Publisher
{
    public class ModuleInfo : IModule
    {
        public ModuleDefinition ModuleDefinition => new ModuleDefinition
        {
            Name = "Publisher",
            Description = "This module allows a user to establish themselves as a publisher and also displays a list of created publications in a table. Rev 1.2",
            Version = "1.0.0",
            ServerManagerType = "Fabletown.Module.Publisher.Manager.PublisherManager, Fabletown.Module.Publisher.Server.Oqtane",
            ReleaseVersions = "1.0.0",
            Dependencies = "Fabletown.Module.Publisher.Shared.Oqtane",
            PackageName = "Fabletown.Module.Publisher" 
        };
    }
}
