using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Turbo.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 255, nullable: false),
                    LastName = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fuels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fuels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpeedControls",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpeedControls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
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
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
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
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
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
                name: "NewsPosts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PhotoURL = table.Column<string>(nullable: true),
                    Title = table.Column<string>(maxLength: 255, nullable: false),
                    ShortInfo = table.Column<string>(maxLength: 500, nullable: false),
                    MainArticle = table.Column<string>(maxLength: 5000, nullable: false),
                    PublishDate = table.Column<DateTime>(nullable: false),
                    CustomUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NewsPosts_AspNetUsers_CustomUserId",
                        column: x => x.CustomUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    BrandId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Models_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Automobiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MainPhotoURL = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    ModelId = table.Column<int>(nullable: false),
                    Year = table.Column<DateTime>(nullable: false),
                    Motor = table.Column<int>(nullable: false),
                    Distance = table.Column<int>(nullable: false),
                    ColorId = table.Column<int>(nullable: false),
                    FuelId = table.Column<int>(nullable: false),
                    SpeedControlId = table.Column<int>(nullable: false),
                    ShortInfo = table.Column<string>(maxLength: 255, nullable: false),
                    FullInfo = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Automobiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Automobiles_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Automobiles_Fuels_FuelId",
                        column: x => x.FuelId,
                        principalTable: "Fuels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Automobiles_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Automobiles_SpeedControls_SpeedControlId",
                        column: x => x.SpeedControlId,
                        principalTable: "SpeedControls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Announcements",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AutomobileId = table.Column<int>(nullable: false),
                    PublishDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    LocationId = table.Column<int>(nullable: false),
                    CustomUserId = table.Column<string>(nullable: true),
                    IsVIP = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Announcements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Announcements_Automobiles_AutomobileId",
                        column: x => x.AutomobileId,
                        principalTable: "Automobiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Announcements_AspNetUsers_CustomUserId",
                        column: x => x.CustomUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Announcements_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AutoPhotos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PhotoURL = table.Column<string>(nullable: true),
                    AutomobileId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoPhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AutoPhotos_Automobiles_AutomobileId",
                        column: x => x.AutomobileId,
                        principalTable: "Automobiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "BMW" },
                    { 10, "Lexus" },
                    { 8, "Mitsubishi" },
                    { 7, "Hyundai" },
                    { 6, "Toyota" },
                    { 9, "Volkswagen" },
                    { 4, "Chevrolet" },
                    { 3, "Nissan" },
                    { 2, "Mercedes" },
                    { 5, "Ford" }
                });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 9, "Qara" },
                    { 14, "Yaş Asfalt" },
                    { 13, "Sarı" },
                    { 12, "Qızılı" },
                    { 11, "Qırmızı" },
                    { 10, "Qəhvəyi" },
                    { 8, "Mavi" },
                    { 15, "Yaşıl" },
                    { 6, "Narıncı" },
                    { 5, "Göy" },
                    { 4, "Çəhrayı" },
                    { 3, "Boz" },
                    { 2, "Bənövşəyi" },
                    { 1, "Ağ" },
                    { 7, "Gümüşü" }
                });

            migrationBuilder.InsertData(
                table: "Fuels",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 5, "Hibrid" },
                    { 4, "Elektro" },
                    { 2, "Dizel" },
                    { 1, "Benzin" },
                    { 3, "Qaz" }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 10, "Naxçıvan" },
                    { 9, "Mingəçevir" },
                    { 8, "Hacıqabul" },
                    { 7, "İmişli" },
                    { 6, "Daşkəsən" },
                    { 4, "Biləsuvar" },
                    { 3, "Bakı" },
                    { 2, "Ağcabədi" },
                    { 1, "Abşeron" },
                    { 5, "Cəlilabad" }
                });

            migrationBuilder.InsertData(
                table: "NewsPosts",
                columns: new[] { "Id", "CustomUserId", "MainArticle", "PhotoURL", "PublishDate", "ShortInfo", "Title" },
                values: new object[,]
                {
                    { 1, null, "Rəsmi açıqlanması ilin sonuna planlaşdırılan su ilə çalışan avtomobillər Çinin Pekin şəhərində istehsal olunacaq. Mütəxəssislər düşünür ki, bu avtomobillərin ixtira olunması ətraf mühitin qorunmasında başlıca rol oynayacaq.", "SouthCarolinaChevy.jpg", new DateTime(2019, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Su ilə çalışan avtomobillər meydana gəlir.", "Avtomobil dünyasında yenilik" },
                    { 2, null, "Rəsmi açıqlanması ilin sonuna planlaşdırılan su ilə çalışan avtomobillər Çinin Pekin şəhərində istehsal olunacaq. Mütəxəssislər düşünür ki, bu avtomobillərin ixtira olunması ətraf mühitin qorunmasında başlıca rol oynayacaq.", "SouthCarolinaChevy.jpg", new DateTime(2019, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Su ilə çalışan avtomobillər meydana gəlir.", "Avtomobil dünyasında yenilik" },
                    { 3, null, "Rəsmi açıqlanması ilin sonuna planlaşdırılan su ilə çalışan avtomobillər Çinin Pekin şəhərində istehsal olunacaq. Mütəxəssislər düşünür ki, bu avtomobillərin ixtira olunması ətraf mühitin qorunmasında başlıca rol oynayacaq.", "SouthCarolinaChevy.jpg", new DateTime(2019, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Su ilə çalışan avtomobillər meydana gəlir.", "Avtomobil dünyasında yenilik" },
                    { 4, null, "Rəsmi açıqlanması ilin sonuna planlaşdırılan su ilə çalışan avtomobillər Çinin Pekin şəhərində istehsal olunacaq. Mütəxəssislər düşünür ki, bu avtomobillərin ixtira olunması ətraf mühitin qorunmasında başlıca rol oynayacaq.", "SouthCarolinaChevy.jpg", new DateTime(2019, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Su ilə çalışan avtomobillər meydana gəlir.", "Avtomobil dünyasında yenilik" },
                    { 5, null, "Rəsmi açıqlanması ilin sonuna planlaşdırılan su ilə çalışan avtomobillər Çinin Pekin şəhərində istehsal olunacaq. Mütəxəssislər düşünür ki, bu avtomobillərin ixtira olunması ətraf mühitin qorunmasında başlıca rol oynayacaq.", "SouthCarolinaChevy.jpg", new DateTime(2019, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Su ilə çalışan avtomobillər meydana gəlir.", "Avtomobil dünyasında yenilik" },
                    { 6, null, "Rəsmi açıqlanması ilin sonuna planlaşdırılan su ilə çalışan avtomobillər Çinin Pekin şəhərində istehsal olunacaq. Mütəxəssislər düşünür ki, bu avtomobillərin ixtira olunması ətraf mühitin qorunmasında başlıca rol oynayacaq.", "SouthCarolinaChevy.jpg", new DateTime(2019, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Su ilə çalışan avtomobillər meydana gəlir.", "Avtomobil dünyasında yenilik" },
                    { 7, null, "Rəsmi açıqlanması ilin sonuna planlaşdırılan su ilə çalışan avtomobillər Çinin Pekin şəhərində istehsal olunacaq. Mütəxəssislər düşünür ki, bu avtomobillərin ixtira olunması ətraf mühitin qorunmasında başlıca rol oynayacaq.", "SouthCarolinaChevy.jpg", new DateTime(2019, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Su ilə çalışan avtomobillər meydana gəlir.", "Avtomobil dünyasında yenilik" },
                    { 8, null, "Rəsmi açıqlanması ilin sonuna planlaşdırılan su ilə çalışan avtomobillər Çinin Pekin şəhərində istehsal olunacaq. Mütəxəssislər düşünür ki, bu avtomobillərin ixtira olunması ətraf mühitin qorunmasında başlıca rol oynayacaq.", "SouthCarolinaChevy.jpg", new DateTime(2019, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Su ilə çalışan avtomobillər meydana gəlir.", "Avtomobil dünyasında yenilik" }
                });

            migrationBuilder.InsertData(
                table: "SpeedControls",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Mexaniki" },
                    { 2, "Avtomat" }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "BrandId", "Name" },
                values: new object[,]
                {
                    { 6, 1, "X6" },
                    { 24, 9, "Passat" },
                    { 19, 9, "Beetle" },
                    { 18, 8, "Galant" },
                    { 17, 8, "Grandis" },
                    { 26, 7, "Accent" },
                    { 25, 7, "i40" },
                    { 23, 6, "Camry" },
                    { 16, 6, "Carolla" },
                    { 15, 6, "Avalon" },
                    { 14, 5, "Mustang" },
                    { 13, 5, "Focus" },
                    { 12, 4, "Aveo" },
                    { 11, 4, "Niva" },
                    { 10, 4, "Cruze" },
                    { 9, 4, "Camaro" },
                    { 3, 3, "Navara" },
                    { 2, 3, "Sunny" },
                    { 1, 3, "X-Trail" },
                    { 22, 2, "S-600" },
                    { 5, 2, "E-500" },
                    { 4, 2, "GL-500" },
                    { 8, 1, "Z4" },
                    { 7, 1, "M5" },
                    { 20, 10, "GS-350" },
                    { 21, 10, "UX-200" }
                });

            migrationBuilder.InsertData(
                table: "Automobiles",
                columns: new[] { "Id", "ColorId", "Distance", "FuelId", "FullInfo", "MainPhotoURL", "ModelId", "Motor", "Price", "ShortInfo", "SpeedControlId", "Year" },
                values: new object[,]
                {
                    { 15, 10, 25000, 3, "Saz vəziyyətdədir. Ciddi şəxslər əlaqə saxlasın. Endirim mümkündür.", "2019-Chevrolet-Silverado-LTZ-037.jpg", 6, 9000, 20000m, "Əla maşındır", 2, new DateTime(2019, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 3, 25000, 1, "Saz vəziyyətdədir. Ciddi şəxslər əlaqə saxlasın. Endirim mümkündür.", "Chevrolet-Beat-main-480.jpg", 9, 9000, 20000m, "Əla maşındır", 1, new DateTime(2019, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 2, 25000, 3, "Saz vəziyyətdədir. Ciddi şəxslər əlaqə saxlasın. Endirim mümkündür.", "chevrolet-camaro-fahren-10581.jpg", 9, 9000, 20000m, "Əla maşındır", 2, new DateTime(2019, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 1, 25000, 3, "Saz vəziyyətdədir. Ciddi şəxslər əlaqə saxlasın. Endirim mümkündür.", "chevrolet-cruze-sedan-1-6-l-2012-id-62933993-type-main.jpg", 9, 9000, 20000m, "Əla maşındır", 2, new DateTime(2019, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, 14, 25000, 2, "Saz vəziyyətdədir. Ciddi şəxslər əlaqə saxlasın. Endirim mümkündür.", "2018-chevrolet-impala-1544730311.jpg", 3, 9000, 20000m, "Əla maşındır", 1, new DateTime(2019, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, 13, 25000, 5, "Saz vəziyyətdədir. Ciddi şəxslər əlaqə saxlasın. Endirim mümkündür.", "2018-chevrolet-traverse-058_720.jpg", 3, 9000, 20000m, "Əla maşındır", 1, new DateTime(2019, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 5, 25000, 1, "Saz vəziyyətdədir. Ciddi şəxslər əlaqə saxlasın. Endirim mümkündür.", "chev.jpg", 3, 9000, 20000m, "Əla maşındır", 2, new DateTime(2019, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 14, 25000, 4, "Saz vəziyyətdədir. Ciddi şəxslər əlaqə saxlasın. Endirim mümkündür.", "chevrolet-sonic-hatchback-front-angle-low-view-118688.jpg", 3, 9000, 20000m, "Əla maşındır", 2, new DateTime(2019, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, 12, 25000, 5, "Saz vəziyyətdədir. Ciddi şəxslər əlaqə saxlasın. Endirim mümkündür.", "2018cht270006_640_11.jpg", 2, 9000, 20000m, "Əla maşındır", 2, new DateTime(2019, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, 8, 25000, 2, "Saz vəziyyətdədir. Ciddi şəxslər əlaqə saxlasın. Endirim mümkündür.", "344579_2019_Chevrolet_Silverado.jpg", 2, 9000, 20000m, "Əla maşındır", 2, new DateTime(2019, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 12, 25000, 5, "Saz vəziyyətdədir. Ciddi şəxslər əlaqə saxlasın. Endirim mümkündür.", "RT_V_bcc587ea94a2466bb4e5b735e6c61416.jpg", 2, 9000, 20000m, "Əla maşındır", 1, new DateTime(2019, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, 11, 25000, 4, "Saz vəziyyətdədir. Ciddi şəxslər əlaqə saxlasın. Endirim mümkündür.", "2019-chevrolet-blazer-050-1565640886.jpg", 1, 9000, 20000m, "Əla maşındır", 2, new DateTime(2019, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, 11, 25000, 1, "Saz vəziyyətdədir. Ciddi şəxslər əlaqə saxlasın. Endirim mümkündür.", "SouthCarolinaChevy.jpg", 1, 9000, 20000m, "Əla maşındır", 1, new DateTime(2019, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, 7, 25000, 2, "Saz vəziyyətdədir. Ciddi şəxslər əlaqə saxlasın. Endirim mümkündür.", "6.jpg", 5, 9000, 20000m, "Əla maşındır", 2, new DateTime(2019, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, 6, 25000, 1, "Saz vəziyyətdədir. Ciddi şəxslər əlaqə saxlasın. Endirim mümkündür.", "cc_2019chc060081_01_640_gtr.jpg", 5, 9000, 20000m, "Əla maşındır", 1, new DateTime(2019, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 13, 25000, 2, "Saz vəziyyətdədir. Ciddi şəxslər əlaqə saxlasın. Endirim mümkündür.", "maxresdefault.jpg", 4, 9000, 20000m, "Əla maşındır", 2, new DateTime(2019, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 4, 25000, 1, "Saz vəziyyətdədir. Ciddi şəxslər əlaqə saxlasın. Endirim mümkündür.", "chevrolet.jpg", 8, 9000, 20000m, "Əla maşındır", 1, new DateTime(2019, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, 9, 25000, 5, "Saz vəziyyətdədir. Ciddi şəxslər əlaqə saxlasın. Endirim mümkündür.", "2019-Chevrolet-Silverado-LTZ-037.jpg", 7, 9000, 20000m, "Əla maşındır", 2, new DateTime(2019, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 15, 25000, 3, "Saz vəziyyətdədir. Ciddi şəxslər əlaqə saxlasın. Endirim mümkündür.", "chevrolet-orlando-front-angle-low-view-898802.jpg", 10, 9000, 20000m, "Əla maşındır", 2, new DateTime(2019, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, 15, 25000, 2, "Saz vəziyyətdədir. Ciddi şəxslər əlaqə saxlasın. Endirim mümkündür.", "1530194245444.jpg", 10, 9000, 20000m, "Əla maşındır", 1, new DateTime(2019, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Announcements",
                columns: new[] { "Id", "AutomobileId", "CustomUserId", "IsVIP", "LocationId", "PublishDate", "UpdateDate" },
                values: new object[,]
                {
                    { 10, 14, null, false, 4, new DateTime(2017, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, 20, null, false, 6, new DateTime(2017, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 5, null, true, 2, new DateTime(2018, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 8, null, true, 4, new DateTime(2017, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 7, null, true, 8, new DateTime(2018, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 6, null, true, 2, new DateTime(2017, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 4, null, true, 2, new DateTime(2018, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, 17, null, false, 10, new DateTime(2016, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, 13, null, false, 10, new DateTime(2017, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, 20, null, false, 10, new DateTime(2016, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, 16, null, false, 3, new DateTime(2016, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, null, true, 7, new DateTime(2019, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, 12, null, false, 5, new DateTime(2016, 7, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, 14, null, false, 7, new DateTime(2016, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 9, null, true, 3, new DateTime(2019, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 3, null, true, 1, new DateTime(2018, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, 11, null, false, 5, new DateTime(2016, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, 11, null, false, 5, new DateTime(2016, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, 20, null, false, 3, new DateTime(2016, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, 1, null, true, 10, new DateTime(2019, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "AutoPhotos",
                columns: new[] { "Id", "AutomobileId", "PhotoURL" },
                values: new object[,]
                {
                    { 8, 12, "chevrolet-sonic-hatchback-front-angle-low-view-118688.jpg" },
                    { 1, 1, "chevrolet.jpg" },
                    { 6, 10, "2019-Chevrolet-Silverado-LTZ-037.jpg" },
                    { 7, 10, "chevrolet-camaro-fahren-10581.jpg" },
                    { 5, 2, "chevrolet.jpg" },
                    { 4, 2, "1530194245444.jpg" },
                    { 3, 2, "2018-chevrolet-traverse-058_720.jpg" },
                    { 10, 12, "RT_V_bcc587ea94a2466bb4e5b735e6c61416.jpg" },
                    { 9, 12, "chevrolet-sonic-hatchback-front-angle-low-view-118688.jpg" },
                    { 2, 1, "Chevrolet-Beat-main-480.jpg" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_AutomobileId",
                table: "Announcements",
                column: "AutomobileId");

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_CustomUserId",
                table: "Announcements",
                column: "CustomUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_LocationId",
                table: "Announcements",
                column: "LocationId");

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
                name: "IX_Automobiles_ColorId",
                table: "Automobiles",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Automobiles_FuelId",
                table: "Automobiles",
                column: "FuelId");

            migrationBuilder.CreateIndex(
                name: "IX_Automobiles_ModelId",
                table: "Automobiles",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Automobiles_SpeedControlId",
                table: "Automobiles",
                column: "SpeedControlId");

            migrationBuilder.CreateIndex(
                name: "IX_AutoPhotos_AutomobileId",
                table: "AutoPhotos",
                column: "AutomobileId");

            migrationBuilder.CreateIndex(
                name: "IX_Models_BrandId",
                table: "Models",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsPosts_CustomUserId",
                table: "NewsPosts",
                column: "CustomUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Announcements");

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
                name: "AutoPhotos");

            migrationBuilder.DropTable(
                name: "NewsPosts");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Automobiles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "Fuels");

            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DropTable(
                name: "SpeedControls");

            migrationBuilder.DropTable(
                name: "Brands");
        }
    }
}
