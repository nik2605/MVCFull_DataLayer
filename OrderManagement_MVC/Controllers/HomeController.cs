using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using OrderManagement_MVC.Mapper;
using OrderManagement_MVC.Models;
using OrderManagement_MVC_Common;

namespace OrderManagement_MVC.Controllers
{
    public class HomeController : SharedController
    {
        public ActionResult Index(string id)
        {
            Order order = new Order();

            if (!string.IsNullOrEmpty(id))
            {
                OrderManagement_MVC_DataLayer.Order ord = new OrderManagement_MVC_DataLayer.Order();

                order = ord.GetOrder(id).Map();

                var test = ord.GetOrdersTemp();
            }



            return View(order);
        }

        public ActionResult About()
        {

           

            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

       
    }
}