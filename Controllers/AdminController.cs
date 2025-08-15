using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;

namespace WebApp.Controllers
{
  public class AdminController : Controller
  {
    private readonly ProductContext _context;

    public AdminController(ProductContext context)
    {
      _context = context;
    }

    public IActionResult Index()
    {
      if (HttpContext.Session.GetString("rol") != "Admin")
        return RedirectToAction("Login", "Account");

      return View();
    }

    public IActionResult AllProducts()
    {
      if (HttpContext.Session.GetString("rol") != "Admin")
        return RedirectToAction("Login", "Account");

      var products = _context.Products
    .Include(p => p.ApprovedByUser)
    .Select(p => new
    {
      p.Id,
      p.Name,
      p.Price,
      p.IsApproved,
      p.ApprovedAt,
      ApprovedBy = p.ApprovedByUser != null ? p.ApprovedByUser.KullaniciAdi : "—"
    })
    .ToList();

      ViewBag.Products = products;

      return View();
    }

    [HttpPost]
    public IActionResult Approve(int id)
    {
      var product = _context.Products.FirstOrDefault(p => p.Id == id);
      if (product == null) return NotFound();

      product.IsApproved = true;
      product.ApprovedAt = DateTime.Now;

      var currentUserName = HttpContext.Session.GetString("kullaniciAdi");
      var currentUser = _context.Users.FirstOrDefault(u => u.KullaniciAdi == currentUserName);
      if (currentUser != null)
        product.ApprovedByUserId = currentUser.ID;

      _context.SaveChanges();

      return RedirectToAction("AllProducts");
    }
  }
}