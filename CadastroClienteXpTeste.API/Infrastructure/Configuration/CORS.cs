namespace CadastroClienteXpTeste.API.Infrastructure.Configuration
{
    public static class ConfigurationExtensions
    {
        public static void AddCustomCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:5228", "https://localhost:5228") // Substitua com os domínios corretos
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                    });
            });
        }
    }

}