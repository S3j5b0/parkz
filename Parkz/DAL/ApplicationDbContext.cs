using Microsoft.EntityFrameworkCore;
using Parkz.Models;

namespace Parkz;

public class ApplicationDbContext : DbContext
{
    public  DbSet<CustomerModel> Customers { get; set; }
    public  DbSet<AdressModel> Adresses { get; set; }
    public  DbSet<PurchaseModel> Purchases { get; set; }
    public  DbSet<SalesPersonModel> SalesPeople { get; set; }
    public  DbSet<CarModel> Cars { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        :base(options)
    {
    }
    // Specify DbSet properties etc
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CarModel>()
            .Property(e => e.Extras)
            .HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));
        // add your own configuration here
    }

    

}