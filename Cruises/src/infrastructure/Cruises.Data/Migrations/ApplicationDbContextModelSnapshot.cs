// <auto-generated />
using Cruises.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Cruises.Data.Migrations
{
  [DbContext(typeof(ApplicationDbContext))]
  partial class ApplicationDbContextModelSnapshot : ModelSnapshot
  {
    protected override void BuildModel(ModelBuilder modelBuilder)
    {
#pragma warning disable 612, 618
      modelBuilder
          .HasAnnotation("ProductVersion", "5.0.12");

      modelBuilder.Entity("Cruises.Domain.Entities.CruiseList", b =>
          {
            b.Property<int>("Id")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("INTEGER");

            b.Property<string>("City")
                      .HasColumnType("TEXT");

            b.Property<string>("Country")
                      .HasColumnType("TEXT");

            b.HasKey("Id");

            b.ToTable("CruiseLists");
          });

      modelBuilder.Entity("Cruises.Domain.Entities.CruisePackage", b =>
          {
            b.Property<int>("Id")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("INTEGER");

            b.Property<bool>("Confirmation")
                      .HasColumnType("INTEGER");

            b.Property<int?>("CruiseListId")
                      .HasColumnType("INTEGER");

            b.Property<int>("Currency")
                      .HasColumnType("INTEGER");

            b.Property<int>("Duration")
                      .HasColumnType("INTEGER");

            b.Property<string>("Hope")
                      .HasColumnType("TEXT");

            b.Property<int>("ListId")
                      .HasColumnType("INTEGER");

            b.Property<string>("MapLocation")
                      .HasColumnType("TEXT");

            b.Property<string>("Name")
                      .HasColumnType("TEXT");

            b.Property<float>("Price")
                      .HasColumnType("REAL");

            b.HasKey("Id");

            b.HasIndex("CruiseListId");

            b.ToTable("CruisePackages");
          });

      modelBuilder.Entity("Cruises.Domain.Entities.CruisePackage", b =>
          {
            b.HasOne("Cruises.Domain.Entities.CruiseList", "CruiseList")
                      .WithMany("CruisePackages")
                      .HasForeignKey("CruiseListId");

            b.Navigation("CruiseList");
          });

      modelBuilder.Entity("Cruises.Domain.Entities.CruiseList", b =>
          {
            b.Navigation("CruisePackages");
          });
#pragma warning restore 612, 618
    }
  }
}
