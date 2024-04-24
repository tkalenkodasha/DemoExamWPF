using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoExam.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public virtual List<Product> Products { get; set; }
        public Category()
        {
            Products = new List<Product>();
        }
        public override string ToString()
        {
            return CategoryName;
        }
    }
}
