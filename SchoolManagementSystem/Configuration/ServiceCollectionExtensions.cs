using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SchoolManagementSystem.Application.Interfaces.Repositories;
using SchoolManagementSystem.Application.Interfaces.Services;
using SchoolManagementSystem.Application.Interfaces.UOW;
using SchoolManagementSystem.Domain.Entities.AuthEntities;
using SchoolManagementSystem.Infrastructure.Implementation.Repositories;
using SchoolManagementSystem.Infrastructure.Implementation.Services;
using SchoolManagementSystem.Infrastructure.Implementation.UOW;
using SchoolManagementSystem.Infrastructure.Mapper;
using SchoolManagementSystem.Infrastructure.Persistence;
using System.Security.Cryptography.Xml;

namespace SchoolManagementSystem.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c => 
            {
                c.SwaggerDoc("v1", new OpenApiInfo 
                {
                    Title = "ShcoolSystemManagment",
                    Version = "v1"
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme 
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter 'Bearer' followed by your token. Example: Bearer eyJhbGciOi..."
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });

            //Add connection string
            services.AddDbContext<ApplicationDBContext>(options => 
                options.UseSqlServer(
                    configuration.GetConnectionString("SchoolManagementSystemConnection"))
                );

			//Add Auto mapper configuration

			var loggerFactory = LoggerFactory.Create(builder =>
			{
				builder.AddConsole();
			});

			var mapperConfig = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile(new MappingProfile());
			}, loggerFactory);

			var mapper = mapperConfig.CreateMapper();

			services.AddSingleton(mapper);

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
            services.AddScoped<IAssignmentRepository, AssignmentRepository>();
            services.AddScoped<IAttendanceRepository, AttendanceRepository>();
            services.AddScoped<IClassRepository, ClassRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IStudentClassRepository, StudentClassRepository>();
            services.AddScoped<ISubmissionRepository, SubmissionRepositroy>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDepartmentService, DepartmentService>();

        }
    }
}
