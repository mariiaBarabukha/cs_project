﻿using GUI.DataBase;
using GUI.Services;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows;

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


        public Guid Guid { get; }

        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public string Login { get; }
    }
}
