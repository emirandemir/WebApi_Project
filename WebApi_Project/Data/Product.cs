using System;
using System.Security.Permissions;

namespace WebApi_Project.Data
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string ImagePath { get; set; }
    }
}
