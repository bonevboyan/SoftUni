using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.Data.Models
{
    public class User
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [MaxLength(20)]
        public string Username{ get; set; }
    }
}
