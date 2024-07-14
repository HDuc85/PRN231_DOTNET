using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace InternManagementData.Models;

public partial class Net17112315InternManagementContext : DbContext
{
    public Net17112315InternManagementContext()
    {
    }

    public Net17112315InternManagementContext(DbContextOptions<Net17112315InternManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<InternProfile> InternProfiles { get; set; }

    public virtual DbSet<MentorIntern> MentorInterns { get; set; }

    public virtual DbSet<MentorProfile> MentorProfiles { get; set; }

    public virtual DbSet<ProgramIntern> ProgramInterns { get; set; }

    public virtual DbSet<ProgramTask> ProgramTasks { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }

    public virtual DbSet<TaskManage> TaskManages { get; set; }

    public virtual DbSet<TrainingProgram> TrainingPrograms { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;uid=sa;pwd=12345;database=Net1711_231_5_InternManagement;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.CompanyId).HasName("PK__Company__2D971C4C9831F889");

            entity.ToTable("Company");

            entity.Property(e => e.CompanyId)
                .ValueGeneratedNever()
                .HasColumnName("CompanyID");
            entity.Property(e => e.CompanyAddress).HasMaxLength(255);
            entity.Property(e => e.CompanyEmail)
                .HasMaxLength(320)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName).HasMaxLength(100);
            entity.Property(e => e.CompanyPhone)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Description).HasMaxLength(300);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__7AD04FF17F5AAD36");

            entity.ToTable("Employee");

            entity.Property(e => e.EmployeeId)
                .ValueGeneratedNever()
                .HasColumnName("EmployeeID");
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.EmployeeAddress).HasMaxLength(255);
            entity.Property(e => e.EmployeeEmail)
                .HasMaxLength(320)
                .IsUnicode(false);
            entity.Property(e => e.EmployeeName).HasMaxLength(100);
            entity.Property(e => e.EmployeePhone)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.Company).WithMany(p => p.Employees)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK__Employee__Compan__4AB81AF0");
        });

        modelBuilder.Entity<InternProfile>(entity =>
        {
            entity.HasKey(e => e.InternId).HasName("PK__InternPr__6910ED828C126731");

            entity.ToTable("InternProfile");

            entity.Property(e => e.InternId)
                .ValueGeneratedNever()
                .HasColumnName("InternID");
            entity.Property(e => e.InternAddress).HasMaxLength(255);
            entity.Property(e => e.InternEmail)
                .HasMaxLength(320)
                .IsUnicode(false);
            entity.Property(e => e.InternName).HasMaxLength(100);
            entity.Property(e => e.InternPhone)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Major).HasMaxLength(50);
            entity.Property(e => e.MentorId).HasColumnName("MentorID");
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.University).HasMaxLength(50);

            entity.HasOne(d => d.Mentor).WithMany(p => p.InternProfiles)
                .HasForeignKey(d => d.MentorId)
                .HasConstraintName("FK__InternPro__Mento__4BAC3F29");
        });

        modelBuilder.Entity<MentorIntern>(entity =>
        {
            entity.HasKey(e => e.MentorInternId).HasName("PK__MentorIn__2217D7BF74365BBB");

            entity.ToTable("MentorIntern");

            entity.Property(e => e.MentorInternId)
                .ValueGeneratedNever()
                .HasColumnName("MentorInternID");
            entity.Property(e => e.InternId).HasColumnName("InternID");
            entity.Property(e => e.MentorId).HasColumnName("MentorID");

            entity.HasOne(d => d.Intern).WithMany(p => p.MentorInterns)
                .HasForeignKey(d => d.InternId)
                .HasConstraintName("FK__MentorInt__Inter__4CA06362");

            entity.HasOne(d => d.Mentor).WithMany(p => p.MentorInterns)
                .HasForeignKey(d => d.MentorId)
                .HasConstraintName("FK__MentorInt__Mento__4D94879B");
        });

        modelBuilder.Entity<MentorProfile>(entity =>
        {
            entity.HasKey(e => e.MentorId).HasName("PK__MentorPr__053B7E78E0CF6563");

            entity.ToTable("MentorProfile");

            entity.Property(e => e.MentorId)
                .ValueGeneratedNever()
                .HasColumnName("MentorID");
            entity.Property(e => e.MentorAddress).HasMaxLength(255);
            entity.Property(e => e.MentorEmail)
                .HasMaxLength(320)
                .IsUnicode(false);
            entity.Property(e => e.MentorName).HasMaxLength(100);
            entity.Property(e => e.MentorPhone)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Password).HasMaxLength(50);
        });

        modelBuilder.Entity<ProgramIntern>(entity =>
        {
            entity.HasKey(e => e.ProgramInternId).HasName("PK__ProgramI__44F12DE3C36A4FFA");

            entity.ToTable("ProgramIntern");

            entity.Property(e => e.ProgramInternId)
                .ValueGeneratedNever()
                .HasColumnName("ProgramInternID");
            entity.Property(e => e.InternId).HasColumnName("InternID");
            entity.Property(e => e.ProgramId).HasColumnName("ProgramID");

            entity.HasOne(d => d.Intern).WithMany(p => p.ProgramInterns)
                .HasForeignKey(d => d.InternId)
                .HasConstraintName("FK__ProgramIn__Inter__4E88ABD4");

            entity.HasOne(d => d.Program).WithMany(p => p.ProgramInterns)
                .HasForeignKey(d => d.ProgramId)
                .HasConstraintName("FK__ProgramIn__Progr__4F7CD00D");
        });

        modelBuilder.Entity<ProgramTask>(entity =>
        {
            entity.HasKey(e => e.ProgramTaskId).HasName("PK__ProgramT__8B64F4851D3399A6");

            entity.ToTable("ProgramTask");

            entity.Property(e => e.ProgramTaskId)
                .ValueGeneratedNever()
                .HasColumnName("ProgramTaskID");
            entity.Property(e => e.ProgramId).HasColumnName("ProgramID");
            entity.Property(e => e.TaskId).HasColumnName("TaskID");

            entity.HasOne(d => d.Program).WithMany(p => p.ProgramTasks)
                .HasForeignKey(d => d.ProgramId)
                .HasConstraintName("FK__ProgramTa__Progr__6754599E");

            entity.HasOne(d => d.Task).WithMany(p => p.ProgramTasks)
                .HasForeignKey(d => d.TaskId)
                .HasConstraintName("FK__ProgramTa__TaskI__68487DD7");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PK__Status__C8EE2043BA5A4C55");

            entity.ToTable("Status");

            entity.Property(e => e.StatusId)
                .ValueGeneratedNever()
                .HasColumnName("StatusID");
            entity.Property(e => e.StatusName).HasMaxLength(1);
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(e => e.TaskId).HasName("PK__Task__7C6949D1F02C41EA");

            entity.ToTable("Task");

            entity.Property(e => e.TaskId)
                .ValueGeneratedNever()
                .HasColumnName("TaskID");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.StatusId).HasColumnName("StatusID");
            entity.Property(e => e.TaskDecription).HasColumnType("ntext");
            entity.Property(e => e.TaskName).HasMaxLength(100);

        entity.Property(e => e.Priority ).HasColumnName("Priority");
            entity.Property(e => e.TaskCategory ).HasColumnName("TaskCategory");
            entity.Property(e => e.Comments ).HasColumnName("Comments");
            entity.Property(e => e.DateCreated ).HasColumnName("DateCreated");
            entity.Property(e => e.LastUpdated).HasColumnName("LastUpdated");

    entity.HasOne(d => d.Status).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("FK__Task__StatusID__52593CB8");
        });

        modelBuilder.Entity<TaskManage>(entity =>
        {
            entity.HasKey(e => e.TaskManageId).HasName("PK__TaskMana__8AFA651A35F4E3AB");

            entity.ToTable("TaskManage");

            entity.Property(e => e.TaskManageId)
                .ValueGeneratedNever()
                .HasColumnName("TaskManageID");
            entity.Property(e => e.InternId).HasColumnName("InternID");
            entity.Property(e => e.MentorId).HasColumnName("MentorID");
            entity.Property(e => e.StatusId).HasColumnName("StatusID");
            entity.Property(e => e.TaskId).HasColumnName("TaskID");

            entity.HasOne(d => d.Intern).WithMany(p => p.TaskManages)
                .HasForeignKey(d => d.InternId)
                .HasConstraintName("FK__TaskManag__Inter__6A30C649");

            entity.HasOne(d => d.Mentor).WithMany(p => p.TaskManages)
                .HasForeignKey(d => d.MentorId)
                .HasConstraintName("FK__TaskManag__Mento__5441852A");

            entity.HasOne(d => d.Status).WithMany(p => p.TaskManages)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("FK__TaskManag__Statu__5535A963");

            entity.HasOne(d => d.Task).WithMany(p => p.TaskManages)
                .HasForeignKey(d => d.TaskId)
                .HasConstraintName("FK__TaskManag__TaskI__6D0D32F4");
        });

        modelBuilder.Entity<TrainingProgram>(entity =>
        {
            entity.HasKey(e => e.ProgramId).HasName("PK__Training__75256038768A047C");

            entity.ToTable("TrainingProgram");

            entity.Property(e => e.ProgramId)
                .ValueGeneratedNever()
                .HasColumnName("ProgramID");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.ProgramDecription).HasColumnType("ntext");
            entity.Property(e => e.ProgramName).HasMaxLength(100);
            entity.Property(e => e.StartDate).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
