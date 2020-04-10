using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Activity3.Models{
    [DataContract]
    public class UserModel{

        public UserModel() {
            this.Username = "";
            this.Password = "";
        }

        public UserModel(string username, string password) {
            this.Username = username;
            this.Password = password;
        }

        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string Password { get; set; }


    }
}