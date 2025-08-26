using Infrastructure.Store.Persistence;
using Core.Store.Application.UseCases.People; // <- IMPORTANTE

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Persistence (EF + Oracle + Repo)
builder.Services.AddPersistence(builder.Configuration);

// Application (registre explicitamente seus casos de uso)
builder.Services.AddScoped<GetAllPeople>();
builder.Services.AddScoped<CreatePerson>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.Run();
