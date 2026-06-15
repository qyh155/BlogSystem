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
            var currentDir = Path.GetDirectoryName(typeof(AppDbContextFactory).Assembly.Location) ?? Directory.GetCurrentDirectory();
            // 1. 找到 API 项目所在的目录（因为 appsettings.json 在那里）
            var apiProjectPath = Path.GetFullPath(Path.Combine(currentDir, "../../../../BlogSystem.API"));

            // 2. 构建配置
            var configuration = new ConfigurationBuilder()
                .SetBasePath(apiProjectPath)
                .AddJsonFile("appsettings.json", optional: false)
                .AddJsonFile("appsettings.Development.json", optional: true)
                .Build();

            // 3. 读取连接字符串
            var connectionString = configuration.GetConnectionString("Default");
            //上面的模式是为了文件配置连接字符串，当然也可以直接写死连接字符串，或者通过环境变量等方式获取连接字符串。

            // 4. 配置 DbContext
            var optionsBuider = new DbContextOptionsBuilder<AppDbContext>();
            
            //var connectionString = "Host=localhost;Port=54321;Database=BlogSystem;Username=postgres;Password=123456";
            optionsBuider.UseNpgsql(connectionString);

            return new AppDbContext(optionsBuider.Options);
        }
    }
}
