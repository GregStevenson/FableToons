using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Oqtane.Databases.Interfaces;
using Oqtane.Migrations;
using Fabletown.Module.Publisher.Migrations.EntityBuilders;
using Fabletown.Module.Publisher.Repository;
using Oqtane.Enums;
using System;

namespace Fabletown.Module.Publisher.Migrations
{
    [DbContext(typeof(PublisherContext))]
    [Migration("Fabletown.Module.Publisher.01.00.00.00")]
    public class InitializeModule : MultiDatabaseMigration
    {
        public InitializeModule(IDatabase database) : base(database)
        {
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            try
            {
                var entityBuilder = new PublisherEntityBuilder(migrationBuilder, ActiveDatabase);
                entityBuilder.Create();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var entityBuilder = new PublisherEntityBuilder(migrationBuilder, ActiveDatabase);
            entityBuilder.Drop();
        }
    }
}
