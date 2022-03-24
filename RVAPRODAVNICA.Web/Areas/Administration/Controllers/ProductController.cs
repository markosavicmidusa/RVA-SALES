
using Microsoft.AspNetCore.Mvc;
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
            return View(productService.ReadAll());
            /*return View();*/
        } 
        #endregion

    }
}
