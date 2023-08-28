using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hydot_Mall_Backend_v1.Migrations
{
    /// <inheritdoc />
    public partial class yrdtjfgkhgshdgfgmhjhngf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Billings");

            migrationBuilder.DropColumn(
                name: "CustomerEmail",
                table: "Accountings");

            migrationBuilder.DropColumn(
                name: "CustomerName",
                table: "Accountings");

            migrationBuilder.DropColumn(
                name: "CustomerPhone",
                table: "Accountings");

            migrationBuilder.DropColumn(
                name: "IssuerEmail",
                table: "Accountings");

            migrationBuilder.DropColumn(
                name: "IssuerId",
                table: "Accountings");

            migrationBuilder.DropColumn(
                name: "IssuerName",
                table: "Accountings");

            migrationBuilder.DropColumn(
                name: "IssuerPhone",
                table: "Accountings");

            migrationBuilder.RenameColumn(
                name: "DateAddded",
                table: "Products",
                newName: "DateAdded");

            migrationBuilder.RenameColumn(
                name: "DateAdded",
                table: "OrderLists",
                newName: "DateOrdered");

            migrationBuilder.RenameColumn(
                name: "CustomerToken",
                table: "DeliveryManagers",
                newName: "RecipientDetails");

            migrationBuilder.RenameColumn(
                name: "CustomerPhone",
                table: "DeliveryManagers",
                newName: "OneTimePassword");

            migrationBuilder.RenameColumn(
                name: "CustomerName",
                table: "DeliveryManagers",
                newName: "DeliveryMethod");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "DeliveryManagers",
                newName: "DeliveryId");

            migrationBuilder.RenameColumn(
                name: "CustomerEmail",
                table: "DeliveryManagers",
                newName: "DeliveryDate");

            migrationBuilder.RenameColumn(
                name: "IssuerRole",
                table: "Accountings",
                newName: "Status");

            migrationBuilder.AddColumn<string>(
                name: "StaffId",
                table: "StaffAccounts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "OrderTotal",
                table: "DeliveryManagers",
                type: "float",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BillingCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BillingId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GpsAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BillingStage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WarehouseStage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QualityStage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountsStage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryStage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryStatus = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillingCards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GpsAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryAddresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleTables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManagerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManagerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleTables", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BillingCards");

            migrationBuilder.DropTable(
                name: "DeliveryAddresses");

            migrationBuilder.DropTable(
                name: "RoleTables");

            migrationBuilder.DropColumn(
                name: "StaffId",
                table: "StaffAccounts");

            migrationBuilder.DropColumn(
                name: "OrderTotal",
                table: "DeliveryManagers");

            migrationBuilder.RenameColumn(
                name: "DateAdded",
                table: "Products",
                newName: "DateAddded");

            migrationBuilder.RenameColumn(
                name: "DateOrdered",
                table: "OrderLists",
                newName: "DateAdded");

            migrationBuilder.RenameColumn(
                name: "RecipientDetails",
                table: "DeliveryManagers",
                newName: "CustomerToken");

            migrationBuilder.RenameColumn(
                name: "OneTimePassword",
                table: "DeliveryManagers",
                newName: "CustomerPhone");

            migrationBuilder.RenameColumn(
                name: "DeliveryMethod",
                table: "DeliveryManagers",
                newName: "CustomerName");

            migrationBuilder.RenameColumn(
                name: "DeliveryId",
                table: "DeliveryManagers",
                newName: "CustomerId");

            migrationBuilder.RenameColumn(
                name: "DeliveryDate",
                table: "DeliveryManagers",
                newName: "CustomerEmail");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Accountings",
                newName: "IssuerRole");

            migrationBuilder.AddColumn<string>(
                name: "CustomerEmail",
                table: "Accountings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerName",
                table: "Accountings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerPhone",
                table: "Accountings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IssuerEmail",
                table: "Accountings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IssuerId",
                table: "Accountings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IssuerName",
                table: "Accountings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IssuerPhone",
                table: "Accountings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Billings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BillingId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Billings", x => x.Id);
                });
        }
    }
}
