using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment2.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    Address = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.Address);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    ReviewId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Text = table.Column<string>(nullable: true),
                    Stars = table.Column<double>(nullable: false),
                    RestaurantAddress = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK_Reviews_Restaurants_RestaurantAddress",
                        column: x => x.RestaurantAddress,
                        principalTable: "Restaurants",
                        principalColumn: "Address",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tables",
                columns: table => new
                {
                    Number = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RestaurantAddress = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tables", x => x.Number);
                    table.ForeignKey(
                        name: "FK_Tables_Restaurants_RestaurantAddress",
                        column: x => x.RestaurantAddress,
                        principalTable: "Restaurants",
                        principalColumn: "Address",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dishes",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    Type = table.Column<string>(nullable: false),
                    Price = table.Column<float>(nullable: false),
                    ReviewId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dishes", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Dishes_Reviews_ReviewId",
                        column: x => x.ReviewId,
                        principalTable: "Reviews",
                        principalColumn: "ReviewId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    ReviewId = table.Column<int>(nullable: true),
                    Time = table.Column<int>(nullable: true),
                    TableNumber = table.Column<int>(nullable: true),
                    Salary = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Persons_Reviews_ReviewId",
                        column: x => x.ReviewId,
                        principalTable: "Reviews",
                        principalColumn: "ReviewId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Persons_Tables_TableNumber",
                        column: x => x.TableNumber,
                        principalTable: "Tables",
                        principalColumn: "Number",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RestaurantDish",
                columns: table => new
                {
                    RestaurantDishId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RestaurantAddress = table.Column<string>(nullable: false),
                    DishType = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantDish", x => x.RestaurantDishId);
                    table.ForeignKey(
                        name: "FK_RestaurantDish_Dishes_DishType",
                        column: x => x.DishType,
                        principalTable: "Dishes",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RestaurantDish_Restaurants_RestaurantAddress",
                        column: x => x.RestaurantAddress,
                        principalTable: "Restaurants",
                        principalColumn: "Address",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GuestDish",
                columns: table => new
                {
                    GuestDishId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GuestName = table.Column<string>(nullable: false),
                    DishName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuestDish", x => x.GuestDishId);
                    table.ForeignKey(
                        name: "FK_GuestDish_Dishes_DishName",
                        column: x => x.DishName,
                        principalTable: "Dishes",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GuestDish_Persons_GuestName",
                        column: x => x.GuestName,
                        principalTable: "Persons",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WaiterTable",
                columns: table => new
                {
                    WaiterTableId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TableNumber = table.Column<int>(nullable: false),
                    WaiterName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaiterTable", x => x.WaiterTableId);
                    table.ForeignKey(
                        name: "FK_WaiterTable_Tables_TableNumber",
                        column: x => x.TableNumber,
                        principalTable: "Tables",
                        principalColumn: "Number",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WaiterTable_Persons_WaiterName",
                        column: x => x.WaiterName,
                        principalTable: "Persons",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_ReviewId",
                table: "Dishes",
                column: "ReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_GuestDish_DishName",
                table: "GuestDish",
                column: "DishName");

            migrationBuilder.CreateIndex(
                name: "IX_GuestDish_GuestName",
                table: "GuestDish",
                column: "GuestName");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_ReviewId",
                table: "Persons",
                column: "ReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_TableNumber",
                table: "Persons",
                column: "TableNumber");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantDish_DishType",
                table: "RestaurantDish",
                column: "DishType");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantDish_RestaurantAddress",
                table: "RestaurantDish",
                column: "RestaurantAddress");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_RestaurantAddress",
                table: "Reviews",
                column: "RestaurantAddress");

            migrationBuilder.CreateIndex(
                name: "IX_Tables_RestaurantAddress",
                table: "Tables",
                column: "RestaurantAddress");

            migrationBuilder.CreateIndex(
                name: "IX_WaiterTable_TableNumber",
                table: "WaiterTable",
                column: "TableNumber");

            migrationBuilder.CreateIndex(
                name: "IX_WaiterTable_WaiterName",
                table: "WaiterTable",
                column: "WaiterName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GuestDish");

            migrationBuilder.DropTable(
                name: "RestaurantDish");

            migrationBuilder.DropTable(
                name: "WaiterTable");

            migrationBuilder.DropTable(
                name: "Dishes");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Tables");

            migrationBuilder.DropTable(
                name: "Restaurants");
        }
    }
}
