using FireSharp.Interfaces;
using FireSharp.Response;
using FireSharp;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FireSharp.Config;
using MyCourseWork.Exceptions;
using MyCourseWork.Entities;

namespace MyCourseWork.Data
{
    public class FireBaseService
    {
        private IFirebaseConfig ifc = new FirebaseConfig()
        {
            AuthSecret = "AIzaSyBw1KwO850Rv3txzjkJA56j1U2EAZOhp58",
            BasePath = "https://mycoursework-default-rtdb.europe-west1.firebasedatabase.app/"
           // BasePath = "https://mycoursework-16775.firebaseapp.com/__/auth/action?mode=action&oobCode=code"
        };

        private IFirebaseClient client;

        public FireBaseService()
        {
            try
            {
                client = new FirebaseClient(ifc);

            }
            catch
            {
                throw new NoInternetException();
            }
        }
    
        public async void AddUserAsync(User user)
        {
            await client.SetAsync("Users/" + user.Id + "/UserInfo", user);
        }
     
        public async void RemoveUserAsync(User user)
        {
            await client.DeleteAsync("Users/" + user.Id);
        }

        public async void UpdateUserAsync(User user)
        {
            await client.DeleteAsync("Users/" + user.Id);
            await client.SetAsync("Users/" + App.User.Id + "/UserInfo", App.User);
        }       

    }
}
