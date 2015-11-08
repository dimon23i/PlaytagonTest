using System.Web.Mvc;
using PlaytagonTest.DAL;
using PlaytagonTest.Web.Models;

namespace PlaytagonTest.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            using (var session = DbContext.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Save(new Character
                    {
                        Name = "Mike3"
                    });
                    transaction.Commit();
                }
            }

            return View();
        }
    }
}
