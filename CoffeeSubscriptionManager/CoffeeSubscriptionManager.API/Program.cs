using CoffeeSubscriptionManager.DAL;
using CoffeeSubscriptionManager.DAL.Interfaces;
using CoffeeSubscriptionManager.Models;
using CoffeeSubscriptionManager.Repository;
using CoffeeSubscriptionManager.Repository.Interfaces;
using CoffeeSubscriptionManager.Services;
using CoffeeSubscriptionManager.Services.Interfaces;
using CoffeeSubscriptionManager.Services.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICoffeeSubscriptionContext, CoffeeSubscriptionContext>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IGenericRepository<Customer>, CustomerRepository>();
builder.Services.AddScoped<ICustomerValidator, CustomerValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
