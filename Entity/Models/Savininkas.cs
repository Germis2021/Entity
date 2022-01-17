using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class Savininkas
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set; }
        public string Vardas { get; set; }

    }
}
