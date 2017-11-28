﻿using System.Data.Entity;

namespace TestDbApp.Model
{
    public class TestDbContext : DbContext
    {
        public TestDbContext(string nameOrConnectionString) : base(nameOrConnectionString: nameOrConnectionString)
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


        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Department> Departments { get; set; }

    }
}
