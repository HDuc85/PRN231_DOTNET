using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InternManagementData.Migrations
{
    /// <inheritdoc />
    public partial class Uodate_Fields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    CompanyID = table.Column<int>(type: "int", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CompanyAddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CompanyPhone = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    CompanyEmail = table.Column<string>(type: "varchar(320)", unicode: false, maxLength: 320, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Company__2D971C4C946A4B9B", x => x.CompanyID);
                });

            migrationBuilder.CreateTable(
                name: "MentorProfile",
                columns: table => new
                {
                    MentorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MentorName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MentorAddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    MentorPhone = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    MentorEmail = table.Column<string>(type: "varchar(320)", unicode: false, maxLength: 320, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__MentorPr__053B7E7816101203", x => x.MentorID);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    StatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Status__C8EE20436BC997AD", x => x.StatusID);
                });

            migrationBuilder.CreateTable(
                name: "TrainingProgram",
                columns: table => new
                {
                    ProgramID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ProgramDecription = table.Column<string>(type: "ntext", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Training__752560382C59AD08", x => x.ProgramID);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EmployeeAddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    EmployeePhone = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    EmployeeEmail = table.Column<string>(type: "varchar(320)", unicode: false, maxLength: 320, nullable: true),
                    CompanyID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Employee__7AD04FF17D952C50", x => x.EmployeeID);
                    table.ForeignKey(
                        name: "FK__Employee__Compan__4AB81AF0",
                        column: x => x.CompanyID,
                        principalTable: "Company",
                        principalColumn: "CompanyID");
                });

            migrationBuilder.CreateTable(
                name: "InternProfile",
                columns: table => new
                {
                    InternID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InternName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    InternAddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    InternEmail = table.Column<string>(type: "varchar(320)", unicode: false, maxLength: 320, nullable: true),
                    InternPhone = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    University = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Major = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MentorID = table.Column<int>(type: "int", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__InternPr__6910ED829DD0E6AF", x => x.InternID);
                    table.ForeignKey(
                        name: "FK__InternPro__Mento__4BAC3F29",
                        column: x => x.MentorID,
                        principalTable: "MentorProfile",
                        principalColumn: "MentorID");
                });

            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    TaskID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TaskDecription = table.Column<string>(type: "ntext", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    StatusID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Task__7C6949D162EF0762", x => x.TaskID);
                    table.ForeignKey(
                        name: "FK__Task__StatusID__52593CB8",
                        column: x => x.StatusID,
                        principalTable: "Status",
                        principalColumn: "StatusID");
                });

            migrationBuilder.CreateTable(
                name: "MentorIntern",
                columns: table => new
                {
                    MentorInternID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InternID = table.Column<int>(type: "int", nullable: true),
                    MentorID = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__MentorIn__2217D7BF4265B011", x => x.MentorInternID);
                    table.ForeignKey(
                        name: "FK__MentorInt__Inter__4CA06362",
                        column: x => x.InternID,
                        principalTable: "InternProfile",
                        principalColumn: "InternID");
                    table.ForeignKey(
                        name: "FK__MentorInt__Mento__4D94879B",
                        column: x => x.MentorID,
                        principalTable: "MentorProfile",
                        principalColumn: "MentorID");
                });

            migrationBuilder.CreateTable(
                name: "ProgramIntern",
                columns: table => new
                {
                    ProgramInternID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InternID = table.Column<int>(type: "int", nullable: true),
                    ProgramID = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ProgramI__44F12DE373C7B9C6", x => x.ProgramInternID);
                    table.ForeignKey(
                        name: "FK__ProgramIn__Inter__4E88ABD4",
                        column: x => x.InternID,
                        principalTable: "InternProfile",
                        principalColumn: "InternID");
                    table.ForeignKey(
                        name: "FK__ProgramIn__Progr__4F7CD00D",
                        column: x => x.ProgramID,
                        principalTable: "TrainingProgram",
                        principalColumn: "ProgramID");
                });

            migrationBuilder.CreateTable(
                name: "ProgramTask",
                columns: table => new
                {
                    ProgramTaskID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskID = table.Column<int>(type: "int", nullable: true),
                    ProgramID = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ProgramT__8B64F485E20E21BB", x => x.ProgramTaskID);
                    table.ForeignKey(
                        name: "FK__ProgramTa__Progr__5070F446",
                        column: x => x.ProgramID,
                        principalTable: "TrainingProgram",
                        principalColumn: "ProgramID");
                    table.ForeignKey(
                        name: "FK__ProgramTa__TaskI__5165187F",
                        column: x => x.TaskID,
                        principalTable: "Task",
                        principalColumn: "TaskID");
                });

            migrationBuilder.CreateTable(
                name: "TaskManage",
                columns: table => new
                {
                    TaskManageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskID = table.Column<int>(type: "int", nullable: true),
                    InternID = table.Column<int>(type: "int", nullable: true),
                    MentorID = table.Column<int>(type: "int", nullable: true),
                    StatusID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TaskMana__8AFA651A1B0DD46F", x => x.TaskManageID);
                    table.ForeignKey(
                        name: "FK__TaskManag__Inter__534D60F1",
                        column: x => x.InternID,
                        principalTable: "InternProfile",
                        principalColumn: "InternID");
                    table.ForeignKey(
                        name: "FK__TaskManag__Mento__5441852A",
                        column: x => x.MentorID,
                        principalTable: "MentorProfile",
                        principalColumn: "MentorID");
                    table.ForeignKey(
                        name: "FK__TaskManag__Statu__5535A963",
                        column: x => x.StatusID,
                        principalTable: "Status",
                        principalColumn: "StatusID");
                    table.ForeignKey(
                        name: "FK__TaskManag__TaskI__5629CD9C",
                        column: x => x.TaskID,
                        principalTable: "Task",
                        principalColumn: "TaskID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_CompanyID",
                table: "Employee",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_InternProfile_MentorID",
                table: "InternProfile",
                column: "MentorID");

            migrationBuilder.CreateIndex(
                name: "IX_MentorIntern_InternID",
                table: "MentorIntern",
                column: "InternID");

            migrationBuilder.CreateIndex(
                name: "IX_MentorIntern_MentorID",
                table: "MentorIntern",
                column: "MentorID");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramIntern_InternID",
                table: "ProgramIntern",
                column: "InternID");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramIntern_ProgramID",
                table: "ProgramIntern",
                column: "ProgramID");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramTask_ProgramID",
                table: "ProgramTask",
                column: "ProgramID");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramTask_TaskID",
                table: "ProgramTask",
                column: "TaskID");

            migrationBuilder.CreateIndex(
                name: "IX_Task_StatusID",
                table: "Task",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_TaskManage_InternID",
                table: "TaskManage",
                column: "InternID");

            migrationBuilder.CreateIndex(
                name: "IX_TaskManage_MentorID",
                table: "TaskManage",
                column: "MentorID");

            migrationBuilder.CreateIndex(
                name: "IX_TaskManage_StatusID",
                table: "TaskManage",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_TaskManage_TaskID",
                table: "TaskManage",
                column: "TaskID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "MentorIntern");

            migrationBuilder.DropTable(
                name: "ProgramIntern");

            migrationBuilder.DropTable(
                name: "ProgramTask");

            migrationBuilder.DropTable(
                name: "TaskManage");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "TrainingProgram");

            migrationBuilder.DropTable(
                name: "InternProfile");

            migrationBuilder.DropTable(
                name: "Task");

            migrationBuilder.DropTable(
                name: "MentorProfile");

            migrationBuilder.DropTable(
                name: "Status");
        }
    }
}
