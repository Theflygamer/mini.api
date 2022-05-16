using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using mini.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mini.DAL.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace mini.api
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
            services.AddCors(options =>
            {
                options.AddPolicy("Kage",
                builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
            });

            //services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IAuthorRepository,AuthorRepository>();
            //services.AddDbContext<Abcontext>();

            services.AddDbContext<Abcontext>(
                x => x.UseSqlServer(@"Server=FTF-LAPTOP;Database=torsdag; Trusted_Connection=True"));




            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "mini.api", Version = "v1" });
            });
           // services.AddController().AddJsonOptions(XmlConfigurationExtensions =>
            //x.JsonSerializerOPtions.ReferencHandler = ReferenceHandler)
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "mini.api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors("Kage");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
