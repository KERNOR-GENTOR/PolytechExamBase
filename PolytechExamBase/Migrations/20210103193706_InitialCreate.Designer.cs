﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PolytechExamBase.Models;

namespace PolytechExamBase.Migrations
{
    [DbContext(typeof(PolytechExamTestContext))]
    [Migration("20210103193706_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PolytechExamBase.Models.Dbuser", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnName("UserID")
                        .HasColumnType("int");

                    b.Property<int?>("AccessFailedCounts")
                        .HasColumnName("Access_Failed_Counts")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(30)")
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    b.Property<DateTime?>("ExpiresIn")
                        .HasColumnName("Expires_In")
                        .HasColumnType("date");

                    b.Property<string>("FirstName")
                        .HasColumnName("First_Name")
                        .HasColumnType("varchar(30)")
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    b.Property<string>("PasswordHash")
                        .HasColumnName("Password_Hash")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("SecondName")
                        .HasColumnName("Second_Name")
                        .HasColumnType("varchar(30)")
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    b.HasKey("UserId")
                        .HasName("User_PK");

                    b.ToTable("DBUser");
                });

            modelBuilder.Entity("PolytechExamBase.Models.Difficulty", b =>
                {
                    b.Property<int>("DifficultyId")
                        .HasColumnName("Difficulty_ID")
                        .HasColumnType("int");

                    b.Property<int?>("DifficultyLevel")
                        .HasColumnName("Difficulty_Level")
                        .HasColumnType("int");

                    b.HasKey("DifficultyId");

                    b.ToTable("Difficulty");
                });

            modelBuilder.Entity("PolytechExamBase.Models.Journal", b =>
                {
                    b.Property<int>("JournalId")
                        .HasColumnName("Journal_ID")
                        .HasColumnType("int");

                    b.Property<int>("UserUserId")
                        .HasColumnName("User_UserID")
                        .HasColumnType("int");

                    b.HasKey("JournalId");

                    b.HasIndex("UserUserId");

                    b.ToTable("Journal");
                });

            modelBuilder.Entity("PolytechExamBase.Models.Mark", b =>
                {
                    b.Property<int>("MarkId")
                        .HasColumnName("Mark_ID")
                        .HasColumnType("int");

                    b.Property<int?>("MarkNumber")
                        .HasColumnName("Mark_Number")
                        .HasColumnType("int");

                    b.Property<string>("MarkString")
                        .HasColumnName("Mark_String")
                        .HasColumnType("varchar(15)")
                        .HasMaxLength(15)
                        .IsUnicode(false);

                    b.Property<int>("PassedTaskPassedTaskId")
                        .HasColumnName("Passed_Task_Passed_Task_ID")
                        .HasColumnType("int");

                    b.HasKey("MarkId");

                    b.HasIndex("PassedTaskPassedTaskId");

                    b.ToTable("Mark");
                });

            modelBuilder.Entity("PolytechExamBase.Models.MarkJournal", b =>
                {
                    b.Property<int>("MarkJournalId")
                        .HasColumnName("Mark_Journal_ID")
                        .HasColumnType("int");

                    b.Property<int>("JournalJournalId")
                        .HasColumnName("Journal_Journal_ID")
                        .HasColumnType("int");

                    b.Property<int>("MarkMarkId")
                        .HasColumnName("Mark_Mark_ID")
                        .HasColumnType("int");

                    b.HasKey("MarkJournalId");

                    b.HasIndex("JournalJournalId");

                    b.HasIndex("MarkMarkId");

                    b.ToTable("Mark_Journal");
                });

            modelBuilder.Entity("PolytechExamBase.Models.PassedTask", b =>
                {
                    b.Property<int>("PassedTaskId")
                        .HasColumnName("Passed_Task_ID")
                        .HasColumnType("int");

                    b.Property<string>("GivenAnswer")
                        .HasColumnName("Given_Answer")
                        .HasColumnType("varchar(8000)")
                        .HasMaxLength(8000)
                        .IsUnicode(false);

                    b.Property<string>("IsRight")
                        .HasColumnName("Is_Right")
                        .HasColumnType("char(1)")
                        .IsFixedLength(true)
                        .HasMaxLength(1)
                        .IsUnicode(false);

                    b.Property<int>("TaskTaskId")
                        .HasColumnName("Task_Task_ID")
                        .HasColumnType("int");

                    b.HasKey("PassedTaskId");

                    b.HasIndex("TaskTaskId");

                    b.ToTable("Passed_Task");
                });

            modelBuilder.Entity("PolytechExamBase.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .HasColumnName("Role_ID")
                        .HasColumnType("int");

                    b.Property<string>("Priority")
                        .HasColumnType("varchar(10)")
                        .HasMaxLength(10)
                        .IsUnicode(false);

                    b.Property<string>("RoleName")
                        .HasColumnName("Role_Name")
                        .HasColumnType("varchar(30)")
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    b.HasKey("RoleId");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("PolytechExamBase.Models.Task", b =>
                {
                    b.Property<int>("TaskId")
                        .HasColumnName("Task_ID")
                        .HasColumnType("int");

                    b.Property<int>("DifficultyDifficultyId")
                        .HasColumnName("Difficulty_Difficulty_ID")
                        .HasColumnType("int");

                    b.Property<string>("Question")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256)
                        .IsUnicode(false);

                    b.Property<string>("Solution")
                        .HasColumnType("varchar(8000)")
                        .HasMaxLength(8000)
                        .IsUnicode(false);

                    b.Property<string>("TaskName")
                        .HasColumnName("Task_Name")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256)
                        .IsUnicode(false);

                    b.HasKey("TaskId");

                    b.HasIndex("DifficultyDifficultyId");

                    b.ToTable("Task");
                });

            modelBuilder.Entity("PolytechExamBase.Models.TaskTestTopic", b =>
                {
                    b.Property<int>("TaskTestTopicId")
                        .HasColumnName("Task_Test_Topic_ID")
                        .HasColumnType("int");

                    b.Property<int>("TaskTaskId")
                        .HasColumnName("Task_Task_ID")
                        .HasColumnType("int");

                    b.Property<int>("TestTopicTopicId")
                        .HasColumnName("Test_Topic_Topic_ID")
                        .HasColumnType("int");

                    b.HasKey("TaskTestTopicId");

                    b.HasIndex("TaskTaskId");

                    b.HasIndex("TestTopicTopicId");

                    b.ToTable("Task_Test_Topic");
                });

            modelBuilder.Entity("PolytechExamBase.Models.TestTopic", b =>
                {
                    b.Property<int>("TopicId")
                        .HasColumnName("Topic_ID")
                        .HasColumnType("int");

                    b.Property<string>("TopicName")
                        .HasColumnName("Topic_Name")
                        .HasColumnType("varchar(64)")
                        .HasMaxLength(64)
                        .IsUnicode(false);

                    b.HasKey("TopicId")
                        .HasName("Test_Topic_PK");

                    b.ToTable("Test_Topic");
                });

            modelBuilder.Entity("PolytechExamBase.Models.UserPassedTask", b =>
                {
                    b.Property<int>("UserPassedTaskId")
                        .HasColumnName("User_Passed_Task_ID")
                        .HasColumnType("int");

                    b.Property<int>("PassedTaskPassedTaskId")
                        .HasColumnName("Passed_Task_Passed_Task_ID")
                        .HasColumnType("int");

                    b.Property<int>("UserUserId")
                        .HasColumnName("User_UserID")
                        .HasColumnType("int");

                    b.HasKey("UserPassedTaskId");

                    b.HasIndex("PassedTaskPassedTaskId");

                    b.HasIndex("UserUserId");

                    b.ToTable("User_Passed_Task");
                });

            modelBuilder.Entity("PolytechExamBase.Models.UserRole", b =>
                {
                    b.Property<int>("UserRoleId")
                        .HasColumnName("User_Role_ID")
                        .HasColumnType("int");

                    b.Property<int>("RoleRoleId")
                        .HasColumnName("Role_Role_ID")
                        .HasColumnType("int");

                    b.Property<int>("UserUserId")
                        .HasColumnName("User_UserID")
                        .HasColumnType("int");

                    b.HasKey("UserRoleId");

                    b.HasIndex("RoleRoleId");

                    b.HasIndex("UserUserId");

                    b.ToTable("User_Role");
                });

            modelBuilder.Entity("PolytechExamBase.Models.Journal", b =>
                {
                    b.HasOne("PolytechExamBase.Models.Dbuser", "UserUser")
                        .WithMany("Journal")
                        .HasForeignKey("UserUserId")
                        .HasConstraintName("Journal_User_FK")
                        .IsRequired();
                });

            modelBuilder.Entity("PolytechExamBase.Models.Mark", b =>
                {
                    b.HasOne("PolytechExamBase.Models.PassedTask", "PassedTaskPassedTask")
                        .WithMany("Mark")
                        .HasForeignKey("PassedTaskPassedTaskId")
                        .HasConstraintName("Mark_Passed_Task_FK")
                        .IsRequired();
                });

            modelBuilder.Entity("PolytechExamBase.Models.MarkJournal", b =>
                {
                    b.HasOne("PolytechExamBase.Models.Journal", "JournalJournal")
                        .WithMany("MarkJournal")
                        .HasForeignKey("JournalJournalId")
                        .HasConstraintName("Mark_Journal_Journal_FK")
                        .IsRequired();

                    b.HasOne("PolytechExamBase.Models.Mark", "MarkMark")
                        .WithMany("MarkJournal")
                        .HasForeignKey("MarkMarkId")
                        .HasConstraintName("Mark_Journal_Mark_FK")
                        .IsRequired();
                });

            modelBuilder.Entity("PolytechExamBase.Models.PassedTask", b =>
                {
                    b.HasOne("PolytechExamBase.Models.Task", "TaskTask")
                        .WithMany("PassedTask")
                        .HasForeignKey("TaskTaskId")
                        .HasConstraintName("Passed_Task_Task_FK")
                        .IsRequired();
                });

            modelBuilder.Entity("PolytechExamBase.Models.Task", b =>
                {
                    b.HasOne("PolytechExamBase.Models.Difficulty", "DifficultyDifficulty")
                        .WithMany("Task")
                        .HasForeignKey("DifficultyDifficultyId")
                        .HasConstraintName("Task_Difficulty_FK")
                        .IsRequired();
                });

            modelBuilder.Entity("PolytechExamBase.Models.TaskTestTopic", b =>
                {
                    b.HasOne("PolytechExamBase.Models.Task", "TaskTask")
                        .WithMany("TaskTestTopic")
                        .HasForeignKey("TaskTaskId")
                        .HasConstraintName("Task_Test_Topic_Task_FK")
                        .IsRequired();

                    b.HasOne("PolytechExamBase.Models.TestTopic", "TestTopicTopic")
                        .WithMany("TaskTestTopic")
                        .HasForeignKey("TestTopicTopicId")
                        .HasConstraintName("Task_Test_Topic_Test_Topic_FK")
                        .IsRequired();
                });

            modelBuilder.Entity("PolytechExamBase.Models.UserPassedTask", b =>
                {
                    b.HasOne("PolytechExamBase.Models.PassedTask", "PassedTaskPassedTask")
                        .WithMany("UserPassedTask")
                        .HasForeignKey("PassedTaskPassedTaskId")
                        .HasConstraintName("User_Passed_Task_Passed_Task_FK")
                        .IsRequired();

                    b.HasOne("PolytechExamBase.Models.Dbuser", "UserUser")
                        .WithMany("UserPassedTask")
                        .HasForeignKey("UserUserId")
                        .HasConstraintName("User_Passed_Task_User_FK")
                        .IsRequired();
                });

            modelBuilder.Entity("PolytechExamBase.Models.UserRole", b =>
                {
                    b.HasOne("PolytechExamBase.Models.Role", "RoleRole")
                        .WithMany("UserRole")
                        .HasForeignKey("RoleRoleId")
                        .HasConstraintName("User_Role_Role_FK")
                        .IsRequired();

                    b.HasOne("PolytechExamBase.Models.Dbuser", "UserUser")
                        .WithMany("UserRole")
                        .HasForeignKey("UserUserId")
                        .HasConstraintName("User_Role_User_FK")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
