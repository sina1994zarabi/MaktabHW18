using ECommerce.Models;
using ECommerce.Services;
using Microsoft.AspNetCore.Mvc;
public class UserController : Controller
{
    private readonly IUserService _userService;
    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(User user)
    {
        if (ModelState.IsValid)
        {
            _userService.Register(user);
            return RedirectToAction("Login");
        }
        return View(user);
    }

    public IActionResult Login()
    {
        return View();
    }


    [HttpPost]
    public IActionResult Login(string username, string password)
    {
        var user = _userService.Login(username, password);
        if (user != null)
        {
            InMemoryDb.Currentuser = user;
            return RedirectToAction("Index", "Home");
        }
        ModelState.AddModelError("", "Invalid username or password");
        return View();
    }

    public IActionResult Logout()
    {
        InMemoryDb.Currentuser = null;
        return RedirectToAction("Login");
    }
}
