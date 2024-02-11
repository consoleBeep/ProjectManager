using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFGetStarted.Migrations
{
    /// <inheritdoc />
    public partial class CreatedTeamsWorkers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WorkerID",
                table: "Todos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeamID",
                table: "Tasks",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    TeamID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    CurrentTaskTaskId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.TeamID);
                    table.ForeignKey(
                        name: "FK_Team_Tasks_CurrentTaskTaskId",
                        column: x => x.CurrentTaskTaskId,
                        principalTable: "Tasks",
                        principalColumn: "TaskId");
                });

            migrationBuilder.CreateTable(
                name: "Worker",
                columns: table => new
                {
                    WorkerID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    CurrentTodoTodoId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Worker", x => x.WorkerID);
                    table.ForeignKey(
                        name: "FK_Worker_Todos_CurrentTodoTodoId",
                        column: x => x.CurrentTodoTodoId,
                        principalTable: "Todos",
                        principalColumn: "TodoId");
                });

            migrationBuilder.CreateTable(
                name: "TeamWorker",
                columns: table => new
                {
                    TeamID = table.Column<int>(type: "INTEGER", nullable: false),
                    WorkerID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamWorker", x => new { x.TeamID, x.WorkerID });
                    table.ForeignKey(
                        name: "FK_TeamWorker_Team_TeamID",
                        column: x => x.TeamID,
                        principalTable: "Team",
                        principalColumn: "TeamID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamWorker_Worker_WorkerID",
                        column: x => x.WorkerID,
                        principalTable: "Worker",
                        principalColumn: "WorkerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Todos_WorkerID",
                table: "Todos",
                column: "WorkerID");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_TeamID",
                table: "Tasks",
                column: "TeamID");

            migrationBuilder.CreateIndex(
                name: "IX_Team_CurrentTaskTaskId",
                table: "Team",
                column: "CurrentTaskTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamWorker_WorkerID",
                table: "TeamWorker",
                column: "WorkerID");

            migrationBuilder.CreateIndex(
                name: "IX_Worker_CurrentTodoTodoId",
                table: "Worker",
                column: "CurrentTodoTodoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Team_TeamID",
                table: "Tasks",
                column: "TeamID",
                principalTable: "Team",
                principalColumn: "TeamID");

            migrationBuilder.AddForeignKey(
                name: "FK_Todos_Worker_WorkerID",
                table: "Todos",
                column: "WorkerID",
                principalTable: "Worker",
                principalColumn: "WorkerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Team_TeamID",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Todos_Worker_WorkerID",
                table: "Todos");

            migrationBuilder.DropTable(
                name: "TeamWorker");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "Worker");

            migrationBuilder.DropIndex(
                name: "IX_Todos_WorkerID",
                table: "Todos");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_TeamID",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "WorkerID",
                table: "Todos");

            migrationBuilder.DropColumn(
                name: "TeamID",
                table: "Tasks");
        }
    }
}
