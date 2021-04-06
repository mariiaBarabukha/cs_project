using System;
using System.IO;

namespace GUI.Users
{
    public class User
    {
        public User(Guid guid, string firstName, string lastName, string email, string login)
        {
            Guid = guid;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Login = login;
        }

        public User(AuthenticationUser authUser)
        {
            StreamReader sr = new StreamReader(@"..\..\..\DataBase\ourCustomers.txt");


            int temp = sr.Read();
            int i = 0;

            if (temp == -1) throw new Exception("Login or password is incorrect");

            while (Convert.ToChar(temp) != ' ')
            {
                if (Convert.ToChar(temp) != authUser.Login.ToCharArray()[i])
                {
                    sr.ReadLine();
                    i = -1;

                }

                temp = sr.Read();
                i++;

                if (temp == -1) throw new Exception("Login or password is incorrect");

            }

            temp = sr.Read();
            i = 0;

            while (Convert.ToChar(temp) != ' ')
            {
                if (Convert.ToChar(temp) != authUser.Password.ToCharArray()[i])
                    throw new Exception("Wrong password.");

                temp = sr.Read();
                i++;
            }

            temp = sr.Read();

            string firstName = "";
            string lastName = "";
            string email = "";
            while (Convert.ToChar(temp) != ' ')
            {
                firstName += Convert.ToChar(temp);
                temp = sr.Read();
            }

            temp = sr.Read();
            while (Convert.ToChar(temp) != ' ')
            {
                lastName += Convert.ToChar(temp);
                temp = sr.Read();
            }

            temp = sr.Read();

            while (Convert.ToChar(temp) != ' ')
            {
                email += Convert.ToChar(temp);
                temp = sr.Read();
                if (temp == -1) break;
            }

            FirstName = firstName;
            Guid = new Guid();
            LastName = lastName;
            Email = email;
            Login = authUser.Login;

            sr.Close();

        }




        public Guid Guid { get; }

        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public string Login { get; }
    }
}
