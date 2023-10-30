﻿// <auto-generated />
using BlazorECommerce.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlazorECommerce.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20231030213902_Categories2")]
    partial class Categories2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BlazorECommerce.Shared.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Stir Fry",
                            Url = "StirFry"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Salad",
                            Url = "Salad"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Curry",
                            Url = "Curry"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Desserts",
                            Url = "Desserts"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Beverages",
                            Url = "Beverages"
                        });
                });

            modelBuilder.Entity("BlazorECommerce.Shared.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Description = "Som tam pla ra is a tasty twist on the classic green papaya salad, hailing all the way from Northeast Thailand. Fermented fish sauce is the key ingredient in this Thai salad",
                            ImageUrl = "https://www.ediblecommunities.com/wp-content/uploads/2019/03/Luke-Nguyen-Street-Food-Asia_-Papaya-salad-900x617.jpg",
                            Price = 100m,
                            Title = "Som Tum Pla Ra"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            Description = "This pad kra pao (pork & holy basil-stir-fry) features a key ingredient: holy basil! With jasmine rice, it’s perfection. And it only takes minutes to make.",
                            ImageUrl = "https://thewoksoflife.com/wp-content/uploads/2016/08/pad-kra-pao-7.jpg",
                            Price = 200m,
                            Title = "Pad Kra Pao"
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 3,
                            Description = "Thai Green Curry in 30 minutes made by freshening up store bought curry paste OR with a homemade green curry paste! Whichever way you go, the one essential step to make a really great green curry is to fry off the curry paste. ",
                            ImageUrl = "https://www.recipetineats.com/wp-content/uploads/2019/02/Thai-Green-Curry_5.jpg",
                            Price = 500m,
                            Title = "GreenCurry"
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 4,
                            Description = "Mango sticky rice is a traditional Thai dessert made with glutinous rice, fresh mango and coconut milk, and eaten with a spoon or sometimes the hands.",
                            ImageUrl = "https://elavegan.com/wp-content/uploads/2020/07/drizzling-coconut-sauce-over-mango-sticky-rice.jpg",
                            Price = 120m,
                            Title = "Mango Sticky Rice"
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 5,
                            Description = "Thai iced tea is a Thai drink made from tea, milk and sugar, and served cold. It is popular in Southeast Asia and is served in many restaurants that serve Thai food.",
                            ImageUrl = "https://hot-thai-kitchen.com/wp-content/uploads/2022/08/Thai-iced-tea.jpg",
                            Price = 50m,
                            Title = "Thai Iced Tea"
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 1,
                            Description = "Tom yum or tom yam is a type of hot and sour Thai soup, usually cooked with shrimp (prawn). Tom yum has its origin in Thailand.",
                            ImageUrl = "https://www.recipetineats.com/wp-content/uploads/2019/09/Tom-Yum-soup_2.jpg",
                            Price = 250m,
                            Title = "Tom Yum Soup"
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 2,
                            Description = "Pad Thai is a stir-fried rice noodle dish commonly served as a street food and at most restaurants in Thailand as part of the country's cuisine.",
                            ImageUrl = "https://www.recipetineats.com/wp-content/uploads/2018/05/Chicken-Pad-Thai_9.jpg",
                            Price = 150m,
                            Title = "Pad Thai"
                        });
                });

            modelBuilder.Entity("BlazorECommerce.Shared.Product", b =>
                {
                    b.HasOne("BlazorECommerce.Shared.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}
