using Microsoft.EntityFrameworkCore.Migrations;

namespace helloworld.Migrations
{
    public partial class Createnotes5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "labels",
                columns: table => new
                {
                    labelid = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    text = table.Column<string>(maxLength: 200, nullable: false),
                    id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_labels", x => x.labelid);
                });

            migrationBuilder.CreateTable(
                name: "notes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    title = table.Column<string>(maxLength: 200, nullable: true),
                    text = table.Column<string>(maxLength: 500, nullable: true),
                    pinned = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notes", x => x.id);
                    table.ForeignKey(
                        name: "FK_notes_labels_id",
                        column: x => x.id,
                        principalTable: "labels",
                        principalColumn: "labelid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "checklist",
                columns: table => new
                {
                    checkid = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    write = table.Column<string>(maxLength: 200, nullable: false),
                    ischecked = table.Column<bool>(nullable: false),
                    id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_checklist", x => x.checkid);
                    table.ForeignKey(
                        name: "FK_checklist_notes_id",
                        column: x => x.id,
                        principalTable: "notes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_checklist_id",
                table: "checklist",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "checklist");

            migrationBuilder.DropTable(
                name: "notes");

            migrationBuilder.DropTable(
                name: "labels");
        }
    }
}
