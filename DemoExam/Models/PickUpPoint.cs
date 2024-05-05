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
        public string NumberHouse { get; set; }
        public string Street { get; set; }
        public int CityId { get; set; }
        public virtual City City{ get; set; }

        public string Index { get; set; }
        public virtual List<Order> Orders { get; set; }
        public PickUpPoint() 
        { 
            Orders=new List<Order>();
        }

        public string FullAddress
        {
            get
            {
                return $"{City.CityName}, {Street},{NumberHouse}";
            }
        }
    }
}
