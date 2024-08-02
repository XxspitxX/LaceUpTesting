using CommunityToolkit.Maui.Core.Extensions;
using LaceUpTesting.Models;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaceUpTesting.Storage.Cart
{
    public class CartDbSource : DbSource
    {
        public const string cartDetailDb = "cartDetails";
        public async Task<ObservableCollection<CartDetail>> GetItemsAsync()
        {
            using var Database = new LiteDatabase(await GetConnectionString());

            var collection = Database?.GetCollection<CartDetail>(cartDetailDb);
            return collection?.Query().ToList().ToObservableCollection();
        }
        public async Task<CartDetail?> GetItemAsync(int? id)
        {
            using var Database = new LiteDatabase(await GetConnectionString());

            var collection = Database?.GetCollection<CartDetail>(cartDetailDb);
            return collection?.Query().Where(x=> x!.Product!.Id == id).FirstOrDefault();
        }
        public async Task SaveItemAsync(CartDetail item)
        {
            using var Database = new LiteDatabase(await GetConnectionString());
            var collection = Database?.GetCollection<CartDetail>(cartDetailDb);


            collection?.Upsert(item);
        }
        public async Task UpdateItemAsync(CartDetail item)
        {
            using var Database = new LiteDatabase(await GetConnectionString());
            var collection = Database?.GetCollection<CartDetail>(cartDetailDb);
            collection?.Upsert(item);

        }
        public async Task DeleteItemAsync(int? id)
        {
            using var Database = new LiteDatabase(await GetConnectionString());

            var collection = Database?.GetCollection<CartDetail>(cartDetailDb);

            collection?.DeleteMany(x => x.Product.Id == id);
            
        }
    }
}
