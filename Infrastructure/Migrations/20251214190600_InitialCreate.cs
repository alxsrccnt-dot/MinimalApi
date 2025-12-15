using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BPTypes",
                columns: table => new
                {
                    TypeCode = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    TypeName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BPTypes", x => x.TypeCode);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemCode = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ItemName = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemCode);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BusinessPartners",
                columns: table => new
                {
                    BPCode = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    BPName = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    BPType = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessPartners", x => x.BPCode);
                    table.ForeignKey(
                        name: "FK_BusinessPartners_BPTypes_BPType",
                        column: x => x.BPType,
                        principalTable: "BPTypes",
                        principalColumn: "TypeCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BPCode = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    LastUpdatedBy = table.Column<int>(type: "int", nullable: true),
                    OrderType = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Orders_BusinessPartners_BPCode",
                        column: x => x.BPCode,
                        principalTable: "BusinessPartners",
                        principalColumn: "BPCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Users_LastUpdatedBy",
                        column: x => x.LastUpdatedBy,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderLines",
                columns: table => new
                {
                    LineID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocID = table.Column<int>(type: "int", nullable: false),
                    ItemCode = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Quantity = table.Column<decimal>(type: "DECIMAL(38,18)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    LastUpdatedBy = table.Column<int>(type: "int", nullable: true),
                    OrderLineType = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    PurchaseOrderID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderLines", x => x.LineID);
                    table.ForeignKey(
                        name: "FK_OrderLines_Items_ItemCode",
                        column: x => x.ItemCode,
                        principalTable: "Items",
                        principalColumn: "ItemCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderLines_Orders_DocID",
                        column: x => x.DocID,
                        principalTable: "Orders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderLines_Orders_PurchaseOrderID",
                        column: x => x.PurchaseOrderID,
                        principalTable: "Orders",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_OrderLines_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderLines_Users_LastUpdatedBy",
                        column: x => x.LastUpdatedBy,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SaleOrderLineComments",
                columns: table => new
                {
                    CommentLineID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocID = table.Column<int>(type: "int", nullable: false),
                    LineID = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleOrderLineComments", x => x.CommentLineID);
                    table.ForeignKey(
                        name: "FK_SaleOrderLineComments_OrderLines_LineID",
                        column: x => x.LineID,
                        principalTable: "OrderLines",
                        principalColumn: "LineID");
                    table.ForeignKey(
                        name: "FK_SaleOrderLineComments_Orders_DocID",
                        column: x => x.DocID,
                        principalTable: "Orders",
                        principalColumn: "ID");
                });

            migrationBuilder.InsertData(
                table: "BPTypes",
                columns: new[] { "TypeCode", "TypeName" },
                values: new object[,]
                {
                    { "C", "Customer" },
                    { "V", "Vendor" }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemCode", "Active", "ItemName" },
                values: new object[,]
                {
                    { "Itm1", true, "Item 1" },
                    { "Itm2", true, "Item 2" }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemCode", "ItemName" },
                values: new object[] { "Itm3", "Item 3" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "Active", "FullName", "Password", "UserName" },
                values: new object[] { 1, true, "User 1", "P1", "U1" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "FullName", "Password", "UserName" },
                values: new object[] { 2, "User 2", "P2", "U2" });

            migrationBuilder.InsertData(
                table: "BusinessPartners",
                columns: new[] { "BPCode", "Active", "BPName", "BPType" },
                values: new object[] { "C0001", true, "Customer 1", "C" });

            migrationBuilder.InsertData(
                table: "BusinessPartners",
                columns: new[] { "BPCode", "BPName", "BPType" },
                values: new object[] { "C0002", "Customer 2", "C" });

            migrationBuilder.InsertData(
                table: "BusinessPartners",
                columns: new[] { "BPCode", "Active", "BPName", "BPType" },
                values: new object[] { "V0001", true, "Vendor 1", "V" });

            migrationBuilder.InsertData(
                table: "BusinessPartners",
                columns: new[] { "BPCode", "BPName", "BPType" },
                values: new object[] { "V0002", "Vendor 2", "V" });

            migrationBuilder.CreateIndex(
                name: "IX_BusinessPartners_BPType",
                table: "BusinessPartners",
                column: "BPType");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_CreatedBy",
                table: "OrderLines",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_DocID",
                table: "OrderLines",
                column: "DocID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_ItemCode",
                table: "OrderLines",
                column: "ItemCode");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_LastUpdatedBy",
                table: "OrderLines",
                column: "LastUpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_PurchaseOrderID",
                table: "OrderLines",
                column: "PurchaseOrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BPCode",
                table: "Orders",
                column: "BPCode");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CreatedBy",
                table: "Orders",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_LastUpdatedBy",
                table: "Orders",
                column: "LastUpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_SaleOrderLineComments_DocID",
                table: "SaleOrderLineComments",
                column: "DocID");

            migrationBuilder.CreateIndex(
                name: "IX_SaleOrderLineComments_LineID",
                table: "SaleOrderLineComments",
                column: "LineID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SaleOrderLineComments");

            migrationBuilder.DropTable(
                name: "OrderLines");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "BusinessPartners");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "BPTypes");
        }
    }
}
