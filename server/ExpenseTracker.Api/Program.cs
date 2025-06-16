using ExpenseTracker.Api;
using ExpenseTracker.Api.Infrastructure;
using ExpenseTracker.Application;
using ExpenseTracker.Infrastructure;
using ExpenseTracker.Infrastructure.Common.Initializers;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddPresentation()
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// app.UseAuthentication(); // якщо згодом буде
// app.UseAuthorization();  // якщо буде [Authorize]

app.MapControllers();

await ExpenseTrackerInitializer.SeedCategoriesDataAsync(app);

app.Run();
