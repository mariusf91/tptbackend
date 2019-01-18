using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThePhantomTroupe.Helper;
using ThePhantomTroupe.Repository;

namespace ThePhantomTroupe.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult RaiderIOCharacter(string n)
        {
            try
            {
                var h = new RaiderIOHelper();
                var c = h.GetCharacter(n);
                if (null == c)
                    return new HttpStatusCodeResult(404);

                var r = new RaiderIoRepository();
                r.InsertRaiderIOCharacter(c);

                return Redirect("/swagger");
            }catch(Exception e)
            {
                return Content(n + " ---> " + e.Message + " ---> " + e.ToString());
            }

        }
    }
}