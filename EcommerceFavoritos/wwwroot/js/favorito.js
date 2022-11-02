
$(".addFavorite").on({
    "click": async function () {
        var myHeaders = new Headers();
        myHeaders.append("Content-Type", "application/json");

        var requestOptions = {
            method: "PUT",
            redirect: 'follow',
            headers: {"Content-type":"application/json;charset=utf-8"}
        };

        IDProducto = this.id;
        IDCliente = 2;
        respuesta = await fetch("https://localhost:7066/addFavorite/"+IDCliente+"/"+IDProducto, requestOptions)
        .then(response => response.json())
        .then(function (result){
            console.log(result.producto.name);
            alert(result.producto.name+' agregado a Favoritos');
            //TODO: agregar un alert
        })
        .catch(error => console.log('error', error));
    }
});

async function deleteFavorite(IDFavorito,IDCliente){

    var myHeaders = new Headers();
    myHeaders.append("Content-Type", "application/json");

    var requestOptions = {
        method: "DELETE",
        redirect: 'follow',
        headers: {"Content-type":"application/json;charset=utf-8"}
    };

    respuesta = await fetch("https://localhost:7066/deleteFavorite/"+IDCliente+"/"+IDFavorito, requestOptions)
    .then(response => response.json())
    .then(function (result){
        getFavorite();
    })
    .catch(error => console.log('error', error));

}

async function getFavorite(){
    var myHeaders = new Headers();
    myHeaders.append("Content-Type", "application/json");

    var requestOptions = {
        method: "GET",
        mode:"no-cors",
        redirect: 'follow',
        headers: {"Content-type":"application/json;charset=utf-8"}
    };

    IDCLiente = 2;
    respuesta = await fetch("https://localhost:7066/Favorite/"+IDCLiente, requestOptions)
    .then(response => response.json())
    .then(function (result){
        //Tabla para mostrar favoritos
        var datosTabla = [];

        result.favorites.forEach(function (favorito, index) {
            //descripcion
            //precio $$
            //accion eliminar
            if(favorito){
                switch (favorito.id) {
                    case "producto1":
                        imgName = 'one';
                        break;
                    case "producto2":
                        imgName = 'two';
                        break;
                    case "producto3":
                        imgName = 'three';
                        break;
                    case "producto4":
                        imgName = 'four';
                        break;
                    case "producto5":
                        imgName = 'five';
                        break;
                    case "producto6":
                        imgName = 'six';
                        break;   
                    default:
                        imgName = '';
                        break;
                }
                
                img = '';
                if(imgName != ''){
                    img = '<img src="images/cart/'+imgName+'.png" alt=""></img>';
                }
               
                iconoAccion = '<a onclick="deleteFavorite(\''+favorito.id+'\','+IDCLiente+')" id="'+favorito.id+'" style="cursor:pointer;"><i class="fa fa-times"></i></a>'
                //'<a title="Eliminar" onclick="eliminarActividad('+index+')"><i class="fas fa-trash" style="font-size:1.6em;color:orangered"></i></a>';
                var fila = {
                    imagen : img,
                    descripcion : favorito.name,
                    precio : '$$',
                    accion : iconoAccion,
                };
    
                
                datosTabla.push(fila);
            }
            
        });

        var favorites = new Tabulator("#favoritesTable", {
            virtualDom:true,
            virtualDomBuffer:300,
            layout:"fitColumns",
            responsiveLayout:false,
            pagination:"local",
            paginationSize:4,
            movableColumns:true,
            printAsHtml:true,
            columns:[
                {title:"Item", field:"imagen",formatter:"html", align:"center", resizable:true},
                {title:"", field:"descripcion",  align:"center",resizable:true},
                {title:"Price", field:"precio", width:'15%',  align:"center",resizable:true}, 
                {title:"", field:"accion",formatter:"html",width:'10%',  align:"center",resizable:true}
            ],
            locale:"es-es"
        });
    
        favorites.setData(datosTabla);
    })
    .catch(error => console.log('error', error));
}