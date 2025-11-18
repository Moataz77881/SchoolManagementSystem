using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Application.Interfaces.Services;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Infrastructure.Implementation.Services;
using SchoolManagementSystem.Infrastructure.Persistence;

namespace SchoolManagementSystem.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            //Add connection string
            services.AddDbContext<ApplicationDBContext>(options => 
                options.UseSqlServer(
                    configuration.GetConnectionString("SchoolManagementSystemConnection"))
                );

            //Add identity configuration
            services.AddIdentity<ApplicationUser,IdentityRole>(options => 
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;   
                options.Password.RequireNonAlphanumeric = true; 
                options.Password.RequiredUniqueChars = 1;
            })
                .AddEntityFrameworkStores<ApplicationDBContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<IJWTService, JWTService>();
            services.AddScoped<IUserAuthService, UserAuthService>();

        }
    }
}
