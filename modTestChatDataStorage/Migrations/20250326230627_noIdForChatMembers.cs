using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace modTestChatDataStorage.Migrations
{
    /// <inheritdoc />
    public partial class noIdForChatMembers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "id",
                table: "chat_members");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "chat_members",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
