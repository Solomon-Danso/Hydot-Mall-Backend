using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hydot_Mall_Backend_v1.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? ProductImagePath { get; set; }
        public string? ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductCategory { get; set; }
        public string? ProductDescription { get; set; }
        public double? Price { get; set; }
        public double? Quantity { get; set; }
        public double? Rating { get; set; }
        public string? DateAdded { get; set; }
        public string? AddedByUserId { get; set; }
        public string? AddedByUserName  { get; set; }
        public string? DateModified { get; set; }
        public string? ModifiedByUserId { get; set; }
        public string? ModifiedByUserName { get; set; }

    }

public class DeliveryAddress{
    public int Id { get; set;}
    public string? Location { get; set;}
    public string? GpsAddress {get; set;}
    public string? UserId{get; set;}

}
public class BillingCard{
    public int Id { get; set;}
    public string? UserId { get; set; }
    public string? OrderId { get; set; }
    public string? BillingId { get; set; } 
    public string? Location { get; set;}
    public string? GpsAddress {get; set;}
    //Trackers 
    public string? BillingStage { get; set; }
    public string? WarehouseStage { get; set; }
    public string? QualityStage { get; set;}
    public string? AccountsStage { get; set; }
    public string? SecurityStage { get; set; }
    public string? DeliveryStage { get; set; }
    public string? DeliveryStatus { get; set; }










}

    public class ProductDto
    {
        public int Id { get; set; }
        public IFormFile? ProductImage { get; set; }
        public string? ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductCategory { get; set; }
        public string? ProductDescription { get; set; }
        public double? Price { get; set; }
        public double? Quantity { get; set; }
        public double? Rating { get; set; }
        public string? DateAddded { get; set; }
        public string? AddedByUserId { get; set; }
        public string? AddedByUserName  { get; set; }
        public string? DateModified { get; set; }
        public string? ModifiedByUserId { get; set; }
        public string? ModifiedByUserName { get; set; }

    }


    public class Cart{
        public int Id { get; set;}
        public string? ProductImagePath { get; set; }
        public string? ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductCategory { get; set; }
        public string? ProductDescription { get; set; }
        public double? Price { get; set; }
        public double? Quantity { get; set; }
        public double? Rating { get; set; }
        public string? UserId { get; set; }
        public string? UserName { get; set; }
        public string? UserEmail { get; set; }
        public string? UserPhone { get; set; }
        public string? DateAdded { get; set; }

    }

    public class OrderList{
        public int Id { get; set;}
        public string? OrderId { get; set; }
        public string? ProductImagePath { get; set; }
        public string? ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductCategory { get; set; }
        public string? ProductDescription { get; set; }
        public double? Price { get; set; }
        public double? Quantity { get; set; }
        public double? Rating { get; set; }
        public string? UserId { get; set; }
        public string? UserName { get; set; }
        public string? UserEmail { get; set; }
        public string? UserPhone { get; set; }
        public string? DateOrdered { get; set; }

    }

   

   

    














}