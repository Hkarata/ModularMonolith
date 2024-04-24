using Carter;
using ModularMonolith.Books;
using System.Reflection;
using ModularMonolith.Users;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

List<Assembly> mediatRAssemblies = [typeof(Program).Assembly];

builder.Services.AddBookModuleServices(builder.Configuration, mediatRAssemblies);
builder.Services.AddUsersModuleServices(builder.Configuration, mediatRAssemblies);

builder.Services.AddMediatR(configuration =>
    configuration.RegisterServicesFromAssemblies(mediatRAssemblies.ToArray()));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapCarter();

app.Run();