using Activity3.Models;
using Activity3.Services.Business.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Activity3.Services.Business{
    public class SecurityService{
        public bool Authenticate(UserModel user){
            SecurityDAO service = new SecurityDAO();
            return service.FindByUser(user);
        }



    }
}