using GestaoResiduos.Data;
using GestaoResiduos.Models;
using GestaoResiduos.Services;
using GestaoResiduos.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseInMemoryDatabase("InternalDatabase"));

var key = Encoding.ASCII.GetBytes(builder.Configuration["JwtConfig:Secret"]);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

builder.Services.AddAuthorization();

builder.Services.AddScoped<INotificacaoService, NotificacaoService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<ApplicationDbContext>();

    dbContext.Notificacoes.AddRange(
        new NotificacaoDto
        {
            Id = 1,
            Titulo = "Rota otimizada definida para coleta de lixo",
            Mensagem = "A rota dos caminhões de coleta de lixo foi otimizada para reduzir o tempo de coleta e melhorar a eficiência.",
            DataEnvio = DateTime.UtcNow,
            Enviada = true
        },
        new NotificacaoDto
        {
            Id = 2,
            Titulo = "Agendamento automático de coleta ativado",
            Mensagem = "A coleta de lixo foi agendada automaticamente com base na capacidade atual dos recipientes de lixo.",
            DataEnvio = DateTime.UtcNow,
            Enviada = false
        },
        new NotificacaoDto
        {
            Id = 3,
            Titulo = "Lembrete: Dia de coleta de resíduos",
            Mensagem = "Hoje é dia de coleta de resíduos. Por favor, separe corretamente o lixo reciclável do não reciclável.",
            DataEnvio = DateTime.UtcNow,
            Enviada = false
        }
    );

    dbContext.SaveChanges();

}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
