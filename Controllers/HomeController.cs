using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ModelBinding.Models;

namespace ModelBinding.Controllers
{
    public class HomeController : Controller
    {
        private IRepository repository;

        public HomeController(IRepository repo)
        {
            repository = repo;
        }

        public IActionResult Index(int? id) 
        {
            Customer customer;
            if (id.HasValue && (customer = repository.Get((int)id)) != null)
                return View(customer);
            else
                return NotFound();
        
        } 

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Customer());
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            return View("Index", customer);
        }

        //string array'i alan
        // public IActionResult Names (string[] names)  //action bir tane string dizisi alıyor. eğer dizi boşsa, boş bir array oluştulup view'a gönderiliyor.
        // {
        //     return View(names ?? new string[0]);
        // }

        //string list alan
        public IActionResult Names (List<string> names)  //action bir tane string listesi alıyor. eğer liste boşsa, boş bir liste oluştulup view'a gönderiliyor.
         {
             return View(names ?? new List<string>());
         }

         public IActionResult Customers (List<CustomerModel> customers)  //action bir tane string listesi alıyor. eğer liste boşsa, boş bir liste oluştulup view'a gönderiliyor.
         {
             return View(customers ?? new List<CustomerModel>());
         }
    }
}