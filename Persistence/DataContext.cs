using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    // avalaible to quary database
    public class DataContext: DbContext
    {
        // constructor DataContext(parameters), o need option from the clase --> base(options)
        public DataContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Value> Values {get; set; }
        // protected method means that it's accessible to the class itself it's defined in
        // any derived classes from this class ovewrite ti
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Value>()
            // methods availabe in class builder
            // hasData configures this entity to have seed data, use to generate data motion
            // the data that we want in our database
                .HasData(
                    new Value { Id = 1, Name = "Value 101"},
                    new Value { Id = 2, Name = "Value 102"},
                    new Value { Id = 3, Name = "Value 103"}
                );

        }
    }
}
