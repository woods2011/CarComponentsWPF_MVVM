using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using CarComponentsWPF.Models;

namespace CarComponentsWPF.Services.DataServices
{
    public class Class1
    {
        public Class1()
        {
            AuthenticationService test = new AuthenticationService();
            Console.WriteLine(test.Login("TestUser", "2002"));

            //IDataService<CarModel> sds = new GenericDataService<CarModel>();
            //var obj = sds.Get(1);
            //Console.WriteLine(obj.Name);
        }
    }
}
