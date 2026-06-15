using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace BlogSystem.src.Infrastructure.Data
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            //从环境变量注入或者硬编码获得连接字符串
            var connectionString = Environment.GetEnvironmentVariable("BLOG_CONNECTION") ?? "Host=localhost;Port=54321;Database=BlogSystem;Username=postgres;Password=123456";
            //创建连接配置
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            //配置为Postgressql
            optionsBuilder.UseNpgsql(connectionString);

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
