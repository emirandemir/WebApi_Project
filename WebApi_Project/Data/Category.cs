using System.Collections.Generic;

namespace WebApi_Project.Data
{
    public class Category
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
