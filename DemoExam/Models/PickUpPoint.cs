using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoExam.Models
{
    public class PickUpPoint
    {
        public int Id { get; set; }
        public string Adress { get; set; }
        public virtual List<Order> Orders { get; set; }
        public PickUpPoint() 
        { 
            Orders=new List<Order>();
        }
    }
}
