using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PolytechExamBase.Models
{
    public partial class PolytechExamTestContext : DbContext
    {
        public PolytechExamTestContext()
        {
        }

        public PolytechExamTestContext(DbContextOptions<PolytechExamTestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Dbuser> Dbuser { get; set; }
        public virtual DbSet<Difficulty> Difficulty { get; set; }
        public virtual DbSet<Journal> Journal { get; set; }
        public virtual DbSet<Mark> Mark { get; set; }
        public virtual DbSet<MarkJournal> MarkJournal { get; set; }
        public virtual DbSet<PassedTask> PassedTask { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Task> Task { get; set; }
        public virtual DbSet<TaskTestTopic> TaskTestTopic { get; set; }
        public virtual DbSet<TestTopic> TestTopic { get; set; }
        public virtual DbSet<UserPassedTask> UserPassedTask { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=ANDRII-DESKTOP-;Database=PolytechExamTest;User Id=test;Password=1234512345;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dbuser>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("User_PK");

                entity.ToTable("DBUser");

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AccessFailedCounts).HasColumnName("Access_Failed_Counts");

                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ExpiresIn)
                    .HasColumnName("Expires_In")
                    .HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .HasColumnName("First_Name")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordHash)
                    .HasColumnName("Password_Hash")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SecondName)
                    .HasColumnName("Second_Name")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Difficulty>(entity =>
            {
                entity.Property(e => e.DifficultyId)
                    .HasColumnName("Difficulty_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.DifficultyLevel).HasColumnName("Difficulty_Level");
            });

            modelBuilder.Entity<Journal>(entity =>
            {
                entity.Property(e => e.JournalId)
                    .HasColumnName("Journal_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.UserUserId).HasColumnName("User_UserID");

                entity.HasOne(d => d.UserUser)
                    .WithMany(p => p.Journal)
                    .HasForeignKey(d => d.UserUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Journal_User_FK");
            });

            modelBuilder.Entity<Mark>(entity =>
            {
                entity.Property(e => e.MarkId)
                    .HasColumnName("Mark_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.MarkNumber).HasColumnName("Mark_Number");

                entity.Property(e => e.MarkString)
                    .HasColumnName("Mark_String")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.PassedTaskPassedTaskId).HasColumnName("Passed_Task_Passed_Task_ID");

                entity.HasOne(d => d.PassedTaskPassedTask)
                    .WithMany(p => p.Mark)
                    .HasForeignKey(d => d.PassedTaskPassedTaskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Mark_Passed_Task_FK");
            });

            modelBuilder.Entity<MarkJournal>(entity =>
            {
                entity.ToTable("Mark_Journal");

                entity.Property(e => e.MarkJournalId)
                    .HasColumnName("Mark_Journal_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.JournalJournalId).HasColumnName("Journal_Journal_ID");

                entity.Property(e => e.MarkMarkId).HasColumnName("Mark_Mark_ID");

                entity.HasOne(d => d.JournalJournal)
                    .WithMany(p => p.MarkJournal)
                    .HasForeignKey(d => d.JournalJournalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Mark_Journal_Journal_FK");

                entity.HasOne(d => d.MarkMark)
                    .WithMany(p => p.MarkJournal)
                    .HasForeignKey(d => d.MarkMarkId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Mark_Journal_Mark_FK");
            });

            modelBuilder.Entity<PassedTask>(entity =>
            {
                entity.ToTable("Passed_Task");

                entity.Property(e => e.PassedTaskId)
                    .HasColumnName("Passed_Task_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.GivenAnswer)
                    .HasColumnName("Given_Answer")
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.IsRight)
                    .HasColumnName("Is_Right")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TaskTaskId).HasColumnName("Task_Task_ID");

                entity.HasOne(d => d.TaskTask)
                    .WithMany(p => p.PassedTask)
                    .HasForeignKey(d => d.TaskTaskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Passed_Task_Task_FK");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleId)
                    .HasColumnName("Role_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Priority)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.RoleName)
                    .HasColumnName("Role_Name")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.Property(e => e.TaskId)
                    .HasColumnName("Task_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.DifficultyDifficultyId).HasColumnName("Difficulty_Difficulty_ID");

                entity.Property(e => e.Question)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Solution)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.TaskName)
                    .HasColumnName("Task_Name")
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.HasOne(d => d.DifficultyDifficulty)
                    .WithMany(p => p.Task)
                    .HasForeignKey(d => d.DifficultyDifficultyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Task_Difficulty_FK");
            });

            modelBuilder.Entity<TaskTestTopic>(entity =>
            {
                entity.ToTable("Task_Test_Topic");

                entity.Property(e => e.TaskTestTopicId)
                    .HasColumnName("Task_Test_Topic_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.TaskTaskId).HasColumnName("Task_Task_ID");

                entity.Property(e => e.TestTopicTopicId).HasColumnName("Test_Topic_Topic_ID");

                entity.HasOne(d => d.TaskTask)
                    .WithMany(p => p.TaskTestTopic)
                    .HasForeignKey(d => d.TaskTaskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Task_Test_Topic_Task_FK");

                entity.HasOne(d => d.TestTopicTopic)
                    .WithMany(p => p.TaskTestTopic)
                    .HasForeignKey(d => d.TestTopicTopicId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Task_Test_Topic_Test_Topic_FK");
            });

            modelBuilder.Entity<TestTopic>(entity =>
            {
                entity.HasKey(e => e.TopicId)
                    .HasName("Test_Topic_PK");

                entity.ToTable("Test_Topic");

                entity.Property(e => e.TopicId)
                    .HasColumnName("Topic_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.TopicName)
                    .HasColumnName("Topic_Name")
                    .HasMaxLength(64)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserPassedTask>(entity =>
            {
                entity.ToTable("User_Passed_Task");

                entity.Property(e => e.UserPassedTaskId)
                    .HasColumnName("User_Passed_Task_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.PassedTaskPassedTaskId).HasColumnName("Passed_Task_Passed_Task_ID");

                entity.Property(e => e.UserUserId).HasColumnName("User_UserID");

                entity.HasOne(d => d.PassedTaskPassedTask)
                    .WithMany(p => p.UserPassedTask)
                    .HasForeignKey(d => d.PassedTaskPassedTaskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("User_Passed_Task_Passed_Task_FK");

                entity.HasOne(d => d.UserUser)
                    .WithMany(p => p.UserPassedTask)
                    .HasForeignKey(d => d.UserUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("User_Passed_Task_User_FK");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.ToTable("User_Role");

                entity.Property(e => e.UserRoleId)
                    .HasColumnName("User_Role_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.RoleRoleId).HasColumnName("Role_Role_ID");

                entity.Property(e => e.UserUserId).HasColumnName("User_UserID");

                entity.HasOne(d => d.RoleRole)
                    .WithMany(p => p.UserRole)
                    .HasForeignKey(d => d.RoleRoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("User_Role_Role_FK");

                entity.HasOne(d => d.UserUser)
                    .WithMany(p => p.UserRole)
                    .HasForeignKey(d => d.UserUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("User_Role_User_FK");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
