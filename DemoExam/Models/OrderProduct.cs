using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoExam.Models
{
    public class OrderProduct
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        
        // Навигационные свойства
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }

    }
}
