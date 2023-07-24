using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CongNgheStore.Migrations
{
    public partial class build : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "varchar(200)", nullable: false),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "varchar(12)", nullable: false),
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
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1500)", nullable: false),
                    IsRemove = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Slides",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Img = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slides", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
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
                    UserId = table.Column<int>(type: "int", nullable: false),
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
                    UserId = table.Column<int>(type: "int", nullable: false)
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
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
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
                    UserId = table.Column<int>(type: "int", nullable: false),
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
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(50)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(12)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    CustomerNotes = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    StoreNotes = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_User",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BrandCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    BrandId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrandCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BrandCategory_Brand",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BrandCategory_Category",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(50)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    ImportPrice = table.Column<long>(type: "bigint", nullable: false),
                    SellingPrice = table.Column<long>(type: "bigint", nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1500)", nullable: true),
                    IsRemove = table.Column<bool>(type: "bit", nullable: false),
                    BrandCategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_BrandCategory",
                        column: x => x.BrandCategoryId,
                        principalTable: "BrandCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BatteryAndChargers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BatteryCapacity = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    BatteryType = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    MaximumChargingSupport = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    BatteryTechnology = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    ProductId = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BatteryAndChargers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BatteryAndCharger_Product",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Img = table.Column<string>(type: "varchar(100)", nullable: false),
                    Price = table.Column<long>(type: "bigint", nullable: false),
                    ProductId = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Colors_Product",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FrontCameras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Resolution = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Feature = table.Column<string>(type: "nvarchar(1000)", nullable: true),
                    ProductId = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FrontCameras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FrontCamera_Product",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MemoryAndStorages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ram = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Rom = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    HardDrive = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    HardDriveType = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Price = table.Column<long>(type: "bigint", nullable: false),
                    ProductId = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemoryAndStorages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MemoryAndStorages_Product",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OSAndCPUs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OperatingSystem = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Cpu = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CpuSpeed = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Gpu = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    ProductId = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OSAndCPUs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OSAndCPU_Product",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RearCameras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Resolution = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Film = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    FlashLight = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Feature = table.Column<string>(type: "nvarchar(1000)", nullable: true),
                    ProductId = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RearCameras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RearCamera_Product",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Screens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScreenTechnology = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Resolution = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Widescreen = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    MaximumBrightness = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    TouchScreen = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    ProductId = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Screens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Screen_Product",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Details",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<string>(type: "varchar(50)", nullable: true),
                    ProductId = table.Column<string>(type: "varchar(50)", nullable: true),
                    ColorId = table.Column<int>(type: "int", nullable: true),
                    MemoryAndStorageId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Details_Color",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Details_MemoryAndStorage",
                        column: x => x.MemoryAndStorageId,
                        principalTable: "MemoryAndStorages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Details_Order",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Details_Product",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 2, "6e3d6829-397c-4c08-9fd9-cf8a474dbf88", "User", "USER" },
                    { 1, "5c6185b4-a68d-4b79-8199-f7be0028b8f6", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Description", "IsRemove", "Name" },
                values: new object[,]
                {
                    { 1, "Thương hiệu Apple được thành lập từ những năm 1976 tại Hoa Kỳ, cũng là nơi đặt trụ sở chính của công ty đến thời điểm hiện tại. Trải qua nhiều năm, với sự phát triển và thay đổi để hoàn thiện, người dùng trên toàn thế giới bắt đầu biết đến và nhớ tới thương hiệu qua logo quả táo khuyết. Không chỉ thế, người dùng còn nhớ đến Apple bởi slogan “Think different” và những sáng tạo không ngừng trên những sản phẩm đã ra mắt. Năm 2007, chiếc iPhone đầu tiên ra đời đánh dấu bước tiến lớn trong ngành công nghiệp smartphone. Cũng kể từ đó, iPhone luôn được nhớ đến với những thiết kế thời thượng, tính năng khác biệt, dẫn đầu xu hướng và vượt lên trên tất cả các nhà sản xuất khác trong ngành.", false, "Apple" },
                    { 2, "Samsung là tập đoàn đa quốc gia thành lập từ năm 1938 và có trụ sở tại Seoul, Hàn Quốc. Ra đời và hoạt động từ quốc gia có ngành công nghiệp hiện đại, phát triển, Samsung nhanh chóng đạt được các cột mốc ấn tượng. Không chỉ dừng lại ở một dòng sản phẩm, Samsung không ngừng sáng tạo, thử nghiệm công nghệ mới, liên tục giới thiệu rất nhiều thiết bị điện tử hữu ích cho cuộc sống hàng ngày. Nhưng trong đó, các mẫu smartphone vẫn là dòng sản phẩm chủ lực, được công ty đầu tư phát triển, đổi mới không ngừng. Tại Việt Nam, một số mẫu điện thoại Samsung phổ biến như Galaxy A, Galaxy S, Galaxy Z,...", false, "Samsung" },
                    { 3, "OPPO là một thương hiệu smartphone đến từ Trung Quốc. Tại quê nhà, OPPO đối đầu trực tiếp với Huawei và xuất sắc vượt lên với 16.8% thị phần. Trở thành thương hiệu di động bán chạy nhất Trung Quốc, đó vừa là niềm tự hào, vừa là trách nhiệm của hãng để luôn đáp ứng kỳ vọng của người dùng. Tại thị trường Việt Nam, OPPO mới vào cuộc chưa lâu nhưng đã chiếm số thị phần rất ấn tượng. Cụ thể là từ 7% vào năm 2014, đến tháng 9/2016, con số này đã là 27.2%. Thậm chí, từ một kẻ ngáng đường, OPPO ngang nhiên chiếm vị trí của Nokia và trở thành thương hiệu smartphone thứ hai tại Việt Nam, chỉ xếp sau Samsung. Thành công của OPPO đến từ nhiều yếu tố. Đầu tiên phải kể đến là cách truyền thông rất khôn ngoan khi luôn gắn sản phẩm với gương mặt người nổi tiếng. Nhắc đến OPPO là nhớ ngay đến Sơn Tùng MTP, đến Noo Phước Thịnh, Hồ Ngọc Hà,… Chiếc di động OPPO xuất hiện dày đặc trên banner đường phố, trên truyền hình, hay thậm chí là đi vào lời hát. Nhiêu đó là đủ để công chúng có một cảm nhận dù chưa rõ ràng về tính cách chiếc điện thoại OPPO. Đó là một sản phẩm bóng bẩy, thời thượng, hào hoa, luôn luôn mới mẻ và gây chú ý.", false, "OPPO" },
                    { 4, "Nokia – thương hiệu điện thoại đến từ Phần Lan, là một trong những thương hiệu đi đầu lịch sử ngành công nghiệp sản xuất điện thoại di động. Từ những chiếc điện thoại không dây “cục gạch” đầu tiên, Nokia đã trở thành “ông vua” vào những năm 90 của thế kỉ 20 và đầu thế kỉ 21. Vào thời kỳ hoàng kim của mình, sản phẩm của Nokia chiếm lĩnh 41% thị trường điện thoại di động. Đó là điều mà không một hãng điện thoại di động nào khác cho đến thời điểm hiện tại, kể cả “gã khổng lồ” Samsung hay Apple có thể làm được. Tuy nhiên, với những bước đi không mấy “sáng suốt”, “ông vua” đã dần bị quên lãng và chính thức đánh rơi vị trí nhà sản xuất điện thoại số 1 thế giới vào tay hãng điện thoại Samsung của Hàn Quốc vào năm 2012. Sau một thời gian ngưng sản xuất, từ năm 2017, thương hiệu điện thoại “vang bóng một thời” đã quay trở lại với sự kết hợp của bộ ba công ty: Nokia Technologies, HMD và Foxconn. Lần này trở lại, Nokia mang khát vọng lấy lại ánh hào quang. Những sản phẩm đánh dấu sự trở lại của Nokia là điện thoại feature phone một thời làm nên tên tuổi của hãng và cả những chiếc smartphone tuyệt nhiên sẽ không làm người dùng thất vọng.'", false, "Nokia" },
                    { 5, "Vivo là hãng điện thoại đến từ Trung Quốc, với lợi thế về điện thoại có cấu hình mạnh mẽ và giá thảnh rẻ phù hợp với thị trường Việt Nam. Được thành lập năm 2009 tuy nhiên mãi tới 2011 Vivo mới cho ra mắt sản phẩm đầu tiên của mình, lý do là trong thời gian đó nhà sản xuất điện thoại giá rẻ này tập trung vào mảng màn hình độ phân giải và âm thanh chất lượng cho smartphone. Khi vào Việt Nam, Vivo khá thông minh khi lựa chọn chiến lược tiếp cận những khách hàng tầm trung trở xuống với chiến lược giá thấp cùng cấu hình tạm ổn, màn hình lớn. Với chiến lược này Vivo tạm thời đã có một chỗ đứng trong thị trường điện thoại smartphone giá rẻ đang rất nhiều đối thủ cạnh tranh.", false, "Vivo" },
                    { 6, "Thương hiệu Xiaomi ra đời từ năm 2010 với trụ sở đặt tại Bắc Kinh, Trung Quốc. Tính đến thời điểm hiện tại, thương hiệu đã hoạt động trên thị trường hơn 13 năm và đạt được nhiều kỷ lục trong ngành. “Ông lớn” Trung Quốc cũng là một trong năm nhà sản xuất smartphone lớn nhất thế giới. Các mẫu điện thoại của hãng xuất hiện ở tất cả các phân khúc, từ giá rẻ, tầm trung đến những flagship cao cấp. Khi thị trường công nghệ phát triển và thay đổi không ngừng mang đến cơ hội cho Xiaomi mở rộng danh mục sản phẩm của mình. Người dùng có thể dễ dàng tìm mua được các mẫu loa, sạc dự phòng, gia dụng,... của thương hiệu này với mức giá vô cùng hợp lý.", false, "Xiaomi" },
                    { 7, "Realme là một thương hiệu điện thoại giá rẻ dành cho phân khúc bình dân. Realme do OPPO hợp tác với Amazon tạo dựng nên với mục đích cạnh tranh trực tiếp với Xiaomi – một hãng điện thoại giá rẻ khác đến từ Trung Quốc. Nguồn gốc của hãng Realme là dòng sản phẩm OPPO Real. Realme chính thức tách khỏi OPPO vào ngày 4/5/2018 và do Sky Li lãnh đạo. Ban đầu, hãng chỉ có mặt tại Ấn Độ, một thị trường đông dân và khá sôi động. Sau đó, chiến lược kinh doanh của Realme thay đổi và được mở rộng đến nhiều thị trường khu vực Đông Á và Đông Nam Á hơn, trong đó có Việt Nam. Realme chính thức đặt chân đến Việt Nam vào tháng 10/2018 với sự góp mặt của bộ đôi Realme 2 và Realme 2 Pro (bao gồm nhiều phiên bản bộ nhớ) cùng chiếc Realme C1. Các sản phẩm của hãng được đánh giá khá tốt về thiết kế bên ngoài, các tính năng và đặc biệt là mức giá vô cùng hấp dẫn. Các chiến lược truyền thông của hãng di động Trung Quốc này cũng khá rõ ràng và hiệu quả, nhắm tới đối tượng người dùng phổ thông. Trong thời gian tới, Realme tiếp tục phát triển và sẽ tung ra nhiều sản phẩm đáng chú ý hơn nữa để đáp ứng nhu cầu của người dùng.", false, "Realme" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 10, "ĐỒ CHƠI CN" },
                    { 9, "ÂM THANH" },
                    { 8, "THẺ SIM" },
                    { 7, "PHỤ KIỆN" },
                    { 5, "SMART HOME" },
                    { 4, "SMART TV" },
                    { 3, "ĐỒNG HỒ" },
                    { 2, "LAPTOP" },
                    { 1, "ĐIỆN THOẠI" },
                    { 6, "TABLET" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Address", "CustomerNotes", "Date", "Name", "PhoneNumber", "Status", "StoreNotes", "UserId" },
                values: new object[,]
                {
                    { "af18e5bf-bc53-4339-8a56-dc514a9e0146", "số 1, đường số 2", null, new DateTime(2023, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nguyễn Văn A", "0909000021", "Chờ xác nhận", null, null },
                    { "06475280-a3ae-4740-b7b7-9a6aaf21a26f", "số 1, đường số 2", null, new DateTime(2023, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nguyễn Văn A", "0909000021", "Đã giao", null, null },
                    { "800910cf-7142-47c4-a610-8d0c7358536b", "số 1, đường số 2", null, new DateTime(2023, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nguyễn Văn A", "0909000021", "Đã xác nhận", null, null }
                });

            migrationBuilder.InsertData(
                table: "Slides",
                columns: new[] { "Id", "Img" },
                values: new object[,]
                {
                    { 5, "web-galaxy-z-fold4-z-flip4-03.jpg" },
                    { 1, "banner-xa-kho-laptop-01.png" },
                    { 2, "oppo-a77s-01_638192222109753594.jpg" },
                    { 3, "redmi-note-12-series-pc.png" },
                    { 4, "taba8-web-1.jpg" },
                    { 6, "yuho-tab-8-01.jpg" }
                });

            migrationBuilder.InsertData(
                table: "BrandCategories",
                columns: new[] { "Id", "BrandId", "CategoryId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 5, 1, 9 },
                    { 13, 3, 6 },
                    { 9, 2, 6 },
                    { 4, 1, 6 },
                    { 8, 2, 4 },
                    { 12, 3, 3 },
                    { 7, 2, 3 },
                    { 3, 1, 3 },
                    { 2, 1, 2 },
                    { 18, 7, 1 },
                    { 17, 6, 1 },
                    { 16, 5, 1 },
                    { 15, 4, 1 },
                    { 11, 3, 1 },
                    { 6, 2, 1 },
                    { 10, 2, 9 },
                    { 14, 3, 9 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandCategoryId", "Date", "Description", "ImportPrice", "IsRemove", "Name", "SellingPrice" },
                values: new object[,]
                {
                    { "f33eb677-8b68-4e4d-8894-6ad6106c7c23", 1, new DateTime(2023, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 100000L, false, "iPhone 14 Pro Max", 26290000L },
                    { "3d362e41-7a87-4ec6-b06a-9074e0ccaa16", 1, new DateTime(2023, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 100000L, false, "iPhone 14 Pro", 24690000L },
                    { "89cc7017-e279-4f5e-bc1b-ae1b307e1e40", 1, new DateTime(2023, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 100000L, false, "iPhone 14", 18990000L },
                    { "a82b1219-b32b-42c3-8de3-6f27be1bfafc", 6, new DateTime(2023, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 100000L, false, "Samsung Galaxy A33", 6350000L },
                    { "f62f9d9f-0348-42a2-8610-97edb2e1a5ec", 6, new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 100000L, false, "Samsung Galaxy A23", 5240000L },
                    { "6f69e283-ee77-44bb-b470-f168191285b4", 11, new DateTime(2023, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 100000L, false, "Oppo A17", 3990000L },
                    { "883c61ab-b736-4a8e-bd63-78afd449d450", 11, new DateTime(2023, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 100000L, false, "Oppo A16", 2790000L },
                    { "8dd43b05-6908-4e36-b312-1b25145302f4", 15, new DateTime(2023, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 100000L, false, "Nokia C20", 1480000L }
                });

            migrationBuilder.InsertData(
                table: "BatteryAndChargers",
                columns: new[] { "Id", "BatteryCapacity", "BatteryTechnology", "BatteryType", "MaximumChargingSupport", "ProductId" },
                values: new object[,]
                {
                    { 1, "4323 mAh", "Sạc không dây MagSafe,Sạc pin nhanh,Sạc không dây,Tiết kiệm pin", "Li-Ion", "20 W", "f33eb677-8b68-4e4d-8894-6ad6106c7c23" },
                    { 8, "iOS 16", null, "Li-Po", null, "8dd43b05-6908-4e36-b312-1b25145302f4" },
                    { 7, "5000 mAh", null, null, null, "883c61ab-b736-4a8e-bd63-78afd449d450" },
                    { 6, "5000 mAh", "Siêu tiết kiệm pin", "Li-Po", "10 W", "6f69e283-ee77-44bb-b470-f168191285b4" },
                    { 5, "5000 mAh", null, null, "25 W", "f62f9d9f-0348-42a2-8610-97edb2e1a5ec" },
                    { 3, null, null, "Lithium‑ion", "Sạc không dây MagSafe lên đến 15W,Sạc không dây Qi lên đến 7,5W", "89cc7017-e279-4f5e-bc1b-ae1b307e1e40" },
                    { 2, "3200 mAh", "Sạc không dây,Tiết kiệm pin,Sạc pin nhanh,Sạc không dây MagSafe", "Lithium‑ion", "Sạc không dây MagSafe lên đến 15W,Sạc không dây Qi lên đến 7,5W", "3d362e41-7a87-4ec6-b06a-9074e0ccaa16" },
                    { 4, "5000 mAh", "Sạc pin nhanh", "Li-Po", "25 W", "a82b1219-b32b-42c3-8de3-6f27be1bfafc" }
                });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "Img", "Name", "Price", "ProductId" },
                values: new object[,]
                {
                    { 4, "1111.webp", "Deep Purple", 300000L, "f33eb677-8b68-4e4d-8894-6ad6106c7c23" },
                    { 14, "anh-chup-man-hinh-2022-09-08-luc-01-58-38-removebg-preview.webp", "Midnight", 300000L, "89cc7017-e279-4f5e-bc1b-ae1b307e1e40" },
                    { 13, "anh-chup-man-hinh-2022-09-08-luc-01-59-18-removebg-preview.webp", "Starlight", 300000L, "89cc7017-e279-4f5e-bc1b-ae1b307e1e40" },
                    { 12, "2222.webp", "Purple", 300000L, "89cc7017-e279-4f5e-bc1b-ae1b307e1e40" },
                    { 11, "14-yellow.webp", "Yellow", 300000L, "89cc7017-e279-4f5e-bc1b-ae1b307e1e40" },
                    { 10, "anh-chup-man-hinh-2022-09-08-luc-01-57-13-removebg-preview.webp", "Blue", 300000L, "89cc7017-e279-4f5e-bc1b-ae1b307e1e40" },
                    { 9, "anh-chup-man-hinh-2022-09-08-luc-01-59-53-removebg-preview.webp", "Red", 0L, "89cc7017-e279-4f5e-bc1b-ae1b307e1e40" },
                    { 17, "image-removebg-preview-27.webp", "Đen", 0L, "f62f9d9f-0348-42a2-8610-97edb2e1a5ec" },
                    { 3, "222222.webp", "Gold", 300000L, "f33eb677-8b68-4e4d-8894-6ad6106c7c23" },
                    { 2, "33333.webp", "Silver", 300000L, "f33eb677-8b68-4e4d-8894-6ad6106c7c23" },
                    { 22, "oppo-a16-3g32g-3.webp", "Đen", 0L, "883c61ab-b736-4a8e-bd63-78afd449d450" },
                    { 20, "image-removebg-preview-26_638018739441185433.webp", "Đen", 0L, "6f69e283-ee77-44bb-b470-f168191285b4" },
                    { 23, "oppo-a16-3g32g-1.webp", "Bạc", 0L, "883c61ab-b736-4a8e-bd63-78afd449d450" },
                    { 18, "image-removebg-preview-2.webp", "Bạc", 0L, "f62f9d9f-0348-42a2-8610-97edb2e1a5ec" },
                    { 15, "a33-1.webp", "Đen", 0L, "a82b1219-b32b-42c3-8de3-6f27be1bfafc" },
                    { 8, "1111.webp", "Deep Purple", 300000L, "3d362e41-7a87-4ec6-b06a-9074e0ccaa16" },
                    { 7, "222222.webp", "Gold", 300000L, "3d362e41-7a87-4ec6-b06a-9074e0ccaa16" },
                    { 6, "33333.webp", "Silver", 300000L, "3d362e41-7a87-4ec6-b06a-9074e0ccaa16" },
                    { 5, "44444.webp", "Black", 0L, "3d362e41-7a87-4ec6-b06a-9074e0ccaa16" },
                    { 1, "44444.webp", "Black", 0L, "f33eb677-8b68-4e4d-8894-6ad6106c7c23" },
                    { 24, "image-removebg-preview-5.webp", "Vàng phù sa", 0L, "8dd43b05-6908-4e36-b312-1b25145302f4" },
                    { 25, "xanh.webp", "Xanh thiên thạch", 0L, "8dd43b05-6908-4e36-b312-1b25145302f4" },
                    { 16, "a33-2.webp", "Trắng", 0L, "a82b1219-b32b-42c3-8de3-6f27be1bfafc" },
                    { 19, "image-removebg-preview-28.webp", "Xanh", 0L, "f62f9d9f-0348-42a2-8610-97edb2e1a5ec" },
                    { 21, "image-removebg-preview-25_638018739643684615.webp", "Xanh", 0L, "6f69e283-ee77-44bb-b470-f168191285b4" }
                });

            migrationBuilder.InsertData(
                table: "FrontCameras",
                columns: new[] { "Id", "Feature", "ProductId", "Resolution" },
                values: new object[,]
                {
                    { 5, null, "f62f9d9f-0348-42a2-8610-97edb2e1a5ec", "8.0 MP" },
                    { 4, "Bộ lọc màu,Chụp đêm,Flash màn hình,Góc rộng (Wide),HDR,Live Photo,Làm đẹp,Nhận diện khuôn mặt,Quay video 4K,Quay video Full HD,Trôi nhanh thời gian (Time Lapse),Xóa phông", "a82b1219-b32b-42c3-8de3-6f27be1bfafc", "13 MP" },
                    { 1, "Xóa phông,Quay video 4K,Retina Flash,Quay video Full HD,Tự động lấy nét (AF),Smart HDR 4,Bộ lọc màu,Live Photo,Trôi nhanh thời gian (Time Lapse),Chụp đêm,Quay chậm (Slow Motion),Cinematic", "f33eb677-8b68-4e4d-8894-6ad6106c7c23", "12 MP" },
                    { 6, "Xóa phông,Nhãn dán (AR Stickers),Toàn cảnh (Panorama),Quay video HD,Làm đẹp,Quay video Full HD,HDR,Bộ lọc màu,Trôi nhanh thời gian (Time Lapse)", "6f69e283-ee77-44bb-b470-f168191285b4", "5 MP" },
                    { 7, null, "883c61ab-b736-4a8e-bd63-78afd449d450", "8 MP" },
                    { 2, "Tự động lấy nét với Focus Pixels,Thấu kính sáu phần tử,Retina Flash,Photogenic Engine,Deep Fusion,HDR thông minh,Chế độ chân dung với hiệu ứng bokeh nâng cao và Kiểm soát độ sâu,Portrait Lighting với sáu hiệu ứng (Tự nhiên, Studio, Đường viền, Sân khấu, Sân khấu Mono, High Key Mono),Animoji và Memoji,Chế độ ban đêm", "3d362e41-7a87-4ec6-b06a-9074e0ccaa16", "12 MP" },
                    { 8, "Quay video HD", "8dd43b05-6908-4e36-b312-1b25145302f4", "5 MP" },
                    { 3, "Quay video 4K tối đa 60 fps,Chế độ điện ảnh lên đến 4K HDR ở tốc độ 30 fps,Quay video HDR với Dolby Vision lên đến 4K ở tốc độ 60 fps,Hỗ trợ video chuyển động cho 1080p ở tốc độ 120 fps,Video tua nhanh thời gian với tính năng ổn định,Chế độ ban đêm Thời gian trôi đi,Video QuickTake,Ổn định video điện ảnh (4K, 1080p và 720p)", "89cc7017-e279-4f5e-bc1b-ae1b307e1e40", "12 MP" }
                });

            migrationBuilder.InsertData(
                table: "MemoryAndStorages",
                columns: new[] { "Id", "HardDrive", "HardDriveType", "Price", "ProductId", "Ram", "Rom" },
                values: new object[] { 13, null, null, 0L, "f62f9d9f-0348-42a2-8610-97edb2e1a5ec", "4GB", "128GB" });

            migrationBuilder.InsertData(
                table: "MemoryAndStorages",
                columns: new[] { "Id", "HardDrive", "HardDriveType", "Price", "ProductId", "Ram", "Rom" },
                values: new object[,]
                {
                    { 14, null, null, 0L, "6f69e283-ee77-44bb-b470-f168191285b4", "4GB", "64GB" },
                    { 15, null, null, 0L, "883c61ab-b736-4a8e-bd63-78afd449d450", "3GB", "32GB" },
                    { 16, null, null, 0L, "8dd43b05-6908-4e36-b312-1b25145302f4", "2GB", "32GB" },
                    { 3, null, null, 1000000L, "f33eb677-8b68-4e4d-8894-6ad6106c7c23", "6GB", "512GB" },
                    { 12, null, null, 0L, "a82b1219-b32b-42c3-8de3-6f27be1bfafc", "6GB", "128GB" },
                    { 1, null, null, 0L, "f33eb677-8b68-4e4d-8894-6ad6106c7c23", "6GB", "128GB" },
                    { 2, null, null, 200000L, "f33eb677-8b68-4e4d-8894-6ad6106c7c23", "6GB", "256GB" },
                    { 5, null, null, 0L, "3d362e41-7a87-4ec6-b06a-9074e0ccaa16", "6GB", "128GB" },
                    { 6, null, null, 200000L, "3d362e41-7a87-4ec6-b06a-9074e0ccaa16", "6GB", "256GB" },
                    { 7, null, null, 1000000L, "3d362e41-7a87-4ec6-b06a-9074e0ccaa16", "6GB", "512GB" },
                    { 8, null, null, 2000000L, "3d362e41-7a87-4ec6-b06a-9074e0ccaa16", "6GB", "1TB" },
                    { 4, null, null, 2000000L, "f33eb677-8b68-4e4d-8894-6ad6106c7c23", "6GB", "1TB" },
                    { 11, null, null, 1000000L, "89cc7017-e279-4f5e-bc1b-ae1b307e1e40", "6GB", "512GB" },
                    { 10, null, null, 200000L, "89cc7017-e279-4f5e-bc1b-ae1b307e1e40", "6GB", "256GB" },
                    { 9, null, null, 0L, "89cc7017-e279-4f5e-bc1b-ae1b307e1e40", "6GB", "128GB" }
                });

            migrationBuilder.InsertData(
                table: "OSAndCPUs",
                columns: new[] { "Id", "Cpu", "CpuSpeed", "Gpu", "OperatingSystem", "ProductId" },
                values: new object[,]
                {
                    { 7, "Helio G35, tối đa 2.3GHz", null, "IMG GE8320@680MHz", "ColorOS 11.1, nền tảng Android 11", "883c61ab-b736-4a8e-bd63-78afd449d450" },
                    { 2, "A16 Bionic", "3.46 GHz", "Apple GPU", "iOS 16", "3d362e41-7a87-4ec6-b06a-9074e0ccaa16" },
                    { 6, "MediaTek Helio G35 8 nhân", "2.3 GHz", "IMG PowerVR GE8320", "Android 12", "6f69e283-ee77-44bb-b470-f168191285b4" },
                    { 1, "Apple A16 Bionic 6 nhân", "3.46 GHz", "Apple GPU 5 nhân", "iOS 16", "f33eb677-8b68-4e4d-8894-6ad6106c7c23" },
                    { 5, "SnapDragon 695 5G", null, null, "Android 12", "f62f9d9f-0348-42a2-8610-97edb2e1a5ec" },
                    { 3, "A15 Bionic", null, null, "iOS 16", "89cc7017-e279-4f5e-bc1b-ae1b307e1e40" },
                    { 8, null, "4 nhân 1.6 GHz & 4 nhân 1.2 GHz", "Mali-G52 MC2", "Android 11 (Go Edition)", "8dd43b05-6908-4e36-b312-1b25145302f4" },
                    { 4, "Exynos 1280 8 nhân", "2 nhân 2.4 GHz & 6 nhân 2 GHz", null, "Android 12", "a82b1219-b32b-42c3-8de3-6f27be1bfafc" }
                });

            migrationBuilder.InsertData(
                table: "RearCameras",
                columns: new[] { "Id", "Feature", "Film", "FlashLight", "ProductId", "Resolution" },
                values: new object[,]
                {
                    { 2, "Nắp ống kính tinh thể sapphirePhotogenic Engine,Deep Fusion,HDR thông minh,Chế độ chân dung với hiệu ứng bokeh nâng cao và Kiểm soát độ sâu,Portrait Lighting với sáu hiệu ứng (Tự nhiên, Studio, Đường viền, Sân khấu, Sân khấu Mono, High Key Mono),Chế độ ban đêm,Chụp chân dung ở chế độ ban đêm được bật bởi LiDAR Scanner,Toàn cảnh (lên đến 63MP),Chụp ảnh phong cách", "Quay video 4K ở tốc độ 60 fps,Quay video HD 1080p ở tốc độ 60 fps,Quay video HD 720p ở tốc độ 30 fps,Chế độ điện ảnh lên đến 4K HDR ở tốc độ 30 fps,Chế độ hành động lên đến 2,8K ở tốc độ 60 fps,Quay video HDR với Dolby Vision lên đến 4K ở tốc độ 60 fps", "True Tone thích ứng", "3d362e41-7a87-4ec6-b06a-9074e0ccaa16", "48MP x 12MP x 12MP" },
                    { 5, "Chống rung OIS 2022,Chụp ảnh chân dung,Chụp Cận Cảnh", "FHD (1920 x 1080)@30fps", "Có", "f62f9d9f-0348-42a2-8610-97edb2e1a5ec", "50.0 MP x 5.0 MP x 2.0 MP x 2.0 MP" },
                    { 4, "Bộ lọc màu,Chuyên nghiệp (Pro),Chạm lấy nét,Chống rung quang học (OIS),Góc rộng (Wide),Góc siêu rộng (Ultrawide),HDR,Làm đẹp,Lấy nét theo pha (PDAF),Nhận diện khuôn mặt,Quay chậm (Slow Motion),Quay Siêu chậm (Super Slow Motion),Siêu cận (Macro),Toàn cảnh (Panorama),Trôi nhanh thời gian (Time Lapse),Tự động lấy nét (AF),Xóa phông,Zoom kỹ thuật số", "4K 2160p@30fps,FullHD 1080p@30fps,FullHD 1080p@60fps,HD 720p@30fps", "Night Mode", "a82b1219-b32b-42c3-8de3-6f27be1bfafc", "Chính 48 MP & Phụ 8 MP, 5 MP, 2 MP" },
                    { 1, "Ban đêm (Night Mode),Trôi nhanh thời gian (Time Lapse),Quay chậm (Slow Motion),Xóa phông,Zoom quang học,Toàn cảnh (Panorama),Chống rung quang học (OIS),Smart HDR 4,Live Photo,Bộ lọc màu,Cinematic,Dolby Vision HDR,Zoom kỹ thuật số,Siêu cận (Macro),Góc siêu rộng (Ultrawide),Chế độ hành động (Action Mode),Deep Fusion", "HD 720p@30fps,FullHD 1080p@60fps,FullHD 1080p@30fps,4K 2160p@24fps,4K 2160p@30fps,4K 2160p@60fps", "Có", "f33eb677-8b68-4e4d-8894-6ad6106c7c23", "Chính 48 MP & Phụ 12 MP, 12 MP" },
                    { 3, "Nắp ống kính tinh thể sapphire,Photogenic Engine,Deep Fusion,HDR thông minh 4,Chế độ chân dung với hiệu ứng bokeh nâng cao và Kiểm soát độ sâu,Portrait Lighting với sáu hiệu ứng (Tự nhiên, Studio, Đường viền, Sân khấu, Sân khấu Mono, High Key Mono),Chế độ ban đêm,Toàn cảnh (lên đến 63MP),Chụp ảnh phong cách,Chụp màu rộng cho ảnh và Ảnh trực tiếp,Hiệu chỉnh ống kính (Siêu rộng),Chỉnh sửa mắt đỏ nâng cao,Ổn định hình ảnh tự động,Chế độ chụp,Gắn thẻ địa lý cho ảnh", "Quay video 4K tối đa 60 fps,Quay video HD 1080p tối đa 60 fps,Quay video HD 720p tối đa 30 fps,Chế độ điện ảnh lên đến 4K HDR ở tốc độ 30 fps,Chế độ hành động lên đến 2,8K ở tốc độ 60 fps,Quay video HDR với Dolby Vision lên đến 4K ở tốc độ 60 fps,Hỗ trợ video chuyển động chậm cho 1080p tối đa 240 fps,Video tua nhanh thời gian với tính năng ổn định,Chế độ ban đêm,Time-lapse", "True Tone", "89cc7017-e279-4f5e-bc1b-ae1b307e1e40", "12MP x 12MP" },
                    { 8, "HDR", "HD 720p@30fps", null, "8dd43b05-6908-4e36-b312-1b25145302f4", "5 MP" },
                    { 7, null, null, null, "883c61ab-b736-4a8e-bd63-78afd449d450", "13 MP (chính) + 2 MP (mono) + 2 MP (marco)" },
                    { 6, "AI Camera,Ban đêm (Night Mode),Trôi nhanh thời gian (Time Lapse),Chụp bằng cử chỉ,Toàn cảnh (Panorama),HDR,Chuyên nghiệp (Pro),Bộ lọc màu,Nhãn dán (AR Stickers),Làm đẹp,Google Lens,Zoom kỹ thuật số", "HD 720p@30fps,FullHD 1080p@30fps", "Có", "6f69e283-ee77-44bb-b470-f168191285b4", "Chính 50 MP & Phụ 0.3 M" }
                });

            migrationBuilder.InsertData(
                table: "Screens",
                columns: new[] { "Id", "MaximumBrightness", "ProductId", "Resolution", "ScreenTechnology", "TouchScreen", "Widescreen" },
                values: new object[,]
                {
                    { 1, "2000 nits", "f33eb677-8b68-4e4d-8894-6ad6106c7c23", "2796 x 1290 Pixels", "OLED", "Kính cường lực Ceramic Shield", "6.7\"" },
                    { 4, "800 nits", "a82b1219-b32b-42c3-8de3-6f27be1bfafc", "Full HD+ (1080 x 2400 Pixels)", "Super AMOLED", null, "6.4\" - Tần số quét 90 Hz" },
                    { 6, "600 nits", "6f69e283-ee77-44bb-b470-f168191285b4", "HD+ (720 x 1612 Pixels)", "PLS LCD", "Kính cường lực Panda", null },
                    { 2, "2000 nits", "3d362e41-7a87-4ec6-b06a-9074e0ccaa16", "Super Retina XDR (2556 x 1179-pixel)", "OLED", "Ceramic Shield", "6.1‑inch" },
                    { 5, null, "f62f9d9f-0348-42a2-8610-97edb2e1a5ec", "1080 x 2408 pixels", "PLS LCD", "Kính cường lực Corning Gorilla Glass 5", "6.6\" - tần số quét 120Hz" },
                    { 3, "1200 nits", "89cc7017-e279-4f5e-bc1b-ae1b307e1e40", "2532 x 1170", "Super Retina XDR", "Ceramic Shield", "OLED 6.1‑inch" },
                    { 7, null, "883c61ab-b736-4a8e-bd63-78afd449d450", "720 x 1600 (HD+)", "LCD", "Kính cường lực Panda", "6.52 inch, màn hình giọt nước" },
                    { 8, null, "8dd43b05-6908-4e36-b312-1b25145302f4", "HD+ (720 x 1600 Pixels)", "IPS LCD", null, null }
                });

            migrationBuilder.InsertData(
                table: "Details",
                columns: new[] { "Id", "ColorId", "MemoryAndStorageId", "OrderId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 1, "af18e5bf-bc53-4339-8a56-dc514a9e0146", "f33eb677-8b68-4e4d-8894-6ad6106c7c23", 1 },
                    { 2, 5, 5, "af18e5bf-bc53-4339-8a56-dc514a9e0146", "3d362e41-7a87-4ec6-b06a-9074e0ccaa16", 2 },
                    { 3, 5, 5, "af18e5bf-bc53-4339-8a56-dc514a9e0146", "3d362e41-7a87-4ec6-b06a-9074e0ccaa16", 1 },
                    { 4, 9, 9, "af18e5bf-bc53-4339-8a56-dc514a9e0146", "89cc7017-e279-4f5e-bc1b-ae1b307e1e40", 1 }
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
                name: "IX_BatteryAndChargers_ProductId",
                table: "BatteryAndChargers",
                column: "ProductId",
                unique: true,
                filter: "[ProductId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BrandCategories_BrandId",
                table: "BrandCategories",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_BrandCategories_CategoryId",
                table: "BrandCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Colors_ProductId",
                table: "Colors",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Details_ColorId",
                table: "Details",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Details_MemoryAndStorageId",
                table: "Details",
                column: "MemoryAndStorageId");

            migrationBuilder.CreateIndex(
                name: "IX_Details_OrderId",
                table: "Details",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Details_ProductId",
                table: "Details",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_FrontCameras_ProductId",
                table: "FrontCameras",
                column: "ProductId",
                unique: true,
                filter: "[ProductId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MemoryAndStorages_ProductId",
                table: "MemoryAndStorages",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OSAndCPUs_ProductId",
                table: "OSAndCPUs",
                column: "ProductId",
                unique: true,
                filter: "[ProductId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandCategoryId",
                table: "Products",
                column: "BrandCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_RearCameras_ProductId",
                table: "RearCameras",
                column: "ProductId",
                unique: true,
                filter: "[ProductId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Screens_ProductId",
                table: "Screens",
                column: "ProductId",
                unique: true,
                filter: "[ProductId] IS NOT NULL");
        }

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
                name: "BatteryAndChargers");

            migrationBuilder.DropTable(
                name: "Details");

            migrationBuilder.DropTable(
                name: "FrontCameras");

            migrationBuilder.DropTable(
                name: "OSAndCPUs");

            migrationBuilder.DropTable(
                name: "RearCameras");

            migrationBuilder.DropTable(
                name: "Screens");

            migrationBuilder.DropTable(
                name: "Slides");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "MemoryAndStorages");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "BrandCategories");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
