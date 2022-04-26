using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace TestXamarin
{
    public class Database : IDatabase
    {
        private SQLiteAsyncConnection _database;

        public Database()
        {
            if (_database != null) return;

            _database = new SQLiteAsyncConnection(Path.Combine(Xamarin.Essentials.FileSystem.AppDataDirectory, "task.db3"));

             _database.CreateTableAsync<Tasks>();
        }

        public Task<List<Tasks>> GetTaskAsync()
        {
            return _database.Table<Tasks>().ToListAsync();
        }

        public async Task<int> SaveTaskAsync(Tasks task)
        {
            if(task.ID != 0)
                return await _database.UpdateAsync(task);
            else
                return await _database.InsertAsync(task);   
        }

        public async Task<int> DeleteTaskAsync(Tasks task)
        {
            return await _database.DeleteAsync(task);
        }
    }
}
