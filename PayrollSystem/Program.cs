using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using PayrollData;
using Microsoft.EntityFrameworkCore;
using PayrollData.Repository;

class Program
{
    static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();
        builder.Services.AddDbContext<PayRollDBContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("PayRollSystem")));
        builder.Services.AddScoped<IPayRollRepo, PayRollRepo>();


        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Payroll API", Version = "v1" });
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Payroll API v1");
            });
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        /*app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });*/

        app.MapControllers();
        app.Run();
    }
}
