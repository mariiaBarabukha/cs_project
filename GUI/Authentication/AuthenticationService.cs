using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GUI.DataBase;
using GUI.Services;
using GUI.Users;

namespace GUI.Authentication
{
    public class AuthenticationService
    {

        private static List<DBUser> _users = new List<DBUser>();
        public async Task<User> Authenticate(AuthenticationUser authUser)
        {

            if (String.IsNullOrWhiteSpace(authUser.Login) || String.IsNullOrWhiteSpace(authUser.Password))
                throw new ArgumentException("Login or password is empty");
            UserHandler userHandler = new UserHandler();
            userHandler.Filename = @"../../../DataBase/Customer/customers.json";
            var users = await userHandler.Find(authUser.Login);
            var dbUser = users.FirstOrDefault(user => user.Login == authUser.Login && 
            user.Password == authUser.Password);

            if (dbUser == null)
            {
                throw new Exception("Incorrect password!");
            }
            return new User(dbUser.Guid, dbUser.FirstName, dbUser.LastName, dbUser.Email, dbUser.Login);
        }

        public async Task<bool> RegisterUser(RegisteredUser regUser)
        {
            Thread.Sleep(2000);
            UserHandler userHandler = new UserHandler();
            userHandler.Filename = @"../../../DataBase/Customer/customers.json";
            List<DBUser> users = await userHandler.GetAllAsync();
            var dbUser = users.FirstOrDefault(user => user.Login == regUser.Login);
            if (dbUser != null)
                throw new Exception("User already exists");
            if (String.IsNullOrWhiteSpace(regUser.Login) || String.IsNullOrWhiteSpace(regUser.Password) || String.IsNullOrWhiteSpace(regUser.LastName))
                throw new ArgumentException("Login, Password or Last Name is Empty");
            dbUser = new DBUser(regUser.FirstName, regUser.LastName, regUser.Email,
                regUser.Login, regUser.Password);
            await userHandler.write(dbUser);
            return true;

        }
    }
}
