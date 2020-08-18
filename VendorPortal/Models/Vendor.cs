using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VendorPortal.Constants;

namespace VendorPortal.Models
{
    public class Vendor : IVendor
    {
        public Vendor()
        {
            VendorTags = new HashSet<VendorTag>();
        }
        public int VendorID { get; set; } 
        public string GUID{ get; set; } 
        public string VendorName { get; set; }
        public string LoginUrl { get; set; }
        public string Username { get; set; }
        public string PasswordSalt { get; set; }
        [Required]
        [RegularExpression(Constants.Constants.PasswordFormat  , ErrorMessage = Constants.Constants.PasswordFormatMessage)]
        public string Password { get; set; }
        public string Notes { get; set; }
        public int SortOrder { get; set; }
        public int? VendorTypeID { get; set; }
        public virtual VendorType VendorType { get; set; }
        public virtual ICollection<VendorTag> VendorTags { get; set; }
   
    }
}