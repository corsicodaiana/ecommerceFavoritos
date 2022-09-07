using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

#pragma warning disable CS8618 
namespace Ecommerce.Request
{
    public class PostRequest
    {
        [Required(ErrorMessage = "El ID del producto es necesario, por favor ingreselo.")]
        [DataType(DataType.Text)]
        public string IDProducto { get; set; }
        [Required(ErrorMessage = "El ID del producto es necesario, por favor ingreselo.")]
        [DataType(DataType.Text)]
        public string IDCliente { get; set; }
    }
}