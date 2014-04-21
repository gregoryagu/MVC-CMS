using System.Web.Mvc;

namespace TheCommLine.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Dashboard()
        {
            return View("Dashboard");
        }
    }
}