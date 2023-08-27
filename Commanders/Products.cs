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
    [Route("api/[controller]")]
    public class Products : ControllerBase
    {
        private readonly DataContext context;
        public Products(DataContext ctx){
            context = ctx;
        }

        Constants constant = new Constants();

[HttpPost("addProduct")]
        public async Task<IActionResult> AddProducts([FromForm]ProductDto request, string ManagerId){
    


    if (request.ProductImage == null || request.ProductImage.Length == 0)
    {
        return BadRequest("Invalid file");
    }

    // Create the uploads directory if it doesn't exist
    var uploadsDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Products", "Images");
    if (!Directory.Exists(uploadsDirectory))
    {
        Directory.CreateDirectory(uploadsDirectory);
    }

    // Get the original file extension
    var fileExtension = Path.GetExtension(request.ProductImage.FileName);

    // Generate a unique file name
    var fileName = Guid.NewGuid().ToString() + fileExtension;

    // Save the uploaded file to the uploads directory
    var filePath = Path.Combine(uploadsDirectory, fileName);
    using (var stream = new FileStream(filePath, FileMode.Create))
    {
        await request.ProductImage.CopyToAsync(stream);
    }

 var manager = context.RoleTables.FirstOrDefault(m=>m.ManagerId==ManagerId && m.Role ==constant.Inventory );
 if (manager == null){
    return BadRequest("You dont have the permisiion to post any product ");
 }

    var product = new Product{
        ProductImagePath =  Path.Combine("Products/Images", fileName),
        ProductId = IDGenerator(),
        ProductName = request.ProductName,
        ProductCategory = request.ProductCategory,
        ProductDescription = request.ProductDescription,
        Price = request.Price,
        Quantity = request.Quantity,
        Rating = request.Rating,
        DateAdded = DateTime.Today.Date.ToString("dd MMMM, yyyy"),
        AddedByUserId = manager.ManagerId,
        AddedByUserName = manager.ManagerName,

    };



    context.Products.Add(product);
    
    await context.SaveChangesAsync();
    return Ok("Product added successfully");   
    }
 


[HttpPost("updateProduct")]
        public async Task<IActionResult> UpdateProducts([FromForm]ProductDto request, string ManagerId, string ProductId){
    


    if (request.ProductImage == null || request.ProductImage.Length == 0)
    {
        return BadRequest("Invalid file");
    }

    // Create the uploads directory if it doesn't exist
    var uploadsDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Products", "Images");
    if (!Directory.Exists(uploadsDirectory))
    {
        Directory.CreateDirectory(uploadsDirectory);
    }

    // Get the original file extension
    var fileExtension = Path.GetExtension(request.ProductImage.FileName);

    // Generate a unique file name
    var fileName = Guid.NewGuid().ToString() + fileExtension;

    // Save the uploaded file to the uploads directory
    var filePath = Path.Combine(uploadsDirectory, fileName);
    using (var stream = new FileStream(filePath, FileMode.Create))
    {
        await request.ProductImage.CopyToAsync(stream);
    }

 var manager = context.RoleTables.FirstOrDefault(m=>m.ManagerId==ManagerId && m.Role ==constant.Inventory);
 if (manager == null){
    return BadRequest("You dont have the permisiion to post any product ");
 }

 var pdt = context.Products.FirstOrDefault(m=>m.ProductId==ProductId);
 if (pdt == null){
    return BadRequest("Product does not exist");
 }

   
        pdt.ProductImagePath =  Path.Combine("Products/Images", fileName);
        pdt.ProductId = IDGenerator();
        pdt.ProductName = request.ProductName;
        pdt.ProductCategory = request.ProductCategory;
        pdt.ProductDescription = request.ProductDescription;
        pdt.Price = request.Price;
        pdt.Quantity = request.Quantity;
        pdt.Rating = request.Rating;
        pdt.DateModified = DateTime.Today.Date.ToString("dd MMMM, yyyy");
        pdt.ModifiedByUserId = manager.ManagerId;
        pdt.ModifiedByUserName = manager.ManagerName;

    
    await context.SaveChangesAsync();
    return Ok("Product updated successfully");   
    }

[HttpGet("allProducts")]
public async Task<IActionResult> GetProducts(){
    var products = context.Products.Where(p=>p.Quantity>0).OrderByDescending(r=>r.Id).ToList();
    return Ok(products);
}

[HttpGet("oneProducts")]
public async Task<IActionResult> OneProducts(string ProductId){
    var products = context.Products.FirstOrDefault(a=>a.ProductId==ProductId);
    if (products==null){
        return BadRequest("Product Not Found");
    }
        return Ok(products);
}

[HttpDelete("DeleteProducts")]
public async Task<IActionResult> DeleteProducts(string ProductId){
   var products = context.Products.FirstOrDefault(a=>a.ProductId==ProductId);
   if (products==null){
    return BadRequest("Product Not Found");
   }
   context.Products.Remove(products);
   await context.SaveChangesAsync();
   return Ok(products);
}


[HttpPost("AddToCart")]
public async Task<IActionResult> AddToCart(string ProductId, string userId){
    var product = context.Products.FirstOrDefault(a=>a.ProductId == ProductId);
    if (product == null){
        return BadRequest("Product not found");
    }
    var regUser = context.CustomerAccounts.FirstOrDefault(a=>a.UserId == userId);
if (regUser==null){
    return BadRequest("Sign Up First ");
}


    var theCart = new Cart{
        ProductImagePath = product.ProductImagePath,
        ProductId = product.ProductId,
        ProductName = product.ProductName,
        ProductCategory = product.ProductCategory,
        ProductDescription = product.ProductDescription,
        Price = product.Price,
        Quantity = product.Quantity,
        Rating = product.Rating,
        UserId = regUser.UserId,
        UserName = regUser.FullName,
        UserEmail = regUser.Email,
        UserPhone = regUser.PhoneNumber,
        DateAdded = DateTime.Today.Date.ToString("dd MMMM, yyyy")

    };

    context.Carts.Add(theCart);
    await context.SaveChangesAsync();
    return Ok("Item added successfully to cart");


}

[HttpGet("CartItems")]
public async Task<IActionResult> CartItems(string userId){
var items = context.Carts.Where(a => a.UserId == userId).ToList();
return Ok(items);
}


[HttpPost("OrderItems")]
public async Task<IActionResult> OrderItems(string userId,[FromBody] BillingCard request){

var OrderId = IDGenerator();
var carts = context.Carts.Where(a => a.UserId == userId).ToList();
var regUser = context.CustomerAccounts.FirstOrDefault(a=>a.UserId == userId);
if (regUser==null){
    return BadRequest("Sign Up First ");
}

foreach(var item in carts){
    var theOrder = new OrderList{
        OrderId = OrderId,
        ProductImagePath = item.ProductImagePath,
        ProductId = item.ProductId,
        ProductName = item.ProductName,
        ProductCategory = item.ProductCategory,
        ProductDescription = item.ProductDescription,
        Price = item.Price,
        Quantity = item.Quantity,
        Rating = item.Rating,
        UserId = item.UserId,
        UserName = item.UserName,
        UserEmail = item.UserEmail,
        UserPhone = item.UserPhone,
        DateOrdered = DateTime.Today.Date.ToString("dd MMMM, yyyy")
    };
    context.OrderLists.Add(theOrder);
    
    
}



var BillCard = new BillingCard{
UserId = regUser.UserId,
OrderId = OrderId,
BillingId = IDGenerator(),
Location = request.Location,
GpsAddress = request.GpsAddress,
BillingStage = constant.Completed

};
context.BillingCards.Add(BillCard);

foreach(var item in carts){
context.Carts.Remove(item);
}

var ware = new Warehouse{
OrderId = OrderId
};
context.Warehouses.Add(ware);

var boss = new Master{
BillingId = BillCard.BillingId,
OrderId = OrderId
};



context.Masters.Add(boss);


await context.SaveChangesAsync();
return Ok("Order Is Successful");

}

[HttpDelete("deleteOrder")]
public async Task<IActionResult> DeleteOrder(string orderId, string userId){
    var theOrders = context.OrderLists.Where(a=>a.OrderId == orderId && a.UserId == userId).ToList();
    foreach(var i in theOrders){
        context.OrderLists.Remove(i);
        await context.SaveChangesAsync();
    }

    return Ok("Order deleted successfully");

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