
using System;
using GUI.Authentication;
using GUI.Users;
using lab;
using Xunit;

namespace Test1
{
    public class AuthRegTests
    {
        [Fact]
        public void TestRegisterAndAuthenticate()
        {
            //this test covers using of UserHandler, customer.json dataBase and mentioned in the name methods of authentication and registration
            //
            var authService = new AuthenticationService();
            var regUser = new RegisteredUser()
            {
                Email = "email@gmail.com",
                FirstName = "FirstName",
                LastName = "LastName",
                Login = "Login",
                Password = "Password"
            };
            var authUser = new AuthenticationUser()
            {
                Login = "Login",
                Password = "Password"
            };

            //
            
            //
            var ex = Assert.ThrowsAsync<Exception>(() => authService.RegisterUser(regUser));
            Assert.False(ex.Result.Equals("User already exists"));
        }
    }
}
