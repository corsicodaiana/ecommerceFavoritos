using System;
#pragma warning disable CS8618 

namespace Ecommerce.Models
{
    public class Favorite
    {
        public string ID {get ; set;}
        public string IDCliente {get; set;}
        public string IDProducto {get; set;}
        public DateTime FechaCreado {get; set;}
        public DateTime? FechaNotificado {get; set;}
    }
}