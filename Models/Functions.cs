using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hydot_Mall_Backend_v1.Models
{
   public class ProductManager{
    public int Id { get; set; }
    public string? ManagerId { get; set; }
    public string? ManagerName { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }

   }
}