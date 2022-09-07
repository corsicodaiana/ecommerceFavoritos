using Microsoft.AspNetCore.Mvc;
using Ecommerce.Models;
using Ecommerce.Response;
using Ecommerce.Request;
using Ecommerce.Services;

#pragma warning disable CS1998 
namespace Ecommerce.Controllers;

[ApiController]
[Route("[controller]")]
public class FavoriteController : ControllerBase
{
    private readonly ILogger<FavoriteController> _logger;

    public FavoriteController(ILogger<FavoriteController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetFavorites")]
    public async Task<GetResponse> Get([FromQuery] GetRequest request) => FavoriteService.GetProductos(request);

    [HttpPost(Name = "PostFavorite")]     
    public async Task<PostResponse> Post([FromBody] PostRequest request) => FavoriteService.PostFavorite(request);

    [HttpDelete(Name ="DeleteFavorite")]
    public async Task<DeleteResponse> Delete([FromBody] DeleteRequest request) => FavoriteService.DeleteFavorite(request);
}
