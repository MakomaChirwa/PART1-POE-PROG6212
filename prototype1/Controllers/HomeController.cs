using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace CMCS.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
        public IActionResult Login() => View();
        public IActionResult Register() => View();
        public IActionResult Claim() => View();
        public IActionResult TrackClaims() => View();
        public IActionResult PreApprove() => View();
        public IActionResult Approve() => View();

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            // For prototype: no validation, just redirect
            if (HttpContext.Session.GetString("Role") == null)
            {
                HttpContext.Session.SetString("Role", "Lecturer"); // default
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Register(string fullname, string email, string password, string confirmPassword, string role)
        {
            HttpContext.Session.SetString("Role", role);
            return RedirectToAction("Login");
        }
    }
}
