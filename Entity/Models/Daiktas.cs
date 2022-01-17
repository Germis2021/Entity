using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class Daiktas
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set; }
        public string Pavadinimas { get; set; }

        public int? SavininkasId { get; set; }

    }
}
