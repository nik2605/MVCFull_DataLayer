﻿using System;
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
            try
            {
                OrderManagement_MVC_DataLayer.Order ord = new OrderManagement_MVC_DataLayer.Order();
               // throw new Exception("Database not available! Please try again later.");
                return View(ord.GetOrders().Select(a => a.Map()));
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View(new List<Order>());
            }
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

        [HttpDelete]
        public JsonResult Delete(Guid id)
        {
            try
            {
                if (string.IsNullOrEmpty(id.ToString()))
                {
                    throw new Exception("Id cannot be null or empty");
                }

                OrderManagement_MVC_DataLayer.Order ord = new OrderManagement_MVC_DataLayer.Order();

                var order = ord.GetOrder(id.ToString());

                if (order != null && order?.OrderId == Guid.Empty)
                {
                    throw new Exception("Order not exist at all!");
                }

                order?.DeleteOrder(id);

                return Json("All good!");
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
    }
}