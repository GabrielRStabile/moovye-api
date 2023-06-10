using DotNetEnv;
using Movye.Api.IoC;
using Movye.Api.Extensions;

Env.Load();

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterServices(builder.Configuration);
builder.Services.AddAuthentication(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddApiProblemDetails();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors();
builder.Services.AddVersioning();
builder.Services.AddSwagger();
builder.Services.AddRouting(options => options.LowercaseUrls = true);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();

app.UseCors(
    builder =>
        builder.SetIsOriginAllowed(_ => true).AllowAnyMethod().AllowAnyHeader().AllowCredentials()
);

app.MapControllers();

app.Run();
