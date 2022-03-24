using System.Diagnostics;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using RRVAPRODAVNICA.Models;
using RVAPRODAVNICA.Data;
using RVAPRODAVNICA.Services;
//using RVAPRODAVNICA.Data;
//using RVAPRODAVNICA.Repositories;
using RVAPRODAVNICA.Web.Models;

namespace RVAPRODAVNICA.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //private readonly IProductRepository productRepository;
        //private readonly IOrderRepository orderRepository;

        private readonly IProductService productService;
        
        public HomeController(ILogger<HomeController> logger, IProductService productService /*, IProductRepository productRepository, IOrderRepository orderRepository*/)
        {
           
            _logger = logger;
            this.productService = productService;
            //this.productRepository = productRepository;
            //this.orderRepository = orderRepository;


        }

        public IActionResult Index()
        {
            //List<Product>? resultProduct = productRepository.readAll();
            //List<Order>? orderProduct = orderRepository.readAll();
            //Product product = new Product();
            //product.Name = "Laptop 3";
            //var createResult = productRepository.Create(product);

           // List<ProductModel>? resultProduct = productService.ReadAll();
            /*ProductModel product2 = productService.Get(1);*/

            Product product3 = new Product();
            /*product3.Name = "Laptop 44";
            product3.Active = true;
            product3.Description = "Great Laptop";
            product3.Price = 1200.00;
            product3.

            var createResult = productService.Create(product3);
            */



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