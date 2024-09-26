using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace library.data.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Message = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Author = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ISBN = table.Column<long>(type: "bigint", maxLength: 13, nullable: false),
                    PublishDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LocationInfo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false, defaultValue: "On the shelf"),
                    BorrowedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MemberId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_AspNetUsers_MemberId",
                        column: x => x.MemberId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", null, "Admin", "ADMIN" },
                    { "2", null, "Moderator", "MODERATOR" },
                    { "3", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "None", "4312d35f-3fe6-4a65-b2b1-b46ef6837147", "admin@hotmail.com", false, "Admin", "Admin", false, null, "ADMIN@HOTMAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAEK8iBs5v2/pAPnCFCzI8U4kMO8sUg2l+YWjiS/Y3T7ZnmnpbVw4PylFdI6YL8QbezA==", "0", false, "c06e6ee0-7903-413f-8a8c-a8fa0b28ab1d", false, "admin" },
                    { "2", 0, "Sancaktepe/İstanbul", "bdd2a59a-5699-496f-a641-9df05d5e7eb7", "mehmet@hotmail.com", false, "Mehmet", "Kayar", false, null, "MEHMET@HOTMAIL.COM", "MEHMETKYR", "AQAAAAIAAYagAAAAEDApODJlp7gQX+EnZKFH0NixCYNJehcCuvIbt+SWHuZ3VwbJdn/UXeN2nds7MTNb7w==", "5318379692", false, "184b5967-4b82-4ee0-bb1e-a7724d2d918e", false, "mehmetkyr" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "BorrowedDate", "ISBN", "Image", "LocationInfo", "MemberId", "Name", "PublishDateTime", "Status", "Type" },
                values: new object[,]
                {
                    { 1, "Sabahattin Ali", null, 9789753638029L, "1.jpeg", "A1-b2", null, "Kürk Mantolu Madonna", new DateTime(2023, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "On the shelf", "Novel" },
                    { 2, "Stephen Hawking", null, 9786051067582L, "2.jpeg", "A2-b1", null, "Zamanın Kısa Tarihi", new DateTime(2023, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "On the shelf", "Science" },
                    { 3, "Franz Kafka", null, 9789750719356L, "3.jpeg", "A1-b1", null, "Dönüşüm", new DateTime(2019, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "On the shelf", "Novel" },
                    { 4, "Jose Mauro De Vasconcelos", null, 9789750738609L, "4.jpeg", "A1-b1", null, "Şeker Portakalı", new DateTime(2019, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "On the shelf", "Novel" },
                    { 5, "Benedictus Spinoza", null, 9789752981478L, "5.jpeg", "A3-b1", null, "Etika", new DateTime(2019, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "On the shelf", "Philosophy" },
                    { 6, "Carl Sagan", null, 9789752107830L, "6.jpeg", "A2-b1", null, "Kozmos Evrenin ve Yaşamın Sırları", new DateTime(2023, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "On the shelf", "Science" },
                    { 7, "Irvin D. Yalom", null, 9789755391465L, "7.jpeg", "A1-b1", null, "Nietzsche Ağladığında", new DateTime(2023, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "On the shelf", "Novel" },
                    { 8, "Victor Hugo", null, 9786052194973L, "8.jpeg", "A1-b1", null, "Bir İdam Mahkumunun Son Günü", new DateTime(2018, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "On the shelf", "Novel" },
                    { 9, "Sabahattin Ali", null, 9789753638029L, "1.jpeg", "A1-b2", null, "Kürk Mantolu Madonna", new DateTime(2023, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "On the shelf", "Novel" },
                    { 10, "Stephen Hawking", null, 9786051067582L, "2.jpeg", "A2-b1", null, "Zamanın Kısa Tarihi", new DateTime(2023, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "On the shelf", "Science" },
                    { 11, "Franz Kafka", null, 9789750719356L, "3.jpeg", "A1-b1", null, "Dönüşüm", new DateTime(2019, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "On the shelf", "Novel" },
                    { 12, "Jose Mauro De Vasconcelos", null, 9789750738609L, "4.jpeg", "A1-b1", null, "Şeker Portakalı", new DateTime(2019, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "On the shelf", "Novel" },
                    { 13, "Benedictus Spinoza", null, 9789752981478L, "5.jpeg", "A3-b1", null, "Etika", new DateTime(2019, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "On the shelf", "Philosophy" },
                    { 14, "Carl Sagan", null, 9789752107830L, "6.jpeg", "A2-b1", null, "Kozmos Evrenin ve Yaşamın Sırları", new DateTime(2023, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "On the shelf", "Science" },
                    { 15, "Irvin D. Yalom", null, 9789755391465L, "7.jpeg", "A1-b1", null, "Nietzsche Ağladığında", new DateTime(2023, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "On the shelf", "Novel" },
                    { 16, "Victor Hugo", null, 9786052194973L, "8.jpeg", "A1-b1", null, "Bir İdam Mahkumunun Son Günü", new DateTime(2018, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "On the shelf", "Novel" }
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Message", "Phone", "Title" },
                values: new object[,]
                {
                    { 1, "mehmet@hotmail.com", "Mehmet", "Kayar", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", "5318379612", "Örnek Konu" },
                    { 2, "ahmet@hotmail.com", "Ahmet", "Kılıç", "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. ", "5318379611", "Örnek Başlık" },
                    { 3, "ayse@hotmail.com", "Ayşe", "Koç", "Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", "5318379632", "Örnek Title" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1", "1" },
                    { "2", "2" },
                    { "3", "2" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Books_MemberId",
                table: "Books",
                column: "MemberId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
