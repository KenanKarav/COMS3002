
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PGASystem.Models;
using PGASystemData;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CaseManagement.Controllers
{
    public class AuthController : Controller
    {
        private readonly PGAContext _ctx;

        public AuthController(PGAContext ctx)
        {
            _ctx = ctx;
        }

    
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return GoToReturnUrl();
            }
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string email, string password)
        {
            var user = _ctx.Users
                           .Include(us => us.Position)
                           .SingleOrDefault(m => m.Email == email);
          
            if(user != null)
            {
                if (password == user.Password)
                {
                    var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, Convert.ToString(user.Id), ClaimValueTypes.Integer, ""),
                    new Claim(ClaimTypes.Name, Convert.ToString(user.FirstName), ClaimValueTypes.String, ""),
                      new Claim(ClaimTypes.Role, Convert.ToString(user.Position.PositionName), ClaimValueTypes.String, "")


                };
                    var userIdentity = new ClaimsIdentity(claims, "SecureLogin");
                    var userPrincipal = new ClaimsPrincipal(userIdentity);
                    

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        userPrincipal,
                        new AuthenticationProperties
                        {
                            ExpiresUtc = DateTime.UtcNow.AddMinutes(40),
                            IsPersistent = false,
                            AllowRefresh = true
                            
                        });

                    return GoToReturnUrl();
                }
            }

            return RedirectToAction(nameof(Index));
        }

        private IActionResult GoToReturnUrl()
        {
           
            return RedirectToAction("Index", "Home");
        }

      

        public IActionResult Denied()
        {
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction(nameof(Index));
           
        }
    }
}
