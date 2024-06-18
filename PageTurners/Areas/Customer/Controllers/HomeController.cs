using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PageTurners.DataAccess.Repository;
using PageTurners.DataAccess.Repository.IRepository;
using PageTurners.Models;

namespace PageTurners.Areas.Customer.Controllers;
[Area("Customer")]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
        IEnumerable<Product> productList = _unitOfWork.Product.GetAll(includeProperties: "Category,ProductImages");
        return View(productList);
    }

    public IActionResult Details(int productId)
    {
        //ShoppingCart cart = new()
        //{
        Product product = _unitOfWork.Product.Get(u => u.Id == productId, includeProperties: "Category,ProductImages");
        //    Count = 1,
        //    ProductId = productId
        //};
        return View(product);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

