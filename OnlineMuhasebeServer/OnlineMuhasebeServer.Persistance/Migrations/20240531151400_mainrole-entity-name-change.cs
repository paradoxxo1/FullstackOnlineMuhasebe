using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineMuhasebeServer.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class mainroleentitynamechange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ISRoleCreatedByAdmin",
                table: "MainRoles",
                newName: "IsRoleCreatedByAdmin");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsRoleCreatedByAdmin",
                table: "MainRoles",
                newName: "ISRoleCreatedByAdmin");
        }
    }
}
