using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Curriculo.API.Data;
using Microsoft.EntityFrameworkCore;

// Criação do Builder: É usado para configurar e construir a aplicação.
var builder = WebApplication.CreateBuilder(args);

// Adicionar serviços ao contêiner.
// Saiba mais sobre a configuração do OpenAPI em https://aka.ms/aspnet/openapi
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});

// Ler a string de conexão do appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Configurar o DbContext com a string de conexão
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlite(connectionString));

// Construção da Aplicação: Constrói a aplicação com base nas configurações do builder.
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.RoutePrefix = string.Empty; // Serve o Swagger UI na raiz do aplicativo
    });
}

// Configuração do Pipeline de Requisição: Aqui você configura os middlewares que manipulam as requisições HTTP, como redirecionamento para HTTPS, autenticação e autorização.
app.UseHttpsRedirection();
app.UseAuthorization();

// Mapeamento de Endpoints: Define como as requisições são roteadas para os controladores.
app.MapControllers();

app.Run();
