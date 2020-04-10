using Activity3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace HelloWorldService {
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class UserService : IUserService {


        List<UserModel> users = new List<UserModel>();


        public UserService() {
            //create a List of Users
            users.Add(new UserModel("Jack", "test1"));
            users.Add(new UserModel("Mark", "test1"));
            users.Add(new UserModel("Jackie", "test1"));
        }

        public DTO GetAllUsers() {
            //return List of Users
            //Note: normally this would call a Business Service and DAO to get this information
            DTO dto = new DTO(0, "OK", users);
            return dto;
        }

        public DTO GetUser(string id) {
            //return a specified User
            //Note: normally this would call a Business Service and DAO to get this information
            int index = Int32.Parse(id);    
            if(index > users.Count) {
                //Index is out of bounds so set an error in the DTO and return the DTO
                DTO dto = new DTO(-1, "User Does NOT Exist", null);
                return dto;
            } else {
                //Initialize DTO with a User and return the DTO
                List<UserModel> user = new List<UserModel>();
                user.Add(users[index]);
                DTO dto = new DTO(0, "OK", user);
                return dto;
            }
                
                
        }




        public string GetData(string value) {
            return "If your voice travels " + value + "meters. The area of influence of your voice is " + Int32.Parse(value) * 3.14 + "sq meters";
        }

        public CompositeType GetObjectModel(string id) {
            if (id == null) {
                throw new NotImplementedException();
            }
            CompositeType composite = new CompositeType();
            if(Int32.Parse(id) < 0) {
                composite.BoolValue = false;
                composite.StringValue = "I am not well :-(";
            } else {
                composite.BoolValue = true;
                composite.StringValue = "I am very happy, thank you :)";
            }
            return composite;
        }

        public string SayHello() {
            return "Hi, this is a message from the SayHello() in Service1";     
        }

    }
}
