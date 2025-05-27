using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MinimalSecurity.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PermissionEntityRoleEntity");

            migrationBuilder.AddColumn<int>(
                name: "id_permission",
                table: "RolePermissionEntity",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "id_role",
                table: "RolePermissionEntity",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissionEntity_id_permission",
                table: "RolePermissionEntity",
                column: "id_permission");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissionEntity_id_role",
                table: "RolePermissionEntity",
                column: "id_role");

            migrationBuilder.AddForeignKey(
                name: "FK_RolePermissionEntity_PermissionEntity_id_permission",
                table: "RolePermissionEntity",
                column: "id_permission",
                principalTable: "PermissionEntity",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RolePermissionEntity_RoleEntity_id_role",
                table: "RolePermissionEntity",
                column: "id_role",
                principalTable: "RoleEntity",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RolePermissionEntity_PermissionEntity_id_permission",
                table: "RolePermissionEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_RolePermissionEntity_RoleEntity_id_role",
                table: "RolePermissionEntity");

            migrationBuilder.DropIndex(
                name: "IX_RolePermissionEntity_id_permission",
                table: "RolePermissionEntity");

            migrationBuilder.DropIndex(
                name: "IX_RolePermissionEntity_id_role",
                table: "RolePermissionEntity");

            migrationBuilder.DropColumn(
                name: "id_permission",
                table: "RolePermissionEntity");

            migrationBuilder.DropColumn(
                name: "id_role",
                table: "RolePermissionEntity");

            migrationBuilder.CreateTable(
                name: "PermissionEntityRoleEntity",
                columns: table => new
                {
                    id_permission = table.Column<int>(type: "int", nullable: false),
                    id_role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionEntityRoleEntity", x => new { x.id_permission, x.id_role });
                    table.ForeignKey(
                        name: "FK_PermissionEntityRoleEntity_PermissionEntity_id_permission",
                        column: x => x.id_permission,
                        principalTable: "PermissionEntity",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PermissionEntityRoleEntity_RoleEntity_id_role",
                        column: x => x.id_role,
                        principalTable: "RoleEntity",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PermissionEntityRoleEntity_id_role",
                table: "PermissionEntityRoleEntity",
                column: "id_role");
        }
    }
}
