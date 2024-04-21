using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoExam.Models
{
    public class Product
    {
        [MaxLength(6), MinLength(4)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        // Отношение один-ко-многим: один товар может иметь только одну категорию,
        // но одна категория  может быть у многих товаров
        public string CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public int Cost { get; set; }
        public int Count { get; set; }

    }
}
