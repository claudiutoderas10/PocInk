﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PocInkDataLayer;

namespace PocInkDataLayer.Migrations
{
    [DbContext(typeof(PocInkDBContext))]
    [Migration("20190205122047_CreatePocInkDB")]
    partial class CreatePocInkDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PocInkDataLayer.Models.InkDrawing", b =>
                {
                    b.Property<Guid>("DrawingId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("LocalFileId");

                    b.Property<string>("Title");

                    b.Property<string>("UserId");

                    b.HasKey("DrawingId");

                    b.ToTable("InkDrawings");
                });

            modelBuilder.Entity("PocInkDataLayer.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Password");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
