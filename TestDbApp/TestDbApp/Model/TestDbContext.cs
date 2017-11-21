using System.Data.Entity;

namespace TestDbApp.Model
{
    public class TestDbContext : DbContext
    {
        public TestDbContext() : base(nameOrConnectionString: "TestDBConnectionString")
        {

            if (!Database.Exists())
            {
                Database.SetInitializer(new NullDatabaseInitializer<TestDbContext>());
            }
            else
            {
                Database.SetInitializer(new CreateDatabaseIfNotExists<TestDbContext>());
            }
        }


    }
}
