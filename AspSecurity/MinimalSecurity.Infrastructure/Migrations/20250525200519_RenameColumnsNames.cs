using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MinimalSecurity.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenameColumnsNames : Migration
    {
        /// <inheritdoc />
        protected override void Up( MigrationBuilder migrationBuilder )
        {
            migrationBuilder.RenameColumn(
                name: "Username",
                table: "User",
                newName: "username" );

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "User",
                newName: "email" );

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "User",
                newName: "id" );

            migrationBuilder.RenameColumn(
                name: "HashedPassword",
                table: "User",
                newName: "hashed_password" );
        }

        /// <inheritdoc />
        protected override void Down( MigrationBuilder migrationBuilder )
        {
            migrationBuilder.RenameColumn(
                name: "username",
                table: "User",
                newName: "Username" );

            migrationBuilder.RenameColumn(
                name: "email",
                table: "User",
                newName: "Email" );

            migrationBuilder.RenameColumn(
                name: "id",
                table: "User",
                newName: "Id" );

            migrationBuilder.RenameColumn(
                name: "hashed_password",
                table: "User",
                newName: "HashedPassword" );
        }
    }
}
