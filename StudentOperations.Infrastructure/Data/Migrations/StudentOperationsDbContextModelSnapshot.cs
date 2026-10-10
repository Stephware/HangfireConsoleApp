using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using StudentOperations.Domain;
using StudentOperations.Infrastructure.Data;

#nullable disable

namespace StudentOperations.Infrastructure.Data.Migrations;

[DbContext(typeof(StudentOperationsDbContext))]
public partial class StudentOperationsDbContextModelSnapshot : ModelSnapshot
{
    protected override void BuildModel(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasAnnotation("ProductVersion", "10.0.12")
            .HasAnnotation("Relational:MaxIdentifierLength", 128);

        modelBuilder.UseIdentityColumns();

        modelBuilder.Entity("StudentOperations.Domain.Student", b =>
        {
            b.Property<int>("Id")
                .ValueGeneratedOnAdd()
                .HasColumnType("int")
                .HasAnnotation("SqlServer:ValueGenerationStrategy",
                    SqlServerValueGenerationStrategy.IdentityColumn);

            b.Property<DateTime>("CreatedAt").HasColumnType("datetime2");
            b.Property<string>("Email").IsRequired().HasMaxLength(150).HasColumnType("nvarchar(150)");
            b.Property<string>("FullName").IsRequired().HasMaxLength(150).HasColumnType("nvarchar(150)");
            b.Property<string>("StudentNumber").IsRequired().HasColumnType("nvarchar(450)");

            b.HasKey("Id");
            b.HasIndex("StudentNumber").IsUnique();
            b.ToTable("Students");
        });

        modelBuilder.Entity("StudentOperations.Domain.EnrollmentRequest", b =>
        {
            b.Property<int>("Id")
                .ValueGeneratedOnAdd()
                .HasColumnType("int")
                .HasAnnotation("SqlServer:ValueGenerationStrategy",
                    SqlServerValueGenerationStrategy.IdentityColumn);

            b.Property<bool>("ConfirmationSent").HasColumnType("bit");
            b.Property<DateTime>("CreatedAt").HasColumnType("datetime2");
            b.Property<bool>("HasFailedOnce").HasColumnType("bit");
            b.Property<DateTime?>("ProcessedAt").HasColumnType("datetime2");
            b.Property<bool>("SimulateTransientFailure").HasColumnType("bit");
            b.Property<EnrollmentStatus>("Status")
                .HasConversion<string>()
                .HasMaxLength(30)
                .HasColumnType("nvarchar(30)");
            b.Property<int>("StudentId").HasColumnType("int");

            b.HasKey("Id");
            b.HasIndex("StudentId");
            b.ToTable("EnrollmentRequests");
        });

        modelBuilder.Entity("StudentOperations.Domain.EnrollmentProcessingLog", b =>
        {
            b.Property<int>("Id")
                .ValueGeneratedOnAdd()
                .HasColumnType("int")
                .HasAnnotation("SqlServer:ValueGenerationStrategy",
                    SqlServerValueGenerationStrategy.IdentityColumn);

            b.Property<DateTime>("CreatedAt").HasColumnType("datetime2");
            b.Property<int>("EnrollmentRequestId").HasColumnType("int");
            b.Property<string>("Message").IsRequired().HasMaxLength(500).HasColumnType("nvarchar(500)");

            b.HasKey("Id");
            b.ToTable("ProcessingLogs");
        });

        modelBuilder.Entity("StudentOperations.Domain.EnrollmentRequest", b =>
        {
            b.HasOne("StudentOperations.Domain.Student", "Student")
                .WithMany("EnrollmentRequests")
                .HasForeignKey("StudentId")
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            b.Navigation("Student");
        });

        modelBuilder.Entity("StudentOperations.Domain.Student", b =>
        {
            b.Navigation("EnrollmentRequests");
        });
    }
}
