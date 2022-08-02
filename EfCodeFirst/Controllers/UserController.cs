using EfCodeFirst.Models.ViewModels;
using EfCodeFirst.Share.Api.Interfaces.Helpers;
using EfCodeFirst.Share.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EfCodeFirst.Controllers
{
    [ServiceFilter(typeof(TokenAttribute))]
    public class UserController : Controller
    {
        private readonly IHelperGetTable _helperGetTable;
        public IConfiguration Configuration { get; }
        public UserController(IHelperGetTable helperGetTable, IConfiguration configuration)
        {
            _helperGetTable = helperGetTable;
            Configuration = configuration;
        }
        [Authorize]
        public async Task<IActionResult> Index()
        {

            var responseApi = await _helperGetTable.GetTable(Configuration["Api:baseUrl"] + "User/GetAllUsers/10/15");
            
            if (responseApi != null)
            {
                var users = JsonConvert.DeserializeObject<List<UsersViewModel>>(responseApi);
                return View(users);
            }
            else
            {
                return Redirect("home/error");
            }
        }
    }
}
