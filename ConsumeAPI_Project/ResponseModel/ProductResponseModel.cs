using System;

namespace ConsumeAPI_Project.ResponseModel
{
    public class ProductResponseModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; } 
        public string ImagePath { get; set; }
        public int? CategoryId { get; set; }
        
    }
}
