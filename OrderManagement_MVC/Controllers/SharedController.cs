using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace OrderManagement_MVC.Controllers
{
    public class SharedController : Controller
    {
        public ActionResult Language(int id)
        {
            Helper.Helper.CurrentCulture = id;

            if (!(Request.UrlReferrer is null))
            {
                return Redirect(Request.UrlReferrer.ToString());
            }

            return RedirectToRoute("/");

        }

        protected override IAsyncResult BeginExecute(System.Web.Routing.RequestContext context, AsyncCallback callback, object state)
        {
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture = Helper.Helper.Culture ?? new CultureInfo("en-US");
            return base.BeginExecute(context, callback, state);
        }
    }
}