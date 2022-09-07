using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Ecommerce.Request;
using Ecommerce.Models;
#pragma warning disable CS8618 

namespace Ecommerce.Database
{
    public class Listas
    {
        private static Listas? listas;

        private static string FavoritesJsonPath = Directory.GetCurrentDirectory() + "/Database/Favorites.json";
        private static string ProductosJsonPath = Directory.GetCurrentDirectory() + "/Database/Productos.json";
        private static string ClientesJsonPath = Directory.GetCurrentDirectory() + "/Database/Clientes.json";
        private static List<Favorite> Favorites;
        private static List<Cliente> Clientes;
        private static List<Producto> Productos;
        private Listas()
        {

        }

        public static List<Favorite> getFavorites()
        {
            if (listas == null)
            {
                CreateLists();
            }
            return Favorites;
        }
        public static List<Producto> getProductos()
        {
            if (listas == null)
            {
                CreateLists();
            }
            return Productos;
        }
        public static List<Cliente> getClientees()
        {
            if (listas == null)
            {
                CreateLists();
            }
            return Clientes;
        }
        public static void  CreateLists()
        {
            if (listas == null)
            {
                listas = new Listas();

                string jsonFavorites = System.IO.File.ReadAllText(FavoritesJsonPath);
                string jsonProductos = System.IO.File.ReadAllText(ProductosJsonPath);
                string jsonClientees = System.IO.File.ReadAllText(ClientesJsonPath);

                Favorites = JsonConvert.DeserializeObject<List<Favorite>>(jsonFavorites);
                Productos = JsonConvert.DeserializeObject<List<Producto>>(jsonProductos);
                Clientes = JsonConvert.DeserializeObject<List<Cliente>>(jsonClientees);

                if (Favorites == null)
                {
                    Favorites = new List<Favorite>();
                }

                if (Productos == null)
                {
                    Productos = new List<Producto>();
                }

                if (Clientes == null)
                {
                    Clientes = new List<Cliente>();
                }
            }
        }

        public static void AddFavorite(Favorite Favorite)
        {
            Favorites.Add(Favorite);
            SaveFavorite(Favorite);
        }

        public static void AddProducto(Producto Producto)
        {
            Productos.Add(Producto);
            SaveProducto(Producto);
        }

        public static void AddCliente(Cliente Cliente)
        {
            Clientes.Add(Cliente);
            SaveCliente(Cliente);
        }
        public static void RemoveFavorite(Favorite Favorite)
        {
            Favorites.Remove(Favorite);
            SaveFavorite(null);
        }

        public static void RemoveProducto(Producto Producto)
        {
            Productos.Remove(Producto);
            SaveProducto(null);
        }

        public static void RemoveCliente(Cliente Cliente)
        {
            Clientes.Remove(Cliente);
            SaveCliente(null);
        }

        private static void SaveFavorite(Favorite? Favorite)
        {
            if (Favorite != null)
            {
                Favorites.Add(Favorite);
                Favorites.OrderBy(x => x.ID);
            }
            string temp = JsonConvert.SerializeObject(Favorites);
            System.IO.File.WriteAllText(FavoritesJsonPath, temp);
        }

        private static void SaveProducto(Producto? Producto)
        {
            if (Producto != null)
            {
                Productos.Add(Producto);
                Productos.OrderBy(x => x.ID);
            }

            string temp = JsonConvert.SerializeObject(Productos);
            System.IO.File.WriteAllText(ProductosJsonPath, temp);
        }


        private static void SaveCliente(Cliente? Cliente)
        {
            if (Cliente != null)
            {
                Clientes.Add(Cliente);
                Clientes.OrderBy(x => x.ID);
            }

            string temp = JsonConvert.SerializeObject(Clientes);
            System.IO.File.WriteAllText(ClientesJsonPath, temp);
        }


        public static List<Producto>? GetProductos(GetRequest request)
        {
            if (Productos.Count > 0)
            {
                List<Favorite> FavoritosTemp = Favorites.FindAll(x => x.IDCliente == request.IDCliente);
                if(FavoritosTemp.Count > 0)
                { 
                    List<Producto> ProductosFavoritos = new List<Producto>();
                    foreach(Favorite favorite in FavoritosTemp)
                    {
                        ProductosFavoritos.Add(Productos.Find(x=> x.ID ==  favorite.IDProducto));                                                
                    }
                    return ProductosFavoritos;
                }
            }

            return null;
        }

        public static bool Exists() => Productos.Count > 0 && Clientes.Count > 0 && Favorites.Count > 0;

        public static Producto? GetProducto(string IDProducto) => Productos.Find(x => x.ID == IDProducto);
        public static Cliente? GetCliente(string IDCliente) => Clientes.Find(x => x.ID == IDCliente);
        public static Favorite? GetFavorite(string IDProducto, string IDCliente) => Favorites.Find(x => x.IDCliente == IDCliente && x.IDProducto == IDProducto);

        public static List<string> GetErrorMessages()
        {
            List<string> messages = new List<string>();

            bool ProductoError =  Productos.Count == 0; 
            bool ClienteError =  Clientes.Count == 0;
            bool FavoriteError = Favorites.Count == 0;

            if(ProductoError) messages.Add("No existen productos, por favor revise los productos cargados.");
            if(ClienteError) messages.Add("No existen clientes, por favor revise los clientes cargados.");
            if(FavoriteError) messages.Add("No existen favoritos añadidos.");

            return messages;            
        }
    }
}