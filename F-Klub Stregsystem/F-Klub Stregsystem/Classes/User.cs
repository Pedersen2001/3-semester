﻿using F_Klub_Stregsystem.Interfaces;
using System.Text.RegularExpressions;

namespace F_Klub_Stregsystem.Classes
{
    public class User : IComparable<User>
    {
        private int _id;
        private string _firstName;
        private string _lastName;
        private string _userName;
        private string _email;
        private decimal _balance;

        public int ID { get { return _id; } set { _id = value; } }
        public string FirstName { get { return _firstName; } set { _firstName = value; } }
        public string LastName { get { return _lastName; } set { _lastName = value; } }
        public string Email { get { return _email; } set { _email = value; } }
        public string UserName { get { return _userName; } set { _userName = value; } }
        public decimal Balance { get { return _balance; } set { _balance = value; } }


        public delegate void UserBalanceNotification(User user, decimal balance);

        public event UserBalanceNotification OnUserBalanceNotification;

        public User(int id, IIdProvider idProvider, string firstName, string lastName, string email, string userName, decimal balance)
        {
            _id = idProvider.TryId(id);

            if (string.IsNullOrEmpty(firstName))
            {
                throw new ArgumentException("Firstname can't be null or empty");
            }


            if (string.IsNullOrEmpty(lastName))
            {
                throw new ArgumentException("Lastname can't be null or empty");
            }


            if (!IsValidUsername(userName))
            {
                throw new ArgumentException("Username is invalid");
            }


            if (!IsValidEmail(email))
            {
                throw new ArgumentException("Email is invalid");
            }


            _firstName = firstName;
            _lastName = lastName;
            _userName = userName;
            _email = email;

            if (balance < 50)
            {
                OnUserBalanceNotification?.Invoke(this, balance);
            }
            else
            {
                _balance = balance;
            }
        }

        public override string ToString()
        {
            return $"Name: { FirstName} { LastName} ID: {ID} Usernam: {UserName} (Email:  { Email})";
        }

        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }

        // If the return is 1, the obj.ID is bigger than ID, meaning that the obj.ID hasn't been a member as long as ID.
        public int CompareTo(User other)
        {
            return ID.CompareTo(other.ID);
        }


        //The first line performs a null check and checks if the type of obj is the same as the type of the current instance.
        //If either of these conditions is not met, the method returns false, indicating that the objects are not equal.
        //The second line casts the obj to a User type and assigns it to the variable user.
        //The final line returns the result of a comparison between the ID property of the current instance and the ID property of the user object.
        //If the two values are equal, the method returns true, indicating that the objects are equal.
        //The method is checking if the two User objects have the same ID property.
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            User user = (User)obj;
            return ID == user.ID;
        }


        // Regular expression:
        // ^[a-z0-9_]+$ checks that username starts with either lowercase from a-z, digits from 0-9, underscore (-) repeadetly
        // The ^ is used to match at the start of a string. The $ is used to match at the end of a string. 
        // When used together, it ensure that the entire string is matched, and any extra charachters before or after ^ $ will ensure the pattern wont match
        private bool IsValidUsername(string username)
        {
            return Regex.IsMatch(username, @"^[a-z0-9_]+$");
        }


        // Regular expression:
        // ^[a-zA-Z0-9._-]+ checks that email starts with either lowercase from a-z, uppercase from A-Z, digits from 0-9, period, underscore or hyphen (. _ -) repeadetly
        // email is followed by @
        // [a-zA-Z0-9.-]+ checks that email starts with either lowercase from a-z, uppercase from A-Z, digits from 0-9, period or hyphen (. -) repeadetly
        // \. indicates, that there is a . in the email
        // [a-zA-Z]{2,}$ indicates, that the email end has a domain, that is atleast 2 characters long, with charazters from a-z and A-Z 
        // The ^ is used to match at the start of a string. The $ is used to match at the end of a string. 
        // When used together, it ensure that the entire string is matched, and any extra charachters before or after ^ $ will ensure the pattern wont match
        private bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
        }

    }
}