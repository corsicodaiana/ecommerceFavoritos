using System.Collections.Generic;
#pragma warning disable CS8618 
namespace Ecommerce.Response
{
    public abstract class Response
    {
        public bool StateExecution {get; set;}
        public List<string> Messages {get; set;}
    }        
}