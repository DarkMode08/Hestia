using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Contacts_Agenda.Migrations
{
    /// <inheritdoc />
    public partial class CreationDB_1er : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    iD_Contact = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nameContact = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    position = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    emailContact = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    phoneNumberContact = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    addres = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.iD_Contact);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");
        }
    }
}
