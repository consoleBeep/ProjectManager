using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFGetStarted.Migrations
{
    /// <inheritdoc />
    public partial class CreateTeamWorkersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeamWorker_Team_TeamID",
                table: "TeamWorker");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamWorker_Worker_WorkerID",
                table: "TeamWorker");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamWorker",
                table: "TeamWorker");

            migrationBuilder.RenameTable(
                name: "TeamWorker",
                newName: "TeamWorkers");

            migrationBuilder.RenameIndex(
                name: "IX_TeamWorker_WorkerID",
                table: "TeamWorkers",
                newName: "IX_TeamWorkers_WorkerID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamWorkers",
                table: "TeamWorkers",
                columns: new[] { "TeamID", "WorkerID" });

            migrationBuilder.AddForeignKey(
                name: "FK_TeamWorkers_Team_TeamID",
                table: "TeamWorkers",
                column: "TeamID",
                principalTable: "Team",
                principalColumn: "TeamID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamWorkers_Worker_WorkerID",
                table: "TeamWorkers",
                column: "WorkerID",
                principalTable: "Worker",
                principalColumn: "WorkerID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeamWorkers_Team_TeamID",
                table: "TeamWorkers");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamWorkers_Worker_WorkerID",
                table: "TeamWorkers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamWorkers",
                table: "TeamWorkers");

            migrationBuilder.RenameTable(
                name: "TeamWorkers",
                newName: "TeamWorker");

            migrationBuilder.RenameIndex(
                name: "IX_TeamWorkers_WorkerID",
                table: "TeamWorker",
                newName: "IX_TeamWorker_WorkerID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamWorker",
                table: "TeamWorker",
                columns: new[] { "TeamID", "WorkerID" });

            migrationBuilder.AddForeignKey(
                name: "FK_TeamWorker_Team_TeamID",
                table: "TeamWorker",
                column: "TeamID",
                principalTable: "Team",
                principalColumn: "TeamID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamWorker_Worker_WorkerID",
                table: "TeamWorker",
                column: "WorkerID",
                principalTable: "Worker",
                principalColumn: "WorkerID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
