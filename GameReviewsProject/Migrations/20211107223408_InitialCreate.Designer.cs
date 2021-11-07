﻿// <auto-generated />
using System;
using GameReviewSolution;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GameReviewSolution.Migrations
{
    [DbContext(typeof(GameReviewContext))]
    [Migration("20211107223408_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("GameReviewSolution.Models.EmailAddress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("EmailAddressUri")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("EmailAddresses");
                });

            modelBuilder.Entity("GameReviewSolution.Models.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("GamePublisherId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("GamePublisherId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("GameReviewSolution.Models.Publisher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("WebsiteUri")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Publishers");
                });

            modelBuilder.Entity("GameReviewSolution.Models.ReviewPost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("GameId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Rating")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ReviewText")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("UserId");

                    b.ToTable("ReviewPosts");
                });

            modelBuilder.Entity("GameReviewSolution.Models.StreetAddress", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("City")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstLine")
                        .HasColumnType("TEXT");

                    b.Property<string>("SecondLine")
                        .HasColumnType("TEXT");

                    b.Property<string>("State")
                        .HasColumnType("TEXT");

                    b.Property<int>("Zipcode")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("StreetAddresses");
                });

            modelBuilder.Entity("GameReviewSolution.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("MailingAddressId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MailingAddressId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GameReviewSolution.Models.EmailAddress", b =>
                {
                    b.HasOne("GameReviewSolution.Models.User", "Owner")
                        .WithOne("UserEmailAddress")
                        .HasForeignKey("GameReviewSolution.Models.EmailAddress", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("GameReviewSolution.Models.Game", b =>
                {
                    b.HasOne("GameReviewSolution.Models.Publisher", "GamePublisher")
                        .WithMany()
                        .HasForeignKey("GamePublisherId");

                    b.Navigation("GamePublisher");
                });

            modelBuilder.Entity("GameReviewSolution.Models.ReviewPost", b =>
                {
                    b.HasOne("GameReviewSolution.Models.Game", null)
                        .WithMany("ReviewsPosts")
                        .HasForeignKey("GameId");

                    b.HasOne("GameReviewSolution.Models.User", "Author")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("GameReviewSolution.Models.User", b =>
                {
                    b.HasOne("GameReviewSolution.Models.StreetAddress", "MailingAddress")
                        .WithMany()
                        .HasForeignKey("MailingAddressId");

                    b.Navigation("MailingAddress");
                });

            modelBuilder.Entity("GameReviewSolution.Models.Game", b =>
                {
                    b.Navigation("ReviewsPosts");
                });

            modelBuilder.Entity("GameReviewSolution.Models.User", b =>
                {
                    b.Navigation("UserEmailAddress");
                });
#pragma warning restore 612, 618
        }
    }
}
