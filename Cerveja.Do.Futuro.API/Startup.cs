using Cerveja.Do.Futuro.Aplication.Interfaces;
using Cerveja.Do.Futuro.Aplication.Services;
using Cerveja.Do.Futuro.Domain.Interfaces;
using Cerveja.Do.Futuro.Domain.Interfaces.Validacao;
using Cerveja.Do.Futuro.Domain.Validation;
using Cerveja.Do.Futuro.Infra.Context;
using Cerveja.Do.Futuro.Infra.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Cerveja.Do.Futuro.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Cerveja do Futuro",
                    Version = "v1",

                });
            });
            AddDbContextCollection(services);

            services.AddControllers();
            services.AddCors();

            services.AddScoped<ICervejariaRepository, CervejariaRepository> ();
            services.AddScoped<ICervejariaValidacao, CervejariasValidacao> ();
            services.AddScoped<ICervejariaService, CervejariaService> ();


        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1 Cerveja do Futuro");
                c.DocExpansion(DocExpansion.None);
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void AddDbContextCollection(IServiceCollection services)
        {
            services.AddDbContext<MainContext>(opt => opt
                .UseSqlServer("Data Source=NT-04844\\SQLEXPRESS;Initial Catalog=Cervejarias;Integrated Security=True;MultipleActiveResultSets=True"));
        }
    }
}
