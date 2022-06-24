using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace MvcBugtracker.Controllers
{
    public class HelloWorldController : Controller
    {
        //
        // Get: /HelloWorld/
        public IActionResult Index()
        {
            return View();
        }

        //
        // GET: /HelloWorld/Welcome/
        // Requires using System.Text.Encodings.Web;
        public string Welcome(string name, int ID = 1)
        {
            return HtmlEncoder.Default.Encode($"Hello {name}, ID is: {ID}");
        }
    }
}