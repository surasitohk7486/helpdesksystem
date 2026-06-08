using System;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace HelpdeskSystem
{
    internal class DatabaseService
    {
        private SQLiteAsyncConnection _database;

        private async Task Init()
        {
            if (_database != null)
                return;

            string dbpatch = Path.Combine(FileSystem.AppDataDirectory, "Helpdesk.db");

            _database = new SQLiteAsyncConnection(dbpatch);

            await _database.CreateTableAsync<Tickets>();
        }

        public async Task<int> SaveTicketAsync(Tickets ticket)
        {
            await Init();
            return await _database.InsertAsync(ticket);
        }
            
        public async Task<List<Tickets>> GetTicketsAsync()
        {
            await Init();
            return await _database.Table<Tickets>().ToListAsync();
        }
    }
}
