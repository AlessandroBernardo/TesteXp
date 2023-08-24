using CadastroClienteXpTeste.API.Core.Interfaces.Repositories;
using CadastroClienteXpTeste.API.Core.Interfaces.Services;
using CadastroClienteXpTeste.API.Infrastructure.AutoMapper;
using CadastroClienteXpTeste.API.Infrastructure.Configuration;
using CadastroClienteXpTeste.API.Infrastructure.Data;
using CadastroClienteXpTeste.API.Infrastructure.Data.Repositories;
using CadastroClienteXpTeste.API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Adicionar serviços ao container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddAutoMapper(typeof(ClienteMap));
builder.Services.AddCustomCors();
builder.Services.AddCors();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//int httpsPort = Convert.ToInt32(builder.Configuration["HTTPS_PORT"]);


var loggerFactory = LoggerFactory.Create(logBuilder =>
{
    logBuilder.AddConsole();
});

// builder.Services.Configure<HttpsRedirectionOptions>(options =>
// {
//     options.HttpsPort = 443;
// });

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(connectionString)
           .UseLoggerFactory(loggerFactory)
           .EnableSensitiveDataLogging();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();        
}

//app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthorization();

app.MapControllers();

app.Run();




// using CadastroClienteXpTeste.API.Core.Interfaces.Repositories;
// using CadastroClienteXpTeste.API.Core.Interfaces.Services;
// using CadastroClienteXpTeste.API.Infrastructure.AutoMapper;
// using CadastroClienteXpTeste.API.Infrastructure.Configuration;
// using CadastroClienteXpTeste.API.Infrastructure.Data;
// using CadastroClienteXpTeste.API.Infrastructure.Data.Repositories;
// using CadastroClienteXpTeste.API.Services;
// using Microsoft.Data.SqlClient;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.Extensions.DependencyInjection;
// using Microsoft.Extensions.Hosting;


// var builder = WebApplication.CreateBuilder(args);

// // Add services to the container.



// builder.Services.AddControllers();
// // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();
// builder.Services.AddScoped<IClienteService, ClienteService>();
// builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
// builder.Services.AddAutoMapper(typeof(ClienteMap));
// builder.Services.AddCustomCors();
// builder.Services.AddCors();

// var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// bool useInMemoryDatabase = false;

// try
// {
//     using var connection = new SqlConnection(connectionString);
//     connection.Open(); 
// }
// catch
// {    
//     useInMemoryDatabase = true;
// }

// var loggerFactory = LoggerFactory.Create(logBuilder => 
// {
//     logBuilder.AddConsole();
// });

// builder.Services.AddDbContext<AppDbContext>(options =>
// {
//     if (useInMemoryDatabase)
//     {
//         options.UseInMemoryDatabase("InMemoryDb")
//                .UseLoggerFactory(loggerFactory) 
//                .EnableSensitiveDataLogging();  
//     }
//     else
//     {
//         options.UseSqlServer(connectionString)
//            .UseLoggerFactory(loggerFactory) 
//            .EnableSensitiveDataLogging();
//     }
// });



// var app = builder.Build();

// // Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

// app.UseHttpsRedirection();

// app.UseAuthorization();

// app.MapControllers();

// app.Run();
