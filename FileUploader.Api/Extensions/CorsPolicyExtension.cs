namespace FileUploader.Api.Extensions
{
    public static class CorsPolicyExtension
    {
        public static void AddCorsPolicyModule(this IServiceCollection services)
        {
            services.AddCors(p => p.AddPolicy("corsapp", builder =>
            {
                builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
            }));
        }
    }
}
