<h1>Trabajo Ecommerce - Favoritos</h1>

<div>
<h2>Sinopsis</h2>
<p>La sección favoritos es una categoría especial en la que el cliente puede guardar los productos de la tienda en una lista, lo que le facilita mantenerse al tanto de todos los productos que desea o tener una lista de deseos para futuras compras.</p>
</div>

<div>
<h2>Requerimientos</h2>
<ul>
    <li>El sistema debe poder marcar un producto del catálogo como favorito.</li>
    <li>El sistema debe poder eliminar un producto de la lista de favoritos.</li>
    <li>El sistema debe poder mostrar un listado de favoritos.</li>
    <li>Si un cliente desea comprar un producto que no tiene stock y lo agrega a la lista de deseos el sistema debe notificarle cuando el producto se encuentre disponible.</li>
    <li>El sistema debe notificar al cliente cuando uno de los productos que tiene como favorito se encuentra en oferta.</li>
    <li>El sistema debe notificar al cliente después de x tiempo que tiene como favorito un producto. notificarOlvido()</li>
</ul>
</div>

<div>
<h2>DTO</h2>
<ul>
    <li>IDProducto - string</li>
    <li>IDcliente - string</li>
    <li>FechaCreado - string (Esta en un cadena de texto mediante <a href ="https://www.ionos.com/digitalguide/websites/web-development/iso-8601/#c226050">ISO8601</a>).</li>
    <li>FechaNotificado - string (Este se añadirá en la segunda iteración).</li>
<ul>
</div>

<div>
<h2>Llamadas a la API</h2>

<p>Se hizo un routing para que al poner Localhost:xyz/Favorite/(Nombre de metodo) se pueda llamar directamente.</p>

<h3>GetFavoritos(string IDCliente)</h3>

|                                  Caso ideal                                 |                                       Caso alternativo                                      |
|:---------------------------------------------------------------------------:|:-------------------------------------------------------------------------------------------:|
| 1 - El caso de uso comienza cuando un Cliente llama a la API.               |                                                                                             |
| 2 - Se verifica la autenticidad de la cookie, esta es autentica y procede.  | 2.1 - No se puede verificar la autenticidad de la cookie, se tira una excepción, Fin de CU. |
| 3 - Se añade a una lista los productos que el cliente agrego anteriormente. | 3.1 - El cliente no tiene ningún producto agregado se muestra un mensaje.                   |
| 4 - Se retorna la lista de productos y fin de CU.                           |                                                                                             |
| 5 - Fin de CU.                                                              |                                                                                             |

<h3>AddFavorito(string IDCliente, string IDProducto)</h3>

|                                 Caso Ideal.                                |                                           Caso Alternativo                                           |
|:--------------------------------------------------------------------------:|:----------------------------------------------------------------------------------------------------:|
| 1 - El caso de uso comienza cuando un Cliente llama a la API.              |                                                                                                      |
| 2 - Se verifica la autenticidad de la cookie, esta es autentica y procede. | 2.1 - No se puede verificar la autenticidad de la cookie, se muestra un mensaje de error, Fin de CU. |
| 3 - Se verifica la existencia del producto, este existe.                   | 3.1 - No se puede verificar la existencia del producto, se muestra un mensaje de error, Fin de CU.   |
| 4 - Se agrega a una db el objeto de favoritos.                             |                                                                                                      |
| 5 - Fin de CU.                                                             |                                                                                                      |
<h3>RemoveFavorito(string IDCliente, string IDProducto)</h3>

|                                 Caso Ideal.                                |                                           Caso Alternativo                                           |
|:--------------------------------------------------------------------------:|:----------------------------------------------------------------------------------------------------:|
| 1 - El caso de uso comienza cuando un Cliente llama a la API.              |                                                                                                      |
| 2 - Se verifica la autenticidad de la cookie, esta es autentica y procede. | 2.1 - No se puede verificar la autenticidad de la cookie, se muestra un mensaje de error, Fin de CU. |
| 3 - Se verifica la existencia del producto, este existe.                   | 3.1 - No se puede verificar la existencia del producto, se muestra un mensaje de error, Fin de CU.   |
| 4 - Se borra de la db.                                                     |                                                                                                      |
| 5 - Fin de CU.                                                             |                                                                                                      |
</div>

   
    
<h3>Agregar árticulo a lista de favoritos.</h3>
<img src = "https://user-images.githubusercontent.com/43465958/200078667-d5c8bf88-df53-4142-81ba-d064e7a75d51.png">
    
<h3>Eliminar árticulo de la lista de favoritos.</h3>
<img src="https://user-images.githubusercontent.com/43465958/200078574-f3dab51d-10e9-426a-9751-f28ed3fb772d.png">
    
<h3>Mostrar lista de Favoritos.</h3>
<img src="https://user-images.githubusercontent.com/43465958/200078286-109f6a23-bee3-4980-884d-6ce2a1d0117c.png">



<div>
<h2>Testing:</h2>
A la hora de testear, primero se debe bajar el <a href ="https://dotnet.microsoft.com/en-us/download">dotnet sdk</a>, después de esto abrir el proyecto en la carpeta <b>“EcommerceFavoritos” </b>, y desde ahi ejecutar el comando <b>“dotnet run”</b>.

Después de esto se pueden probar de dos maneras, La forma más simple es cuando se testea mediante interfaz grafica, donde podemos gestionar los favoritos mediante una pagina web.
Y la otra manera es testeando los metodos mediante Swagger u otro tester de APIs (ya sea Postman o Insomnia por ejemplo).

Sí se testea mediante esta segunda manera se deben saber los siguientes atributos, hay 4 <a href="https://github.com/corsicodaiana/ecommerceFavoritos/blob/main/EcommerceFavoritos/Database/Clientes.json">personas precargadas</a> con numero de identificador 1,2,3,4.

También existen 6 <a href ="">productos precagados</a> con nombre producto1, producto2, producto3, producto4, producto5 y producto6. 
Y por ultimo, dejamos precargados unos <a href= "https://github.com/corsicodaiana/ecommerceFavoritos/blob/main/EcommerceFavoritos/Database/Favorites.json">favoritos</a> entre los usuarios y los productos.
</div>

