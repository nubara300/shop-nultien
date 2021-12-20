﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NultienShop.DataAccess.Domain;

namespace NultienShop.DataAccess.Domain.Migrations
{
    [DbContext(typeof(TheShopContext))]
    [Migration("20211220034906_ArticleProcedure")]
    partial class ArticleProcedure
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NultienShop.DataAccess.Domain.Models.Article", b =>
                {
                    b.Property<int>("ArticleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ArticleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ArticlePrice")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("ArticleId");

                    b.ToTable("Article");

                    b.HasData(
                        new
                        {
                            ArticleId = 1,
                            ArticleName = "Article No.1",
                            ArticlePrice = 100,
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ArticleId = 2,
                            ArticleName = "Article No.2",
                            ArticlePrice = 350,
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ArticleId = 3,
                            ArticleName = "Article No.3",
                            ArticlePrice = 750,
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ArticleId = 4,
                            ArticleName = "Article No.4",
                            ArticlePrice = 400,
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ArticleId = 5,
                            ArticleName = "Article No.5",
                            ArticlePrice = 600,
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ArticleId = 6,
                            ArticleName = "Article No.6",
                            ArticlePrice = 2000,
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ArticleId = 7,
                            ArticleName = "Article No.7",
                            ArticlePrice = 400,
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ArticleId = 8,
                            ArticleName = "Article No.8",
                            ArticlePrice = 600,
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ArticleId = 9,
                            ArticleName = "Article No.9",
                            ArticlePrice = 600,
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ArticleId = 10,
                            ArticleName = "Article No.10",
                            ArticlePrice = 600,
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("NultienShop.DataAccess.Domain.Models.ArticleOrder", b =>
                {
                    b.Property<int>("ArticleOrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ArticleId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.HasKey("ArticleOrderId");

                    b.HasIndex("ArticleId");

                    b.HasIndex("OrderId");

                    b.ToTable("ArticleOrder");
                });

            modelBuilder.Entity("NultienShop.DataAccess.Domain.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CustomerEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("CustomerId");

                    b.ToTable("Customer");

                    b.HasData(
                        new
                        {
                            CustomerId = 1,
                            CustomerName = "Customer No.1",
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            CustomerId = 2,
                            CustomerName = "Customer No.2",
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            CustomerId = 3,
                            CustomerName = "Customer No.3",
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            CustomerId = 4,
                            CustomerName = "Customer No.4",
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            CustomerId = 5,
                            CustomerName = "Customer No.5",
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            CustomerId = 6,
                            CustomerName = "Customer No.6",
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            CustomerId = 7,
                            CustomerName = "Customer No.7",
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            CustomerId = 8,
                            CustomerName = "Customer No.8",
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            CustomerId = 9,
                            CustomerName = "Customer No.9",
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            CustomerId = 10,
                            CustomerName = "Customer No.10,",
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("NultienShop.DataAccess.Domain.Models.Inventory", b =>
                {
                    b.Property<int>("InventoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("InventoryLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InventoryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("InventoryId");

                    b.ToTable("Inventory");

                    b.HasData(
                        new
                        {
                            InventoryId = 1,
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            InventoryName = "Inventory No.1"
                        },
                        new
                        {
                            InventoryId = 2,
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            InventoryName = "Inventory No.2"
                        },
                        new
                        {
                            InventoryId = 3,
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            InventoryName = "Inventory No.3"
                        },
                        new
                        {
                            InventoryId = 4,
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            InventoryName = "Inventory No.4"
                        },
                        new
                        {
                            InventoryId = 5,
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            InventoryName = "Inventory No.5"
                        },
                        new
                        {
                            InventoryId = 6,
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            InventoryName = "Inventory No.6"
                        },
                        new
                        {
                            InventoryId = 7,
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            InventoryName = "Inventory No.7"
                        },
                        new
                        {
                            InventoryId = 8,
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            InventoryName = "Inventory No.8"
                        },
                        new
                        {
                            InventoryId = 9,
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            InventoryName = "Inventory No.9"
                        },
                        new
                        {
                            InventoryId = 10,
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            InventoryName = "Inventory No.10,"
                        });
                });

            modelBuilder.Entity("NultienShop.DataAccess.Domain.Models.InventoryArticle", b =>
                {
                    b.Property<int>("InventoryArticleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ArticleId")
                        .HasColumnType("int");

                    b.Property<int>("ArticleQuantity")
                        .HasColumnType("int");

                    b.Property<int>("InventoryId")
                        .HasColumnType("int");

                    b.HasKey("InventoryArticleId");

                    b.HasIndex("ArticleId");

                    b.HasIndex("InventoryId");

                    b.ToTable("InventoryArticle");

                    b.HasData(
                        new
                        {
                            InventoryArticleId = 1,
                            ArticleId = 1,
                            ArticleQuantity = 500,
                            InventoryId = 1
                        },
                        new
                        {
                            InventoryArticleId = 2,
                            ArticleId = 2,
                            ArticleQuantity = 300,
                            InventoryId = 2
                        },
                        new
                        {
                            InventoryArticleId = 3,
                            ArticleId = 3,
                            ArticleQuantity = 200,
                            InventoryId = 3
                        },
                        new
                        {
                            InventoryArticleId = 4,
                            ArticleId = 4,
                            ArticleQuantity = 700,
                            InventoryId = 4
                        },
                        new
                        {
                            InventoryArticleId = 5,
                            ArticleId = 5,
                            ArticleQuantity = 2700,
                            InventoryId = 5
                        },
                        new
                        {
                            InventoryArticleId = 6,
                            ArticleId = 6,
                            ArticleQuantity = 50,
                            InventoryId = 6
                        },
                        new
                        {
                            InventoryArticleId = 7,
                            ArticleId = 7,
                            ArticleQuantity = 1170,
                            InventoryId = 7
                        },
                        new
                        {
                            InventoryArticleId = 8,
                            ArticleId = 8,
                            ArticleQuantity = 206,
                            InventoryId = 8
                        },
                        new
                        {
                            InventoryArticleId = 9,
                            ArticleId = 9,
                            ArticleQuantity = 758,
                            InventoryId = 9
                        },
                        new
                        {
                            InventoryArticleId = 10,
                            ArticleId = 10,
                            ArticleQuantity = 789,
                            InventoryId = 10
                        },
                        new
                        {
                            InventoryArticleId = 11,
                            ArticleId = 1,
                            ArticleQuantity = 650,
                            InventoryId = 10
                        },
                        new
                        {
                            InventoryArticleId = 12,
                            ArticleId = 2,
                            ArticleQuantity = 758,
                            InventoryId = 9
                        },
                        new
                        {
                            InventoryArticleId = 13,
                            ArticleId = 3,
                            ArticleQuantity = 206,
                            InventoryId = 8
                        },
                        new
                        {
                            InventoryArticleId = 14,
                            ArticleId = 4,
                            ArticleQuantity = 1170,
                            InventoryId = 7
                        },
                        new
                        {
                            InventoryArticleId = 15,
                            ArticleId = 5,
                            ArticleQuantity = 50,
                            InventoryId = 6
                        },
                        new
                        {
                            InventoryArticleId = 16,
                            ArticleId = 6,
                            ArticleQuantity = 2700,
                            InventoryId = 5
                        },
                        new
                        {
                            InventoryArticleId = 17,
                            ArticleId = 7,
                            ArticleQuantity = 332,
                            InventoryId = 4
                        },
                        new
                        {
                            InventoryArticleId = 18,
                            ArticleId = 8,
                            ArticleQuantity = 77,
                            InventoryId = 3
                        },
                        new
                        {
                            InventoryArticleId = 19,
                            ArticleId = 9,
                            ArticleQuantity = 10,
                            InventoryId = 2
                        },
                        new
                        {
                            InventoryArticleId = 20,
                            ArticleId = 10,
                            ArticleQuantity = 0,
                            InventoryId = 1
                        });
                });

            modelBuilder.Entity("NultienShop.DataAccess.Domain.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Completed")
                        .HasColumnType("bit");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int?>("TotalCost")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("NultienShop.DataAccess.Domain.Models.ArticleOrder", b =>
                {
                    b.HasOne("NultienShop.DataAccess.Domain.Models.Article", "Article")
                        .WithMany()
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("NultienShop.DataAccess.Domain.Models.Order", "Order")
                        .WithMany("ArticleOrders")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Article");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("NultienShop.DataAccess.Domain.Models.InventoryArticle", b =>
                {
                    b.HasOne("NultienShop.DataAccess.Domain.Models.Article", "Article")
                        .WithMany()
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("NultienShop.DataAccess.Domain.Models.Inventory", "Inventory")
                        .WithMany("InventoryArticles")
                        .HasForeignKey("InventoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Article");

                    b.Navigation("Inventory");
                });

            modelBuilder.Entity("NultienShop.DataAccess.Domain.Models.Order", b =>
                {
                    b.HasOne("NultienShop.DataAccess.Domain.Models.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("NultienShop.DataAccess.Domain.Models.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("NultienShop.DataAccess.Domain.Models.Inventory", b =>
                {
                    b.Navigation("InventoryArticles");
                });

            modelBuilder.Entity("NultienShop.DataAccess.Domain.Models.Order", b =>
                {
                    b.Navigation("ArticleOrders");
                });
#pragma warning restore 612, 618
        }
    }
}
