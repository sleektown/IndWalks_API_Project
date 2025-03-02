using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace INDWalks.Migrations
{
    /// <inheritdoc />
    public partial class Data_Seeding_DB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("092600b8-e6ff-4bc5-b762-4b2f494a8510"), "Hard" },
                    { new Guid("4c04209b-8490-41f7-a97f-dd68618c6307"), "Medium" },
                    { new Guid("c9a4a37f-6f4d-4e3b-b0e7-a928bb4bf87b"), "Easy" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("1469cb3d-71fe-4133-a5ad-a466cc004edc"), "BR", "Bihar", "Bihar-state.jpg" },
                    { new Guid("6a618c79-d331-49cd-a5f6-1a1e92fcc2bb"), "WB", "West-Bengal", "" },
                    { new Guid("a7c091ca-79d7-47a8-b3f9-bb2b74155f56"), "TN", "Tamil Nadu", "Tamil-Nadu-state.jpg" },
                    { new Guid("ebd40265-3712-42bc-9171-4808c250533a"), "DL", "New Delhi", "New-Delhi-state.jpg" },
                    { new Guid("f85a8f88-a975-47f9-9f88-fcd6ddf9b4de"), "MH", "Maharastra", "Maharastra-state.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("092600b8-e6ff-4bc5-b762-4b2f494a8510"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("4c04209b-8490-41f7-a97f-dd68618c6307"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("c9a4a37f-6f4d-4e3b-b0e7-a928bb4bf87b"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("1469cb3d-71fe-4133-a5ad-a466cc004edc"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("6a618c79-d331-49cd-a5f6-1a1e92fcc2bb"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("a7c091ca-79d7-47a8-b3f9-bb2b74155f56"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("ebd40265-3712-42bc-9171-4808c250533a"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("f85a8f88-a975-47f9-9f88-fcd6ddf9b4de"));
        }
    }
}
