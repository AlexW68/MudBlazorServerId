using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MudBlazorServerId.IdentityUtils
{
    public class LoginModel<TUser> where TUser: class
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public TUser User { get; set; }

        public string TwoFactorCode { get; set; }

        public bool RememberMe { get; set; }

        public bool RememberMachine { get; set; }

        public string ReturnUrl { get; set; } = "/";

        public DateTime LoginStarted { get; set; }

        public string Error { get; set; }
    }

}

