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

/*
    No contexto do ASP.NET Core, builder.Services.AddCors() é usado para configurar as políticas de CORS (Cross-Origin Resource Sharing) no seu aplicativo.

    CORS é um mecanismo de segurança que permite ou restringe requisições feitas por um domínio (origem) diferente do domínio onde o servidor está hospedado. Isto é importante para aplicações web que precisam interagir com APIs hospedadas em domínios diferentes.

    Quando você usa AddCors(), está dizendo ao ASP.NET Core para adicionar o serviço CORS à coleção de serviços da aplicação, permitindo que você configure políticas de CORS específicas.

    Aqui está um exemplo básico de como configurar uma política CORS:

    csharp
    var builder = WebApplication.CreateBuilder(args);

    // Adiciona o serviço CORS
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowSpecificOrigin",
            builder => builder.WithOrigins("https://example.com")
                            .AllowAnyHeader()
                            .AllowAnyMethod());
    });

    var app = builder.Build();

    // Usa a política CORS configurada
    app.UseCors("AllowSpecificOrigin");

    app.MapGet("/", () => "Hello World!");

    app.Run();
    Neste exemplo, o serviço CORS é configurado para permitir requisições apenas do domínio https://example.com, mas permitindo quaisquer cabeçalhos e métodos HTTP.
*/

builder.Services.AddCors();

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

app.UseCors(access => access.AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowAnyOrigin()
);

// Mapeamento de Endpoints: Define como as requisições são roteadas para os controladores.
app.MapControllers();

app.Run();
