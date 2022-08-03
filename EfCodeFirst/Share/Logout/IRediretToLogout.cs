using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EfCodeFirst.Share.Logout
{
    public interface IRediretToLogout : IActionFilter
    {
        void LocalRedirect(ActionExecutingContext context);
    }
}
