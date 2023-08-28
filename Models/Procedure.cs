using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Net.Http.Headers;

namespace Hydot_Mall_Backend_v1.Models
{
    public class OptionalSaveThisBillingAddress{
        public int Id { get; set;}
        public string? UserId { get; set; }
        public string? UserName { get; set; }
        public string? Address { get; set; }

    }


 public class Master{
        public int Id { get; set;}
        public string? MasterId { get; set; }
        public string? BillingId { get; set; }
        public string? OrderId { get; set; }
        public string? UserId {get; set; }
        public string? WarehouseId { get; set;}
        public string? QualityId { get; set; }
        public string? AccountId { get; set; }
        public string? DeliveryId { get; set; }
        public string? CustomerToken { get; set; }
        public string? DeliveryStatus { get; set; }
      
    }



    public class Warehouse{
        public int Id { get; set;}
        public string? OrderId{ get; set; }
        public string? WarehouseId{ get; set; }
        public string? IssuerId {get; set;}
        public string? IssuerName {get; set;}
        public string? IssuerEmail {get; set;}
        public string? IssuerPhone {get; set;}
        public string? IssuerRole {get; set;}
        public string? IssuerComment {get; set;}
        public string? DateOfIssue {get; set;}

    }

    public class Quality{
        public int Id { get; set;}
        public string? OrderId { get; set; }
        public string? QualityId{ get; set; }
        public string? IssuerId {get; set;}
        public string? IssuerName {get; set;}
        public string? IssuerEmail {get; set;}
        public string? IssuerPhone {get; set;}
        public string? IssuerRole {get; set;}
        public string? IssuerComment {get; set;}
        public string? DateOfIssue {get; set;}

    }

    public class Accounting{
        public int Id { get; set;}
        public string? OrderId { get; set; }
        public string? AccountId{ get; set; }
        public double? ReceivableAmount {get; set; }
        public string? Status {get; set; }
        public string? DateOfIssue {get; set;}
    }


public class DeliveryManager{
        public int Id { get; set;}
        public string? OrderId { get; set; }
        public string? DeliveryPersonId { get; set; }
        public string? DeliveryPersonName { get; set; }
        public string? DeliveryPersonPhone { get; set;}
        public string? DeliveryPersonEmail { get; set; }
        public string? BillingId { get; set; }
        public string? DeliveryId { get; set; }
        public string? OneTimePassword{ get; set; }
        public string? IssuerId {get; set;}
        public string? IssuerName {get; set;}
        public string? IssuerEmail {get; set;}
        public string? IssuerPhone {get; set;}
        public string? IssuerRole {get; set;}
        public string? IssuerComment {get; set;}
        public string? DateOfIssue {get; set;}
        public string? DeliveryDate {get; set;}
        public string? DeliveryMethod {get; set;}
        public string? RecipientDetails {get; set;}
        public double? OrderTotal  {get; set;}

    }



public class Security{
        public int Id { get; set;}
        public string? OrderId { get; set; }
        public string? SecurityId{ get; set; }
        public string? IssuerId {get; set;}
        public string? IssuerName {get; set;}
        public string? IssuerEmail {get; set;}
        public string? IssuerPhone {get; set;}
        public string? IssuerRole {get; set;}
        public string? IssuerComment {get; set;}
        public string? DateOfIssue {get; set;}

    }

public class Delivery{
        public int Id { get; set;}
        public string? OrderId { get; set; }
        public string? DeliveryId{ get; set; }
        public string? DeliveryStatus {get; set;}
        public string? DeliveryPersonId {get; set;}
        public string? DeliveryName {get; set;}
        public string? DeliveryEmail {get; set;}
        public string? DeliveryPhone {get; set;}

        public string? CustomerId {get; set;}
        public string? CustomerName {get; set;}
        public string? CustomerEmail {get; set;}
        public string? CustomerPhone {get; set;}
        public string? BillingId {get; set;}


        public string? OneTimePassword {get; set;}
        public string? DeliveryDate {get; set;}
        public string? DeliveryMethod {get;set;}
        public bool? PasswordCorrect {get; set;}

        public string? DateOfIssue {get; set;}

    }






}