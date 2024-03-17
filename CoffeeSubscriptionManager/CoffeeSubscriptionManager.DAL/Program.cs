using CoffeeSubscriptionManager.DAL;

internal class Program
{
    private static void Main(string[] args)
    {
        using var db = new CoffeeSubscriptionContext();
        DatabaseSeeder.Seed(db);
        db.SaveChanges();
    }
}