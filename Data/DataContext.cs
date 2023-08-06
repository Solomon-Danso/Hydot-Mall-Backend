using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
base.OnConfiguring(optionsBuilder); optionsBuilder.UseSqlServer("Server=localhost,1433;Database=HDSS;User=sa;Password=HydotTech;TrustServerCertificate=true;");
}  

//public DbSet<Model> Models {get; set; }


    }
}