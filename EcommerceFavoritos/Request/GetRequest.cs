using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

#pragma warning disable CS8618 
namespace Ecommerce.Request
{
    public class GetRequest
    {
        [Required(ErrorMessage = "El ID del cliente es necesario, por favor ingreselo.")]   
        [DataType(DataType.Text)]  
        public string IDCliente {get; set;}
    }
}