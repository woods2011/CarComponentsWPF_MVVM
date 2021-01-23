using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarComponentsWPF.Services.DataServices
{
    public interface IAuthenticationService
    {
        bool Login(string username, string password);
    }
}
