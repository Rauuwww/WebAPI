using Microsoft.Extensions.Configuration;
using WebAPI;
using WebAPI.Middlewares;
using WebAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSqlServer<TareasContext> (builder.Configuration.GetConnectionString("cnTareas"));
builder.Services.AddScoped<IHelloWorldService, HelloWorldServices>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<ITareasService, TareasService>();
//builder.Services.AddScoped<IHelloWorldService>(p => new HelloWorldServices());
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//app.UseWelcomePage();
//app.UseTimeMiddleware();

app.MapControllers();

app.Run();
