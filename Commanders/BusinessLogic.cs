using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
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
var theamount = context.OrderLists.Where(x=>x.OrderId==Order.OrderId).Sum(r=>r.Price);

var quali = new Accounting{
    OrderId = Order.OrderId,
    AccountId = IDGenerator(),
    ReceivableAmount = theamount,
    Status = constant.YetToRecieve,
    DateOfIssue = DateTime.Today.Date.ToString("dd MMMM, yyyy")

};
Boss.AccountId = quali.AccountId;
theStage.AccountsStage = constant.Completed;
context.Accountings.Add(quali);

var delivery = new DeliveryManager{
OrderId = Order.OrderId,
};
context.DeliveryManagers.Add(delivery);


await context.SaveChangesAsync();
return Ok("Quality and Accounting Steps Completed");

}




[HttpPost("AddDelivery")]
public async Task<IActionResult> AddDelivery([FromBody] DeliveryManager request, string ManagerId, string OrderId, string DeliPersonId){
var manager =  context.RoleTables.FirstOrDefault(t => t.ManagerId == ManagerId && t.Role==constant.DeliveryManager );
if (manager == null){
    return BadRequest("You dont have the permission to perform this action");
}
var Order = context.DeliveryManagers.FirstOrDefault(t=>t.OrderId == OrderId);
var Boss = context.Masters.FirstOrDefault(t=>t.OrderId == OrderId);
var theStage = context.BillingCards.FirstOrDefault(t=>t.OrderId==OrderId);
var deliPerson = context.StaffAccounts.FirstOrDefault(t=>t.StaffId ==DeliPersonId);
var customer = context.OrderLists.FirstOrDefault(t=>t.OrderId==OrderId);


if (Order == null || Boss == null || theStage == null|| deliPerson == null|| customer == null){
    return BadRequest("No order found");
}
 
Order.DeliveryId = IDGenerator();
Order.IssuerId = manager.ManagerId;
Order.IssuerName = manager.ManagerName;
Order.IssuerEmail = manager.Email;
Order.IssuerPhone = manager.PhoneNumber;
Order.IssuerRole = manager.Role;
Order.IssuerComment = request.IssuerComment;
Order.DateOfIssue = DateTime.Today.Date.ToString("dd MMMM, yyyy");
Order.DeliveryPersonId = deliPerson.StaffId;
Order.DeliveryPersonProfilePic = deliPerson.ProfilePicture;
Order.DeliveryPersonName = deliPerson.FullName;
Order.DeliveryPersonPhone = deliPerson.PhoneNumber;
Order.DeliveryPersonEmail = deliPerson.Email;
Order.OneTimePassword = IDGenerator();
Order.BillingId = Boss.BillingId;
Order.DeliveryDate = request.DeliveryDate;
Order.DeliveryMethod = constant.DeliveryMethod;
Order.RecipientDetails = customer.UserName + " " + customer.UserPhone; 




Boss.DeliveryId = Order.DeliveryId;
theStage.DeliveryStage = constant.Completed;

var quali = new Quality{
    OrderId = Order.OrderId,
};
context.Qualities.Add(quali);
await context.SaveChangesAsync();

var c = context.BillingCards.FirstOrDefault(x=>x.OrderId == Order.OrderId);
if (c == null){
    return BadRequest("OrderId Not Found");
}

   try
{

 var items = context.OrderLists.Where(t=>t.OrderId==OrderId).ToList();
    double total = context.OrderLists.Where(t => t.OrderId == OrderId).Sum(t => (double?)t.Price) ?? 0.0;

     if (total<1){
        return BadRequest("Order Not Found");
    }
  

    if (string.IsNullOrEmpty(customer.UserName) ||
        string.IsNullOrEmpty(customer.UserEmail) ||
        string.IsNullOrEmpty(Boss.BillingId) ||
        Order.DeliveryDate == null ||
        string.IsNullOrEmpty(Order.DeliveryMethod) ||
        string.IsNullOrEmpty(Order.RecipientDetails) ||
        string.IsNullOrEmpty(c.Location))

    {
        return BadRequest("All the fields are required");
    }


    // Assuming you have a list of items with their details
    // Create a formatted list of items

    StringBuilder itemsList = new StringBuilder();
    foreach (var item in items)
    {
        itemsList.AppendLine($"{item.ProductName} - {item.Quantity} items");
    }

    string recipientDetails = $"{customer.UserName}, {customer.UserEmail}, {customer.UserPhone}";

    await SendOrderConfirmationEmail(
        customer.UserName,
        customer.UserEmail,
        Boss.BillingId,
        Order.DeliveryDate,
        Order.DeliveryMethod,
        recipientDetails,
        c.Location,
        itemsList.ToString(),
       total
        

    );
}
catch (Exception)
{
    return BadRequest("Failed to send messages. Please try again later.");
}



return Ok("Warehouse Steps Completed");

}





private async Task SendOrderConfirmationEmail(string customerName, string email, string orderNumber, string deliveryDate, string deliveryMethod, string recipientDetails, string deliveryAddress, string theItem, double totalPrice)
{
    string subject = "Order Confirmation";
    string body = $@"<!DOCTYPE html>
<html>
<head>
<style>
    body {{
        font-family: Arial, sans-serif;
    }}

    .container {{
        max-width: 600px;
    }}

    .header {{
        font-size: 24px;
    }}

    .text {{
        color: #666666;
        margin-bottom: 10px;
    }}

    .order-details {{
        background-color: #f5f5f5;
        padding: 10px;
        margin-top: 10px;
    }}

    .table {{
        width: 100%;
        border-collapse: collapse;
    }}

    .table th, .table td {{
        border: 1px solid #dddddd;
        padding: 8px;
        text-align: left;
    }}

    .footer {{
        color: #999999;
    }}
</style>
</head>
<body>
    <div class='container'>
        <div class='header'>Order Confirmation</div>
        <div class='text'>Hi {customerName},</div>
        <div class='text'>Thank you for shopping with us!</div>
        <div class='order-details'>
            <div class='text'>Your order {orderNumber} has been confirmed successfully.</div>
            <table class='table'>
                <tr>
                    <th>Estimated Delivery Date</th>
                    <td>{deliveryDate}</td>
                </tr>
                <tr>
                    <th>Delivery Method</th>
                    <td>{deliveryMethod}</td>
                </tr>
                <tr>
                    <th>Recipient Details</th>
                    <td>{recipientDetails}</td>
                </tr>
                <tr>
                    <th>Delivery Address</th>
                    <td>{deliveryAddress}</td>
                </tr>
            </table>
            <div class='text'>You ordered:</div>
            <div class='text'>{theItem}</div>
            <div class='text'>Total price: {totalPrice}</div>
        </div>
        <div class='text'>Please note:</div>
        <div class='text'>You can track your order through your account.</div>
        <div class='text'>If you have any questions, please visit our Help Center.</div>
        <div class='footer'>Happy Shopping!</div>
    </div>
</body>
</html>";

      using (SmtpClient smtpClient = new SmtpClient(constant.SmtpHost, constant.SmtpPort))
    {
        
        smtpClient.EnableSsl = true;
        smtpClient.UseDefaultCredentials = false;
        smtpClient.Credentials = new NetworkCredential(constant.SmtpUserName, constant.SmtpPassword);

        MailMessage mailMessage = new MailMessage();
        mailMessage.From = new MailAddress(constant.SmtpUserName);
        mailMessage.To.Add(email);
        mailMessage.Subject = subject;
        mailMessage.Body = body;
        mailMessage.IsBodyHtml = true; // Set the email body format to HTML

        await smtpClient.SendMailAsync(mailMessage);
    }
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