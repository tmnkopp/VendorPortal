using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace VendorPortal.Data.Migrations
{
    public partial class vendors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*
             migrationBuilder.DropIndex(
                    name: "IX_AspNetUserRoles_UserId",
                    table: "AspNetUserRoles");
             */


            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "VendorCategory",
                columns: table => new
                {
                    VendorCategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendorCategory", x => x.VendorCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "VendorType",
                columns: table => new
                {
                    VendorTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GUID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendorType", x => x.VendorTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Vendor",
                columns: table => new
                {
                    VendorID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VendorName = table.Column<string>(nullable: true),
                    VendorTypeID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendor", x => x.VendorID);
                    table.ForeignKey(
                        name: "FK_Vendor_VendorType_VendorTypeID",
                        column: x => x.VendorTypeID,
                        principalTable: "VendorType",
                        principalColumn: "VendorTypeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VendorCategoryMap",
                columns: table => new
                {
                    VendorId = table.Column<int>(nullable: false),
                    VendorCategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendorCategoryMap", x => new { x.VendorId, x.VendorCategoryId });
                    table.ForeignKey(
                        name: "FK_VendorCategoryMap_VendorCategory_VendorCategoryId",
                        column: x => x.VendorCategoryId,
                        principalTable: "VendorCategory",
                        principalColumn: "VendorCategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VendorCategoryMap_Vendor_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendor",
                        principalColumn: "VendorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Vendor_VendorTypeID",
                table: "Vendor",
                column: "VendorTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_VendorCategoryMap_VendorCategoryId",
                table: "VendorCategoryMap",
                column: "VendorCategoryId");
            /*
        migrationBuilder.AddForeignKey(
            name: "FK_AspNetUserTokens_AspNetUsers_UserId",
            table: "AspNetUserTokens",
            column: "UserId",
            principalTable: "AspNetUsers",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);
            */

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "VendorCategoryMap");

            migrationBuilder.DropTable(
                name: "VendorCategory");

            migrationBuilder.DropTable(
                name: "Vendor");

            migrationBuilder.DropTable(
                name: "VendorType");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "AspNetUsers");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);
        }
    }
}
