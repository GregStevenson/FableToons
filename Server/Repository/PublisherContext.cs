using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Oqtane.Modules;
using Oqtane.Repository;
using Oqtane.Infrastructure;
using Oqtane.Repository.Databases.Interfaces;

namespace Fabletown.Module.Publisher.Repository
{
    public class PublisherContext : DBContextBase, ITransientService, IMultiDatabase
    {
        public virtual DbSet<Models.Publisher> Publisher { get; set; }

        public PublisherContext(IDBContextDependencies DBContextDependencies) : base(DBContextDependencies)
        {
            // ContextBase handles multi-tenant database connections
        }
    }
}
