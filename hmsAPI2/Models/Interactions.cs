using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace hmsAPI2.Models
{
    public class Interactions
    {
        [Key]
        public int InteractionID { get; set; }

        public string Name { get; set; }

        public string With { get; set; }
    }
}
