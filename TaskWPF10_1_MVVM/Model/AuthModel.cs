using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace TaskWPF10_1_MVVM.Model
{
    public static class AuthModel
    {
        private const string ValidUsername = "admin";
        private const string ValidPassword = "12345";

        public static bool Authenticate(string? username, string? password)
        {
            bool status = false;
            if (username == ValidUsername && password == ValidPassword) { status = true; }
            return status;
        }
    }
}
