﻿// <auto-generated />
using System;
using BookWyrmBackend;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BookWyrmBackend.Migrations
{
    [DbContext(typeof(UserContext))]
    [Migration("20201029124808_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8");

            modelBuilder.Entity("BookWyrmBackend.Models.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int?>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("BookWyrmBackend.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AuthorId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("BookHoardId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("ISBN")
                        .HasColumnType("TEXT");

                    b.Property<string>("Language")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("PublishDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Publisher")
                        .HasColumnType("TEXT");

                    b.Property<int?>("PublisherId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("BookHoardId");

                    b.HasIndex("PublisherId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("BookWyrmBackend.Models.BookHoard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("BookHoards");
                });

            modelBuilder.Entity("BookWyrmBackend.Models.Publisher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int?>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Publishers");
                });

            modelBuilder.Entity("BookWyrmBackend.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AuthToken")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BookWyrmBackend.Models.Author", b =>
                {
                    b.HasOne("BookWyrmBackend.Models.User", null)
                        .WithMany("FavAuthors")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("BookWyrmBackend.Models.Book", b =>
                {
                    b.HasOne("BookWyrmBackend.Models.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId");

                    b.HasOne("BookWyrmBackend.Models.BookHoard", null)
                        .WithMany("Hoard")
                        .HasForeignKey("BookHoardId");

                    b.HasOne("BookWyrmBackend.Models.Publisher", null)
                        .WithMany("Books")
                        .HasForeignKey("PublisherId");
                });

            modelBuilder.Entity("BookWyrmBackend.Models.BookHoard", b =>
                {
                    b.HasOne("BookWyrmBackend.Models.User", null)
                        .WithMany("BookHoards")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookWyrmBackend.Models.Publisher", b =>
                {
                    b.HasOne("BookWyrmBackend.Models.User", null)
                        .WithMany("FavPublishers")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
