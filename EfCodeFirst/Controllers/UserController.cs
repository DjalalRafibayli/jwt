using AnotherModel.FilterModels.User;
using EfCodeFirst.Models.Page;
using EfCodeFirst.Models.ViewModels;
using EfCodeFirst.Share.Api.Interfaces.Helpers;
using EfCodeFirst.Share.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EfCodeFirst.Controllers
{
    [ServiceFilter(typeof(TokenAttribute))]
    [Authorize]
    
    public class UserController : Controller
    {
        private readonly IHelperGetTable _helperGetTable;
        public IConfiguration Configuration { get; }
        public UserController(IHelperGetTable helperGetTable, IConfiguration configuration)
        {
            _helperGetTable = helperGetTable;
            Configuration = configuration;
        }
        public async Task<IActionResult> Index(UserFM userFM)
        {
            userFM.limit = userFM.limit > 100 ? 100 : userFM.limit;
            int[] limitTable = { 10, 25, 50, 100 };
            if (!limitTable.Contains(userFM.limit))
            {
                userFM.limit = 10;
            }
            ViewBag.username = userFM.username;
            //userFM.username = ViewBag.username;
            ViewData["limit"] = userFM.limit;
            //userFM.limit = ViewBag.limit;
            string url = string.Format($"{Configuration["Api:baseUrl"]}{$"User/GetAllUsers"}");
            //UserFM userFM = new UserFM();
            //userFM.username = "aaa";
            //userFM.limit = 50;
            //userFM.page = page;
            var responseApi = await _helperGetTable.GetTable(url, userFM);

            //if (responseApi != "" && responseApi != null)
            //{
            var users = JsonConvert.DeserializeObject<PagedResult<UserViewModel>>(responseApi);
            return View(users);
            //}
            //else
            //{
            //    return Redirect("home/error");
            //}
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
    }
}
