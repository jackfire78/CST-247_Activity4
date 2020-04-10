using Activity3.Models;
using Activity3.Services.Business;
using Activity3.Services.Utility;
using NLog;
using System;
using System.Collections.Generic;
using System.Runtime.Caching;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Activity3.Controllers {

    public class LoginController : Controller {

        // GET: Login
        [CustomAction]
        public ActionResult Index() {
            return View("Login");
        }

        [HttpPost]
        public ActionResult Login(UserModel user) {

            //put an item in the log file stateting you've entered this method
            MyLogger.GetInstance().Info("");
            MyLogger.GetInstance().Info("Entering the login controller. Login method");
            try {

                //Call the Security Business Service Authenticate() method from the Login() method
                //and save the results of the method call in a local method variable

                SecurityService securityService = new SecurityService();
                Boolean success = securityService.Authenticate(user);

                if (success) {
                    MyLogger.GetInstance().Info("Exiting the login controller. Login Success!");

                    return View("LoginSuccess", user); //"<h2>Login Success</h2><p>User: " + user.Username + " Pass: " + user.Password + " is correct!</p>";
                } else {
                    MyLogger.GetInstance().Info("Exiting the login controller. Login Failure");

                    return View("LoginFailed");  //"<h1>Fail!</h1>";
                }

            } catch (Exception e) {
                MyLogger.GetInstance().Error("Exception!" + e.Message);

                return Content("Exception in login" + e.Message);
            }
        }

        [HttpGet]
        public string GetUsers() {
            //Get the default memory cache
            var cache = MemoryCache.Default;

            //Get Users from the Cache and if Users do not exist in the Cache then put them in Cache
            List<UserModel> users = cache.Get("Users") as List<UserModel>;
            if (users == null) {
                //Log Message
                MyLogger.GetInstance().Info("Jack's App: Creating Users and putting them into the Cache.");

                //Create a List of Users
                users = new List<UserModel>();
                users.Add(new UserModel("Mark", "Test1"));
                users.Add(new UserModel("Justine", "Test1"));
                users.Add(new UserModel("Brianna", "Test1"));

                //Save the Users in the Cache with a 60s expiration policy 
                var policy = new CacheItemPolicy().AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(60.0);
                cache.Set("Users", users, policy);
            } else {
                //Log Message
                MyLogger.GetInstance().Info("Jack's App: Got Users from the Cache.");
            }
            //Return JSON Serialized list of users
            return new JavaScriptSerializer().Serialize(users);
        }
        
        [HttpGet]
        [CustomAuthorization]
        public ActionResult privateSectionMustBeLoggedIn() {
            return Content("I am a protected method if the propter attribute is applied to me.");
        }


    }
}