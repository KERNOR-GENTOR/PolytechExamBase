using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PolytechExamBase.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DBUser",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false),
                    First_Name = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    Second_Name = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    Email = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    Password_Hash = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Expires_In = table.Column<DateTime>(type: "date", nullable: true),
                    Access_Failed_Counts = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("User_PK", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Difficulty",
                columns: table => new
                {
                    Difficulty_ID = table.Column<int>(nullable: false),
                    Difficulty_Level = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Difficulty", x => x.Difficulty_ID);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Role_ID = table.Column<int>(nullable: false),
                    Role_Name = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    Priority = table.Column<string>(unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Role_ID);
                });

            migrationBuilder.CreateTable(
                name: "Test_Topic",
                columns: table => new
                {
                    Topic_ID = table.Column<int>(nullable: false),
                    Topic_Name = table.Column<string>(unicode: false, maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Test_Topic_PK", x => x.Topic_ID);
                });

            migrationBuilder.CreateTable(
                name: "Journal",
                columns: table => new
                {
                    Journal_ID = table.Column<int>(nullable: false),
                    User_UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Journal", x => x.Journal_ID);
                    table.ForeignKey(
                        name: "Journal_User_FK",
                        column: x => x.User_UserID,
                        principalTable: "DBUser",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    Task_ID = table.Column<int>(nullable: false),
                    Task_Name = table.Column<string>(unicode: false, maxLength: 256, nullable: true),
                    Question = table.Column<string>(unicode: false, maxLength: 256, nullable: true),
                    Solution = table.Column<string>(unicode: false, maxLength: 8000, nullable: true),
                    Difficulty_Difficulty_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.Task_ID);
                    table.ForeignKey(
                        name: "Task_Difficulty_FK",
                        column: x => x.Difficulty_Difficulty_ID,
                        principalTable: "Difficulty",
                        principalColumn: "Difficulty_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User_Role",
                columns: table => new
                {
                    User_Role_ID = table.Column<int>(nullable: false),
                    Role_Role_ID = table.Column<int>(nullable: false),
                    User_UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Role", x => x.User_Role_ID);
                    table.ForeignKey(
                        name: "User_Role_Role_FK",
                        column: x => x.Role_Role_ID,
                        principalTable: "Role",
                        principalColumn: "Role_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "User_Role_User_FK",
                        column: x => x.User_UserID,
                        principalTable: "DBUser",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Passed_Task",
                columns: table => new
                {
                    Passed_Task_ID = table.Column<int>(nullable: false),
                    Given_Answer = table.Column<string>(unicode: false, maxLength: 8000, nullable: true),
                    Is_Right = table.Column<string>(unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    Task_Task_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passed_Task", x => x.Passed_Task_ID);
                    table.ForeignKey(
                        name: "Passed_Task_Task_FK",
                        column: x => x.Task_Task_ID,
                        principalTable: "Task",
                        principalColumn: "Task_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Task_Test_Topic",
                columns: table => new
                {
                    Task_Test_Topic_ID = table.Column<int>(nullable: false),
                    Test_Topic_Topic_ID = table.Column<int>(nullable: false),
                    Task_Task_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task_Test_Topic", x => x.Task_Test_Topic_ID);
                    table.ForeignKey(
                        name: "Task_Test_Topic_Task_FK",
                        column: x => x.Task_Task_ID,
                        principalTable: "Task",
                        principalColumn: "Task_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Task_Test_Topic_Test_Topic_FK",
                        column: x => x.Test_Topic_Topic_ID,
                        principalTable: "Test_Topic",
                        principalColumn: "Topic_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Mark",
                columns: table => new
                {
                    Mark_ID = table.Column<int>(nullable: false),
                    Mark_Number = table.Column<int>(nullable: true),
                    Mark_String = table.Column<string>(unicode: false, maxLength: 15, nullable: true),
                    Passed_Task_Passed_Task_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mark", x => x.Mark_ID);
                    table.ForeignKey(
                        name: "Mark_Passed_Task_FK",
                        column: x => x.Passed_Task_Passed_Task_ID,
                        principalTable: "Passed_Task",
                        principalColumn: "Passed_Task_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User_Passed_Task",
                columns: table => new
                {
                    User_Passed_Task_ID = table.Column<int>(nullable: false),
                    Passed_Task_Passed_Task_ID = table.Column<int>(nullable: false),
                    User_UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Passed_Task", x => x.User_Passed_Task_ID);
                    table.ForeignKey(
                        name: "User_Passed_Task_Passed_Task_FK",
                        column: x => x.Passed_Task_Passed_Task_ID,
                        principalTable: "Passed_Task",
                        principalColumn: "Passed_Task_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "User_Passed_Task_User_FK",
                        column: x => x.User_UserID,
                        principalTable: "DBUser",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Mark_Journal",
                columns: table => new
                {
                    Mark_Journal_ID = table.Column<int>(nullable: false),
                    Journal_Journal_ID = table.Column<int>(nullable: false),
                    Mark_Mark_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mark_Journal", x => x.Mark_Journal_ID);
                    table.ForeignKey(
                        name: "Mark_Journal_Journal_FK",
                        column: x => x.Journal_Journal_ID,
                        principalTable: "Journal",
                        principalColumn: "Journal_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Mark_Journal_Mark_FK",
                        column: x => x.Mark_Mark_ID,
                        principalTable: "Mark",
                        principalColumn: "Mark_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Journal_User_UserID",
                table: "Journal",
                column: "User_UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Mark_Passed_Task_Passed_Task_ID",
                table: "Mark",
                column: "Passed_Task_Passed_Task_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Mark_Journal_Journal_Journal_ID",
                table: "Mark_Journal",
                column: "Journal_Journal_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Mark_Journal_Mark_Mark_ID",
                table: "Mark_Journal",
                column: "Mark_Mark_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Passed_Task_Task_Task_ID",
                table: "Passed_Task",
                column: "Task_Task_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Task_Difficulty_Difficulty_ID",
                table: "Task",
                column: "Difficulty_Difficulty_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Task_Test_Topic_Task_Task_ID",
                table: "Task_Test_Topic",
                column: "Task_Task_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Task_Test_Topic_Test_Topic_Topic_ID",
                table: "Task_Test_Topic",
                column: "Test_Topic_Topic_ID");

            migrationBuilder.CreateIndex(
                name: "IX_User_Passed_Task_Passed_Task_Passed_Task_ID",
                table: "User_Passed_Task",
                column: "Passed_Task_Passed_Task_ID");

            migrationBuilder.CreateIndex(
                name: "IX_User_Passed_Task_User_UserID",
                table: "User_Passed_Task",
                column: "User_UserID");

            migrationBuilder.CreateIndex(
                name: "IX_User_Role_Role_Role_ID",
                table: "User_Role",
                column: "Role_Role_ID");

            migrationBuilder.CreateIndex(
                name: "IX_User_Role_User_UserID",
                table: "User_Role",
                column: "User_UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mark_Journal");

            migrationBuilder.DropTable(
                name: "Task_Test_Topic");

            migrationBuilder.DropTable(
                name: "User_Passed_Task");

            migrationBuilder.DropTable(
                name: "User_Role");

            migrationBuilder.DropTable(
                name: "Journal");

            migrationBuilder.DropTable(
                name: "Mark");

            migrationBuilder.DropTable(
                name: "Test_Topic");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "DBUser");

            migrationBuilder.DropTable(
                name: "Passed_Task");

            migrationBuilder.DropTable(
                name: "Task");

            migrationBuilder.DropTable(
                name: "Difficulty");
        }
    }
}
