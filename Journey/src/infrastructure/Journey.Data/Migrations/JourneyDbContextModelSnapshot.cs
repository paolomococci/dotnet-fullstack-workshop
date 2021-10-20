using Journey.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Journey.Data.Migrations
{
    [DbContext(typeof(JourneyDbContext))]
    partial class JourneyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("Journey.Domain.Entities.JourneyList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("City")
                        .HasColumnType("TEXT");

                    b.Property<string>("Country")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("JourneyLists");
                });

            modelBuilder.Entity("Journey.Domain.Entities.JourneySelection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Confirmation")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Currency")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Duration")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Hope")
                        .HasColumnType("TEXT");

                    b.Property<int?>("JourneysId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ListId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("MapLocation")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<float>("Price")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("JourneysId");

                    b.ToTable("JourneySelections");
                });

            modelBuilder.Entity("Journey.Domain.Entities.JourneySelection", b =>
                {
                    b.HasOne("Journey.Domain.Entities.JourneyList", "Journeys")
                        .WithMany("Trips")
                        .HasForeignKey("JourneysId");

                    b.Navigation("Journeys");
                });

            modelBuilder.Entity("Journey.Domain.Entities.JourneyList", b =>
                {
                    b.Navigation("Trips");
                });
#pragma warning restore 612, 618
        }
    }
}
