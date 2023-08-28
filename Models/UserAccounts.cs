using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hydot_Mall_Backend_v1.Models
{
    public class CustomerAccount
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set;}
        public string? Password { get; set; }
        public string? PasswordResetToken { get; set; }
        public DateTime? PasswordResetTokenExpiration { get; set; }
        public string? TwoFactorEnabledToken { get; set; }
        public DateTime? TwoFactorEnabledTokenExpire { get; set; }

    }

     public class StaffAccount
    {
        public int Id { get; set; }
        public string? ProfilePicture { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set;}
        public string? StaffId {get; set;}
        public string? Password { get; set; }
        public string? PasswordResetToken { get; set; }
        public DateTime? PasswordResetTokenExpiration { get; set; }
        public string? TwoFactorEnabledToken { get; set; }
        public DateTime? TwoFactorEnabledTokenExpire { get; set; }
        public string? Role {get; set;}



    }

     public class StaffAccountDto
    {
        public int Id { get; set; }
        public IFormFile? ProfilePictureFile { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set;}
        public string? Password { get; set; }
        public string? PasswordResetToken { get; set; }
        public DateTime? PasswordResetTokenExpiration { get; set; }
        public string? TwoFactorEnabledToken { get; set; }
        public DateTime? TwoFactorEnabledTokenExpire { get; set; }
        public string? Role {get; set;}
        

    }

 public class RoleTable{
    public int Id { get; set; }
    public string? ManagerId { get; set; }
    public string? ManagerName { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string? Role {get;set;}

   }



}