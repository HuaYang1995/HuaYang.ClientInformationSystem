using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class CreatingInteractions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interactions_Clients_ClientsId",
                table: "Interactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Interactions_Employees_EmployeesId",
                table: "Interactions");

            migrationBuilder.DropIndex(
                name: "IX_Interactions_ClientsId",
                table: "Interactions");

            migrationBuilder.DropIndex(
                name: "IX_Interactions_EmployeesId",
                table: "Interactions");

            migrationBuilder.DropColumn(
                name: "ClientsId",
                table: "Interactions");

            migrationBuilder.DropColumn(
                name: "EmployeesId",
                table: "Interactions");

            migrationBuilder.AlterColumn<string>(
                name: "Remarks",
                table: "Interactions",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "IntDate",
                table: "Interactions",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateIndex(
                name: "IX_Interactions_ClientId",
                table: "Interactions",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Interactions_EmpId",
                table: "Interactions",
                column: "EmpId");

            migrationBuilder.AddForeignKey(
                name: "FK_Interactions_Clients_ClientId",
                table: "Interactions",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Interactions_Employees_EmpId",
                table: "Interactions",
                column: "EmpId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interactions_Clients_ClientId",
                table: "Interactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Interactions_Employees_EmpId",
                table: "Interactions");

            migrationBuilder.DropIndex(
                name: "IX_Interactions_ClientId",
                table: "Interactions");

            migrationBuilder.DropIndex(
                name: "IX_Interactions_EmpId",
                table: "Interactions");

            migrationBuilder.AlterColumn<string>(
                name: "Remarks",
                table: "Interactions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "IntDate",
                table: "Interactions",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AddColumn<int>(
                name: "ClientsId",
                table: "Interactions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployeesId",
                table: "Interactions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Interactions_ClientsId",
                table: "Interactions",
                column: "ClientsId");

            migrationBuilder.CreateIndex(
                name: "IX_Interactions_EmployeesId",
                table: "Interactions",
                column: "EmployeesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Interactions_Clients_ClientsId",
                table: "Interactions",
                column: "ClientsId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Interactions_Employees_EmployeesId",
                table: "Interactions",
                column: "EmployeesId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
