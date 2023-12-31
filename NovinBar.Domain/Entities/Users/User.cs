﻿using NovinBar.Domain.Entities.Users;
using NovinBar.Domain.SendingShipments;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace NovinBar.Domain.Users
{
    public class User
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string UserName { get; private set; }
        public string PassWord { get; private set; }
        public string PhoneNumber { get; private set; }
        public bool IsDelete { get; private set; }

        public User(string firstName, string lastName, string userName, string passWord, string phoneNumber)
        {
            CheckUser.FirstName(firstName);
            CheckUser.LastName(lastName);
            CheckUser.UserName(userName);
            CheckUser.Password(passWord);
            CheckUser.PhoneNumber(phoneNumber);
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            PassWord = passWord;
            PhoneNumber = phoneNumber;
            IsDelete = false;
        }
        public void UpdateUser(string firstName , string lastName , string passWord
           , string phoneNumber)
        {
            CheckUser.FirstName(firstName);
            CheckUser.LastName(lastName);
            CheckUser.Password(passWord);
            CheckUser.PhoneNumber(phoneNumber);
            FirstName = firstName;
            LastName = lastName;
            PassWord = passWord;
            PhoneNumber = phoneNumber;
        }
        public void Delete()
        {
            IsDelete= true;
        }
        public void Recovery()
        {
            IsDelete = false;
        }

    }
}
