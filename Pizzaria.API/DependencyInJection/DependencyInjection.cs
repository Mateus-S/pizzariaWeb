using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Pizzaria.Application.Interfaces.Services;
using Pizzaria.Application.Interfaces.Services.CustomerService;
using Pizzaria.Application.Interfaces.Services.EmployeeService;
using Pizzaria.Application.Interfaces.Services.MenuItemService;
using Pizzaria.Application.Interfaces.Services.OrderItemService;
using Pizzaria.Application.Interfaces.Services.OrderService;
using Pizzaria.Application.Interfaces.Services.UserService;
using Pizzaria.Application.Mappings;
using Pizzaria.Application.Services;
using Pizzaria.Application.Services.CustomerService;
using Pizzaria.Application.Services.EmployeeService;
using Pizzaria.Application.Services.MenuItemService;
using Pizzaria.Application.Services.OrderItemService;
using Pizzaria.Application.Services.OrderService;
using Pizzaria.Application.Services.UserService;
using Pizzaria.Domain.Interfaces.Repositories.CategoryRepository;
using Pizzaria.Domain.Interfaces.Repositories.CustomerRespository;
using Pizzaria.Domain.Interfaces.Repositories.EmployeeRespository;
using Pizzaria.Domain.Interfaces.Repositories.MenuRepository;
using Pizzaria.Domain.Interfaces.Repositories.OrderItemRepository;
using Pizzaria.Domain.Interfaces.Repositories.OrderRepository;
using Pizzaria.Domain.Interfaces.Repositories.UserRepository;
using Pizzaria.Infrastructure.Data;
using Pizzaria.Infrastructure.Repositories;
using Pizzaria.Infrastructure.Repositories.CustomerRepository;
using Pizzaria.Infrastructure.Repositories.MenuItemRepository;
using Pizzaria.Infrastructure.Repositories.OrderItemRepository;
using Pizzaria.Infrastructure.Repositories.OrderRepository;
using Pizzaria.Infrastructure.Repositories.UserRepository;
using Pizzaria.Infrastructure.RepositoriesRepository;
using System.Text;

namespace Pizzaria.API.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddProjectServices(this IServiceCollection services, IConfiguration configuration)
        {
            // 🔐 JWT
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    var secret = configuration["Jwt:Secret"] ?? "MySuperSecretKey123!";
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = configuration["Jwt:Issuer"] ?? "PizzariaAPI",
                        ValidAudience = configuration["Jwt:Audience"] ?? "PizzariaClient",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret))
                    };
                });

            // 🌐 Versionamento
            services.AddControllers();
            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
            });

            // 🌍 CORS
            services.AddCors(options =>
            {
                options.AddPolicy("AllowBlazorClient", policy =>
                {
                    policy.WithOrigins("https://localhost:5002", "https://localhost:5028")
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

            // 📚 Swagger
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Pizzaria API", Version = "v1" });

                var jwtScheme = new OpenApiSecurityScheme
                {
                    BearerFormat = "JWT",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = JwtBearerDefaults.AuthenticationScheme,
                    Description = "Insira o token no formato: Bearer {token}",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };

                options.AddSecurityDefinition(jwtScheme.Reference.Id, jwtScheme);
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { jwtScheme, Array.Empty<string>() }
                });
            });

            // 📦 Injeções dos projetos internos
            services.AddDbContext<PizzariaDbContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));

            // AutoMapping Service
            services.AddAutoMapper(typeof(CategoryProfile).Assembly); // já carrega todos

            services.AddScoped<IMenuItemRepository, MenuItemRepository>();
            services.AddScoped<IMenuItemService, MenuItemService>();

            // 🧑‍🍳 Category
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryService, CategoryService>();

            // 🧑‍ Customer
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerService, CustomerService>();

            // 👨‍🍳 Employee
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEmployeeService, EmployeeService>();

            // 📦 Order
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderService, OrderService>();

            // 🧾 OrderItem
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();
            services.AddScoped<IOrderItemService, OrderItemService>();

            // 👤 User
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();



            return services;
        }
    }
}
