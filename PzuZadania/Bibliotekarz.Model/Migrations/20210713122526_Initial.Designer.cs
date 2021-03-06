// <auto-generated />
using System;
using Bibliotekarz.Model.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Bibliotekarz.Model.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210713122526_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Bibliotekarz.Model.Entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int?>("BorrowerId")
                        .HasColumnType("int");

                    b.Property<bool>("IsBorrowed")
                        .HasColumnType("bit");

                    b.Property<int>("PageCount")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.HasIndex("BorrowerId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Bibliotekarz.Model.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Borrowers");
                });

            modelBuilder.Entity("Bibliotekarz.Model.Entities.Book", b =>
                {
                    b.HasOne("Bibliotekarz.Model.Entities.Customer", "Borrower")
                        .WithMany("Books")
                        .HasForeignKey("BorrowerId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Borrower");
                });

            modelBuilder.Entity("Bibliotekarz.Model.Entities.Customer", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
