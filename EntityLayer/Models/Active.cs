using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Models
{
    public class Active
    {
        public int Id { get; set; }
        public string name { get; set; }
        public byte sequ { get; set; }
        public byte active { get; set; }
    }
}
