using Entities;
using Repository;
using Service;
using ex1.Controllers;
var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddScoped<IuserService, userService>();
builder.Services.AddScoped<IuserRepository, userRepository>();

builder.Services.AddScoped<IcategoryRepository, categoryRepository>();
builder.Services.AddScoped<IcategoryService, categoryService>();

builder.Services.AddScoped<IproductRepository ,productRepository>();
builder.Services.AddScoped<IproductService, productService>();

builder.Services.AddScoped<IorderRepository, orderRepository>();
builder.Services.AddScoped<IordersService, ordersService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<StoreDataBase2Context>();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
