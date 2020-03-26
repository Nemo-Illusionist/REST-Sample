using Microsoft.AspNetCore.Mvc;

namespace Sample.Web.Admin.Controllers
{
    /// <summary>
    /// Home controller
    /// </summary>
    public class HomeController : ControllerBase
    {
        /// <summary>
        /// Base method
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return Redirect("/swagger");
        }
    }
}