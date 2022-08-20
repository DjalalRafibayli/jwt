using AnotherModels.FilterModels.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnotherModel.FilterModels.User
{
    public class UserFM : PaginationModel
    {
        public string username { get; set; }
    }
}
