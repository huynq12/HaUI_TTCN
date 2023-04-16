using LaptopShop.Data;
using LaptopShop.Models.EF;
using Microsoft.EntityFrameworkCore;

namespace LaptopShop.Models
{
    public static class SeedData
    {
        public static void InitializeCategory(IServiceProvider serviceProvider)
        {
            using (var context = new LaptopDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<LaptopDbContext>>()))
            {
                // Look for any product
                if (context.Categories.Any())
                {
                    return; // DB has been seeded
                }
                // seed category
                context.Categories.AddRange(
                    new Category
                    {
                        Name = "Acer",
                        Description = "Acer là tập đoàn đa quốc gia về thiết bị điện tử và phần cứng máy tính của Đài Loan"
                    },
                    new Category
                    {
                        Name = "Dell",
                        Description = "Thương hiệu Dell được thành lập vào năm 1984, công ty đa quốc gia của Hoa Kỳ - Dell Inc"
                    },
                    new Category
                    {
                        Name = "HP",
                        Description = "Thương hiệu HP được thành lập vào 01/01/1939 tại bang California, Palo Alto, nước Mỹ"
                    },
                    new Category
                    {
                        Name = "Lenovo",
                        Description = "Lenovo là tập đoàn đa quốc gia về công nghệ máy tính, được thành lập vào năm 1984 ở Bắc Kinh với tên Legend"
                    },
                    new Category
                    {
                        Name = "Macbook",
                        Description = "Mặc dù Apple là công ty công nghệ có trụ sở chính đặt tại California"
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
