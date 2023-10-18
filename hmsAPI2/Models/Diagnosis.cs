using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace hmsAPI2.Models
{
    public class Diagnosis
    {
        [Key]
        public string ICD10_code { get; set; }

        public string DiagnosisName { get; set; }

        public DateTime DateDiagnosed { get; set; }
    }
}
