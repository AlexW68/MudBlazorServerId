using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MudBlazorServerId.IdentityUtils
{
    public class BlazorCookieLoginMiddleware<TUser> where TUser : class
    {

        #region Static Login Cache

        static IDictionary<Guid, LoginModel<TUser>> Logins { get; set; }
            = new ConcurrentDictionary<Guid, LoginModel<TUser>>();

        public static Guid AnnounceLogin(LoginModel<TUser> loginInfo)
        {
            loginInfo.LoginStarted = DateTime.Now;
            var key = Guid.NewGuid();
            Logins[key] = loginInfo;
            return key;
        }
        public static LoginModel<TUser> GetLoginInProgress(string key)
        {
            return GetLoginInProgress(Guid.Parse(key));
        }

        public static LoginModel<TUser> GetLoginInProgress(Guid key)
        {
            if (Logins.ContainsKey(key))
            {
                return Logins[key];
            }
            else
            {
                return null;
            }
        }

        #endregion

        private readonly RequestDelegate _next;

        public BlazorCookieLoginMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, SignInManager<TUser> signInMgr, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (context.Request.Path == "/login" && context.Request.Query.ContainsKey("key"))
            {
                var key = Guid.Parse(context.Request.Query["key"]);
                var info = Logins[key];

                var result = await signInMgr.PasswordSignInAsync(info.Email, info.Password, info.RememberMe, lockoutOnFailure: false);
                
                //Uncache password for security:
                info.Password = null;

                if (result.Succeeded)
                {
                    Logins.Remove(key);
                    var user = await userManager.FindByNameAsync(info.Email);
                    var userRoles = await userManager.GetRolesAsync(user);
                    // based on the roles of the user you can redirect to any
                    // endpoint, put the most restrictive roles first e.g. Admin

                    foreach (string role in userRoles)
                    {
                        if (role.ToUpper() == "ADMINROLE")
                        {
                            context.Response.Redirect("/claims");
                            return;
                        }
                    }


                    //var userRoles = await UserManager.GetRolesAsync(user.Id);


                    // this is the key place to go after login

                    // based on what roles the users is included in the redirect will be different


                    context.Response.Redirect("/claims");
                    return;
                }
                else if (result.RequiresTwoFactor)
                {
                    context.Response.Redirect("/loginwith2fa/" + key);
                    return;
                }
                else if (result.IsLockedOut)
                {
                    info.Error = "You are locked out. Please contact support.";
                }
                else
                {
                    info.Error = "Login failed. Check your username and password.";
                    await _next.Invoke(context);
                }
            }
            else if (context.Request.Path.StartsWithSegments("/logout"))
            {
                await signInMgr.SignOutAsync();
                context.Response.Redirect("/login");
                return;
            }

            //Continue http middleware chain:
            await _next.Invoke(context);
        }
    }
}
