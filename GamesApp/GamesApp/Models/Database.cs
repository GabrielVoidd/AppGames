using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace GamesApp.Models
{
    public class Database
    {
        readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Jogo>().Wait();
        }

        public Task<List<Jogo>> GetJogoAsync()
        {
            return _database.Table<Jogo>().ToListAsync();
        }

        public Task<int> SaveJogoAsync(Jogo jogo)
        {
            return _database.InsertAsync(jogo);
        }
    }
}
