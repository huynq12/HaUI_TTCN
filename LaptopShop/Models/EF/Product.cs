using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace LaptopShop.Models.EF
{
	[Table("Product")]
	public class Product
	{
        public Product()
        {
			this.OrderDetails = new HashSet<OrderDetail>();
        }

        [Key]
		public int Id { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        [Column(TypeName = "nvarchar(50)")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        [Column(TypeName = "nvarchar(150)")]
		public string Name { get; set; }

		[Required(ErrorMessage = "This field is required!")]
		[Column(TypeName = "nvarchar(50)")]
		public string OperatingSystem { get; set; }

		[Required(ErrorMessage = "This field is required!")]
		[Column(TypeName = "nvarchar(200)")]
		public string Monitor { get; set; }

		[Required(ErrorMessage = "This field is required!")]
		[Column(TypeName = "nvarchar(200)")]
		public string CPU { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        [Column(TypeName = "nvarchar(200)")]
        public string RAM { get; set; }

        [Required(ErrorMessage = "This field is required!")]
		[Column(TypeName = "nvarchar(100)")]
		public string Storage { get; set; }

		[Required(ErrorMessage = "This field is required!")]
		[Column(TypeName = "nvarchar(200)")]
		public string Graphics { get; set; }

		[Required(ErrorMessage = "This field is required!")]
		public double Weight { get; set; }

		[Required(ErrorMessage = "This field is required!")]
		[Column(TypeName = "nvarchar(100)")]
		public string Color { get; set; }

		[Required(ErrorMessage = "This field is required!")]
		[Column(TypeName = "nvarchar(200)")]
		public string BatteryInfor { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        public byte Warranty { get; set; } // số tháng bảo hành

        [Column(TypeName = "ntext")]
        public string? Description { get; set; }

        [Column(TypeName = "ntext")]
        public string? ImageUrl { get; set; } // link hình ảnh

        [Required(ErrorMessage = "This field is required!")]
		[Column(TypeName = "decimal(10)")]
		public decimal Price { get; set; } // giá bán

		[Column(TypeName = "decimal(10)")]
		public decimal? PromotionalPrice { get; set; } // giá khuyến mãi

		[Required(ErrorMessage = "This field is required!")]
		public int Quantity { get; set; } // số lượng còn trong kho

		public int? CategoryId { get; set; }
		[ForeignKey("CategoryId")]
		public virtual Category Category { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        private List<string> dellLaptops = new List<string>() {
            "Dell XPS 13", "Dell Inspiron 15 7000", "Dell G3 15 Gaming", "Dell Latitude 7400", "Dell Precision 5550",
            "Dell Alienware m17 R4", "Dell Vostro 15 3500", "Dell XPS 15 9500", "Dell G7 17 Gaming", "Dell Latitude 5410"
        };
        private List<string> hpLaptops = new List<string>() {
            "HP Spectre x360", "HP Envy 13", "HP Pavilion 15", "HP EliteBook 840", "HP Omen 15",
            "HP ZBook Fury 17 G8", "HP ProBook 455 G8", "HP Pavilion Gaming 15", "HP Elite Dragonfly", "HP Spectre x360 14"
        };
        private List<string> acerLaptops = new List<string>() {
            "Acer Aspire 5", "Acer Predator Helios 300", "Acer Swift 3", "Acer Nitro 5", "Acer Spin 5",
            "Acer ConceptD 7", "Acer Chromebook Spin 713", "Acer Predator Triton 500", "Acer Predator X27", "Acer TravelMate P6"
        };
        private List<string> lenovoLaptops = new List<string>() {
            "Lenovo ThinkPad X1 Carbon", "Lenovo Yoga 9i", "Lenovo Legion 5", "Lenovo IdeaPad 5", "Lenovo ThinkPad X13",
            "Lenovo ThinkBook Plus","Lenovo ThinkPad P15", "Lenovo Yoga 7i", "Lenovo IdeaPad 3", "Lenovo ThinkPad X1 Fold"
        };
        private List<string> macbookLaptops = new List<string>()
        {
            "MacBook Pro (M1 chip)","MacBook Air (M1 chip)","MacBook Pro 16-inch","MacBook Pro 13-inch (M1 chip)",
            "MacBook Air (Retina, 13-inch, 2020)","MacBook Pro 15-inch (Retina)","MacBook Air (Retina, 13-inch, 2018)",
            "MacBook (Retina, 12-inch)","MacBook Pro 13-inch (2019)","MacBook Pro 13-inch (2018)"
        };
        private List<string> brands = new List<string>()
        {
            "Acer","Dell","HP","Lenovo","Macbook"
        };
        private List<string> monitorList = new List<string>()
        {
            "Ultrasharp U2718Q",
            "27UD88-W",
            "ROG Swift PG279QZ",
            "Predator X27",
            "PD3200U",
            "CHG90",
            "EliteDisplay E243p",
            "ViewSonic XG2405",
            "ThinkVision P32u-10",
            "Philips Brilliance 499P9H"
        };
        private List<string> cpuList = new List<string>()
        {
            "AMD Ryzen 9 5950X",
            "Intel Core i9-11900K",
            "AMD Ryzen 7 5800X",
            "Intel Core i7-11700K",
            "AMD Ryzen 5 5600X",
            "Intel Core i5-11600K",
            "AMD Ryzen 9 5900X",
            "Intel Core i9-10900K",
            "AMD Ryzen 7 5700G",
            "Intel Core i7-10700K"
        };
        private List<string> storageList = new List<string>()
        {
            "Samsung 970 EVO Plus 2TB NVMe SSD",
            "Crucial MX500 2TB 3D NAND SATA SSD",
            "Western Digital Black SN850 1TB NVMe SSD",
            "Seagate FireCuda 520 2TB NVMe SSD",
            "Samsung 870 QVO 8TB SATA SSD",
            "ADATA XPG GAMMIX S70 1TB NVMe SSD",
            "Kingston KC600 2TB SATA SSD",
            "SK hynix Gold P31 1TB NVMe SSD",
            "SanDisk Extreme Pro 2TB Portable SSD",
            "Intel Optane 905P 1.5TB PCIe SSD"
        };
        private List<string> graphicsList = new List<string>()
        {
            "NVIDIA GeForce RTX 3090",
            "AMD Radeon RX 6900 XT",
            "NVIDIA GeForce RTX 3080 Ti",
            "AMD Radeon RX 6800 XT",
            "NVIDIA GeForce RTX 3070",
            "AMD Radeon RX 6700 XT",
            "NVIDIA GeForce GTX 1660 Super",
            "AMD Radeon RX 6600 XT",
            "NVIDIA GeForce GT 710",
            "AMD Radeon RX 5500 XT"
        };
        private List<string> colorList = new List<string>()
        {
            "Red",
            "Green",
            "Blue",
            "Yellow",
            "Purple",
            "Orange",
            "Pink",
            "Black",
            "White",
            "Gray"
        };
        private List<string> batteryInfoList = new List<string>()
        {
            "Lithium-Ion (Li-Ion)",
            "Lithium-Polymer (Li-Po)"

        };
        private List<decimal> priceList = new List<decimal>()
        {
            17000000,
            18000000,
            19000000,
            20000000,
            21000000,
            22000000,
            23000000,
            25000000,
            29000000,
            31000000
        };
        private List<string> detailDesciptionList = new List<string>()
        {
            "Hàng chính hãng",
            "Giá tốt",
            "Máy mới 90%",
            "Máy thiết kế đẹp",
            "Máy khỏe, chạy mượt",
            "Không mới nhưng vẫn tốt",
            "Đại hạ giá",
            "Dành cho công việc văn phòng",
            "Bảo hành trọn đời",
            "Mua ngay kẻo hết"
        };
        public List<Product> geneLaptop(int n, List<Category> listCategories)
        {
            List<Product> list = new List<Product>();
            Random random = new Random();
            for (int i = 1; i <= n; i++)
            {
                Product product = new Product();
                int x = random.Next(10);
                x = x * i % 10;
                int CateId = x % 5;
                product.Category = listCategories[CateId];
                product.Brand = product.Category.Name;
                product.OperatingSystem = "Windows 11";
                if (product.Brand.Equals("Acer"))
                {
                    product.Name = acerLaptops[x];
                }
                else if (product.Brand.Equals("HP"))
                {
                    product.Name = hpLaptops[x];
                }
                else if (product.Brand.Equals("Dell"))
                {
                    product.Name = dellLaptops[x];
                }
                else if (product.Brand.Equals("Macbook"))
                {
                    product.Name = macbookLaptops[x];
                    product.OperatingSystem = "MacOS";
                }
                else
                {
                    product.Name = lenovoLaptops[x];
                }
                
                x = random.Next(10);
                x = x * i % 10;
                product.Monitor = monitorList[x];
                x = random.Next(10);
                x = x * i % 10;
                product.CPU = cpuList[x];
                x = random.Next(10);
                x = x * i % 10;
                product.Storage = storageList[x];
                product.RAM = (x * 2 + 2).ToString() +" GB";
                x = random.Next(10);
                x = x * i % 10;
                product.Graphics = graphicsList[x];
                product.Weight = ((double)x / 10) + 1.5;
                x = random.Next(10);
                x = x * i % 10;
                product.Color = colorList[x];
                x = random.Next(10);
                x = x * i % 10;
                product.BatteryInfor = batteryInfoList[x%2];
                x = random.Next(10);
                x = x * i % 10;
                product.Price = priceList[x];
                product.PromotionalPrice = product.Price - 1500000;
                product.Quantity = x;
                product.Warranty = (byte)x;
                x = random.Next(10);
                x = x * i % 10;
                product.Description = detailDesciptionList[x];
                product.CategoryId = product.Category.Id;
                list.Add(product);
            }
            return list;
        }
    }
}
