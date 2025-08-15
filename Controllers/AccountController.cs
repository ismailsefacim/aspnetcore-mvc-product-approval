using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Data;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace WebApp.Controllers
{
  public class AccountController : Controller
  {
    private readonly ProductContext _context;


    public AccountController(ProductContext context)
    {
      _context = context;
    }


    [HttpGet]
    public IActionResult Login()
    {
      return View();
    }


    [HttpPost]
    public IActionResult Login(string kullaniciAdi, string sifre)
    {
      var user = _context.Users
                  .Where(u => u.KullaniciAdi == kullaniciAdi && u.Sifre == sifre)
                  .Select(u => new
                  {
                    u.ID,
                    u.KullaniciAdi,
                    u.Role.RolAdi
                  })
                  .FirstOrDefault();

      if (user != null)
      {
        HttpContext.Session.SetString("kullaniciAdi", user.KullaniciAdi);
        HttpContext.Session.SetString("rol", user.RolAdi);
        if (user.RolAdi == "Admin")
        {
          return RedirectToAction("AllProducts", "Admin");
        }
        else
        {
          return RedirectToAction("Index", "Product");
        }
      }

      ViewBag.Hata = "Kullanıcı adı veya şifre hatalı.";
      return View();
    }


    public IActionResult Logout()
    {
      HttpContext.Session.Clear();
      return RedirectToAction("Login");
    }
  }
}