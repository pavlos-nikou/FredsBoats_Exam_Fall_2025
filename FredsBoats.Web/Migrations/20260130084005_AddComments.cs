using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FredsBoats.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddComments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "comment",
                columns: table => new
                {
                    commentid = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    content = table.Column<string>(type: "TEXT", nullable: false),
                    author = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    fkboatid = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comment", x => x.commentid);
                });

            migrationBuilder.CreateTable(
                name: "BoatComment",
                columns: table => new
                {
                    BoatsBoatId = table.Column<int>(type: "INTEGER", nullable: false),
                    CommentsCommentId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoatComment", x => new { x.BoatsBoatId, x.CommentsCommentId });
                    table.ForeignKey(
                        name: "FK_BoatComment_boat_BoatsBoatId",
                        column: x => x.BoatsBoatId,
                        principalTable: "boat",
                        principalColumn: "boatid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BoatComment_comment_CommentsCommentId",
                        column: x => x.CommentsCommentId,
                        principalTable: "comment",
                        principalColumn: "commentid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BoatComment_CommentsCommentId",
                table: "BoatComment",
                column: "CommentsCommentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoatComment");

            migrationBuilder.DropTable(
                name: "comment");
        }
    }
}
