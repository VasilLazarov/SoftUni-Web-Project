﻿// <auto-generated />
using System;
using LaLigaFans.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LaLigaFans.Infrastructure.Migrations
{
    [DbContext(typeof(LaLigaFansDbContext))]
    partial class LaLigaFansDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("LaLigaFans.Infrastructure.Data.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Address identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasComment("Address city");

                    b.Property<int>("OrderId")
                        .HasColumnType("int")
                        .HasComment("Payment order identifier");

                    b.Property<string>("StreetEtc")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Address street etc");

                    b.HasKey("Id");

                    b.HasIndex("OrderId")
                        .IsUnique();

                    b.ToTable("Addresses");

                    b.HasComment("Address is a entity class");
                });

            modelBuilder.Entity("LaLigaFans.Infrastructure.Data.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Application user first name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Application user last name");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasComment("ApplicationUser is a entity class that extends IdentityUser");
                });

            modelBuilder.Entity("LaLigaFans.Infrastructure.Data.Models.ApplicationUserProduct", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasComment("Product identifier");

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("nvarchar(450)")
                        .HasComment("ApplicationUser identifier");

                    b.HasKey("ProductId", "ApplicationUserId");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("ApplicationUsersProducts");

                    b.HasComment("ApplicationUserProduct is a mapping table entity class");
                });

            modelBuilder.Entity("LaLigaFans.Infrastructure.Data.Models.ApplicationUserTeam", b =>
                {
                    b.Property<int>("TeamId")
                        .HasColumnType("int")
                        .HasComment("Team identifier");

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("nvarchar(450)")
                        .HasComment("ApplicationUser identifier");

                    b.HasKey("TeamId", "ApplicationUserId");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("ApplicationUsersTeams");

                    b.HasComment("ApplicationUserTeam is a mapping table entity class");
                });

            modelBuilder.Entity("LaLigaFans.Infrastructure.Data.Models.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Cart identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ApplicationUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasComment("Cart applicaion user identifier");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId")
                        .IsUnique();

                    b.ToTable("Carts");

                    b.HasComment("Cart is a entity class");
                });

            modelBuilder.Entity("LaLigaFans.Infrastructure.Data.Models.CartProduct", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasComment("Product identifier");

                    b.Property<int>("CartId")
                        .HasColumnType("int")
                        .HasComment("Cart identifier");

                    b.HasKey("ProductId", "CartId");

                    b.HasIndex("CartId");

                    b.ToTable("CartsProducts");

                    b.HasComment("CartProduct is a mapping table entity class");
                });

            modelBuilder.Entity("LaLigaFans.Infrastructure.Data.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Category identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasComment("Category name");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasComment("Category is a entity class");
                });

            modelBuilder.Entity("LaLigaFans.Infrastructure.Data.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Comment identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AuthorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasComment("Comment author");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)")
                        .HasComment("Comment content");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2")
                        .HasComment("Comment creation date");

                    b.Property<int?>("NewsId")
                        .HasColumnType("int")
                        .HasComment("Comment news identifier");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int")
                        .HasComment("Comment product identifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasComment("Comment title");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("NewsId");

                    b.HasIndex("ProductId");

                    b.ToTable("Comments");

                    b.HasComment("Comment is a entity class");
                });

            modelBuilder.Entity("LaLigaFans.Infrastructure.Data.Models.News", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("News identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(4096)
                        .HasColumnType("nvarchar(max)")
                        .HasComment("News content");

                    b.Property<int>("DisLikes")
                        .HasColumnType("int")
                        .HasComment("News dislikes");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasComment("News image URL");

                    b.Property<int>("Likes")
                        .HasColumnType("int")
                        .HasComment("News likes");

                    b.Property<string>("OwnerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasComment("News owner identifier");

                    b.Property<DateTime>("PublishedOn")
                        .HasColumnType("datetime2")
                        .HasComment("News published date");

                    b.Property<int?>("TeamId")
                        .HasColumnType("int")
                        .HasComment("Identifier of team the news is about");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("News title");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.HasIndex("TeamId");

                    b.ToTable("News");

                    b.HasComment("News is a entity class");
                });

            modelBuilder.Entity("LaLigaFans.Infrastructure.Data.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Order identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("BuyerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasComment("Order buyer identifier");

                    b.HasKey("Id");

                    b.HasIndex("BuyerId");

                    b.ToTable("Order");

                    b.HasComment("Order is a entity class");
                });

            modelBuilder.Entity("LaLigaFans.Infrastructure.Data.Models.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Payment identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("OrderId")
                        .HasColumnType("int")
                        .HasComment("Payment order identifier");

                    b.Property<int>("PaymentMethod")
                        .HasColumnType("int")
                        .HasComment("Payment method");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)")
                        .HasComment("Payment total price");

                    b.HasKey("Id");

                    b.HasIndex("OrderId")
                        .IsUnique();

                    b.ToTable("Payments");

                    b.HasComment("Payment is a entity class");
                });

            modelBuilder.Entity("LaLigaFans.Infrastructure.Data.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Player identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Age")
                        .HasColumnType("int")
                        .HasComment("Player age");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Player first name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Player last name");

                    b.Property<string>("PlayerImageUrl")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasComment("Player image URL");

                    b.Property<int>("TeamId")
                        .HasColumnType("int")
                        .HasComment("Player team id");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Players");

                    b.HasComment("Player is a entity class");
                });

            modelBuilder.Entity("LaLigaFans.Infrastructure.Data.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Product identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasComment("Product category identifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Product description");

                    b.Property<int>("DisLikes")
                        .HasColumnType("int")
                        .HasComment("Product dislikes");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasComment("Product image URL");

                    b.Property<int>("Likes")
                        .HasColumnType("int")
                        .HasComment("Product likes");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasComment("Product name");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)")
                        .HasComment("Product price");

                    b.Property<int>("TeamId")
                        .HasColumnType("int")
                        .HasComment("Product team identifier");

                    b.Property<int>("UnitsAvailable")
                        .HasColumnType("int")
                        .HasComment("Product available units");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("TeamId");

                    b.ToTable("Products");

                    b.HasComment("Product is a entity class");
                });

            modelBuilder.Entity("LaLigaFans.Infrastructure.Data.Models.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Question identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AuthorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasComment("Question author identifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasComment("Question content");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2")
                        .HasComment("Question created on date");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasComment("Question title");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Questions");

                    b.HasComment("Question is a entity class");
                });

            modelBuilder.Entity("LaLigaFans.Infrastructure.Data.Models.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Team identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CoachName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Team coach name");

                    b.Property<int>("FoundedYear")
                        .HasColumnType("int")
                        .HasComment("Team founded year");

                    b.Property<string>("Information")
                        .IsRequired()
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)")
                        .HasComment("Team information");

                    b.Property<string>("LogoUrl")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasComment("Team logo URL");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasComment("Team name");

                    b.HasKey("Id");

                    b.ToTable("Teams");

                    b.HasComment("Team is a entity class");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("LaLigaFans.Infrastructure.Data.Models.Address", b =>
                {
                    b.HasOne("LaLigaFans.Infrastructure.Data.Models.Order", "Order")
                        .WithOne("Address")
                        .HasForeignKey("LaLigaFans.Infrastructure.Data.Models.Address", "OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("LaLigaFans.Infrastructure.Data.Models.ApplicationUserProduct", b =>
                {
                    b.HasOne("LaLigaFans.Infrastructure.Data.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("FavoriteProducts")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LaLigaFans.Infrastructure.Data.Models.Product", "Product")
                        .WithMany("UsersFavorite")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("LaLigaFans.Infrastructure.Data.Models.ApplicationUserTeam", b =>
                {
                    b.HasOne("LaLigaFans.Infrastructure.Data.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("FollowedTeams")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LaLigaFans.Infrastructure.Data.Models.Team", "Team")
                        .WithMany("Followers")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("LaLigaFans.Infrastructure.Data.Models.Cart", b =>
                {
                    b.HasOne("LaLigaFans.Infrastructure.Data.Models.ApplicationUser", "ApplicationUser")
                        .WithOne("Cart")
                        .HasForeignKey("LaLigaFans.Infrastructure.Data.Models.Cart", "ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("LaLigaFans.Infrastructure.Data.Models.CartProduct", b =>
                {
                    b.HasOne("LaLigaFans.Infrastructure.Data.Models.Cart", "Cart")
                        .WithMany("CartsProducts")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LaLigaFans.Infrastructure.Data.Models.Product", "Product")
                        .WithMany("CartsProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("LaLigaFans.Infrastructure.Data.Models.Comment", b =>
                {
                    b.HasOne("LaLigaFans.Infrastructure.Data.Models.ApplicationUser", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LaLigaFans.Infrastructure.Data.Models.News", "News")
                        .WithMany("Comments")
                        .HasForeignKey("NewsId");

                    b.HasOne("LaLigaFans.Infrastructure.Data.Models.Product", "Product")
                        .WithMany("Comments")
                        .HasForeignKey("ProductId");

                    b.Navigation("Author");

                    b.Navigation("News");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("LaLigaFans.Infrastructure.Data.Models.News", b =>
                {
                    b.HasOne("LaLigaFans.Infrastructure.Data.Models.ApplicationUser", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LaLigaFans.Infrastructure.Data.Models.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId");

                    b.Navigation("Owner");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("LaLigaFans.Infrastructure.Data.Models.Order", b =>
                {
                    b.HasOne("LaLigaFans.Infrastructure.Data.Models.ApplicationUser", "Buyer")
                        .WithMany("Orders")
                        .HasForeignKey("BuyerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Buyer");
                });

            modelBuilder.Entity("LaLigaFans.Infrastructure.Data.Models.Payment", b =>
                {
                    b.HasOne("LaLigaFans.Infrastructure.Data.Models.Order", "Order")
                        .WithOne("Payment")
                        .HasForeignKey("LaLigaFans.Infrastructure.Data.Models.Payment", "OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("LaLigaFans.Infrastructure.Data.Models.Player", b =>
                {
                    b.HasOne("LaLigaFans.Infrastructure.Data.Models.Team", "Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("LaLigaFans.Infrastructure.Data.Models.Product", b =>
                {
                    b.HasOne("LaLigaFans.Infrastructure.Data.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LaLigaFans.Infrastructure.Data.Models.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("LaLigaFans.Infrastructure.Data.Models.Question", b =>
                {
                    b.HasOne("LaLigaFans.Infrastructure.Data.Models.ApplicationUser", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("LaLigaFans.Infrastructure.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("LaLigaFans.Infrastructure.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LaLigaFans.Infrastructure.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("LaLigaFans.Infrastructure.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LaLigaFans.Infrastructure.Data.Models.ApplicationUser", b =>
                {
                    b.Navigation("Cart")
                        .IsRequired();

                    b.Navigation("FavoriteProducts");

                    b.Navigation("FollowedTeams");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("LaLigaFans.Infrastructure.Data.Models.Cart", b =>
                {
                    b.Navigation("CartsProducts");
                });

            modelBuilder.Entity("LaLigaFans.Infrastructure.Data.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("LaLigaFans.Infrastructure.Data.Models.News", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("LaLigaFans.Infrastructure.Data.Models.Order", b =>
                {
                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("Payment")
                        .IsRequired();
                });

            modelBuilder.Entity("LaLigaFans.Infrastructure.Data.Models.Product", b =>
                {
                    b.Navigation("CartsProducts");

                    b.Navigation("Comments");

                    b.Navigation("UsersFavorite");
                });

            modelBuilder.Entity("LaLigaFans.Infrastructure.Data.Models.Team", b =>
                {
                    b.Navigation("Followers");

                    b.Navigation("Players");
                });
#pragma warning restore 612, 618
        }
    }
}
