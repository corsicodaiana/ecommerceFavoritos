using Ecommerce.Database;
using Ecommerce.Models;
using Ecommerce.Response;
using Ecommerce.Request;

namespace Ecommerce.Services
{
    public static class FavoriteService
    {
        public static GetResponse GetProductos(GetRequest request)
        {
            GetResponse response = new GetResponse();
            response.Messages = new List<string>();
            if (Listas.Exists())
            {
                response.favorites = Listas.GetProductos(request);
                response.StateExecution = response.favorites != null && response.favorites.Count > 0;

                if(response.StateExecution)
                {
                    response.Messages.Add("Se ha retornado los elementos en favorito.");
                }
                else
                {
                    response.Messages.Add("No se ha encontrado productos favoritos para ese cliente");
                }
            }
            else
            {
                response.StateExecution = false;
                response.Messages = ErrorMessage();
            }


            return response;
        }

        public static PostResponse PostFavorite(PostRequest request)
        {
            PostResponse response = new PostResponse();
            response.Messages = new List<string>();

            if (Listas.Exists())
            {
                response.producto = Listas.GetProducto(request.IDProducto);
                var cliente = Listas.GetCliente(request.IDCliente);
                response.StateExecution = response.producto != null && cliente != null;
                if (response.StateExecution)
                {
                    Favorite favorite = new Favorite();
                    favorite.IDCliente = request.IDCliente;
                    favorite.IDProducto = request.IDProducto;
                    favorite.FechaCreado = DateTime.Today;
                    Listas.AddFavorite(favorite);
                }
                else
                {
                    response.Messages.Add("Oops, parece que no se ha encontrado el producto");
                }
            }
            else
            {
                response.StateExecution = false;
                response.Messages = ErrorMessage();
            }

            return response;
        }

        public static DeleteResponse DeleteFavorite(DeleteRequest request)
        {
            DeleteResponse response = new DeleteResponse();
            response.Messages = new List<string>();

            if (Listas.Exists())
            {
                var favorite = Listas.GetFavorite(request.IDProducto, request.IDCliente) ;
                response.StateExecution = favorite != null;

                if(response.StateExecution)
                {
                    Listas.RemoveFavorite(favorite);   
                }
                else
                {
                    response.Messages.Add("El cliente no tiene ese articulo en favoritos.");
                }
            }
            else
            {
                response.StateExecution = false;
                response.Messages = ErrorMessage();
            }
            return response;
        }

        private static List<string> ErrorMessage() => Listas.GetErrorMessages();
    }
}