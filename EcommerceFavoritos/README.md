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

<p>Para ver la documentación más en tiempo real o por sí esta esta desactualizada, se puede ver <a href = "https://docs.google.com/document/d/1pgvbJH-FUGPf-FYwet31InNrEFcPjDBXCVLfEEpbf5E/edit?usp=sharing">link</a>.</p>
</div>
