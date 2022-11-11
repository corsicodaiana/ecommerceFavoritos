<h1>Testing</h1>

<div>
<h2>Testing Devolución:</h2>

| N°  | Acción | Valores Ingresados  | Resultado Esperado | Resultado Observado | ¿Pasó la prueba?  | Tipo de Error | Prioridad |  
| ------------- | ------------- | ------------- | ------------- | ------------- | ------------- | ------------- | ------------- |
| 1  | Formato de los valores en la sección precio.  | -  | $7.500 o $7.500,00  | 7550,0000  | No   |    UI     | Bajo          |
| 2  | Falta de verificación en Tipo  | asdasdasda  | Tipo de Dato erroneo  | asdasdasda  | No  | Funcional     | Alto          |
| 3  | Falta de verificación en Motivo| asdasdasda  | Tipo de Dato erroneo  | asdasdasda  | No  | Funcional     | Alto          |
| 4  | Formato de caracteres especiales| El producto tiene un problema o está incompleto”  | El producto tiene un problema o está incompleto”  | “El producto tiene un problema o est� incompleto”  | No | Integridad de datos  | Alto |
| 5  | Limitación de cantidad de caracteres en comentario  | Valor menor a 20 y mayor a 5000  | Advertencia de valor esta fuera de rango.  | Advertencia de valor esta fuera de rango.  | Si  | -  | -  |
| 6  | Verificación de Tipo con espacio  | " "  | No puede dejar el campo vacio  | No puede dejar el campo vacio  | Si  | -  | - |
| 7  | Verificación de Motivo con espacio  | " "  | No puede dejar el campo vacio  | No puede dejar el campo vacio  | Si  | -  | - |
| 8  | Salir de la vista Reclamo  | Se hace click en "Salir" desde la vista reclamo  | Volver al menú principal  | Falla el renderizado de la pantalla principal, haciendo una fusión de vistas  | No  | UI | Alto  |
| 9  | Autogeneración de Identificadores de reclamos  | "Primera carga"  | ID = 1  | ID = 46142213  | No | Persistencia  | Media  |
| 10 | Dos reclamos con la misma compra.  | Cargar dos reclamos con la misma compra. | Reclamar la compra 16 de nuevo.  | Esta compra ya tiene un reclamo realizado  | Si | - | - |
| 11 | No se cierra el programa.  | No se pude cerrar el programa salvo que sea administrador de tarea.  | Deberia de haber un botón para cerrar el programa, solamente se deja de renderizar.  | A veces queda funcionando y otras veces no.  | No | Funcionalidad | Urgente |
</div>

<div>
<h2>Testing Newsletter:</h2>

| N°  | Acción | Valores Ingresados  | Resultado Esperado | Resultado Observado | ¿Pasó la prueba?  | Tipo de Error | Prioridad |  
| ------------- | ------------- | ------------- | ------------- | ------------- | ------------- | ------------- | ------------- |
| 1  | Recibir información de promociones con fechaFinal anterior a la fecha de inicio.  | Fecha inicio: [ 2022, 11, 9 ] Fecha final: [ 2021, 10, 10 ]  | Deberia mostrar un error de que la fechas no corresponden  | Envió el correo normalmente  | No   |    Funcionalidad     | Alto |
| 2  | Recibir información de promociones sin descripción  | Descripción: null  | Deberia mostrar un error de que falta información  | Envió el correo normalmente  | No  | Funcional     | Alto          |
| 3  | Cambiar el contenido de la descripción en la interfaz | Descripción: Descuento en ropa de mujer  | Debería mostrar un error de que falta información  | Descripción: Descuento en ropa de hombre  | No  | Funcional     | Alto          |
| 4  | Cambiar el contenido del asunto en la interfaz | Asunto: prueba  | Debería mandarse el correo con el nuevo asunto  | Asunto: descuento  | No | Funcionalidad  | Alto |
| 5  | Cambiar el email de destino en la interfaz  | Email: corsico.daiana@gmail.com.  | Debería mandarse el correo al nuevo destino  | Destino: dai3793@gmail.com  | No  | Funcional | Alto  |
| 6  | Recibir informacion de promociones sin fechaInicio  | Fecha inicio: [ ] | Debería mostrar un error de que falta información  | No ejecuta | Si  | -  | - |
| 7  | Recibir informacion de promociones sin fechaFinal   | Fecha final : [ ] | Debería mostrar un error de que falta información  | No ejecuta | Si  | -  | - |
| 8  | Generar dos promociones con la misma fecha. | {"descripcion": "Promocion 2x1","fechaFinal": [ 2022, 10, 10 ],"fechaInicio": [ 2022, 11, 9 ],"id": 0,"titulo": "promo"}, {"descripcion": "Descuento en ropa de hombre","fechaFinal": [ 2023, 10, 10 ],"fechaInicio": [ 2022, 11, 9 ],"id": 1,"titulo": "descuento"} | Deberia enviar ambas promociones.  | Envia ambas promociones.  | Si  | - | - |
| 9  | Generar un Newsletter sin asunto  | Asunto: ''  | Debería mostrar un error de que falta información  | Envía el correo normalmente  | No | Funcional  | Alto  |
| 10 | Generar un Newsletter sin descripción  | Descripcion: '' | Debería mostrar un error de que falta información  | Envía el correo normalmente | No | Funcional | Alto |
| 11 | Enviar un Newsletter a un usuario sin dirección de mail  | email:""  | Debería mostrar un error de que falta la direccion de correo para enviar el mensaje | Muestra un error: datos incorrectos  | Si | - | - |
| 12 | Enviar un Newsletter a un usuario que no este subscripto  | Por la logica del programa no se puede realizar esta prueba  | Debería mostrar un error de que el usuario no esta subscripto al newsletter  | Por la lógica del programa no se puede realizar esta prueba  | Si  | - | - |
| 13 | Enviar un Newsletter a un correo invalido  | email:"dai3793" email:"dai3793@pepito"  | Debería mostrar un error de que el correo no existe | Muestra un error: datos incorrectos | Si | - | - |
| 14 | Cambiar el estado con un estado no booleano.  | "aceptaNovedades": 14 | Debería mostrar un error de que el tipo de dato no es correcto  | No ejecuta | No | - | - |
| 15 | Enviar un Newsletter con una descripcion extensa  | Cantidad de caracteres: 170482 | Debería mostra un alerta de tamaño excedido en lo descripción. | Envía el correo normalmente.  | No | Funcionalidad | Media |
</div>
