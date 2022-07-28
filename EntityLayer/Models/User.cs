using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Models
{
    public class User
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string refreshtoken { get; set; }
        public DateTime? refreshtokenExpireTime { get; set; }
        public byte active { get; set; }
    }
}