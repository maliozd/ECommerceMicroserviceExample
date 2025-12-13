using BuildingBlocks.Behaviors;
using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCarter();

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
});

builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);

var connectionString = builder.Configuration.GetConnectionString("DbConnectionString")!;
builder.Services.AddNpgsqlDataSource(connectionString);

builder.Services.AddMarten(options =>
{
    options.DatabaseSchemaName = "public";
})
.UseLightweightSessions()
.UseNpgsqlDataSource();

var app = builder.Build();

app.MapCarter();

app.UseExceptionHandler(builder =>
{
    builder.Run(async context =>
    {
        var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;
        if (exception is null)
            return;

        var exceptionDetail = new
        {
            Message = exception.Message,
            ExceptionType = exception.GetType().Name,
            StackTrace = exception.StackTrace,
        };
        context.Response.ContentType = "application/problem+json";
        context.Response.StatusCode = 500;
        await context.Response.WriteAsJsonAsync(exceptionDetail);

    });
});

app.Run();