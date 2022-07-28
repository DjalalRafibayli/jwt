using EfCodeFirst.Share.Api.Interfaces.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EfCodeFirst.Controllers
{
    public class UserController : Controller
    {
        private readonly IHelperGetDatas _helperGetDatas;

        public UserController(IHelperGetDatas helperGetDatas)
        {
            _helperGetDatas = helperGetDatas;
        }

        public async Task<IActionResult> Index()
        {
            //var responseApi = await _helperGetDatas.GetDatas();
            return View();
        }
    }
}
