using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Hydot_Mall_Backend_v1.Data;
using Hydot_Mall_Backend_v1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hydot_Mall_Backend_v1.Commanders
{
    [ApiController]
    [Route("api/Business")]
    public class BusinessLogic : ControllerBase
    {
         private readonly DataContext context;
        public BusinessLogic(DataContext ctx){
            context = ctx;
        }
        Constants constant = new Constants();

[HttpPost("AddWarehouse")]
public async Task<IActionResult> AddWarehouse([FromBody] Warehouse request, string ManagerId, string OrderId){
var manager =  context.RoleTables.FirstOrDefault(t => t.ManagerId == ManagerId && t.Role==constant.Warehouse );
if (manager == null){
    return BadRequest("You dont have the permission to perform this action");
}
var Order = context.Warehouses.FirstOrDefault(t=>t.OrderId == OrderId);
var Boss = context.Masters.FirstOrDefault(t=>t.OrderId == OrderId);
var theStage = context.BillingCards.FirstOrDefault(t=>t.OrderId==OrderId);


if (Order == null || Boss == null || theStage == null){
    return BadRequest("No order found");
}
Order.WarehouseId = IDGenerator();
Order.IssuerId = manager.ManagerId;
Order.IssuerName = manager.ManagerName;
Order.IssuerEmail = manager.Email;
Order.IssuerPhone = manager.PhoneNumber;
Order.IssuerRole = manager.Role;
Order.IssuerComment = request.IssuerComment;
Order.DateOfIssue = DateTime.Today.Date.ToString("dd MMMM, yyyy");

Boss.WarehouseId = Order.WarehouseId;
theStage.WarehouseStage = constant.Completed;

var quali = new Quality{
    OrderId = Order.OrderId,
};
context.Qualities.Add(quali);
await context.SaveChangesAsync();
return Ok("Warehouse Steps Completed");

}


[HttpPost("AddQuality")]
public async Task<IActionResult> AddQuality([FromBody] Quality request, string ManagerId, string OrderId){
var manager =  context.RoleTables.FirstOrDefault(t => t.ManagerId == ManagerId && t.Role==constant.Quality );
if (manager == null){
    return BadRequest("You dont have the permission to perform this action");
}
var Order = context.Qualities.FirstOrDefault(t=>t.OrderId == OrderId);
var Boss = context.Masters.FirstOrDefault(t=>t.OrderId == OrderId);
var theStage = context.BillingCards.FirstOrDefault(t=>t.OrderId==OrderId);


if (Order == null || Boss == null || theStage == null){
    return BadRequest("No order found");
}
Order.QualityId = IDGenerator();
Order.IssuerId = manager.ManagerId;
Order.IssuerName = manager.ManagerName;
Order.IssuerEmail = manager.Email;
Order.IssuerPhone = manager.PhoneNumber;
Order.IssuerRole = manager.Role;
Order.IssuerComment = request.IssuerComment;
Order.DateOfIssue = DateTime.Today.Date.ToString("dd MMMM, yyyy");

Boss.QualityId = Order.QualityId;
theStage.QualityStage = constant.Completed;

var quali = new Accounting{
    OrderId = Order.OrderId,
};
context.Accountings.Add(quali);
await context.SaveChangesAsync();
return Ok("Quality Steps Completed");

}






private string IDGenerator()
{
    byte[] randomBytes = new byte[2]; // Increase the array length to 2 for a 4-digit random number
    using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
    {
        rng.GetBytes(randomBytes);
    }

    ushort randomNumber = BitConverter.ToUInt16(randomBytes, 0);
    int fullNumber = randomNumber; // 109000 is added to ensure the number is 5 digits long

    return fullNumber.ToString("D5");
}



    }
}