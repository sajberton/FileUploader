using FileUploader.Services.Mappers;

namespace FileUploader.Api.Extensions
{
    public static class AutoMapperExtension
    {
        public static void AddAutoMapperModule(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(TextFileMapperProfile), 
                typeof(TextFileDataMappperProfile));
        }
    }
}
