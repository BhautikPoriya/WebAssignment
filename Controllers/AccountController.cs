using Microsoft.AspNetCore.Mvc;

namespace WebAssignment.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            // Dummy authentication logic (Replace with database verification)
            if (username == "admin" && password == "password")
            {
                // Store user data in session
                HttpContext.Session.SetString("UserName", username);
                return RedirectToAction(nameof(Dashboard));
            }
            ViewBag.Message = "Invalid credentials!";
            return View();
        }

        public IActionResult Dashboard()
        {
            var userName = HttpContext.Session.GetString("UserName");
            if (string.IsNullOrEmpty(userName))
            {
                return RedirectToAction(nameof(Login));
            }

            ViewBag.UserName = userName;
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); // Clear session
            return RedirectToAction(nameof(Login));
        }
    }
}
