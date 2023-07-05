using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Repository.Interfaces;
using System.Runtime.CompilerServices;

namespace Repository.DbModels;

public partial class DiaryContext : DbContext, IDiaryContext
{

    public DiaryContext()
    { }

    public DiaryContext(DbContextOptions<DiaryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<Lesson> Lessons { get; set; }

    public virtual DbSet<School> Schools { get; set; }

    public virtual DbSet<Student> Students { get; set; }
    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<StudentExistance> StudentExistances { get; set; }
    public virtual DbSet<Unit> Units { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
         //optionsBuilder.UseSqlServer("Server=.;Database=diary;Trusted_Connection=True;trustserverCertificate=true");
    }
    public override EntityEntry Entry(object entity)
    {
        return base.Entry(entity);
    }

#warning To protect potentially sensitive information in your connection string, you should move it out of source code. 
#warning  You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148.
#warning  For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
    //       => optionsBuilder.UseSqlServer("Server=.;Database=diary;Trusted_Connection=True;trustserverCertificate=true");
    //       => optionsBuilder.UseSqlServer("Data Source=FSQLN\\FSQLN;Initial Catalog=Diary_YomAroch_5783;Integrated Security=True;trustservercertificate=true");


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ////TPH -table per hirarchy

        ////TPT - table per type
        //modelBuilder.Entity<Student>(entity=>entity.ToTable("Students"));

        ////TPC - table per concret type
        ////modelBuilder.Entity<User>().UseTpcMappingStrategy()
        ////    .ToTable("Users");
        ////modelBuilder.Entity<Student>()
        ////    .ToTable("Students");
        ////modelBuilder.Entity<Teacher>()
        ////    .ToTable("Teachers");

        //modelBuilder.Entity<Group>(entity =>
        //{
        //    //fluent api
        //    entity.HasKey(e => e.Id).HasName("PK_dbo.Groups");
        //   // entity.HasData(new Group() { GroupName = "Cita vav" });
        //    entity.HasIndex(e => e.SchoolId, "IX_SchoolId");

        //    entity.HasOne(d => d.School).WithMany(p => p.Groups)
        //        .HasForeignKey(d => d.SchoolId)
        //        .HasConstraintName("FK_dbo.Groups_dbo.Schools_SchoolId");
        //});

        //modelBuilder.Entity<Lesson>(entity =>
        //{

        //    entity.HasKey(e => e.Id).HasName("PK_dbo.Lessons");

        //    entity.HasIndex(e => e.GroupId, "IX_Group_Id");

        //    entity.Property(e => e.GroupId).HasColumnName("Group_Id");

        //    entity.HasOne(d => d.Group).WithMany(p => p.Lessons)
        //        .HasForeignKey(d => d.GroupId)
        //        .HasConstraintName("FK_dbo.Lessons_dbo.Groups_Group_Id");
        //});

        //modelBuilder.Entity<School>(entity =>
        //{
        //    entity.HasKey(e => e.Id).HasName("PK_dbo.Schools");
        //});

        //modelBuilder.Entity<StudentExistance>(entity =>
        //{
        //    entity.HasKey(e => e.Id).HasName("PK_dbo.StudentExistances");

        //    entity.HasIndex(e => e.LessonId, "IX_LessonId");

        //    entity.HasIndex(e => e.StudentId, "IX_StudentId");

        //    entity.HasOne(d => d.Lesson).WithMany(p => p.StudentExistances)
        //        .HasForeignKey(d => d.LessonId)
        //        .HasConstraintName("FK_dbo.StudentExistances_dbo.Lessons_LessonId");

        //    entity.HasOne(d => d.Student).WithMany(p => p.StudentExistances)
        //        .HasForeignKey(d => d.StudentId)
        //        .HasConstraintName("FK_dbo.StudentExistances_dbo.Students_StudentId");
        //});

        //modelBuilder.Entity<Unit>(entity =>
        //{
        //    entity.ToTable(nameof(Units), e => e.IsTemporal());

        //    entity.Property(e => e.UnitName).HasMaxLength(50);

        //    entity.HasKey(e => e.UnitId).HasName("PK_dbo.Units");

        //    entity.HasMany(d => d.Lessons).WithMany(p => p.Units)
        //        .UsingEntity<Dictionary<string, object>>(
        //            "UnitLesson",
        //            r => r.HasOne<Lesson>().WithMany()
        //                .HasForeignKey("LessonId")
        //                .HasConstraintName("FK_dbo.UnitLessons_dbo.Lessons_Lesson_Id"),
        //            l => l.HasOne<Unit>().WithMany()
        //                .HasForeignKey("UnitId")
        //                .HasConstraintName("FK_dbo.UnitLessons_dbo.Units_Unit_Id"),
        //            j =>
        //            {
        //                j.HasKey("UnitId", "LessonId").HasName("PK_dbo.UnitLessons");
        //                j.ToTable("UnitLessons");
        //                j.HasIndex(new[] { "LessonId" }, "IX_Lesson_Id");
        //                j.HasIndex(new[] { "UnitId" }, "IX_Unit_Id");
        //                j.IndexerProperty<int>("UnitId").HasColumnName("Unit_Id");
        //                j.IndexerProperty<int>("LessonId").HasColumnName("Lesson_Id");
        //            });
        //});

        // OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

}

