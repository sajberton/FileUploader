
using FileUploader.Services.TextFileDataServices;
using FileUploader.Services.TextFileServices;

namespace FileUploader.Api.Extensions
{
    public static class ServicesExtension
    {
        public static void AddServicesModule(this IServiceCollection services) 
        {
            services.AddScoped<ITextFileServices, TextFileServices>();
            services.AddScoped<ITextFileDataService, TextFileDataService>();
        }
    }
}
