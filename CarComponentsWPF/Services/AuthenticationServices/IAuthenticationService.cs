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

    public class TryAuthResultEventArgs : EventArgs
    {
        public TryAuthResultEventArgs(bool? authResult, string errorMessage)
        {
            AuthResult = authResult;
            ErrorMessage = errorMessage;
        }

        public bool? AuthResult { get; }
        public string ErrorMessage { get; }
    }

    public delegate void TryAuthResultEventHandler(object sender, TryAuthResultEventArgs e);
}
