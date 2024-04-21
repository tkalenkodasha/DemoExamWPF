﻿using DemoExam.Pages;
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
        public int ClientId { get; set; }
        
        public virtual Client Client { get; set; }
        public int GettingCode { get; set; }
    }
}
