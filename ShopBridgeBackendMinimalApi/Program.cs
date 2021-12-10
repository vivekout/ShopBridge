using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ShopBridgeBackendMinimalApi.Data;
using ShopBridgeBackendMinimalApi.Models;
using ShopBridgeBackendMinimalApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<ProductContext>(options =>
       options.UseSqlServer(builder.Configuration.GetConnectionString("ShopBridgeConnectionString")));

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "ShopBrige Products API",
        Description = "The Products you like",
        Version = "v1"
    });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ShopBrige Products API V1");
});


app.MapGet("/", () => "Hello World!");

app.MapGet("/products", async (IProductService _service) => await _service.Get());

app.MapGet("/product/{id}", async (IProductService _service, int id) =>
{
    var product = await _service.Get(id);
    if (product is null)
    {
        return Results.NotFound();
    }
    return Results.Ok(product);
});

app.MapPost("/product", async (IProductService _service, Product product) =>
{
    var createdProduct = await _service.Create(product);
    return Results.Created($"/product/{createdProduct.Id}", product);
});

app.MapPut("/product/{id}", async (IProductService _service, Product updateProduct, int id) =>
{
    var product = await _service.Update(updateProduct, id);
    if (product is null) return Results.NotFound();
    
    return Results.NoContent();
});

app.MapDelete("/product/{id}", async (IProductService _service, int id) =>
{
    var product = await _service.Remove(id);
    if (product is null)
    {
        return Results.NotFound();
    }
    return Results.Ok();
});

app.Run();
