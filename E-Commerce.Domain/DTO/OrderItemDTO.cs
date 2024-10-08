﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.DTO
{
    public class OrderItemDTO
    {
       
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        
        public int ProductId { get; set; }
        
        public int Quantity { get; set; }
        public int UnitPrice { get; set; }      
    }
}
