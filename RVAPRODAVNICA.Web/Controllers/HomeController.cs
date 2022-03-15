using System.Diagnostics;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using RVAPRODAVNICA.Data;
using RVAPRODAVNICA.Repositories;
using RVAPRODAVNICA.Web.Models;

namespace RVAPRODAVNICA.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductRepository productRepository;
        private readonly IOrderRepository orderRepository;
        public HomeController(ILogger<HomeController> logger, IProductRepository productRepository, IOrderRepository orderRepository)
        {
           
            _logger = logger;
            this.productRepository = productRepository;
            this.orderRepository = orderRepository;


        }

        public IActionResult Index()
        {
            List<Product>? resultProduct = productRepository.readAll();
            List<Order>? orderProduct = orderRepository.readAll();

            //Product product = new Product();
            //product.Name = "Laptop 3";

            //var createResult = productRepository.Create(product);
            
            return View();
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
}