using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderManagement_MVC_Common
{
    public class Common
    {
        public enum OrderStatus
        {
            Pending,
            Approved,
            Active,
            Ordered,
            InTransit,
            Delivered
        }



    }
}