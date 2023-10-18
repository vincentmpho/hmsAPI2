using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace hmsAPI2.Models
{
    public class Prescription
    {
        [Key]
        public int PrescriptionId { get; set; }

        [Display(Name = "Prescription Date")]
        public DateTime PrescriptionDate { get; set; }

        // doctor

        public string Medication{ get; set; }

        [Display(Name = "Quantity")]
        // string
        public string Quantity { get; set; }

        [Column(TypeName ="nvarchar(255)")]
        public string Instructions { get; set; }

        public int Repeats { get; set; }

        public int RepeatsLeft { get; set; }

        public string Dispenser { get; set; }

        public bool Filled { get; set; }

        public string PatientID { get; set; }

        public string DoctorName { get; set; }
    }
}
