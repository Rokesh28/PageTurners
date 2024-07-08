﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PageTurners.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateShoppingCartTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "CartUpdatedDate",
                table: "ShoppingCarts",
                type: "date",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CartUpdatedDate",
                table: "ShoppingCarts");
        }
    }
}