﻿// <auto-generated />
using Book.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Book.Migrations
{
    [DbContext(typeof(SongDbContext))]
    [Migration("20210704170107_EkleAlbumSarkiTablosuna")]
    partial class EkleAlbumSarkiTablosuna
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Book.Models.Song", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Album")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SarkiAd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sarkici")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Song");
                });
#pragma warning restore 612, 618
        }
    }
}
