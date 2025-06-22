using Microsoft.EntityFrameworkCore;
using Entities;
using Repositories;
using Microsoft.EntityFrameworkCore;

public class DatabaseFixture : IDisposable
{
    public Prudoct_Kategory_webApi DbContext { get; }

    public DatabaseFixture()
    {
        var options = new DbContextOptionsBuilder<Prudoct_Kategory_webApi>()
            .UseInMemoryDatabase("IntegrationTestDb")
            .Options;
        DbContext = new Prudoct_Kategory_webApi(options);
        DbContext.Database.EnsureCreated();
    }

    public void Dispose()
    {
        DbContext.Database.EnsureDeleted();
        DbContext.Dispose();
    }

    public void ClearDatabase()
    {
        // מחיקת כל הטבלאות*
        DbContext.Users.RemoveRange(DbContext.Users);
        // הוסף כאן RemoveRange לטבלאות נוספות במידת הצורך
        DbContext.SaveChanges();
    }
}