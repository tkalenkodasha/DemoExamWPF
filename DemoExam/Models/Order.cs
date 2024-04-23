using DemoExam.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoExam.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public DateTime DateOrder { get; set; }
        public DateTime DateDelivery { get; set; }
        public int ClientId { get; set; }
        
        public virtual Client Client { get; set; }
        public int GettingCode { get; set; }
        public int PickUpPointId { get; set; }

        public virtual PickUpPoint PickUpPoint { get; set; }

        public virtual List<OrderProduct> Products { get; set; }
        public Order()
        {
            Products=new List<OrderProduct>();
        }
    }
}
