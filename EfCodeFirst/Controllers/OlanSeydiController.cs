using EfCodeFirst.Share.Api.Interfaces.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace EfCodeFirst.Controllers
{
    public class OlanSeydiController : Controller
    {
        public IConfiguration Configuration { get; }
        public IRequest request;

        public OlanSeydiController(IConfiguration configuration, IRequest request)
        {
            Configuration = configuration;
            this.request = request;
        }

        public IActionResult Index()
        {
            string url = string.Format($"{Configuration["Api:baseUrl"]}{$"User/GetAllUsers"}");
            var responseApi = request.GetTable(url);
            
            return View();
        }
    }
}
