using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace OrderManagementSystem.Models
{
    public class Product : EntityBase
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string? Description { get; set; }
        public Category Category { get; set; }
        public double Price { get; set; }
        public int TotalAmmount { get; set; }

    }

    public class Category : EntityBase
    {
        public string Name { get; set; }
    }
}