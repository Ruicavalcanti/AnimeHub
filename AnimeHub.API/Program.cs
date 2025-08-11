using AnimeHub.CrossCutting.AppDependencies;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// 1️⃣ Configuração do logger antes de criar a aplicação
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug() // nível global (mínimo)
    .WriteTo.Console()    // tudo no console
    .WriteTo.File(
        "logs/animehub.log",
        rollingInterval: RollingInterval.Day,
        restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Error) // só erros no arquivo
    .CreateLogger();

// 2️⃣ Registrar Serilog no HostBuilder
builder.Host.UseSerilog(Log.Logger);

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "AnimeHub API",
        Version = "v1",
        Description = "API para gerenciamento de animes"
    });
});

var app = builder.Build();

// 3️⃣ Middleware de exceção global
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler(errorApp =>
    {
        errorApp.Run(async context =>
        {
            var exceptionHandlerPathFeature =
                context.Features.Get<Microsoft.AspNetCore.Diagnostics.IExceptionHandlerPathFeature>();

            if (exceptionHandlerPathFeature?.Error != null)
            {
                Log.Error(exceptionHandlerPathFeature.Error, "Erro não tratado capturado pelo middleware global");
            }

            context.Response.StatusCode = 500;
            await context.Response.WriteAsJsonAsync(new
            {
                error = "Ocorreu um erro interno. Tente novamente mais tarde."
            });
        });
    });
}
else
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "AnimeHub API V1");
    });
}

// 4️⃣ Registrar logging de requisições
app.UseSerilogRequestLogging();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
