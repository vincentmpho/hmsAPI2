using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace hmsAPI2.Models
{
    public class Phamacy
    {

        [Key]
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string PhamacyName { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Address { get; set; }


        [Column(TypeName = "nvarchar(20)")]
        public string ContactNumber { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string EmailAddress { get; set; }

        public int LicenceNumber { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string ResponsiblePharmacist {get; set; }


    }
}
