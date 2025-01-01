using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersInfos",
                table: "UsersInfos");

            migrationBuilder.RenameTable(
                name: "UsersInfos",
                newName: "UserInfos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserInfos",
                table: "UserInfos",
                column: "Id");

            migrationBuilder.Sql(@"
                INSERT INTO UserInfos (Name, DateOfBirth, Married, Phone, Salary)
                VALUES 
                ('Alice Smith', '1985-05-15', 1, '+380501234567', 50000),
                ('Bob Johnson', '1990-08-22', 0, '+380673456789', 60000),
                ('Charlie Brown', '1979-03-10', 1, '+380931112223', 55000),
                ('Diana Prince', '1987-11-30', 0, '+380662223344', 65000),
                ('Ethan Hunt', '1983-07-18', 1, '+380682334455', 72000),
                ('Fiona Gallagher', '1992-02-25', 0, '+380631223344', 45000),
                ('George Miller', '1980-12-05', 1, '+380672223344', 58000),
                ('Hannah Baker', '1995-06-12', 0, '+380931223344', 40000),
                ('Ian Wright', '1988-04-21', 1, '+380992334455', 53000),
                ('Jane Doe', '1991-09-15', 0, '+380501112233', 47000);
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("UserInfos");
        }
    }
}
