using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MinimalSecurity.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRolesAndPermissions : Migration
    {
        /// <inheritdoc />
        protected override void Up( MigrationBuilder migrationBuilder )
        {
            migrationBuilder.DropTable(
                name: "User" );

            migrationBuilder.CreateTable(
                name: "PermissionEntity",
                columns: table => new
                {
                    id = table.Column<int>( type: "int", nullable: false )
                        .Annotation( "SqlServer:Identity", "1, 1" ),
                    Name = table.Column<string>( type: "nvarchar(max)", nullable: true )
                },
                constraints: table =>
                {
                    table.PrimaryKey( "PK_PermissionEntity", x => x.id );
                } );

            migrationBuilder.CreateTable(
                name: "RoleEntity",
                columns: table => new
                {
                    id = table.Column<int>( type: "int", nullable: false )
                        .Annotation( "SqlServer:Identity", "1, 1" ),
                    Name = table.Column<string>( type: "nvarchar(max)", nullable: true )
                },
                constraints: table =>
                {
                    table.PrimaryKey( "PK_RoleEntity", x => x.id );
                } );

            migrationBuilder.CreateTable(
                name: "UserEntity",
                columns: table => new
                {
                    id = table.Column<Guid>( type: "uniqueidentifier", nullable: false ),
                    username = table.Column<string>( type: "nvarchar(30)", maxLength: 30, nullable: false ),
                    hashed_password = table.Column<string>( type: "nvarchar(max)", nullable: false ),
                    email = table.Column<string>( type: "nvarchar(50)", maxLength: 50, nullable: false )
                },
                constraints: table =>
                {
                    table.PrimaryKey( "PK_UserEntity", x => x.id );
                } );

            migrationBuilder.CreateTable(
                name: "PermissionEntityRoleEntity",
                columns: table => new
                {
                    id_permission = table.Column<int>( type: "int", nullable: false ),
                    id_role = table.Column<int>( type: "int", nullable: false )
                },
                constraints: table =>
                {
                    table.PrimaryKey( "PK_PermissionEntityRoleEntity", x => new { x.id_permission, x.id_role } );
                    table.ForeignKey(
                        name: "FK_PermissionEntityRoleEntity_PermissionEntity_id_permission",
                        column: x => x.id_permission,
                        principalTable: "PermissionEntity",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade );
                    table.ForeignKey(
                        name: "FK_PermissionEntityRoleEntity_RoleEntity_id_role",
                        column: x => x.id_role,
                        principalTable: "RoleEntity",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade );
                } );

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    id_role = table.Column<int>( type: "int", nullable: false ),
                    id_user = table.Column<Guid>( type: "uniqueidentifier", nullable: false )
                },
                constraints: table =>
                {
                    table.PrimaryKey( "PK_UserRole", x => new { x.id_role, x.id_user } );
                    table.ForeignKey(
                        name: "FK_UserRole_RoleEntity_id_role",
                        column: x => x.id_role,
                        principalTable: "RoleEntity",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade );
                    table.ForeignKey(
                        name: "FK_UserRole_UserEntity_id_user",
                        column: x => x.id_user,
                        principalTable: "UserEntity",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade );
                } );

            migrationBuilder.InsertData(
                table: "PermissionEntity",
                columns: new[] { "id", "Name" },
                values: new object[,]
                {
                    { 1, "Read" },
                    { 2, "Create" },
                    { 3, "Update" },
                    { 4, "Delete" }
                } );

            migrationBuilder.InsertData(
                table: "RoleEntity",
                columns: new[] { "id", "Name" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "User" }
                } );

            migrationBuilder.CreateIndex(
                name: "IX_PermissionEntityRoleEntity_id_role",
                table: "PermissionEntityRoleEntity",
                column: "id_role" );

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_id_user",
                table: "UserRole",
                column: "id_user" );
        }

        /// <inheritdoc />
        protected override void Down( MigrationBuilder migrationBuilder )
        {
            migrationBuilder.DropTable(
                name: "PermissionEntityRoleEntity" );

            migrationBuilder.DropTable(
                name: "UserRole" );

            migrationBuilder.DropTable(
                name: "PermissionEntity" );

            migrationBuilder.DropTable(
                name: "RoleEntity" );

            migrationBuilder.DropTable(
                name: "UserEntity" );

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<Guid>( type: "uniqueidentifier", nullable: false ),
                    email = table.Column<string>( type: "nvarchar(50)", maxLength: 50, nullable: false ),
                    hashed_password = table.Column<string>( type: "nvarchar(max)", nullable: false ),
                    username = table.Column<string>( type: "nvarchar(30)", maxLength: 30, nullable: false )
                },
                constraints: table =>
                {
                    table.PrimaryKey( "PK_User", x => x.id );
                } );
        }
    }
}
