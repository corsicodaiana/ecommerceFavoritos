using Ecommerce.Models;
using System.Collections.Generic;

namespace Ecommerce.Response
{
    public class GetResponse : Response
    {
        public List<Producto>? favorites {get; set;}
    }
}