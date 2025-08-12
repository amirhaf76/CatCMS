using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMSRepository.Migrations
{
    /// <inheritdoc />
    public partial class second_migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HostConfiguration",
                columns: table => new
                {
                    HostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GeneratedCodesDirectory = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    DomainAddress = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HostConfiguration");
        }
    }
}
