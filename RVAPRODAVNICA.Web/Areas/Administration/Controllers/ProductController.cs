
using Microsoft.AspNetCore.Mvc;
using RRVAPRODAVNICA.Models;
using RVAPRODAVNICA.Services;

namespace RVAPRODAVNICA.Web.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Route("Administration/[controller]/[action]/{id?}")]
   
    public class ProductController : Controller
    {
        #region Dependency injection
        private readonly IProductService productService;
        #endregion

        #region Constructors
        
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="productService"></param>
        public ProductController(IProductService productService)
        {

            this.productService = productService;
        }
        #endregion

        #region Functions
        
        
        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns></returns>
        public IActionResult Products()
        {
            //return View(productService.ReadAll());
            return View();
        }

        

        /// <summary>
        /// Adding certain collections from db
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="rowsPerPage"></param>
        /// <returns></returns>

        public IActionResult Rows(int pageNumber, int rowsPerPage, string search)
        {
            var products = productService.TableSearch(pageNumber, rowsPerPage, search);
            return View(products);
            /*return View();*/
        }


        /// <summary>
        /// Create method
        /// </summary>
        /// <returns></returns>
        public IActionResult Create() { 
                
            return View();

        }


        /// <summary>
        /// Post Create method
        /// </summary>
        /// <returns></returns
        [HttpPost]
        public IActionResult Create(ProductModel model) 
        {
            if (!ModelState.IsValid)
            {
                TempData["Response"] = false;
                TempData["ResponseMessage"] = "Neuspesno kreiranje !";
                return View(model);
            }
            else
            {

                try
                {
                    var result = productService.Create(model);
                    
                    if (result != null)
                    {
                        TempData["Response"] = true;
                        TempData["ResponseMessage"] = "Uspesno kreirano !";
                        return View(model);
                    }
                    else
                    {
                        TempData["Response"] = false;
                        TempData["ResponseMessage"] = "Neuspesno kreiranje !";
                        return View(model);

                    }
                   

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                    TempData["Response"] = false;
                    TempData["ResponseMessage"] = "Neuspesno kreiranje !";
                    return View(model);
                }


            }

        }

        /// <summary>
        /// Update method
        /// </summary>
        /// <returns></returns>
        public IActionResult Update( int id) {

            var result = productService.ReadOne(id);
            return View(result);
        }

        /// <summary>
        /// Update method post
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpPost]
        public IActionResult Update(ProductModel model)
        {

            if (!ModelState.IsValid)
            {
                TempData["Response"] = false;
                TempData["ResponseMessage"] = "Neuspesno editovanje !";
                return View(model);
            }
            else
            {

                try
                {
                  productService.Update(model);

                   
                        TempData["Response"] = true;
                        TempData["ResponseMessage"] = "Uspesno editovanje !";
                        return View(model);

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                    TempData["Response"] = false;
                    TempData["ResponseMessage"] = "Neuspesno editovanje !";
                    return View(model);
                }
            }

        }


        #endregion

    }
}
