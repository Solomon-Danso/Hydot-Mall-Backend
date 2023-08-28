using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hydot_Mall_Backend_v1.Data;
using Hydot_Mall_Backend_v1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hydot_Mall_Backend_v1.Commanders
{
    [ApiController]
    [Route("api/AllTheGetters")]
    public class AllTheGetters : ControllerBase
    {
        private readonly DataContext context;
        Constants constant = new Constants();
        public AllTheGetters(DataContext ctx){
            context = ctx;
        }
    [HttpPost("AddRoles")]
    public async Task<IActionResult> AddRoles([FromBody]RoleTable request){
    
    var role = new RoleTable{
        ManagerId = request.ManagerId,
        ManagerName = request.ManagerName,
        PhoneNumber = request.PhoneNumber,
        Email = request.Email,
        Role = request.Role
    };
    bool checker = await context.RoleTables.AnyAsync(a=>a.ManagerId==role.ManagerId&&a.Role==role.Role);
    if(checker){
        return BadRequest("Role already assigned to the manager");
    }
    context.RoleTables.Add(role);
    await context.SaveChangesAsync();
    return Ok("Role added successfully");

    }

    [HttpGet("ViewAllRoles")]
    public async Task<IActionResult> ViewAllRoles(){
        var role = context.RoleTables.ToList();
        return Ok(role);
    }

    [HttpDelete("DeleteRole")]
    public async Task<IActionResult> DeleteRole(string ManagerId, string Role, string SuperAdminId){
        
        var power = context.RoleTables.FirstOrDefault(a=>a.ManagerId==SuperAdminId && a.Role==constant.SuperAccount);
    if (power==null){
        return BadRequest("You dont have the power to perform this operation");
    }
        
        var role = context.RoleTables.FirstOrDefault(a=>a.ManagerId==ManagerId && a.Role==Role);
        if (role == null){
            return BadRequest("Couldn't find role associated with Manager");
        }
        context.RoleTables.Remove(role);
        await context.SaveChangesAsync();
        return Ok("Deleted successfully");
    }

    [HttpGet("GetAllWarehouse")]
    public async Task<IActionResult> GetAllWarehouse(string ManagerId){
    var power = context.RoleTables.FirstOrDefault(a=>a.ManagerId==ManagerId && a.Role==constant.SuperAccount);
    if (power==null){
        return BadRequest("You dont have the power to perform this operation");
    }
    var Warehouse = context.Warehouses.OrderByDescending(r=>r.Id).ToList();
    return Ok(Warehouse);
    
    }


  [HttpGet("GetManagerWarehouse")]
    public async Task<IActionResult> GetManagerWarehouse(string ManagerId){
    var power = context.RoleTables.FirstOrDefault(a=>a.ManagerId==ManagerId && a.Role==constant.Warehouse);
    if (power==null){
        return BadRequest("You dont have the power to perform this operation");
    }
    var Warehouse = context.Warehouses.Where(a=>a.IssuerId==ManagerId).OrderByDescending(r=>r.Id).ToList();
    return Ok(Warehouse);
    
    }

 [HttpGet("GetSingleWarehouse")]
    public async Task<IActionResult> GetSingleWarehouse(string ManagerId, string WarehouseId){
    var power = context.RoleTables.FirstOrDefault(a=>a.ManagerId==ManagerId && a.Role==constant.Warehouse);
    if (power==null){
        return BadRequest("You dont have the power to perform this operation");
    }
    var Warehouse = context.Warehouses.FirstOrDefault(a=>a.IssuerId==ManagerId&&a.WarehouseId==WarehouseId);
    return Ok(Warehouse);
    
    }

[HttpDelete("DeleteSingleWarehouse")]
    public async Task<IActionResult> DeleteSingleWarehouse(string ManagerId, string WarehouseId){
    var power = context.RoleTables.FirstOrDefault(a=>a.ManagerId==ManagerId && a.Role==constant.SuperAccount);
    if (power==null){
        return BadRequest("You dont have the power to perform this operation");
    }

    var Warehouse = context.Warehouses.FirstOrDefault(a=>a.IssuerId==ManagerId&&a.WarehouseId==WarehouseId);
    if (Warehouse==null){
        return BadRequest("ID is not valid for this operation");
    }
    context.Warehouses.Remove(Warehouse);
    await context.SaveChangesAsync();
    
    return Ok(Warehouse);
    
    }

[HttpGet("GetAllQuality")]
    public async Task<IActionResult> GetAllQuality(string ManagerId){
    var power = context.RoleTables.FirstOrDefault(a=>a.ManagerId==ManagerId && a.Role==constant.SuperAccount);
    if (power==null){
        return BadRequest("You dont have the power to perform this operation");
    }
    var Quality = context.Qualities.OrderByDescending(r=>r.Id).ToList();
    return Ok(Quality);
    
    }


  [HttpGet("GetManagerQuality")]
    public async Task<IActionResult> GetManagerQuality(string ManagerId){
    var power = context.RoleTables.FirstOrDefault(a=>a.ManagerId==ManagerId && a.Role==constant.Quality);
    if (power==null){
        return BadRequest("You dont have the power to perform this operation");
    }
    var Quality = context.Qualities.Where(a=>a.IssuerId==ManagerId).OrderByDescending(r=>r.Id).ToList();
    return Ok(Quality);
    
    }

 [HttpGet("GetSingleQuality")]
    public async Task<IActionResult> GetSingleQuality(string ManagerId, string QualityId){
    var power = context.RoleTables.FirstOrDefault(a=>a.ManagerId==ManagerId && a.Role==constant.Quality);
    if (power==null){
        return BadRequest("You dont have the power to perform this operation");
    }
    var Quality = context.Qualities.FirstOrDefault(a=>a.IssuerId==ManagerId&&a.QualityId==QualityId);
    return Ok(Quality);
    
    }

[HttpDelete("DeleteSingleQuality")]
    public async Task<IActionResult> DeleteSingleQuality(string ManagerId, string QualityId){
    var power = context.RoleTables.FirstOrDefault(a=>a.ManagerId==ManagerId && a.Role==constant.SuperAccount);
    if (power==null){
        return BadRequest("You dont have the power to perform this operation");
    }

    var Quality = context.Qualities.FirstOrDefault(a=>a.IssuerId==ManagerId&&a.QualityId==QualityId);
    if (Quality==null){
        return BadRequest("ID is not valid for this operation");
    }
    context.Qualities.Remove(Quality);
    await context.SaveChangesAsync();
    
    return Ok(Quality);
    
    }

      [HttpGet("GetAllAccount")]
    public async Task<IActionResult> GetAllAccount(string ManagerId){
    var power = context.RoleTables.FirstOrDefault(a=>a.ManagerId==ManagerId && a.Role==constant.Account);
    if (power==null){
        return BadRequest("You dont have the power to perform this operation");
    }
   var Account = context.Accountings.OrderByDescending(r=>r.Id).ToList();

    return Ok(Account);
    
    }


 [HttpGet("GetSingleAccount")]
    public async Task<IActionResult> GetSingleAccount(string ManagerId, string AccountId){
    var power = context.RoleTables.FirstOrDefault(a=>a.ManagerId==ManagerId && a.Role==constant.Account);
    if (power==null){
        return BadRequest("You dont have the power to perform this operation");
    }
    var Account = context.Accountings.FirstOrDefault(a=>a.AccountId==AccountId);
    return Ok(Account);
   }

[HttpDelete("DeleteSingleAccount")]
    public async Task<IActionResult> DeleteSingleAccount(string ManagerId, string AccountId){
    var power = context.RoleTables.FirstOrDefault(a=>a.ManagerId==ManagerId && a.Role==constant.SuperAccount);
    if (power==null){
        return BadRequest("You dont have the power to perform this operation");
    }

    var Account = context.Accountings.FirstOrDefault(a=>a.AccountId==AccountId);
    if (Account==null){
        return BadRequest("ID is not valid for this operation");
    }
    context.Accountings.Remove(Account);
    await context.SaveChangesAsync();
    
    return Ok(Account);
    
    }



    [HttpGet("GetAllDelivery")]
    public async Task<IActionResult> GetAllDelivery(string ManagerId){
    var power = context.RoleTables.FirstOrDefault(a=>a.ManagerId==ManagerId && a.Role==constant.SuperAccount);
    if (power==null){
        return BadRequest("You dont have the power to perform this operation");
    }
    var Deliveries = context.Deliveries.OrderByDescending(r=>r.Id).ToList();
    return Ok(Deliveries);
    
    }


  [HttpGet("GetManagerDelivery")]
    public async Task<IActionResult> GetManagerDelivery(string ManagerId){
    var power = context.RoleTables.FirstOrDefault(a=>a.ManagerId==ManagerId && a.Role==constant.Delivery);
    if (power==null){
        return BadRequest("You dont have the power to perform this operation");
    }
    var Deliveries = context.Deliveries.Where(a=>a.DeliveryPersonId==ManagerId).OrderByDescending(r=>r.Id).ToList();
    return Ok(Deliveries);
    
    }

 [HttpGet("GetSingleDelivery")]
    public async Task<IActionResult> GetSingleDelivery(string ManagerId, string DeliveryId){
    var power = context.RoleTables.FirstOrDefault(a=>a.ManagerId==ManagerId && a.Role==constant.Delivery);
    if (power==null){
        return BadRequest("You dont have the power to perform this operation");
    }
    var Deliveries = context.Deliveries.FirstOrDefault(a=>a.DeliveryPersonId==ManagerId&&a.DeliveryId==DeliveryId);
    return Ok(Deliveries);
    
    }

[HttpDelete("DeleteSingleDelivery")]
    public async Task<IActionResult> DeleteSingleDelivery(string ManagerId, string DeliveryId){
    var power = context.RoleTables.FirstOrDefault(a=>a.ManagerId==ManagerId && a.Role==constant.SuperAccount);
    if (power==null){
        return BadRequest("You dont have the power to perform this operation");
    }

    var Deliveries = context.Deliveries.FirstOrDefault(a=>a.DeliveryPersonId==ManagerId&&a.DeliveryId==DeliveryId);
    if (Deliveries==null){
        return BadRequest("ID is not valid for this operation");
    }
    context.Deliveries.Remove(Deliveries);
    await context.SaveChangesAsync();
    
    return Ok(Deliveries);
    
    }







    }
}