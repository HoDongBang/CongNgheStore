using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;

namespace CongNgheStore.Models.DbContext_Folder
{
    public class CongNgheStoreDBContext : IdentityDbContext<User, Role, int>
    {

        public CongNgheStoreDBContext(DbContextOptions options) : base(options)
        {

        }

        #region DbSet
        public DbSet<Slide> Slides { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<BrandCategory> BrandCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<MemoryAndStorage> MemoryAndStorages { get; set; }
        public DbSet<Screen> Screens { get; set; }
        public DbSet<RearCamera> RearCameras { get; set; }
        public DbSet<FrontCamera> FrontCameras { get; set; }
        public DbSet<OSAndCPU> OSAndCPUs { get; set; }
        public DbSet<BatteryAndCharger> BatteryAndChargers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Detail> Details { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            #region Fluent API 
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Id).IsRequired()
                    .HasColumnType("int")
                    .ValueGeneratedOnAdd()
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                entity.Property(e => e.Name).IsRequired()
                    .HasColumnType("nvarchar(50)");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).IsRequired()
                    .HasColumnType("int")
                    .ValueGeneratedOnAdd()
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                entity.Property(e => e.PhoneNumber).IsRequired()
                    .HasColumnType("varchar(12)");

                entity.Property(e => e.FirstName).IsRequired()
                    .HasColumnType("nvarchar(50)");

                entity.Property(e => e.LastName).IsRequired()
                    .HasColumnType("nvarchar(50)");

                entity.Property(e => e.PasswordHash).IsRequired()
                    .HasColumnType("varchar(200)");
            });

            modelBuilder.Entity<Slide>(entity =>
            {
                entity.Property(e => e.Id).IsRequired()
                    .HasColumnType("int")
                    .ValueGeneratedOnAdd()
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                entity.Property(e => e.Img).IsRequired()
                    .HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Id).IsRequired()
                    .HasColumnType("int")
                    .ValueGeneratedOnAdd()
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                entity.Property(e => e.Name).IsRequired()
                    .HasColumnType("nvarchar(50)");

                entity.Property(e => e.UrlHandle).IsRequired()
                    .HasColumnType("nvarchar(50)");
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.Property(e => e.Id).IsRequired()
                     .HasColumnType("int")
                     .ValueGeneratedOnAdd()
                     .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                entity.Property(e => e.Name).IsRequired()
                    .HasColumnType("nvarchar(50)");

                entity.Property(e => e.Description).IsRequired()
                    .HasColumnType("nvarchar(1500)");

                entity.Property(e => e.IsRemove).IsRequired();

                entity.Property(e => e.UrlHandle).IsRequired()
                    .HasColumnType("nvarchar(50)");
            });

            modelBuilder.Entity<BrandCategory>(entity =>
            {
                entity.Property(e => e.Id).IsRequired()
                     .HasColumnType("int")
                     .ValueGeneratedOnAdd()
                     .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                entity.HasOne(e => e.Brand)
                    .WithMany(e => e.BrandCategories)
                    .HasForeignKey(e => e.BrandId)
                    .HasConstraintName("FK_BrandCategory_Brand");

                entity.HasOne(e => e.Category)
                    .WithMany(e => e.BrandCategories)
                    .HasForeignKey(e => e.CategoryId)
                    .HasConstraintName("FK_BrandCategory_Category");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Id).IsRequired()
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Name).IsRequired()
                    .HasColumnType("nvarchar(50)");

                entity.Property(e => e.ImportPrice).IsRequired()
                    .HasColumnType("bigint");

                entity.Property(e => e.SellingPrice).IsRequired()
                    .HasColumnType("bigint");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Description).HasColumnType("nvarchar(1500)");

                entity.Property(e => e.IsRemove).IsRequired();

                entity.HasOne(e => e.BrandCategory)
                    .WithMany(e => e.Products)
                    .HasForeignKey(e => e.BrandCategoryId)
                    .HasConstraintName("FK_Products_BrandCategory");
            });

            modelBuilder.Entity<Color>(entity =>
            {
                entity.Property(e => e.Id).IsRequired()
                     .HasColumnType("int")
                     .ValueGeneratedOnAdd()
                     .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                entity.Property(e => e.Name).IsRequired()
                    .HasColumnType("nvarchar(50)");

                entity.Property(e => e.Img).IsRequired()
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Price).IsRequired()
                    .HasColumnType("bigint");

                entity.HasOne(e => e.Product)
                    .WithMany(e => e.Colors)
                    .HasForeignKey(e => e.ProductId)
                    .HasConstraintName("FK_Colors_Product");
            });

            modelBuilder.Entity<MemoryAndStorage>(entity =>
            {
                entity.Property(e => e.Id).IsRequired()
                     .HasColumnType("int")
                     .ValueGeneratedOnAdd()
                     .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                entity.Property(e => e.Ram).IsRequired()
                    .HasColumnType("nvarchar(50)");

                entity.Property(e => e.Rom).HasColumnType("nvarchar(50)");

                entity.Property(e => e.HardDrive).HasColumnType("nvarchar(50)");

                entity.Property(e => e.HardDriveType).HasColumnType("nvarchar(50)");

                entity.Property(e => e.Price).IsRequired()
                    .HasColumnType("bigint");

                entity.HasOne(e => e.Product)
                    .WithMany(e => e.MemoryAndStorages)
                    .HasForeignKey(e => e.ProductId)
                    .HasConstraintName("FK_MemoryAndStorages_Product");
            });

            modelBuilder.Entity<Screen>(entity =>
            {
                entity.Property(e => e.Id).IsRequired()
                     .HasColumnType("int")
                     .ValueGeneratedOnAdd()
                     .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                entity.Property(e => e.ScreenTechnology).HasColumnType("nvarchar(50)");

                entity.Property(e => e.Resolution).HasColumnType("nvarchar(50)");

                entity.Property(e => e.Widescreen).HasColumnType("nvarchar(50)");

                entity.Property(e => e.MaximumBrightness).HasColumnType("nvarchar(50)");

                entity.Property(e => e.TouchScreen).HasColumnType("nvarchar(100)");

                entity.HasOne(e => e.Product)
                    .WithOne(e => e.Screen)
                    .HasForeignKey<Screen>(e => e.ProductId)
                    .HasConstraintName("FK_Screen_Product");
            });

            modelBuilder.Entity<RearCamera>(entity =>
            {
                entity.Property(e => e.Id).IsRequired()
                     .HasColumnType("int")
                     .ValueGeneratedOnAdd()
                     .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                entity.Property(e => e.Resolution).HasColumnType("nvarchar(50)");

                entity.Property(e => e.Film).HasColumnType("nvarchar(500)");

                entity.Property(e => e.FlashLight).HasColumnType("nvarchar(50)");

                entity.Property(e => e.Feature).HasColumnType("nvarchar(1000)");

                entity.HasOne(e => e.Product)
                    .WithOne(e => e.RearCamera)
                    .HasForeignKey<RearCamera>(e => e.ProductId)
                    .HasConstraintName("FK_RearCamera_Product");
            });

            modelBuilder.Entity<FrontCamera>(entity =>
            {
                entity.Property(e => e.Id).IsRequired()
                     .HasColumnType("int")
                     .ValueGeneratedOnAdd()
                     .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                entity.Property(e => e.Resolution).HasColumnType("nvarchar(50)");

                entity.Property(e => e.Feature).HasColumnType("nvarchar(1000)");

                entity.HasOne(e => e.Product)
                    .WithOne(e => e.FrontCamera)
                    .HasForeignKey<FrontCamera>(e => e.ProductId)
                    .HasConstraintName("FK_FrontCamera_Product");

            });

            modelBuilder.Entity<OSAndCPU>(entity =>
            {
                entity.Property(e => e.Id).IsRequired()
                     .HasColumnType("int")
                     .ValueGeneratedOnAdd()
                     .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                entity.Property(e => e.OperatingSystem).HasColumnType("nvarchar(50)");

                entity.Property(e => e.Cpu).HasColumnType("nvarchar(50)");

                entity.Property(e => e.CpuSpeed).HasColumnType("nvarchar(50)");

                entity.Property(e => e.Gpu).HasColumnType("nvarchar(50)");

                entity.HasOne(e => e.Product)
                    .WithOne(e => e.OSAndCPU)
                    .HasForeignKey<OSAndCPU>(e => e.ProductId)
                    .HasConstraintName("FK_OSAndCPU_Product");

            });

            modelBuilder.Entity<BatteryAndCharger>(entity =>
            {
                entity.Property(e => e.Id).IsRequired()
                     .HasColumnType("int")
                     .ValueGeneratedOnAdd()
                     .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                entity.Property(e => e.BatteryCapacity).HasColumnType("nvarchar(50)");

                entity.Property(e => e.BatteryType).HasColumnType("nvarchar(50)");

                entity.Property(e => e.MaximumChargingSupport).HasColumnType("nvarchar(500)");

                entity.Property(e => e.BatteryTechnology).HasColumnType("nvarchar(500)");

                entity.HasOne(e => e.Product)
                    .WithOne(e => e.BatteryAndCharger)
                    .HasForeignKey<BatteryAndCharger>(e => e.ProductId)
                    .HasConstraintName("FK_BatteryAndCharger_Product");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Id).IsRequired()
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.PhoneNumber).IsRequired()
                    .HasColumnType("varchar(12)");

                entity.Property(e => e.Name).IsRequired()
                    .HasColumnType("nvarchar(50)");

                entity.Property(e => e.Address).IsRequired()
                    .HasColumnType("nvarchar(200)");

                entity.Property(e => e.CustomerNotes).HasColumnType("nvarchar(500)");

                entity.Property(e => e.StoreNotes).HasColumnType("nvarchar(500)");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Status).IsRequired()
                    .HasColumnType("nvarchar(50)");

                entity.HasOne(e => e.User)
                    .WithMany(e => e.Orders)
                    .HasForeignKey(e => e.UserId)
                    .HasConstraintName("FK_Orders_User");
            });

            modelBuilder.Entity<Detail>(entity =>
            {
                entity.Property(e => e.Id).IsRequired()
                     .HasColumnType("int")
                     .ValueGeneratedOnAdd()
                     .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                entity.Property(e => e.Quantity).IsRequired()
                    .HasColumnType("int");

                entity.HasOne(e => e.Color)
                    .WithMany(e => e.Details)
                    .HasForeignKey(e => e.ColorId)
                    .HasConstraintName("FK_Details_Color");

                entity.HasOne(e => e.MemoryAndStorage)
                    .WithMany(e => e.Details)
                    .HasForeignKey(e => e.MemoryAndStorageId)
                    .HasConstraintName("FK_Details_MemoryAndStorage");

                entity.HasOne(e => e.MemoryAndStorage)
                    .WithMany(e => e.Details)
                    .HasForeignKey(e => e.MemoryAndStorageId)
                    .HasConstraintName("FK_Details_MemoryAndStorage");

                entity.HasOne(e => e.Product)
                    .WithMany(e => e.Details)
                    .HasForeignKey(e => e.ProductId)
                    .HasConstraintName("FK_Details_Product");

                entity.HasOne(e => e.Order)
                    .WithMany(e => e.Details)
                    .HasForeignKey(e => e.OrderId)
                    .HasConstraintName("FK_Details_Order");
            });

            #endregion           
            this.SeedData(modelBuilder);
        }
        protected void SeedData(ModelBuilder modelBuilder)
        {
            #region HasData
            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = 1,
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new Role
                {
                    Id = 2,
                    Name = "User",
                    NormalizedName = "USER"
                }
            );
            /*
            var hasher = new PasswordHasher<User>();
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    UserName = "0900100200",

                    //userManager.FindByNameAsync tìm theo thằng Normalized này, email cũng vậy
                    NormalizedUserName = "0900100200",
                    PhoneNumber = "0900100200",
                    PhoneNumberConfirmed = true,
                    FirstName = "Ho Minh",
                    LastName = "Thien",

                    //hasd này k đúng với cách hasd của userManager.CreateAsync
                    PasswordHash = hasher.HashPassword(null, "admin@123")
                },
                new User
                {
                    Id = 2,
                    UserName = "0900300400",
                    NormalizedUserName = "0900300400",
                    PhoneNumber = "0900300400",
                    PhoneNumberConfirmed = true,
                    FirstName = "Ho Minh",
                    LastName = "Thien",
                    PasswordHash = hasher.HashPassword(null, "user@123")
                }
            );
            */
            modelBuilder.Entity<Slide>().HasData(
                new Slide
                {
                    Id = 1,
                    Img = "banner-xa-kho-laptop-01.png"
                },
                new Slide
                {
                    Id = 2,
                    Img = "oppo-a77s-01_638192222109753594.jpg"
                },
                new Slide
                {
                    Id = 3,
                    Img = "redmi-note-12-series-pc.png"
                },
                new Slide
                {
                    Id = 4,
                    Img = "taba8-web-1.jpg"
                },
                new Slide
                {
                    Id = 5,
                    Img = "web-galaxy-z-fold4-z-flip4-03.jpg"
                },
                new Slide
                {
                    Id = 6,
                    Img = "yuho-tab-8-01.jpg"
                }
            );

            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "ĐIỆN THOẠI",
                    UrlHandle = "dien-thoai"
                },
                new Category
                {
                    Id = 2,
                    Name = "LAPTOP",
                    UrlHandle = "laptop"
                },
                new Category
                {
                    Id = 3,
                    Name = "ĐỒNG HỒ",
                    UrlHandle = "dong-ho"
                },
                new Category
                {
                    Id = 4,
                    Name = "SMART TV",
                    UrlHandle = "smart-tv"
                },
                new Category
                {
                    Id = 5,
                    Name = "SMART HOME",
                    UrlHandle = "smart-home"
                },
                new Category
                {
                    Id = 6,
                    Name = "TABLET",
                    UrlHandle = "tablet"
                },
                new Category
                {
                    Id = 7,
                    Name = "PHỤ KIỆN",
                    UrlHandle = "phu-kien"
                },
                new Category
                {
                    Id = 8,
                    Name = "THẺ SIM",
                    UrlHandle = "the-sim"
                },
                new Category
                {
                    Id = 9,
                    Name = "ÂM THANH",
                    UrlHandle = "am-thanh"
                },
                new Category
                {
                    Id = 10,
                    Name = "ĐỒ CHƠI CN",
                    UrlHandle = "do-choi-cn"
                }
            );

            modelBuilder.Entity<Brand>().HasData(
                new Brand
                {
                    Id = 1,
                    Name = "Apple",
                    Description = "Thương hiệu Apple được thành lập từ những năm 1976 tại Hoa Kỳ, cũng là nơi đặt trụ sở chính của công ty đến thời điểm hiện tại. Trải qua nhiều năm, với sự phát triển và thay đổi để hoàn thiện, người dùng trên toàn thế giới bắt đầu biết đến và nhớ tới thương hiệu qua logo quả táo khuyết. Không chỉ thế, người dùng còn nhớ đến Apple bởi slogan “Think different” và những sáng tạo không ngừng trên những sản phẩm đã ra mắt. Năm 2007, chiếc iPhone đầu tiên ra đời đánh dấu bước tiến lớn trong ngành công nghiệp smartphone. Cũng kể từ đó, iPhone luôn được nhớ đến với những thiết kế thời thượng, tính năng khác biệt, dẫn đầu xu hướng và vượt lên trên tất cả các nhà sản xuất khác trong ngành.",
                    IsRemove = false,
                    UrlHandle = "apple"
                },
                new Brand
                {
                    Id = 2,
                    Name = "Samsung",
                    Description = "Samsung là tập đoàn đa quốc gia thành lập từ năm 1938 và có trụ sở tại Seoul, Hàn Quốc. Ra đời và hoạt động từ quốc gia có ngành công nghiệp hiện đại, phát triển, Samsung nhanh chóng đạt được các cột mốc ấn tượng. Không chỉ dừng lại ở một dòng sản phẩm, Samsung không ngừng sáng tạo, thử nghiệm công nghệ mới, liên tục giới thiệu rất nhiều thiết bị điện tử hữu ích cho cuộc sống hàng ngày. Nhưng trong đó, các mẫu smartphone vẫn là dòng sản phẩm chủ lực, được công ty đầu tư phát triển, đổi mới không ngừng. Tại Việt Nam, một số mẫu điện thoại Samsung phổ biến như Galaxy A, Galaxy S, Galaxy Z,...",
                    IsRemove = false,
                    UrlHandle = "samsung"
                },
                new Brand
                {
                    Id = 3,
                    Name = "OPPO",
                    Description = "OPPO là một thương hiệu smartphone đến từ Trung Quốc. Tại quê nhà, OPPO đối đầu trực tiếp với Huawei và xuất sắc vượt lên với 16.8% thị phần. Trở thành thương hiệu di động bán chạy nhất Trung Quốc, đó vừa là niềm tự hào, vừa là trách nhiệm của hãng để luôn đáp ứng kỳ vọng của người dùng. Tại thị trường Việt Nam, OPPO mới vào cuộc chưa lâu nhưng đã chiếm số thị phần rất ấn tượng. Cụ thể là từ 7% vào năm 2014, đến tháng 9/2016, con số này đã là 27.2%. Thậm chí, từ một kẻ ngáng đường, OPPO ngang nhiên chiếm vị trí của Nokia và trở thành thương hiệu smartphone thứ hai tại Việt Nam, chỉ xếp sau Samsung. Thành công của OPPO đến từ nhiều yếu tố. Đầu tiên phải kể đến là cách truyền thông rất khôn ngoan khi luôn gắn sản phẩm với gương mặt người nổi tiếng. Nhắc đến OPPO là nhớ ngay đến Sơn Tùng MTP, đến Noo Phước Thịnh, Hồ Ngọc Hà,… Chiếc di động OPPO xuất hiện dày đặc trên banner đường phố, trên truyền hình, hay thậm chí là đi vào lời hát. Nhiêu đó là đủ để công chúng có một cảm nhận dù chưa rõ ràng về tính cách chiếc điện thoại OPPO. Đó là một sản phẩm bóng bẩy, thời thượng, hào hoa, luôn luôn mới mẻ và gây chú ý.",
                    IsRemove = false,
                    UrlHandle = "oppo"
                },
                new Brand
                {
                    Id = 4,
                    Name = "Nokia",
                    Description = "Nokia – thương hiệu điện thoại đến từ Phần Lan, là một trong những thương hiệu đi đầu lịch sử ngành công nghiệp sản xuất điện thoại di động. Từ những chiếc điện thoại không dây “cục gạch” đầu tiên, Nokia đã trở thành “ông vua” vào những năm 90 của thế kỉ 20 và đầu thế kỉ 21. Vào thời kỳ hoàng kim của mình, sản phẩm của Nokia chiếm lĩnh 41% thị trường điện thoại di động. Đó là điều mà không một hãng điện thoại di động nào khác cho đến thời điểm hiện tại, kể cả “gã khổng lồ” Samsung hay Apple có thể làm được. Tuy nhiên, với những bước đi không mấy “sáng suốt”, “ông vua” đã dần bị quên lãng và chính thức đánh rơi vị trí nhà sản xuất điện thoại số 1 thế giới vào tay hãng điện thoại Samsung của Hàn Quốc vào năm 2012. Sau một thời gian ngưng sản xuất, từ năm 2017, thương hiệu điện thoại “vang bóng một thời” đã quay trở lại với sự kết hợp của bộ ba công ty: Nokia Technologies, HMD và Foxconn. Lần này trở lại, Nokia mang khát vọng lấy lại ánh hào quang. Những sản phẩm đánh dấu sự trở lại của Nokia là điện thoại feature phone một thời làm nên tên tuổi của hãng và cả những chiếc smartphone tuyệt nhiên sẽ không làm người dùng thất vọng.'",
                    IsRemove = false,
                    UrlHandle = "nokia"
                },
                new Brand
                {
                    Id = 5,
                    Name = "Vivo",
                    Description = "Vivo là hãng điện thoại đến từ Trung Quốc, với lợi thế về điện thoại có cấu hình mạnh mẽ và giá thảnh rẻ phù hợp với thị trường Việt Nam. Được thành lập năm 2009 tuy nhiên mãi tới 2011 Vivo mới cho ra mắt sản phẩm đầu tiên của mình, lý do là trong thời gian đó nhà sản xuất điện thoại giá rẻ này tập trung vào mảng màn hình độ phân giải và âm thanh chất lượng cho smartphone. Khi vào Việt Nam, Vivo khá thông minh khi lựa chọn chiến lược tiếp cận những khách hàng tầm trung trở xuống với chiến lược giá thấp cùng cấu hình tạm ổn, màn hình lớn. Với chiến lược này Vivo tạm thời đã có một chỗ đứng trong thị trường điện thoại smartphone giá rẻ đang rất nhiều đối thủ cạnh tranh.",
                    IsRemove = false,
                    UrlHandle = "vivo"
                },
                new Brand
                {
                    Id = 6,
                    Name = "Xiaomi",
                    Description = "Thương hiệu Xiaomi ra đời từ năm 2010 với trụ sở đặt tại Bắc Kinh, Trung Quốc. Tính đến thời điểm hiện tại, thương hiệu đã hoạt động trên thị trường hơn 13 năm và đạt được nhiều kỷ lục trong ngành. “Ông lớn” Trung Quốc cũng là một trong năm nhà sản xuất smartphone lớn nhất thế giới. Các mẫu điện thoại của hãng xuất hiện ở tất cả các phân khúc, từ giá rẻ, tầm trung đến những flagship cao cấp. Khi thị trường công nghệ phát triển và thay đổi không ngừng mang đến cơ hội cho Xiaomi mở rộng danh mục sản phẩm của mình. Người dùng có thể dễ dàng tìm mua được các mẫu loa, sạc dự phòng, gia dụng,... của thương hiệu này với mức giá vô cùng hợp lý.",
                    IsRemove = false,
                    UrlHandle = "xiaomi"
                },
                new Brand
                {
                    Id = 7,
                    Name = "Realme",
                    Description = "Realme là một thương hiệu điện thoại giá rẻ dành cho phân khúc bình dân. Realme do OPPO hợp tác với Amazon tạo dựng nên với mục đích cạnh tranh trực tiếp với Xiaomi – một hãng điện thoại giá rẻ khác đến từ Trung Quốc. Nguồn gốc của hãng Realme là dòng sản phẩm OPPO Real. Realme chính thức tách khỏi OPPO vào ngày 4/5/2018 và do Sky Li lãnh đạo. Ban đầu, hãng chỉ có mặt tại Ấn Độ, một thị trường đông dân và khá sôi động. Sau đó, chiến lược kinh doanh của Realme thay đổi và được mở rộng đến nhiều thị trường khu vực Đông Á và Đông Nam Á hơn, trong đó có Việt Nam. Realme chính thức đặt chân đến Việt Nam vào tháng 10/2018 với sự góp mặt của bộ đôi Realme 2 và Realme 2 Pro (bao gồm nhiều phiên bản bộ nhớ) cùng chiếc Realme C1. Các sản phẩm của hãng được đánh giá khá tốt về thiết kế bên ngoài, các tính năng và đặc biệt là mức giá vô cùng hấp dẫn. Các chiến lược truyền thông của hãng di động Trung Quốc này cũng khá rõ ràng và hiệu quả, nhắm tới đối tượng người dùng phổ thông. Trong thời gian tới, Realme tiếp tục phát triển và sẽ tung ra nhiều sản phẩm đáng chú ý hơn nữa để đáp ứng nhu cầu của người dùng.",
                    IsRemove = false,
                    UrlHandle = "realme"
                }
            );
            modelBuilder.Entity<BrandCategory>().HasData(
                //apple
                new BrandCategory
                {
                    Id = 1,
                    BrandId = 1,
                    CategoryId = 1
                },
                new BrandCategory
                {
                    Id = 2,
                    BrandId = 1,
                    CategoryId = 2
                },
                new BrandCategory
                {
                    Id = 3,
                    BrandId = 1,
                    CategoryId = 3
                },
                new BrandCategory
                {
                    Id = 4,
                    BrandId = 1,
                    CategoryId = 6
                },
                new BrandCategory
                {
                    Id = 5,
                    BrandId = 1,
                    CategoryId = 9
                },

                //samsung
                new BrandCategory
                {
                    Id = 6,
                    BrandId = 2,
                    CategoryId = 1
                },
                new BrandCategory
                {
                    Id = 7,
                    BrandId = 2,
                    CategoryId = 3
                },
                new BrandCategory
                {
                    Id = 8,
                    BrandId = 2,
                    CategoryId = 4
                },
                new BrandCategory
                {
                    Id = 9,
                    BrandId = 2,
                    CategoryId = 6
                },
                new BrandCategory
                {
                    Id = 10,
                    BrandId = 2,
                    CategoryId = 9
                },

                //oppo
                new BrandCategory
                {
                    Id = 11,
                    BrandId = 3,
                    CategoryId = 1
                },
                new BrandCategory
                {
                    Id = 12,
                    BrandId = 3,
                    CategoryId = 3
                },
                new BrandCategory
                {
                    Id = 13,
                    BrandId = 3,
                    CategoryId = 6
                },
                new BrandCategory
                {
                    Id = 14,
                    BrandId = 3,
                    CategoryId = 9
                },

                //nokia
                new BrandCategory
                {
                    Id = 15,
                    BrandId = 4,
                    CategoryId = 1
                },
                //vivo 
                new BrandCategory
                {
                    Id = 16,
                    BrandId = 5,
                    CategoryId = 1
                },
                //Xiaomi 
                new BrandCategory
                {
                    Id = 17,
                    BrandId = 6,
                    CategoryId = 1
                },
                //Realme 
                new BrandCategory
                {
                    Id = 18,
                    BrandId = 7,
                    CategoryId = 1
                }
            );

            var productIds = new List<Guid>
            {
                Guid.NewGuid(),
                Guid.NewGuid(),
                Guid.NewGuid(),
                Guid.NewGuid(),
                Guid.NewGuid(),
                Guid.NewGuid(),
                Guid.NewGuid(),
                Guid.NewGuid()
            };

            modelBuilder.Entity<Product>().HasData(
                //iphone
                new Product
                {
                    Id = productIds[0],
                    Name = "iPhone 14 Pro Max",
                    ImportPrice = 100000,
                    SellingPrice = 26290000,
                    Date = new DateTime(2023, 05, 20),
                    Description = null,
                    IsRemove = false,
                    BrandCategoryId = 1
                },
                new Product
                {
                    Id = productIds[1],
                    Name = "iPhone 14 Pro",
                    ImportPrice = 100000,
                    SellingPrice = 24690000,
                    Date = new DateTime(2023, 05, 19),
                    Description = null,
                    IsRemove = false,
                    BrandCategoryId = 1
                },
                new Product
                {
                    Id = productIds[2],
                    Name = "iPhone 14",
                    ImportPrice = 100000,
                    SellingPrice = 18990000,
                    Date = new DateTime(2023, 05, 18),
                    Description = null,
                    IsRemove = false,
                    BrandCategoryId = 1
                },

                //samsung
                new Product
                {
                    Id = productIds[3],
                    Name = "Samsung Galaxy A33",
                    ImportPrice = 100000,
                    SellingPrice = 6350000,
                    Date = new DateTime(2023, 05, 17),
                    Description = null,
                    IsRemove = false,
                    BrandCategoryId = 6
                },
                new Product
                {
                    Id = productIds[4],
                    Name = "Samsung Galaxy A23",
                    ImportPrice = 100000,
                    SellingPrice = 5240000,
                    Date = new DateTime(2023, 05, 16),
                    Description = null,
                    IsRemove = false,
                    BrandCategoryId = 6
                },

                //oppo
                new Product
                {
                    Id = productIds[5],
                    Name = "Oppo A17",
                    ImportPrice = 100000,
                    SellingPrice = 3990000,
                    Date = new DateTime(2023, 05, 15),
                    Description = null,
                    IsRemove = false,
                    BrandCategoryId = 11
                },
                new Product
                {
                    Id = productIds[6],
                    Name = "Oppo A16",
                    ImportPrice = 100000,
                    SellingPrice = 2790000,
                    Date = new DateTime(2023, 05, 14),
                    Description = null,
                    IsRemove = false,
                    BrandCategoryId = 11
                },

                //Nokia
                new Product
                {
                    Id = productIds[7],
                    Name = "Nokia C20",
                    ImportPrice = 100000,
                    SellingPrice = 1480000,
                    Date = new DateTime(2023, 05, 13),
                    Description = null,
                    IsRemove = false,
                    BrandCategoryId = 15
                }
            );

            modelBuilder.Entity<Color>().HasData(
                new Color
                {
                    Id = 1,
                    Name = "Black",
                    Img = "44444.webp",
                    Price = 0,
                    ProductId = productIds[0]
                },
                new Color
                {
                    Id = 2,
                    Name = "Silver",
                    Img = "33333.webp",
                    Price = 300000,
                    ProductId = productIds[0]
                },
                new Color
                {
                    Id = 3,
                    Name = "Gold",
                    Img = "222222.webp",
                    Price = 300000,
                    ProductId = productIds[0]
                },
                new Color
                {
                    Id = 4,
                    Name = "Deep Purple",
                    Img = "1111.webp",
                    Price = 300000,
                    ProductId = productIds[0]
                },

                new Color
                {
                    Id = 5,
                    Name = "Black",
                    Img = "44444.webp",
                    Price = 0,
                    ProductId = productIds[1]
                },
                new Color
                {
                    Id = 6,
                    Name = "Silver",
                    Img = "33333.webp",
                    Price = 300000,
                    ProductId = productIds[1]
                },
                new Color
                {
                    Id = 7,
                    Name = "Gold",
                    Img = "222222.webp",
                    Price = 300000,
                    ProductId = productIds[1]
                },
                new Color
                {
                    Id = 8,
                    Name = "Deep Purple",
                    Img = "1111.webp",
                    Price = 300000,
                    ProductId = productIds[1]
                },

                new Color
                {
                    Id = 9,
                    Name = "Red",
                    Img = "anh-chup-man-hinh-2022-09-08-luc-01-59-53-removebg-preview.webp",
                    Price = 0,
                    ProductId = productIds[2]
                },
                new Color
                {
                    Id = 10,
                    Name = "Blue",
                    Img = "anh-chup-man-hinh-2022-09-08-luc-01-57-13-removebg-preview.webp",
                    Price = 300000,
                    ProductId = productIds[2]
                },
                new Color
                {
                    Id = 11,
                    Name = "Yellow",
                    Img = "14-yellow.webp",
                    Price = 300000,
                    ProductId = productIds[2]
                },
                new Color
                {
                    Id = 12,
                    Name = "Purple",
                    Img = "2222.webp",
                    Price = 300000,
                    ProductId = productIds[2]
                },
                new Color
                {
                    Id = 13,
                    Name = "Starlight",
                    Img = "anh-chup-man-hinh-2022-09-08-luc-01-59-18-removebg-preview.webp",
                    Price = 300000,
                    ProductId = productIds[2]
                },
                new Color
                {
                    Id = 14,
                    Name = "Midnight",
                    Img = "anh-chup-man-hinh-2022-09-08-luc-01-58-38-removebg-preview.webp",
                    Price = 300000,
                    ProductId = productIds[2]
                },

                new Color
                {
                    Id = 15,
                    Name = "Đen",
                    Img = "a33-1.webp",
                    Price = 0,
                    ProductId = productIds[3]
                },
                new Color
                {
                    Id = 16,
                    Name = "Trắng",
                    Img = "a33-2.webp",
                    Price = 0,
                    ProductId = productIds[3]
                },

                new Color
                {
                    Id = 17,
                    Name = "Đen",
                    Img = "image-removebg-preview-27.webp",
                    Price = 0,
                    ProductId = productIds[4]
                },
                new Color
                {
                    Id = 18,
                    Name = "Bạc",
                    Img = "image-removebg-preview-2.webp",
                    Price = 0,
                    ProductId = productIds[4]
                },
                new Color
                {
                    Id = 19,
                    Name = "Xanh",
                    Img = "image-removebg-preview-28.webp",
                    Price = 0,
                    ProductId = productIds[4]
                },

                new Color
                {
                    Id = 20,
                    Name = "Đen",
                    Img = "image-removebg-preview-26_638018739441185433.webp",
                    Price = 0,
                    ProductId = productIds[5]
                },
                new Color
                {
                    Id = 21,
                    Name = "Xanh",
                    Img = "image-removebg-preview-25_638018739643684615.webp",
                    Price = 0,
                    ProductId = productIds[5]
                },

                new Color
                {
                    Id = 22,
                    Name = "Đen",
                    Img = "oppo-a16-3g32g-3.webp",
                    Price = 0,
                    ProductId = productIds[6]
                },
                new Color
                {
                    Id = 23,
                    Name = "Bạc",
                    Img = "oppo-a16-3g32g-1.webp",
                    Price = 0,
                    ProductId = productIds[6]
                },

                new Color
                {
                    Id = 24,
                    Name = "Vàng phù sa",
                    Img = "image-removebg-preview-5.webp",
                    Price = 0,
                    ProductId = productIds[7]
                },
                new Color
                {
                    Id = 25,
                    Name = "Xanh thiên thạch",
                    Img = "xanh.webp",
                    Price = 0,
                    ProductId = productIds[7]
                }
            );

            modelBuilder.Entity<MemoryAndStorage>().HasData(
                //iphone
                new MemoryAndStorage
                {
                    Id = 1,
                    Ram = "6GB",
                    Rom = "128GB",
                    HardDrive = null,
                    HardDriveType = null,
                    Price = 0,
                    ProductId = productIds[0]
                },
                new MemoryAndStorage
                {
                    Id = 2,
                    Ram = "6GB",
                    Rom = "256GB",
                    HardDrive = null,
                    HardDriveType = null,
                    Price = 200000,
                    ProductId = productIds[0]
                },
                new MemoryAndStorage
                {
                    Id = 3,
                    Ram = "6GB",
                    Rom = "512GB",
                    HardDrive = null,
                    HardDriveType = null,
                    Price = 1000000,
                    ProductId = productIds[0]
                },
                new MemoryAndStorage
                {
                    Id = 4,
                    Ram = "6GB",
                    Rom = "1TB",
                    HardDrive = null,
                    HardDriveType = null,
                    Price = 2000000,
                    ProductId = productIds[0]
                },

                new MemoryAndStorage
                {
                    Id = 5,
                    Ram = "6GB",
                    Rom = "128GB",
                    HardDrive = null,
                    HardDriveType = null,
                    Price = 0,
                    ProductId = productIds[1]
                },
                new MemoryAndStorage
                {
                    Id = 6,
                    Ram = "6GB",
                    Rom = "256GB",
                    HardDrive = null,
                    HardDriveType = null,
                    Price = 200000,
                    ProductId = productIds[1]
                },
                new MemoryAndStorage
                {
                    Id = 7,
                    Ram = "6GB",
                    Rom = "512GB",
                    HardDrive = null,
                    HardDriveType = null,
                    Price = 1000000,
                    ProductId = productIds[1]
                },
                new MemoryAndStorage
                {
                    Id = 8,
                    Ram = "6GB",
                    Rom = "1TB",
                    HardDrive = null,
                    HardDriveType = null,
                    Price = 2000000,
                    ProductId = productIds[1]
                },

                new MemoryAndStorage
                {
                    Id = 9,
                    Ram = "6GB",
                    Rom = "128GB",
                    HardDrive = null,
                    HardDriveType = null,
                    Price = 0,
                    ProductId = productIds[2]
                },
                new MemoryAndStorage
                {
                    Id = 10,
                    Ram = "6GB",
                    Rom = "256GB",
                    HardDrive = null,
                    HardDriveType = null,
                    Price = 200000,
                    ProductId = productIds[2]
                },
                new MemoryAndStorage
                {
                    Id = 11,
                    Ram = "6GB",
                    Rom = "512GB",
                    HardDrive = null,
                    HardDriveType = null,
                    Price = 1000000,
                    ProductId = productIds[2]
                },

                //samsung
                new MemoryAndStorage
                {
                    Id = 12,
                    Ram = "6GB",
                    Rom = "128GB",
                    HardDrive = null,
                    HardDriveType = null,
                    Price = 0,
                    ProductId = productIds[3]
                },
                new MemoryAndStorage
                {
                    Id = 13,
                    Ram = "4GB",
                    Rom = "128GB",
                    HardDrive = null,
                    HardDriveType = null,
                    Price = 0,
                    ProductId = productIds[4]
                },

                //oppo
                new MemoryAndStorage
                {
                    Id = 14,
                    Ram = "4GB",
                    Rom = "64GB",
                    HardDrive = null,
                    HardDriveType = null,
                    Price = 0,
                    ProductId = productIds[5]
                },
                new MemoryAndStorage
                {
                    Id = 15,
                    Ram = "3GB",
                    Rom = "32GB",
                    HardDrive = null,
                    HardDriveType = null,
                    Price = 0,
                    ProductId = productIds[6]
                },

                //Nokia
                new MemoryAndStorage
                {
                    Id = 16,
                    Ram = "2GB",
                    Rom = "32GB",
                    HardDrive = null,
                    HardDriveType = null,
                    Price = 0,
                    ProductId = productIds[7]
                }
            );

            modelBuilder.Entity<Screen>().HasData(
                //iphone
                new Screen
                {
                    Id = 1,
                    ScreenTechnology = "OLED",
                    Resolution = "2796 x 1290 Pixels",
                    Widescreen = "6.7\"",
                    MaximumBrightness = "2000 nits",
                    TouchScreen = "Kính cường lực Ceramic Shield",
                    ProductId = productIds[0]
                },
                new Screen
                {
                    Id = 2,
                    ScreenTechnology = "OLED",
                    Resolution = "Super Retina XDR (2556 x 1179-pixel)",
                    Widescreen = "6.1‑inch",
                    MaximumBrightness = "2000 nits",
                    TouchScreen = "Ceramic Shield",
                    ProductId = productIds[1]
                },
                new Screen
                {
                    Id = 3,
                    ScreenTechnology = "Super Retina XDR",
                    Resolution = "2532 x 1170",
                    Widescreen = "OLED 6.1‑inch",
                    MaximumBrightness = "1200 nits",
                    TouchScreen = "Ceramic Shield",
                    ProductId = productIds[2]
                },

                //samsung
                new Screen
                {
                    Id = 4,
                    ScreenTechnology = "Super AMOLED",
                    Resolution = "Full HD+ (1080 x 2400 Pixels)",
                    Widescreen = "6.4\" - Tần số quét 90 Hz",
                    MaximumBrightness = "800 nits",
                    TouchScreen = null,
                    ProductId = productIds[3]
                },
                new Screen
                {
                    Id = 5,
                    ScreenTechnology = "PLS LCD",
                    Resolution = "1080 x 2408 pixels",
                    Widescreen = "6.6\" - tần số quét 120Hz",
                    MaximumBrightness = null,
                    TouchScreen = "Kính cường lực Corning Gorilla Glass 5",
                    ProductId = productIds[4]
                },

                //oppo
                new Screen
                {
                    Id = 6,
                    ScreenTechnology = "PLS LCD",
                    Resolution = "HD+ (720 x 1612 Pixels)",
                    Widescreen = null,
                    MaximumBrightness = "600 nits",
                    TouchScreen = "Kính cường lực Panda",
                    ProductId = productIds[5]
                },
                new Screen
                {
                    Id = 7,
                    ScreenTechnology = "LCD",
                    Resolution = "720 x 1600 (HD+)",
                    Widescreen = "6.52 inch, màn hình giọt nước",
                    MaximumBrightness = null,
                    TouchScreen = "Kính cường lực Panda",
                    ProductId = productIds[6]
                },

                //Nokia
                new Screen
                {
                    Id = 8,
                    ScreenTechnology = "IPS LCD",
                    Resolution = "HD+ (720 x 1600 Pixels)",
                    Widescreen = null,
                    MaximumBrightness = null,
                    TouchScreen = null,
                    ProductId = productIds[7]
                }
            );

            modelBuilder.Entity<RearCamera>().HasData(
                //iphone
                new RearCamera
                {
                    Id = 1,
                    Resolution = "Chính 48 MP & Phụ 12 MP, 12 MP",
                    Film = "HD 720p@30fps,FullHD 1080p@60fps,FullHD 1080p@30fps,4K 2160p@24fps,4K 2160p@30fps,4K 2160p@60fps",
                    FlashLight = "Có",
                    Feature = "Ban đêm (Night Mode),Trôi nhanh thời gian (Time Lapse),Quay chậm (Slow Motion),Xóa phông,Zoom quang học,Toàn cảnh (Panorama),Chống rung quang học (OIS),Smart HDR 4,Live Photo,Bộ lọc màu,Cinematic,Dolby Vision HDR,Zoom kỹ thuật số,Siêu cận (Macro),Góc siêu rộng (Ultrawide),Chế độ hành động (Action Mode),Deep Fusion",
                    ProductId = productIds[0]
                },
                new RearCamera
                {
                    Id = 2,
                    Resolution = "48MP x 12MP x 12MP",
                    Film = "Quay video 4K ở tốc độ 60 fps,Quay video HD 1080p ở tốc độ 60 fps,Quay video HD 720p ở tốc độ 30 fps,Chế độ điện ảnh lên đến 4K HDR ở tốc độ 30 fps,Chế độ hành động lên đến 2,8K ở tốc độ 60 fps,Quay video HDR với Dolby Vision lên đến 4K ở tốc độ 60 fps",
                    FlashLight = "True Tone thích ứng",
                    Feature = "Nắp ống kính tinh thể sapphirePhotogenic Engine,Deep Fusion,HDR thông minh,Chế độ chân dung với hiệu ứng bokeh nâng cao và Kiểm soát độ sâu,Portrait Lighting với sáu hiệu ứng (Tự nhiên, Studio, Đường viền, Sân khấu, Sân khấu Mono, High Key Mono),Chế độ ban đêm,Chụp chân dung ở chế độ ban đêm được bật bởi LiDAR Scanner,Toàn cảnh (lên đến 63MP),Chụp ảnh phong cách",
                    ProductId = productIds[1]
                },
                new RearCamera
                {
                    Id = 3,
                    Resolution = "12MP x 12MP",
                    Film = "Quay video 4K tối đa 60 fps,Quay video HD 1080p tối đa 60 fps,Quay video HD 720p tối đa 30 fps,Chế độ điện ảnh lên đến 4K HDR ở tốc độ 30 fps,Chế độ hành động lên đến 2,8K ở tốc độ 60 fps,Quay video HDR với Dolby Vision lên đến 4K ở tốc độ 60 fps,Hỗ trợ video chuyển động chậm cho 1080p tối đa 240 fps,Video tua nhanh thời gian với tính năng ổn định,Chế độ ban đêm,Time-lapse",
                    FlashLight = "True Tone",
                    Feature = "Nắp ống kính tinh thể sapphire,Photogenic Engine,Deep Fusion,HDR thông minh 4,Chế độ chân dung với hiệu ứng bokeh nâng cao và Kiểm soát độ sâu,Portrait Lighting với sáu hiệu ứng (Tự nhiên, Studio, Đường viền, Sân khấu, Sân khấu Mono, High Key Mono),Chế độ ban đêm,Toàn cảnh (lên đến 63MP),Chụp ảnh phong cách,Chụp màu rộng cho ảnh và Ảnh trực tiếp,Hiệu chỉnh ống kính (Siêu rộng),Chỉnh sửa mắt đỏ nâng cao,Ổn định hình ảnh tự động,Chế độ chụp,Gắn thẻ địa lý cho ảnh",
                    ProductId = productIds[2]
                },

                //samsung
                new RearCamera
                {
                    Id = 4,
                    Resolution = "Chính 48 MP & Phụ 8 MP, 5 MP, 2 MP",
                    Film = "4K 2160p@30fps,FullHD 1080p@30fps,FullHD 1080p@60fps,HD 720p@30fps",
                    FlashLight = "Night Mode",
                    Feature = "Bộ lọc màu,Chuyên nghiệp (Pro),Chạm lấy nét,Chống rung quang học (OIS),Góc rộng (Wide),Góc siêu rộng (Ultrawide),HDR,Làm đẹp,Lấy nét theo pha (PDAF),Nhận diện khuôn mặt,Quay chậm (Slow Motion),Quay Siêu chậm (Super Slow Motion),Siêu cận (Macro),Toàn cảnh (Panorama),Trôi nhanh thời gian (Time Lapse),Tự động lấy nét (AF),Xóa phông,Zoom kỹ thuật số",
                    ProductId = productIds[3]
                },
                new RearCamera
                {
                    Id = 5,
                    Resolution = "50.0 MP x 5.0 MP x 2.0 MP x 2.0 MP",
                    Film = "FHD (1920 x 1080)@30fps",
                    FlashLight = "Có",
                    Feature = "Chống rung OIS 2022,Chụp ảnh chân dung,Chụp Cận Cảnh",
                    ProductId = productIds[4]
                },

                //oppo
                new RearCamera
                {
                    Id = 6,
                    Resolution = "Chính 50 MP & Phụ 0.3 M",
                    Film = "HD 720p@30fps,FullHD 1080p@30fps",
                    FlashLight = "Có",
                    Feature = "AI Camera,Ban đêm (Night Mode),Trôi nhanh thời gian (Time Lapse),Chụp bằng cử chỉ,Toàn cảnh (Panorama),HDR,Chuyên nghiệp (Pro),Bộ lọc màu,Nhãn dán (AR Stickers),Làm đẹp,Google Lens,Zoom kỹ thuật số",
                    ProductId = productIds[5]
                },
                new RearCamera
                {
                    Id = 7,
                    Resolution = "13 MP (chính) + 2 MP (mono) + 2 MP (marco)",
                    Film = null,
                    FlashLight = null,
                    Feature = null,
                    ProductId = productIds[6]
                },

                //Nokia
                new RearCamera
                {
                    Id = 8,
                    Resolution = "5 MP",
                    Film = "HD 720p@30fps",
                    FlashLight = null,
                    Feature = "HDR",
                    ProductId = productIds[7]
                }
            );

            modelBuilder.Entity<FrontCamera>().HasData(
                //iphone
                new FrontCamera
                {
                    Id = 1,
                    Resolution = "12 MP",
                    Feature = "Xóa phông,Quay video 4K,Retina Flash,Quay video Full HD,Tự động lấy nét (AF),Smart HDR 4,Bộ lọc màu,Live Photo,Trôi nhanh thời gian (Time Lapse),Chụp đêm,Quay chậm (Slow Motion),Cinematic",
                    ProductId = productIds[0]
                },
                new FrontCamera
                {
                    Id = 2,
                    Resolution = "12 MP",
                    Feature = "Tự động lấy nét với Focus Pixels,Thấu kính sáu phần tử,Retina Flash,Photogenic Engine,Deep Fusion,HDR thông minh,Chế độ chân dung với hiệu ứng bokeh nâng cao và Kiểm soát độ sâu,Portrait Lighting với sáu hiệu ứng (Tự nhiên, Studio, Đường viền, Sân khấu, Sân khấu Mono, High Key Mono),Animoji và Memoji,Chế độ ban đêm",
                    ProductId = productIds[1]
                },
                new FrontCamera
                {
                    Id = 3,
                    Resolution = "12 MP",
                    Feature = "Quay video 4K tối đa 60 fps,Chế độ điện ảnh lên đến 4K HDR ở tốc độ 30 fps,Quay video HDR với Dolby Vision lên đến 4K ở tốc độ 60 fps,Hỗ trợ video chuyển động cho 1080p ở tốc độ 120 fps,Video tua nhanh thời gian với tính năng ổn định,Chế độ ban đêm Thời gian trôi đi,Video QuickTake,Ổn định video điện ảnh (4K, 1080p và 720p)",
                    ProductId = productIds[2]
                },

                //samsung
                new FrontCamera
                {
                    Id = 4,
                    Resolution = "13 MP",
                    Feature = "Bộ lọc màu,Chụp đêm,Flash màn hình,Góc rộng (Wide),HDR,Live Photo,Làm đẹp,Nhận diện khuôn mặt,Quay video 4K,Quay video Full HD,Trôi nhanh thời gian (Time Lapse),Xóa phông",
                    ProductId = productIds[3]
                },
                new FrontCamera
                {
                    Id = 5,
                    Resolution = "8.0 MP",
                    Feature = null,
                    ProductId = productIds[4]
                },

                //oppo
                new FrontCamera
                {
                    Id = 6,
                    Resolution = "5 MP",
                    Feature = "Xóa phông,Nhãn dán (AR Stickers),Toàn cảnh (Panorama),Quay video HD,Làm đẹp,Quay video Full HD,HDR,Bộ lọc màu,Trôi nhanh thời gian (Time Lapse)",
                    ProductId = productIds[5]
                },
                new FrontCamera
                {
                    Id = 7,
                    Resolution = "8 MP",
                    Feature = null,
                    ProductId = productIds[6]
                },

                //Nokia
                new FrontCamera
                {
                    Id = 8,
                    Resolution = "5 MP",
                    Feature = "Quay video HD",
                    ProductId = productIds[7]
                }
            );

            modelBuilder.Entity<OSAndCPU>().HasData(
                //iphone
                new OSAndCPU
                {
                    Id = 1,
                    OperatingSystem = "iOS 16",
                    Cpu = "Apple A16 Bionic 6 nhân",
                    CpuSpeed = "3.46 GHz",
                    Gpu = "Apple GPU 5 nhân",
                    ProductId = productIds[0]
                },
                new OSAndCPU
                {
                    Id = 2,
                    OperatingSystem = "iOS 16",
                    Cpu = "A16 Bionic",
                    CpuSpeed = "3.46 GHz",
                    Gpu = "Apple GPU",
                    ProductId = productIds[1]
                },
                new OSAndCPU
                {
                    Id = 3,
                    OperatingSystem = "iOS 16",
                    Cpu = "A15 Bionic",
                    CpuSpeed = null,
                    Gpu = null,
                    ProductId = productIds[2]
                },

                //samsung
                new OSAndCPU
                {
                    Id = 4,
                    OperatingSystem = "Android 12",
                    Cpu = "Exynos 1280 8 nhân",
                    CpuSpeed = "2 nhân 2.4 GHz & 6 nhân 2 GHz",
                    Gpu = null,
                    ProductId = productIds[3]
                },
                new OSAndCPU
                {
                    Id = 5,
                    OperatingSystem = "Android 12",
                    Cpu = "SnapDragon 695 5G",
                    CpuSpeed = null,
                    Gpu = null,
                    ProductId = productIds[4]
                },

                //oppo
                new OSAndCPU
                {
                    Id = 6,
                    OperatingSystem = "Android 12",
                    Cpu = "MediaTek Helio G35 8 nhân",
                    CpuSpeed = "2.3 GHz",
                    Gpu = "IMG PowerVR GE8320",
                    ProductId = productIds[5]
                },
                new OSAndCPU
                {
                    Id = 7,
                    OperatingSystem = "ColorOS 11.1, nền tảng Android 11",
                    Cpu = "Helio G35, tối đa 2.3GHz",
                    CpuSpeed = null,
                    Gpu = "IMG GE8320@680MHz",
                    ProductId = productIds[6]
                },

                //Nokia
                new OSAndCPU
                {
                    Id = 8,
                    OperatingSystem = "Android 11 (Go Edition)",
                    Cpu = null,
                    CpuSpeed = "4 nhân 1.6 GHz & 4 nhân 1.2 GHz",
                    Gpu = "Mali-G52 MC2",
                    ProductId = productIds[7]
                }
            );

            modelBuilder.Entity<BatteryAndCharger>().HasData(
                //iphone
                new BatteryAndCharger
                {
                    Id = 1,
                    BatteryCapacity = "4323 mAh",
                    BatteryType = "Li-Ion",
                    MaximumChargingSupport = "20 W",
                    BatteryTechnology = "Sạc không dây MagSafe,Sạc pin nhanh,Sạc không dây,Tiết kiệm pin",
                    ProductId = productIds[0]
                },
                new BatteryAndCharger
                {
                    Id = 2,
                    BatteryCapacity = "3200 mAh",
                    BatteryType = "Lithium‑ion",
                    MaximumChargingSupport = "Sạc không dây MagSafe lên đến 15W,Sạc không dây Qi lên đến 7,5W",
                    BatteryTechnology = "Sạc không dây,Tiết kiệm pin,Sạc pin nhanh,Sạc không dây MagSafe",
                    ProductId = productIds[1]
                },
                new BatteryAndCharger
                {
                    Id = 3,
                    BatteryCapacity = null,
                    BatteryType = "Lithium‑ion",
                    MaximumChargingSupport = "Sạc không dây MagSafe lên đến 15W,Sạc không dây Qi lên đến 7,5W",
                    BatteryTechnology = null,
                    ProductId = productIds[2]
                },

                //samsung
                new BatteryAndCharger
                {
                    Id = 4,
                    BatteryCapacity = "5000 mAh",
                    BatteryType = "Li-Po",
                    MaximumChargingSupport = "25 W",
                    BatteryTechnology = "Sạc pin nhanh",
                    ProductId = productIds[3]
                },
                new BatteryAndCharger
                {
                    Id = 5,
                    BatteryCapacity = "5000 mAh",
                    BatteryType = null,
                    MaximumChargingSupport = "25 W",
                    BatteryTechnology = null,
                    ProductId = productIds[4]
                },

                //oppo
                new BatteryAndCharger
                {
                    Id = 6,
                    BatteryCapacity = "5000 mAh",
                    BatteryType = "Li-Po",
                    MaximumChargingSupport = "10 W",
                    BatteryTechnology = "Siêu tiết kiệm pin",
                    ProductId = productIds[5]
                },
                new BatteryAndCharger
                {
                    Id = 7,
                    BatteryCapacity = "5000 mAh",
                    BatteryType = null,
                    MaximumChargingSupport = null,
                    BatteryTechnology = null,
                    ProductId = productIds[6]
                },

                //Nokia
                new BatteryAndCharger
                {
                    Id = 8,
                    BatteryCapacity = "iOS 16",
                    BatteryType = "Li-Po",
                    MaximumChargingSupport = null,
                    BatteryTechnology = null,
                    ProductId = productIds[7]
                }
            );

            var orderIds = new List<Guid>
            {
                Guid.NewGuid(),
                Guid.NewGuid(),
                Guid.NewGuid()
            };
            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    Id = orderIds[0],
                    PhoneNumber = "0909000021",
                    Name = "Nguyễn Văn A",
                    Address = "số 1, đường số 2",
                    CustomerNotes = null,
                    StoreNotes = null,
                    Date = new DateTime(2023, 05, 20),
                    Status = "Chờ xác nhận",
                    UserId = null
                },
                new Order
                {
                    Id = orderIds[1],
                    PhoneNumber = "0909000021",
                    Name = "Nguyễn Văn A",
                    Address = "số 1, đường số 2",
                    CustomerNotes = null,
                    StoreNotes = null,
                    Date = new DateTime(2023, 05, 20),
                    Status = "Đã giao",
                    UserId = null
                },
                new Order
                {
                    Id = orderIds[2],
                    PhoneNumber = "0909000021",
                    Name = "Nguyễn Văn A",
                    Address = "số 1, đường số 2",
                    CustomerNotes = null,
                    StoreNotes = null,
                    Date = new DateTime(2023, 05, 20),
                    Status = "Đã xác nhận",
                    UserId = null
                }
            );
            modelBuilder.Entity<Detail>().HasData(
                new Detail
                {
                    Id = 1,
                    Quantity = 1,
                    OrderId = orderIds[0],
                    ProductId = productIds[0],
                    ColorId = 1,
                    MemoryAndStorageId = 1
                },
                new Detail
                {
                    Id = 2,
                    Quantity = 2,
                    OrderId = orderIds[0],
                    ProductId = productIds[1],
                    ColorId = 5,
                    MemoryAndStorageId = 5
                },

                new Detail
                {
                    Id = 3,
                    Quantity = 1,
                    OrderId = orderIds[0],
                    ProductId = productIds[1],
                    ColorId = 6,
                    MemoryAndStorageId = 5
                },

                new Detail
                {
                    Id = 4,
                    Quantity = 1,
                    OrderId = orderIds[0],
                    ProductId = productIds[2],
                    ColorId = 9,
                    MemoryAndStorageId = 9
                }
            );
            #endregion          
        }
    }
}


            