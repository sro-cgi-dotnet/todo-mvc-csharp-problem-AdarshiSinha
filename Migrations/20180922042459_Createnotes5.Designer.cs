﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using helloworld.Models;

namespace helloworld.Migrations
{
    [DbContext(typeof(efmodel))]
    [Migration("20180922042459_Createnotes5")]
    partial class Createnotes5
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065");

            modelBuilder.Entity("helloworld.Models.Checklist", b =>
                {
                    b.Property<int>("checkid")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("id");

                    b.Property<bool>("ischecked");

                    b.Property<string>("write")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("checkid");

                    b.HasIndex("id");

                    b.ToTable("checklist");
                });

            modelBuilder.Entity("helloworld.Models.Label", b =>
                {
                    b.Property<int>("labelid")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("id");

                    b.Property<string>("text")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("labelid");

                    b.ToTable("labels");
                });

            modelBuilder.Entity("helloworld.Models.Notes", b =>
                {
                    b.Property<int>("id");

                    b.Property<bool>("pinned");

                    b.Property<string>("text")
                        .HasMaxLength(500);

                    b.Property<string>("title")
                        .HasMaxLength(200);

                    b.HasKey("id");

                    b.ToTable("notes");
                });

            modelBuilder.Entity("helloworld.Models.Checklist", b =>
                {
                    b.HasOne("helloworld.Models.Notes")
                        .WithMany("checklist")
                        .HasForeignKey("id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("helloworld.Models.Notes", b =>
                {
                    b.HasOne("helloworld.Models.Label", "label")
                        .WithMany()
                        .HasForeignKey("id")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
