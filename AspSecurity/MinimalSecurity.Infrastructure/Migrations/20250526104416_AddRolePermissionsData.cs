using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MinimalSecurity.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRolePermissionsData : Migration
    {
        /// <inheritdoc />
        protected override void Up( MigrationBuilder migrationBuilder )
        {
            migrationBuilder.CreateTable(
                name: "RolePermissionEntity",
                columns: table => new
                {
                    PermissionId = table.Column<int>( type: "int", nullable: false ),
                    RoleId = table.Column<int>( type: "int", nullable: false )
                },
                constraints: table =>
                {
                    table.PrimaryKey( "PK_RolePermissionEntity", x => new { x.RoleId, x.PermissionId } );
                } );
        }

        /// <inheritdoc />
        protected override void Down( MigrationBuilder migrationBuilder )
        {
            migrationBuilder.DropTable(
                name: "RolePermissionEntity" );
        }
    }
}
