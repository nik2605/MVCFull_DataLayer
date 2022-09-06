using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OrderManagement_MVC.Models;
using OrderManagement_MVC_Common;

namespace OrderManagement_MVC.Mapper
{
    public static class OrderMapper
    {
        public static Order Map(this OrderManagement_MVC_DataLayer.Order entities)
        {
            Enum.TryParse(entities.OrderStatus, true, out Common.OrderStatus result2);

            return new Order()
            {
                OrderDate = entities.OrderDate,
                OrderId = entities.OrderId,
                OrderName = entities.OrderName,
                OrderStatus = result2
            };
        }
    }
}