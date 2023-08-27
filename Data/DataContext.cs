using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hydot_Mall_Backend_v1.Models;
using Microsoft.EntityFrameworkCore;

namespace Hydot_Mall_Backend_v1.Data
{
    public class DataContext:DbContext
    {
      public DataContext(): base(){
}

//Database Connection String
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
base.OnConfiguring(optionsBuilder); optionsBuilder.UseSqlServer("Server=localhost,1433;Database=HydotMall;User=sa;Password=HydotTech;TrustServerCertificate=true;");
}  

public DbSet< CustomerAccount> CustomerAccounts { get; set; }
public DbSet<StaffAccount> StaffAccounts { get; set; }
public DbSet<Product> Products { get; set; }
public DbSet<Cart> Carts { get; set; }
public DbSet<OrderList> OrderLists { get; set; }
public DbSet<OptionalSaveThisBillingAddress> OptionalSaveThisBillingAddresses{ get; set; }
public DbSet<Master> Masters{ get; set; }
public DbSet<Warehouse> Warehouses{get; set; }
public DbSet<Quality> Qualities { get; set; }
public DbSet<Accounting> Accountings {get; set; }
public DbSet<DeliveryManager> DeliveryManagers { get; set;}
public DbSet<Security> Securities { get; set; }
public DbSet<Delivery> Deliveries { get; set; }
public DbSet<RoleTable> RoleTables { get; set; }
public DbSet<BillingCard> BillingCards{ get; set; }
public DbSet<DeliveryAddress> DeliveryAddresses { get; set; }








    }
}