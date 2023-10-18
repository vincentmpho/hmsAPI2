using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace hmsAPI2.Models
{
    public class ActiveEngredients
    {
        [Key]
        public int EngredientID { get; set; }

        public string EngredientName { get; set; }
    }
}
