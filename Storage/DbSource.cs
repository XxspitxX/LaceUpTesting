using LaceUpTesting.Models;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaceUpTesting.Storage
{
    public class DbSource 
    {
        public const string DatabaseFilename = "TodoSQLite.db";

        public static string DatabasePath =>
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DatabaseFilename);

        public async Task<string > GetConnectionString()
        {
            var password = await SecureStorage.GetAsync("password_Db");
            if(password == null)
            {
                password = Guid.NewGuid().ToString();
                File.Create(DatabasePath).Close();
                await SecureStorage.SetAsync("password_Db", password);
            }
            return $"FileName={DatabasePath};Password={password}";
        }
    }
}
