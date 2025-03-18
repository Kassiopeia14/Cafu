using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel((context, serverOptions) =>
{
    serverOptions.ListenAnyIP(5005);
});;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/test", () =>
{
    return "TEST";
});

app.MapPost("/message", ([FromBody] string message) =>
{
    //string? message = JsonSerializer.Deserialize<string>(json);

    Console.WriteLine($"Received message: {message}");
});

app.Run();