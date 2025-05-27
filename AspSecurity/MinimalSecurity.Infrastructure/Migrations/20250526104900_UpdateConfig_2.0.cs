using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MinimalSecurity.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateConfig_20 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissionEntity_PermissionId",
                table: "RolePermissionEntity",
                column: "PermissionId");

            migrationBuilder.AddForeignKey(
                name: "FK_RolePermissionEntity_PermissionEntity_PermissionId",
                table: "RolePermissionEntity",
                column: "PermissionId",
                principalTable: "PermissionEntity",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RolePermissionEntity_RoleEntity_RoleId",
                table: "RolePermissionEntity",
                column: "RoleId",
                principalTable: "RoleEntity",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RolePermissionEntity_PermissionEntity_PermissionId",
                table: "RolePermissionEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_RolePermissionEntity_RoleEntity_RoleId",
                table: "RolePermissionEntity");

            migrationBuilder.DropIndex(
                name: "IX_RolePermissionEntity_PermissionId",
                table: "RolePermissionEntity");

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
    }
}
