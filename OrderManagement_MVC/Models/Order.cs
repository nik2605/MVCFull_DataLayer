using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using OrderManagement_MVC_Common;

namespace OrderManagement_MVC.Models
{
    public class Order
    {
        public Guid OrderId { get; set; }

        public string OrderName { get; set; }

        [Display(ResourceType =  typeof(Resources.OrderManagement),Name = "Order_OrderDate_Order_Date")]
        [Required]
        public DateTime OrderDate { get; set; }
        
        public Common.OrderStatus OrderStatus { get; set; }

        public decimal TotalAmount()
        {
            return 1000;
        }
    }
}