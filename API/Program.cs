using API.Configurations;
using API.Configurations.AuthenticationJwtConfiguration;
using API.Hub;
using Infraestrutura.DataBase;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddDbContext<DataBaseContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")!, b => b.MigrationsAssembly("API")));

builder.Services
    .AddRepositoryInjections()
    .AddAuthenticationJwt(configuration);

builder.Services.AddControllers();
builder.Services.AddSignalR();

// Configuração de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy
            .WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials(); 
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors("AllowAll");

app.UseRouting();  

app.UseAuthentication();
app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<SystemMonitorHub>("/systemmonitorhub");
});

// Configuração de HTTPS
app.UseHttpsRedirection();

// Mapeamento de controladores
app.MapControllers();

app.Run();
