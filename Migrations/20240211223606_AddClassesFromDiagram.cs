using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFGetStarted.Migrations
{
    /// <inheritdoc />
    public partial class AddClassesFromDiagram : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Team_TeamID",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Team_Tasks_CurrentTaskTaskId",
                table: "Team");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamWorkers_Team_TeamID",
                table: "TeamWorkers");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamWorkers_Worker_WorkerID",
                table: "TeamWorkers");

            migrationBuilder.DropForeignKey(
                name: "FK_Todos_Worker_WorkerID",
                table: "Todos");

            migrationBuilder.DropForeignKey(
                name: "FK_Worker_Todos_CurrentTodoTodoId",
                table: "Worker");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Worker",
                table: "Worker");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Team",
                table: "Team");

            migrationBuilder.RenameTable(
                name: "Worker",
                newName: "Workers");

            migrationBuilder.RenameTable(
                name: "Team",
                newName: "Teams");

            migrationBuilder.RenameIndex(
                name: "IX_Worker_CurrentTodoTodoId",
                table: "Workers",
                newName: "IX_Workers_CurrentTodoTodoId");

            migrationBuilder.RenameIndex(
                name: "IX_Team_CurrentTaskTaskId",
                table: "Teams",
                newName: "IX_Teams_CurrentTaskTaskId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Workers",
                table: "Workers",
                column: "WorkerID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teams",
                table: "Teams",
                column: "TeamID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Teams_TeamID",
                table: "Tasks",
                column: "TeamID",
                principalTable: "Teams",
                principalColumn: "TeamID");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Tasks_CurrentTaskTaskId",
                table: "Teams",
                column: "CurrentTaskTaskId",
                principalTable: "Tasks",
                principalColumn: "TaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_TeamWorkers_Teams_TeamID",
                table: "TeamWorkers",
                column: "TeamID",
                principalTable: "Teams",
                principalColumn: "TeamID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamWorkers_Workers_WorkerID",
                table: "TeamWorkers",
                column: "WorkerID",
                principalTable: "Workers",
                principalColumn: "WorkerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Todos_Workers_WorkerID",
                table: "Todos",
                column: "WorkerID",
                principalTable: "Workers",
                principalColumn: "WorkerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_Todos_CurrentTodoTodoId",
                table: "Workers",
                column: "CurrentTodoTodoId",
                principalTable: "Todos",
                principalColumn: "TodoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Teams_TeamID",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Tasks_CurrentTaskTaskId",
                table: "Teams");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamWorkers_Teams_TeamID",
                table: "TeamWorkers");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamWorkers_Workers_WorkerID",
                table: "TeamWorkers");

            migrationBuilder.DropForeignKey(
                name: "FK_Todos_Workers_WorkerID",
                table: "Todos");

            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Todos_CurrentTodoTodoId",
                table: "Workers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Workers",
                table: "Workers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teams",
                table: "Teams");

            migrationBuilder.RenameTable(
                name: "Workers",
                newName: "Worker");

            migrationBuilder.RenameTable(
                name: "Teams",
                newName: "Team");

            migrationBuilder.RenameIndex(
                name: "IX_Workers_CurrentTodoTodoId",
                table: "Worker",
                newName: "IX_Worker_CurrentTodoTodoId");

            migrationBuilder.RenameIndex(
                name: "IX_Teams_CurrentTaskTaskId",
                table: "Team",
                newName: "IX_Team_CurrentTaskTaskId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Worker",
                table: "Worker",
                column: "WorkerID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Team",
                table: "Team",
                column: "TeamID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Team_TeamID",
                table: "Tasks",
                column: "TeamID",
                principalTable: "Team",
                principalColumn: "TeamID");

            migrationBuilder.AddForeignKey(
                name: "FK_Team_Tasks_CurrentTaskTaskId",
                table: "Team",
                column: "CurrentTaskTaskId",
                principalTable: "Tasks",
                principalColumn: "TaskId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Todos_Worker_WorkerID",
                table: "Todos",
                column: "WorkerID",
                principalTable: "Worker",
                principalColumn: "WorkerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Worker_Todos_CurrentTodoTodoId",
                table: "Worker",
                column: "CurrentTodoTodoId",
                principalTable: "Todos",
                principalColumn: "TodoId");
        }
    }
}
