using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;
using Oqtane.Databases.Interfaces;
using Oqtane.Migrations;
using Oqtane.Migrations.EntityBuilders;

namespace Fabletown.Module.Publisher.Migrations.EntityBuilders
{
    public class PublisherEntityBuilder : AuditableBaseEntityBuilder<PublisherEntityBuilder>
    {
        private const string _entityTableName = "FabletownPublisher";
        private readonly PrimaryKey<PublisherEntityBuilder> _primaryKey = new("PK_FabletownPublisher", x => x.PublisherId);
        private readonly ForeignKey<PublisherEntityBuilder> _moduleForeignKey = new("FK_FabletownPublisher_Module", x => x.ModuleId, "Module", "ModuleId", ReferentialAction.Cascade);
        private readonly ForeignKey<PublisherEntityBuilder> _userForeignKey =
            new("FK_Publisher_User", x => x.UserId, "User", "UserId", ReferentialAction.Cascade);

        //private readonly Index<PublisherEntityBuilder> _uniqueUserIdIndex =
        //    new("IX_Publisher_UserId", x => x.UserId, isUnique: true);

        public PublisherEntityBuilder(MigrationBuilder migrationBuilder, IDatabase database) : base(migrationBuilder, database)
        {
            EntityTableName = _entityTableName;
            PrimaryKey = _primaryKey;
            ForeignKeys.Add(_moduleForeignKey);
            ForeignKeys.Add(_userForeignKey);

           // AddIndex("IX_Publisher_UserId", "UserId", true);
        }

        protected override PublisherEntityBuilder BuildTable(ColumnsBuilder table)
        {
            PublisherId = AddAutoIncrementColumn(table,"PublisherId");
            ModuleId = AddIntegerColumn(table, "ModuleId");
            UserId = AddIntegerColumn(table, "UserId");
            Name = AddMaxStringColumn(table, "Name");
            Tagline = AddMaxStringColumn(table, "Tagline");
            Description = AddMaxStringColumn(table, "Description");
            LogoFileId = AddIntegerColumn(table, "LogoFileId");
            BannerFileId = AddIntegerColumn(table, "BannerFileId");
            AddAuditableColumns(table);
            return this;
        }

        public OperationBuilder<AddColumnOperation> PublisherId { get; set; }
        public OperationBuilder<AddColumnOperation> ModuleId { get; set; }
        public OperationBuilder<AddColumnOperation> UserId { get; set; }
        public OperationBuilder<AddColumnOperation> Name { get; set; }
        public OperationBuilder<AddColumnOperation> Tagline { get; set; }
        public OperationBuilder<AddColumnOperation> Description { get; set; }
        public OperationBuilder<AddColumnOperation> LogoFileId { get; set; }
        public OperationBuilder<AddColumnOperation> BannerFileId { get; set; }
    }
}
