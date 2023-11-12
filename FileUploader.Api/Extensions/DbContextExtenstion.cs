using FileUploader.Data;
using Microsoft.EntityFrameworkCore;

namespace FileUploader.Api.Extensions
{
    public static class DbContextExtenstion
    {
        public static void AddDbContextModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FileUploaderContext>
                (opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
