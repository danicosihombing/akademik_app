using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test7.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "dosen",
                columns: table => new
                {
                    Nip = table.Column<string>(type: "NVarChar(12)", nullable: false),
                    Nama_Dosen = table.Column<string>(type: "NVarChar(25)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dosen", x => x.Nip);
                });

            migrationBuilder.CreateTable(
                name: "mahasiswa",
                columns: table => new
                {
                    Nim = table.Column<string>(type: "NVarChar(9)", nullable: false),
                    Nama_Mhs = table.Column<string>(type: "NVarChar(25)", nullable: false),
                    Tgl_Lahir = table.Column<DateOnly>(type: "date", nullable: false),
                    Alamat = table.Column<string>(type: "NVarChar(25)", nullable: false),
                    Jenis_Kelamin = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mahasiswa", x => x.Nim);
                });

            migrationBuilder.CreateTable(
                name: "matakuliah",
                columns: table => new
                {
                    Kode_MK = table.Column<string>(type: "NVarChar(6)", nullable: false),
                    Nama_MK = table.Column<string>(type: "NVarChar(20)", nullable: false),
                    Sks = table.Column<int>(type: "Int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_matakuliah", x => x.Kode_MK);
                });

            migrationBuilder.CreateTable(
                name: "perkuliahan",
                columns: table => new
                {
                    PerkuliahanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nim = table.Column<string>(type: "NVarChar(9)", nullable: false),
                    Kode_MK = table.Column<string>(type: "NVarChar(6)", nullable: false),
                    Nip = table.Column<string>(type: "NVarChar(12)", nullable: false),
                    Nilai = table.Column<string>(type: "Char(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_perkuliahan", x => x.PerkuliahanId);
                    table.ForeignKey(
                        name: "FK_perkuliahan_dosen_Nip",
                        column: x => x.Nip,
                        principalTable: "dosen",
                        principalColumn: "Nip",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_perkuliahan_mahasiswa_Nim",
                        column: x => x.Nim,
                        principalTable: "mahasiswa",
                        principalColumn: "Nim",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_perkuliahan_matakuliah_Kode_MK",
                        column: x => x.Kode_MK,
                        principalTable: "matakuliah",
                        principalColumn: "Kode_MK",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_perkuliahan_Kode_MK",
                table: "perkuliahan",
                column: "Kode_MK");

            migrationBuilder.CreateIndex(
                name: "IX_perkuliahan_Nim",
                table: "perkuliahan",
                column: "Nim");

            migrationBuilder.CreateIndex(
                name: "IX_perkuliahan_Nip",
                table: "perkuliahan",
                column: "Nip");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "perkuliahan");

            migrationBuilder.DropTable(
                name: "dosen");

            migrationBuilder.DropTable(
                name: "mahasiswa");

            migrationBuilder.DropTable(
                name: "matakuliah");
        }
    }
}
