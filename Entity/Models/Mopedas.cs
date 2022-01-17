using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class Mopedas
    {
        [Key]
        public int Id { get; set; } 
        public string Marke { get; set; } 
        public string Modelis { get; set; }

        public int ? SavininkoId { get; set; }
    }
}
