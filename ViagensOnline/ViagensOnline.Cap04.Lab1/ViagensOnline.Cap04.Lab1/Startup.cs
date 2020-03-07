using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.Cookies;

[assembly: OwinStartup(typeof(ViagensOnline.Cap04.Lab1.Startup))]

namespace ViagensOnline.Cap04.Lab1
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            app.UseCookieAuthentication(
                new CookieAuthenticationOptions()
                {
                    AuthenticationType = "AppViagensOnlineCookie",
                    LoginPath = new PathString("/Admin/Login")
                });
        }
    }
}
