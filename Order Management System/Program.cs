using System.Data.Common;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Order_Management_System.Controllers;
using Order_Management_System.data;
using Order_Management_System.Interfaces;
using Order_Management_System.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IOrderService,OrderService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddAutoMapper(typeof(Program));

//his is for database connection
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseMySql(builder.Configuration
    .GetConnectionString("DefaultConnection"),
    new MySqlServerVersion(new Version(8, 0, 42)));
});
// Add services to the controller
builder.Services.AddControllers();
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.InvalidModelStateResponseFactory = context =>
    {
        var errors = context.ModelState
               .Where(e => e.Value != null && e.Value.Errors.Count > 0)
               .SelectMany(e => e.Value!.Errors.Select(e => e.ErrorMessage)).ToList();

        return new BadRequestObjectResult(ApiResponse<object>
        .ErrorResponse(errors, 400, "Validation failed!"));
    };
});
// .ConfigureApiBehaviorOptions(options =>
// {
//     options.SuppressModelStateInvalidFilter = true;//Disable  automatic Model validation  response
// });
builder.Services.AddEndpointsApiExplorer();// for neccessary swager tool generation
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

// public record Product(int Id, string Name, decimal Price);//This is DTO(One kinde of structure)



//CRUD(Create,Read,Update,Delete) for Catagory of product
// POST: for create a new catagory
// GET : For show(Read) a catagory
// PUT: For update a catagory
// DELETE; for delete a catagory

