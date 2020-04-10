using System.Web.Mvc;

namespace Activity3.Controllers {

    public class TestController : Controller {


        [HttpGet]
        [CustomAuthorization]
        public ActionResult Index() {
            return Content("I am in the Test Controller. I should be protected content because of the custom authorization attribute.");
        }

        [HttpGet]
        public ActionResult LessSecureMethod() {
            return Content("I am less protected content.");
        }


    }
}