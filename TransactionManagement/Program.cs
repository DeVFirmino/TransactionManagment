using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using TransactionManagment.DbContext;
using TransactionManagment.Interfaces;
using TransactionManagment.Repository;
using TransactionManagment.Services;
using TransactionManagment.Validation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IFinancialGoalRepository, FinancialGoalRepository>();
builder.Services.AddScoped<IFinancialGoalService, FinancialGoalService>();
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddValidatorsFromAssemblyContaining<CreateTransactionValidator>(); 
//That gets all validators to 
//work without needing to  validate others

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
// builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer
    (builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddFluentValidationAutoValidation();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();