using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMS.Persistence
{
    /// <inheritdoc />
    public partial class removinghostConfig_migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HostConfiguration");

            migrationBuilder.AddColumn<string>(
                name: "DomainAddress",
                table: "Host",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "GeneratedCodesDirectory",
                table: "Host",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DomainAddress",
                table: "Host");

            migrationBuilder.DropColumn(
                name: "GeneratedCodesDirectory",
                table: "Host");

            migrationBuilder.CreateTable(
                name: "HostConfiguration",
                columns: table => new
                {
                    HostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DomainAddress = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    GeneratedCodesDirectory = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HostConfiguration", x => x.HostId);
                    table.ForeignKey(
                        name: "FK_HostConfiguration_Host_HostId",
                        column: x => x.HostId,
                        principalTable: "Host",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
        }
    }
}
