using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace InfoRutas.Backend.Repository
{
    public class ContextFactory : IDesignTimeDbContextFactory<InfoRutasDbContext>
    {
        public InfoRutasDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<InfoRutasDbContext>();
            optionsBuilder.UseNpgsql(
                    "Host=localhost;Port=25432;Username=solisystems;Password=welcome;Database=InfoRutas;",
                    npgsqlOptionsAction: options =>
                    {
                        options.EnableRetryOnFailure(
                            maxRetryCount: 3,
                            maxRetryDelay: TimeSpan.FromSeconds(5),
                            errorCodesToAdd: null);
                        //options.MigrationsAssembly("InfoRutas.Backend.MigrationsAssembly");
                    }).UseSnakeCaseNamingConvention();

            return new InfoRutasDbContext(optionsBuilder.Options);
        }
    }
}