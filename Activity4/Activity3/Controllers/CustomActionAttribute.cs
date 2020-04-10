using Activity3.Services.Utility;
using System;
using System.Web.Mvc;

namespace Activity3.Controllers {

    //Define a [CustomAction] attribute that can be decorated on any Controller or Controller Method to log enter and exit of Action Methods
    public class CustomActionAttribute : FilterAttribute, IActionFilter {

        //This method is called after an Action Method is executed
        public void OnActionExecuted(ActionExecutedContext filterContext) {
            //Use our Logger service to log when we exit an Action method
            //NOTE: you would typically provide a configuration option to enable an disable this capability
            string name = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName + ":" + filterContext.ActionDescriptor.ActionName;
            MyLogger.GetInstance().Info("Existing Controller: " + name);
        }

        //This method is called before an Action is executed
        public void OnActionExecuting(ActionExecutingContext filterContext) {
            //Use our Logger service to log when we enter an Action method
            //NOTE: you would typically provide a configuration option to enable and disable this capability
            string name = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName + ":" + filterContext.ActionDescriptor.ActionName;
            MyLogger.GetInstance().Info("Entering Controller: " + name);

        }
    }
}