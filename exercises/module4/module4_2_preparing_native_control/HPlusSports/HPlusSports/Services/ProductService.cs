using Newtonsoft.Json;using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace HPlusSports.Services
{
	public static class ProductService
    {
        private const string WISHLIST_FILE = "wishlist.json";
		static HttpClient client;

        public static List<Product> WishList
        {
            get;
            set;
        }

        static ProductService()
		{
			client = new HttpClient();
			client.BaseAddress = new Uri("https://hplussport.com/api/");
            WishList = new List<Product>();
		}

        public static async Task<List<Product>> GetProductsAsync()
		{
            var productsRaw = await client.GetStringAsync("products/");

            var serializer = new JsonSerializer();
            using(var tReader = new StringReader(productsRaw))
            {
                using(var jReader = new JsonTextReader(tReader))
                {
                    var products = serializer.Deserialize<List<Product>>(
                        jReader);

                    return products;
                }
            }
		}

        public static async Task SaveWishList()
        {
            if (WishList != null)
            {
                //Save wishlist to file
                var path = System.IO.Path.Combine(
                    FileSystem.AppDataDirectory, WISHLIST_FILE);
                using (var swriter = new StreamWriter(path))
                {
                    using(var jWriter = new JsonTextWriter(swriter))
                    {
                        JsonSerializer.CreateDefault().Serialize(jWriter, WishList);
                    }
                }
            }
        }

        public static async Task LoadWishList()
        {
            //Load wishlist from file
            var path = System.IO.Path.Combine(FileSystem.AppDataDirectory, WISHLIST_FILE);

            if (System.IO.File.Exists(path))
            {
                using (var sReader = new StreamReader(path))
                {
                    using (var jReader = new JsonTextReader(sReader))
                    {
                        try
                        {
                            WishList = JsonSerializer.CreateDefault().Deserialize<List<Product>>(jReader);
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Debug.WriteLine(ex.Message);
                        }
                    }
                }
            }
        }
    }
}
