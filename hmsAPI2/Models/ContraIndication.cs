using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace hmsAPI2.Models
{
    public class ContraIndication
    {
        [Key]
        public string ICD10_code { get; set; }

        public string ActiveEngredients { get; set; }

        public string Diagnosis { get; set; }
    }
}
