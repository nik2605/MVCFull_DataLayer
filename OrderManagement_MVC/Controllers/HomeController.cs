using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OrderManagement_MVC.Models;

namespace OrderManagement_MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string id)
        {
            Order order = new Order();
            if (!string.IsNullOrEmpty(id))
            {
                OrderManagement_MVC_DataLayer.Order ord = new OrderManagement_MVC_DataLayer.Order();

                var data = ord.GetOrder(id);

                var temp = ord.GetOrders();
            }


            ViewBag.Nik = "This is test value";

            ViewBag.Nik = "This";




            return View(new Order(){OrderName = "TEST"});
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