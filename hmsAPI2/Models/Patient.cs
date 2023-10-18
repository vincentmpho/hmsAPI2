using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace hmsAPI2.Models
{
    public class Patient
    {
        [Key]
        [Required]
        [Column(TypeName = "nvarchar(15)")]
        public string PatientID { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string PatientName { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string PatientSurname { get; set; }

        [Column(TypeName = "nvarchar(150)")]
        public string PatientAddress { get; set; }

        [Column(TypeName = "nvarchar(15)")]
        public int PatientContact { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string PatientEmail { get; set; }

        public DateTime PatientDOB { get; set; }

        public string PatientGender { get; set; }

        public string Allegies { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string Chronic_code { get; set; }

        public string DIAGNOSIS { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string DATE_DIAGNOSED { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string MEDICATION_NAME { get; set; }


    }
}
