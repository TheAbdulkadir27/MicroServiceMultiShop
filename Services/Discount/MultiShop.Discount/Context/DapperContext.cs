using Microsoft.EntityFrameworkCore;
using MultiShop.Discount.Entities;
using System.Data;
using System.Data.SqlClient;

namespace MultiShop.Discount.Context
{
    public class DapperContext : DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _ConnectionStrings;
        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _ConnectionStrings = configuration.GetConnectionString("DefaultConnection");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS; Initial Catalog=MultiShopDiscount; Integrated Security=true");
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Coupon> Coupons { get; set; }
        public IDbConnection CreateConnection() => new SqlConnection(_ConnectionStrings);
    }
}
