using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using TodoList.Models;

namespace TodoList.Repositry
{
    public class TodoRepository
    {
        private SQLiteAsyncConnection _database;
         public TodoRepository(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<TodoItem>().Wait();
        }
        public Task<List<TodoItem>> GetItemsAsync()
        {
            return _database.Table<TodoItem>().ToListAsync();
        }
        public Task<TodoItem> GetItemAsync(int id)
        {
            return _database.Table<TodoItem>()
                            .Where(i => i.Id == id)
                            .FirstOrDefaultAsync();
        }
        public Task<int> SaveItemAsync(TodoItem item)
        {
            if (item.Id != 0)
            {
                return _database.UpdateAsync(item);
            }
            else
            {
                return _database.InsertAsync(item);
            }
        }
        public Task<int> DeleteItemAsync(TodoItem item)
        {
            return _database.DeleteAsync(item);
        }

    }
}
