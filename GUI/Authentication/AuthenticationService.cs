using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Windows.Documents;
using GUI.Users;

namespace GUI.Authentication
{
    public class AuthenticationService
    {

        private static List<DBUser> _users = new List<DBUser>();
        public User Authenticate(AuthenticationUser authUser)
        {

            if (String.IsNullOrWhiteSpace(authUser.Login) || String.IsNullOrWhiteSpace(authUser.Password))
                throw new ArgumentException("Login or password is empty");

            return new User(authUser);
        }

        public User RegisterUser(RegisteredUser regUser)
        {
            var dbUser = _users.FirstOrDefault(user => user.Login == regUser.Login);
            if (dbUser != null)
               throw new Exception("User already exists");

            if (String.IsNullOrWhiteSpace(regUser.Login) || String.IsNullOrWhiteSpace(regUser.Password) ||
                String.IsNullOrWhiteSpace(regUser.LastName))
                throw new ArgumentException("Login, Password or Last Name is empty");
            dbUser = new DBUser(regUser.FirstName, regUser.LastName, regUser.Email, regUser.Login, regUser.Password);
            _users.Add(dbUser);
            return new User(dbUser.Guid, dbUser.FirstName, dbUser.LastName, dbUser.Email, dbUser.Login);

        }
    }
}
