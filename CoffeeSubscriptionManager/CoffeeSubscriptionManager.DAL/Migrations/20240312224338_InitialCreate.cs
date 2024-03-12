using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoffeeSubscriptionManager.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accessories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    StockCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accessories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Coffees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coffees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    Surname = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    FirstLineOfAddress = table.Column<string>(type: "TEXT", nullable: false),
                    SecondLineOfAddress = table.Column<string>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: false),
                    Postcode = table.Column<string>(type: "TEXT", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CoffeeBatches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CoffeeId = table.Column<int>(type: "INTEGER", nullable: false),
                    BatchNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    IsAvailable = table.Column<bool>(type: "INTEGER", nullable: false),
                    BatchDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoffeeBatches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoffeeBatches_Coffees_CoffeeId",
                        column: x => x.CoffeeId,
                        principalTable: "Coffees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContactPreferences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SMS = table.Column<bool>(type: "INTEGER", nullable: false),
                    Email = table.Column<bool>(type: "INTEGER", nullable: false),
                    Mail = table.Column<bool>(type: "INTEGER", nullable: false),
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactPreferences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactPreferences_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GrindSizes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CoffeeBatchId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrindSizes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GrindSizes_CoffeeBatches_CoffeeBatchId",
                        column: x => x.CoffeeBatchId,
                        principalTable: "CoffeeBatches",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: false),
                    FrequencyInDays = table.Column<int>(type: "INTEGER", nullable: false),
                    CoffeeBatchId = table.Column<int>(type: "INTEGER", nullable: false),
                    GrindSizeId = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderSize = table.Column<string>(type: "TEXT", nullable: false),
                    NextSendDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    BaseOrderPrice = table.Column<double>(type: "REAL", nullable: false),
                    PaymentMethod = table.Column<string>(type: "TEXT", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subscriptions_CoffeeBatches_CoffeeBatchId",
                        column: x => x.CoffeeBatchId,
                        principalTable: "CoffeeBatches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subscriptions_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subscriptions_GrindSizes_GrindSizeId",
                        column: x => x.GrindSizeId,
                        principalTable: "GrindSizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SubscriptionId = table.Column<int>(type: "INTEGER", nullable: false),
                    ScheduledSendDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsSent = table.Column<bool>(type: "INTEGER", nullable: false),
                    AddedExtrasId = table.Column<int>(type: "INTEGER", nullable: true),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Accessories_AddedExtrasId",
                        column: x => x.AddedExtrasId,
                        principalTable: "Accessories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_Subscriptions_SubscriptionId",
                        column: x => x.SubscriptionId,
                        principalTable: "Subscriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoffeeBatches_CoffeeId",
                table: "CoffeeBatches",
                column: "CoffeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactPreferences_CustomerId",
                table: "ContactPreferences",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_GrindSizes_CoffeeBatchId",
                table: "GrindSizes",
                column: "CoffeeBatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AddedExtrasId",
                table: "Orders",
                column: "AddedExtrasId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_SubscriptionId",
                table: "Orders",
                column: "SubscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_CoffeeBatchId",
                table: "Subscriptions",
                column: "CoffeeBatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_CustomerId",
                table: "Subscriptions",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_GrindSizeId",
                table: "Subscriptions",
                column: "GrindSizeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactPreferences");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Accessories");

            migrationBuilder.DropTable(
                name: "Subscriptions");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "GrindSizes");

            migrationBuilder.DropTable(
                name: "CoffeeBatches");

            migrationBuilder.DropTable(
                name: "Coffees");
        }
    }
}
