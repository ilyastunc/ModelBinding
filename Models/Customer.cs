using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ModelBinding.Models
{
    [Bind(nameof(FirstName), nameof(LastName))] //Böyle diyerek formdan sadece FirstName ve LastName alanlarının formdan gönderilmesini sağladık. Güvenlik için kullanılmalı bu veya BindNever.
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirhtDate { get; set; }
        public Address Address { get; set; }
        public Role Role { get; set; }
        [BindNever] //Bu sayede IdentityNumber hiç bir zaman formdan gönderilmeyecek.
        public string IdentityNumber {get; set;}
    }

    public class Address 
    {
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }

    public enum Role
    {
        Admin,
        User,
        Member
    }
}