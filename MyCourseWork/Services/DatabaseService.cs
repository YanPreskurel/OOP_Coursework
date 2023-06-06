using FireSharp.Interfaces;
using FireSharp.Response;
using FireSharp;
using Newtonsoft.Json;
using MyCourseWork.Exceptions;
using MyCourseWork.Entities;
using FireSharp.Config;

namespace MyCourseWork.Services
{
    public class DatabaseService
    {
        private IFirebaseConfig ifc = new FirebaseConfig()
        {
            AuthSecret = "2PW0Gzqw5VG691pO1SB5jzjpzdx7EdcejM5jVj4y",
            BasePath = "https://mycoursework-16775-default-rtdb.firebaseio.com/"
        };

        private IFirebaseClient client;

        public DatabaseService()
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

        public async Task AddUserAsync(User user)
        {
            await client.SetAsync("Users/" + user.Id, user);
        }

        public async Task<User> GetUserAsync(string id)
        {
            FirebaseResponse response = await client.GetAsync("Users/" + id);
            var user = JsonConvert.DeserializeObject<User>(response.Body);
            return user;
        }

        public async Task UpdateUserAsync(User user)
        {
            await client.DeleteAsync("Users/" + user.Id);
            await client.SetAsync("Users/" + user.Id, user);
        }
    }
}
