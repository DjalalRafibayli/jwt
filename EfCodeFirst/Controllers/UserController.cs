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
        public async Task<IActionResult> Index(int page, int limit)
        {
            limit = limit > 100 ? 100 : limit;
            int[] limitTable = { 10, 25, 50, 100 };
            if (!limitTable.Contains(limit))
            {
                limit = 10;
            }
            ViewData["limit"] = limit;
            string url = string.Format($"{Configuration["Api:baseUrl"] }{$"User/GetAllUsers/{page}/{ limit }"}");
            UserFM userFM = new UserFM();
            userFM.username = "demo";
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
    }
}
