using Microsoft.EntityFrameworkCore;
using DistribuidoraAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Adicionar o DbContext ao container de serviços
builder.Services.AddDbContext<FaturamentoContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Adicione o serviço de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

// Outros serviços
builder.Services.AddControllers();

// Construir a aplicação
var app = builder.Build();

// Configurar o pipeline de requisição HTTP
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

// Ative o CORS para permitir requisições de qualquer origem
app.UseCors("AllowAllOrigins");

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
