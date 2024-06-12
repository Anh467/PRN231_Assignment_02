using Microsoft.AspNetCore.Mvc;
using Entity.Models;
using eBookStore.Utils;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using eBookStore.Models;
namespace eBookStore.Controllers
{
    public class AuthenController : Controller
    {
        HttpClient? _client;
        string _url;

        public AuthenController()
        {
            _client = new HttpClient();
            _url = "https://localhost:7151/api/User";
        }

        [Route("~/Authen/SignIn")]
        public IActionResult SignIn(string requestPath)
        {
            if (User.Identity.IsAuthenticated)
            {
                return Redirect("~/");
            }

            ViewBag.RequestPath = requestPath ?? "/";
            return View();
        }
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        [Route("~/Authen/SignUp")]
        public async Task<IActionResult> SignUp(User user)
        {

            if (User.Identity.IsAuthenticated)
            {
                return Redirect("~/SignIn");
            }
            try
            {
                if (ModelState.IsValid)
                {
                    user = await ApiHandler.DeserializeApiResponse<User>(_url, HttpMethod.Post, user);
                    return Redirect("~/Authen/SignIn");
                }

                //return Redirect("~/Authen/SignIn");
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
            }

            return View();
        }

        [Route("~/Authen/SignIn")]
        [HttpPost]
        public async Task<IActionResult> SignIn(User model)
        {
            // get user
            var urlTemp = $"{_url}?$filter={nameof(Entity.Models.User.Password)} eq '{model.Password}' and " +
            $"{nameof(Entity.Models.User.EmailAddress)} eq '{model.EmailAddress}'";
            var users = (await ApiHandler.DeserializeApiResponse<List<User>>($"{urlTemp}", HttpMethod.Get));
            if(users == null || users.Count() == 0)
                return View(model);
            var temp = users[0];
            if (temp == null)
            {
                ViewBag.Message = "Wrong credential";
                return View(model);
            }
                
            string role = "admin";
            if (!temp.EmailAddress.Equals("admin@estore.com"))
                role = "user";
            // create claims
            List<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, "Cookie authentication demo"),
                    new Claim(ClaimTypes.Email, temp.EmailAddress),
                    new Claim(ClaimTypes.NameIdentifier, temp.UserId.ToString()),
                    new Claim(ClaimTypes.Role, role)
                };

            // create identity
            ClaimsIdentity identity = new ClaimsIdentity(claims, "cookie");

            // create principal
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);

            // sign-in
            await HttpContext.SignInAsync(
                    scheme: "DemoSecurityScheme",
                    principal: principal,
                    properties: new AuthenticationProperties
                    {
                        //IsPersistent = true, // for 'remember me' feature
                        //ExpiresUtc = DateTime.UtcNow.AddMinutes(1)
                    });

            return Redirect("~/");
        }

        [Route("~/Authen/Logout")]
        [HttpGet]
        public async Task<IActionResult> Logout(string requestPath)
        {
            await HttpContext.SignOutAsync(
                    scheme: "DemoSecurityScheme");

            return Redirect("~/Authen/SignIn");
        }
    }
}
