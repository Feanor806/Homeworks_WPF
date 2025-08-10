using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskWPF8_1_DataTemplate
{
    public enum ProductTypes
    {
        Food,
        HomeAppliances
    }
    public class Product
    {
        public string? ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string? ImagePath { get; set; }
        public ProductTypes ProductType { get; set; }
    }
}
