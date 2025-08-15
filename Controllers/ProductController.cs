using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Data;
using System.Linq;

namespace WebApp.Controllers
{
  public class ProductController : Controller
  {
    private readonly ProductContext _context;

    public ProductController(ProductContext context)
    {
      _context = context;
    }

    public IActionResult Index()
    {
      if (HttpContext.Session.GetString("kullaniciAdi") == null)
        return RedirectToAction("Login", "Account");

      var products = _context.Products.ToList();
      return View(products);
    }

    [HttpGet]
    public IActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public IActionResult Create(Product product)
    {
      product.IsApproved = false;
      product.ApprovedAt = null;
      product.ApprovedByUserId = null;

      _context.Products.Add(product);
      _context.SaveChanges();

      if (HttpContext.Session.GetString("rol") == "Admin")
        return RedirectToAction("AllProducts", "Admin");
      else
        return RedirectToAction("Index", "Product");
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
      var product = _context.Products.FirstOrDefault(p => p.Id == id);
      if (product != null)
      {
        _context.Products.Remove(product);
        _context.SaveChanges();
      }

      if (HttpContext.Session.GetString("rol") == "Admin")
        return RedirectToAction("AllProducts", "Admin");
      else
        return RedirectToAction("Index", "Product");
    }


    [HttpGet]
    public IActionResult Edit(int id)
    {
      var product = _context.Products.FirstOrDefault(p => p.Id == id);
      if (product == null)
        return NotFound();

      return View(product);
    }


    [HttpPost]
    public IActionResult Edit(Product updatedProduct)
    {
      var product = _context.Products.FirstOrDefault(p => p.Id == updatedProduct.Id);
      if (product == null)
        return NotFound();

      product.Name = updatedProduct.Name;
      product.Price = updatedProduct.Price;

      _context.SaveChanges();

      if (HttpContext.Session.GetString("rol") == "Admin")
        return RedirectToAction("AllProducts", "Admin");
      else
        return RedirectToAction("Index", "Product");
    }




  }
}

