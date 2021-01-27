using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace CarComponentsWPF.Services.DataServices
{
    public class AuthenticationService : IAuthenticationService
    {
        public bool Login(string username, string password)
        {
            var sha1 = new SHA1CryptoServiceProvider();
            var sha1data = sha1.ComputeHash(Encoding.ASCII.GetBytes(password));
            //var sha1data = sha1.ComputeHash(Encoding.ASCII.GetBytes("!Sfbovdolkntw2002"));
            string inputPassHash = Encoding.ASCII.GetString(sha1data);
            //Console.WriteLine(inputPassHash);
            


            string passHash = "";

            if (_loginPassHashDictionary.TryGetValue(username, out passHash))
                if (passHash == inputPassHash)
                    return true;

            return false;
        }


        private Dictionary<string, string> _loginPassHashDictionary;

        public AuthenticationService()
        {
            //Временное решение
            _loginPassHashDictionary = new Dictionary<string, string>();
            //_loginPassHashDictionary.Add("TestUser", @".?w????h>V???~m?h?y");
            _loginPassHashDictionary.Add("TestUser2000", @"??	???\p6?[?6???????");
        }
    }
}
