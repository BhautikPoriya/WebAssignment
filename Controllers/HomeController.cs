using Microsoft.AspNetCore.Mvc;

namespace WebAssignment.Controllers;

public class HomeController : Controller
{
   
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(string username, string password)
    {
        if (username == "admin" && password == "password")
        {
           
            string token = Guid.NewGuid().ToString();

            // Set cookie with token
            Response.Cookies.Append("AuthToken", token, new CookieOptions
            {
                HttpOnly = true,  
                Secure = true,    
                Expires = DateTime.UtcNow.AddMinutes(30) 
            });

            return RedirectToAction(nameof(Dashboard1));
        }

        ViewBag.Message = "Invalid credentials!";
        return View();
    }

    public IActionResult Dashboard1()
    {
        string token = Request.Cookies["AuthToken"];

        if (string.IsNullOrEmpty(token))
        {
            return RedirectToAction(nameof(Login));
        }

        ViewBag.Token = token;
        return View();
    }

    public IActionResult Logout()
    {
        Response.Cookies.Delete("AuthToken");
        return RedirectToAction(nameof(Login));
    }

}
