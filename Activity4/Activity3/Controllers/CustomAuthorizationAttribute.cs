using System;
using System.Web.Mvc;

namespace Activity3.Controllers {

    //Define a [CustomAuthorization] attribute that can be decorated on any Controller or Controller Method to ensure user is authenticated
    public class CustomAuthorizationAttribute : FilterAttribute, IAuthorizationFilter {
        //This method is called before an Action Method is called to perform an Authorization check
        public void OnAuthorization(AuthorizationContext filterContext) {
            //TODO: This is where your Security Token and Security Business Logic would need to be run
            //If user is not authenticated then reidrect back to /Login action to force the Login Page to be displayed
            //filterContext.HttpContextResponse.Redirect("/Login");
            filterContext.Result = new RedirectResult("/Login");
        }



    }
}