using ListaTarefas.Entities;
using ListaTarefas.Mappers;
using ListaTarefas.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

var conectionString = builder.Configuration.GetConnectionString("TarefaEventoCs");
builder.Services.AddDbContext<TarefasDBContext>(o => o.UseSqlServer(conectionString));

builder.Services.AddAutoMapper(typeof(TarefaEventoProfile));

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Lista de Tarefas: ",
        Contact = new OpenApiContact 
        { 
            Name = "Lucas Leonette da Cruz",
            Email = "lucas_leonette@hotmail.com"
        }
    });
    var xmlFile = "ListaTarefa.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        
    });
    
}

app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();

app.Run();
