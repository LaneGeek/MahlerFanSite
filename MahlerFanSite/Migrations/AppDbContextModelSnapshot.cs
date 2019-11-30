﻿// <auto-generated />
using System;
using MahlerFanSite.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MahlerFanSite.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MahlerFanSite.Models.Author", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BookId");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("AuthorId");

                    b.HasIndex("BookId");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("MahlerFanSite.Models.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("PublishedDate");

                    b.Property<string>("Title");

                    b.HasKey("BookId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("MahlerFanSite.Models.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int?>("RevStoryStoryId");

                    b.Property<string>("Text");

                    b.HasKey("CommentId");

                    b.HasIndex("RevStoryStoryId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("MahlerFanSite.Models.Link", b =>
                {
                    b.Property<int>("LinkId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Url");

                    b.HasKey("LinkId");

                    b.ToTable("Links");
                });

            modelBuilder.Entity("MahlerFanSite.Models.Rating", b =>
                {
                    b.Property<int>("RatingId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Score");

                    b.Property<int?>("StoryId");

                    b.HasKey("RatingId");

                    b.HasIndex("StoryId");

                    b.ToTable("Rating");
                });

            modelBuilder.Entity("MahlerFanSite.Models.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BookId");

                    b.Property<DateTime>("ReviewDate");

                    b.Property<int?>("ReviewStoryStoryId");

                    b.Property<string>("ReviewText");

                    b.Property<int?>("ReviewerUserId");

                    b.HasKey("ReviewId");

                    b.HasIndex("BookId");

                    b.HasIndex("ReviewStoryStoryId");

                    b.HasIndex("ReviewerUserId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("MahlerFanSite.Models.Story", b =>
                {
                    b.Property<int>("StoryId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AuthorUserId");

                    b.Property<DateTime>("PublishedDate");

                    b.Property<string>("Text");

                    b.HasKey("StoryId");

                    b.HasIndex("AuthorUserId");

                    b.ToTable("Stories");
                });

            modelBuilder.Entity("MahlerFanSite.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmailAddress");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MahlerFanSite.Models.Author", b =>
                {
                    b.HasOne("MahlerFanSite.Models.Book")
                        .WithMany("Authors")
                        .HasForeignKey("BookId");
                });

            modelBuilder.Entity("MahlerFanSite.Models.Comment", b =>
                {
                    b.HasOne("MahlerFanSite.Models.Story", "RevStory")
                        .WithMany("Comments")
                        .HasForeignKey("RevStoryStoryId");
                });

            modelBuilder.Entity("MahlerFanSite.Models.Rating", b =>
                {
                    b.HasOne("MahlerFanSite.Models.Story")
                        .WithMany("Ratings")
                        .HasForeignKey("StoryId");
                });

            modelBuilder.Entity("MahlerFanSite.Models.Review", b =>
                {
                    b.HasOne("MahlerFanSite.Models.Book")
                        .WithMany("Reviews")
                        .HasForeignKey("BookId");

                    b.HasOne("MahlerFanSite.Models.Story", "ReviewStory")
                        .WithMany()
                        .HasForeignKey("ReviewStoryStoryId");

                    b.HasOne("MahlerFanSite.Models.User", "Reviewer")
                        .WithMany()
                        .HasForeignKey("ReviewerUserId");
                });

            modelBuilder.Entity("MahlerFanSite.Models.Story", b =>
                {
                    b.HasOne("MahlerFanSite.Models.User", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorUserId");
                });
#pragma warning restore 612, 618
        }
    }
}
