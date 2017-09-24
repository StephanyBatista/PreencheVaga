using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PreencheVaga.Dado.Context;
using PreencheVaga.Dado.Repositorio;
using PreencheVaga.Dominio.BuscaCandidatos;
using PreencheVaga.Dominio.Candidatos;
using PreencheVaga.Dominio.Tecnologias;
using PreencheVaga.Dominio.Vagas;
using PreencheVaga.Dominio._Base;
using PreencheVaga.UI.Filters;

namespace PreencheVaga.UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(opt => opt.UseInMemoryDatabase("database"));
            
            services
                .AddMvc(config => {
                    config.Filters.Add(typeof(ExcecaoFilter));
                })
                .AddJsonOptions(jsonOptions=>
                {
                    jsonOptions.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                });

            services.AddScoped(typeof(IRepositorioBase<>), typeof(RepositorioBase<>));
            services.AddScoped(typeof(IRepositorioBase<Candidato>), typeof(CandidatoRepositorio));
            services.AddScoped<UnitOfWork>();
            services.AddScoped<ArmazenadorDeTecnologia>();
            services.AddScoped<ArmazenadorDeVaga>();
            services.AddScoped<ArmazenadorDeCandidato>();
            services.AddScoped<ProcessadorDeCandidatosParaVaga>();
            services.AddScoped(typeof(IValidadorDeProcessoDeCandidatosParaVaga), typeof(ValidadorDeProcessoDeCandidatosParaVaga));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.Use(async (context, next) =>
            {
                //Request
                await next.Invoke();
                //Response
                var unitOfWork = (UnitOfWork)context.RequestServices.GetService(typeof(UnitOfWork));
                await unitOfWork.Commit();
            });
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}