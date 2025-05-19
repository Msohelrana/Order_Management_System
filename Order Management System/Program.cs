using System.Data.Common;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Order_Management_System.Controllers;
using Order_Management_System.Interfaces;
using Order_Management_System.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IOrderService,OrderService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddAutoMapper(typeof(Program));

//This is for database connection
//builder.Services.AddDbContext<AppDbContext>(options =>
//{
//    options.UseNpgsql(builder.Configuration
//    .GetConnectionString("DefaultConnection"));
//});
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

// app.MapGet("/hello", () =>
// {
//     var response = new
//     {
//         Message = "This is a json object",
//         Success = true
//     };

//     // return response; // response is an object
//     return Results.Ok(response);
// });   //app.MapGet("url or endpoints",methode);ei url a hit korle ja return korte cai seta ei method a likhbo
// app.MapGet("/", () =>
// {
//     return "Get Methode: This root derectory";
// });

// app.MapPost("/hello", () =>
// {
//     // return "POST method: this is for post method"; //post method browser theke test kora jay na
//     return Results.Created(); // 201
// });

// app.MapDelete("/hello", () =>
// {
//     // return "DELETE Methode: This is delete method";
//     return Results.NoContent(); //status code 204
// });
// app.MapPut("/hello", () =>
// {
//     // return "PUT Methode: This is PUT method";
//     return Results.NoContent();
// });

// //For return html code
// app.MapGet("/html", () =>
// {
//     return Results.Content("<h1> Hello World!</h1>", "text/html");
// });





app.MapControllers();

app.Run();

// public record Product(int Id, string Name, decimal Price);//This is DTO(One kinde of structure)



//CRUD(Create,Read,Update,Delete) for Catagory of product
// POST: for create a new catagory
// GET : For show(Read) a catagory
// PUT: For update a catagory
// DELETE; for delete a catagory

