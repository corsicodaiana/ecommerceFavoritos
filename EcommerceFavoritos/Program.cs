using Ecommerce.Database;
using Ecommerce.Services;
using Ecommerce.Request;
using Ecommerce.Response;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.UseDefaultFiles();

app.UseStaticFiles();

//Response.AppendHeader("Access-Control-Allow-Origin", "*");

Listas.CreateLists();

//TODO: trae los favoritos de un cliente 
app.MapGet("Favorite/{IDCliente}", (string IDCliente) =>
{
    var request = new GetRequest();
    request.IDCliente = IDCliente;
    return FavoriteService.GetProductos(request);
});

app.MapPut("addFavorite/{IDCliente}/{IDProducto}", (string IDCliente, string IDProducto) =>
{
    var request = new PostRequest();
    request.IDCliente = IDCliente;
    request.IDProducto = IDProducto;

    return FavoriteService.PostFavorite(request);
});

app.MapDelete("deleteFavorite/{IDCliente}/{IDProducto}", (string IDCliente, string IDProducto) =>
{
    var request = new DeleteRequest();
    request.IDCliente = IDCliente;
    request.IDProducto = IDProducto;
    return FavoriteService.DeleteFavorite(request);
});

app.Run();
