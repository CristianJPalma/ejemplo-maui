using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace MauiApp1.SQLite
{
    public class HabitosDataBase
    {
        SQLiteAsyncConnection database;

        async Task Init()
        {
            if (database != null)
                return;
            database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            var result = await database.CreateTableAsync<Habito>();
        }
        public async Task<List<Habito>> GetHabitosAsync()
        {
            await Init();
            return await database.Table<Habito>().ToListAsync();
        }
        public async Task<int> SaveHabitoAsync(Habito habito)
        {
            await Init();
            if (habito.Id != 0)
                return await database.UpdateAsync(habito);
            else
                return await database.InsertAsync(habito);
        }
    }
}
