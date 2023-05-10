using Microsoft.AspNetCore.Mvc;

namespace View.Controllers
{
    public class ProductsController : Controller
    {
        [Route("products/all")]
        public IActionResult All()
        {
            return View();
        }
    }
}
