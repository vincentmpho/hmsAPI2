using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using hmsAPI2.Models;

namespace hmsAPI2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<hmsAPI2.Models.ActiveEngredients> ActiveEngredients { get; set; }
        public DbSet<hmsAPI2.Models.ContraIndication> ContraIndication { get; set; }
        public DbSet<hmsAPI2.Models.Diagnosis> Diagnosis { get; set; }
        public DbSet<hmsAPI2.Models.Doctor> Doctor { get; set; }
        public DbSet<hmsAPI2.Models.FirstVisit> FirstVisit { get; set; }
        public DbSet<hmsAPI2.Models.Interactions> Interactions { get; set; }
        public DbSet<hmsAPI2.Models.MedicalPractice> MedicalPractice { get; set; }
        public DbSet<hmsAPI2.Models.Medication> Medication { get; set; }
        public DbSet<hmsAPI2.Models.Patient> Patient { get; set; }
        public DbSet<hmsAPI2.Models.Phamacist> Phamacist { get; set; }
        public DbSet<hmsAPI2.Models.Phamacy> Phamacy { get; set; }
        
            public DbSet<hmsAPI2.Models.Content> Content { get; set; }

        public DbSet<hmsAPI2.Models.Prescription> Prescription { get; set; }
        public DbSet<hmsAPI2.Models.User> User { get; set; }
        public DbSet<hmsAPI2.Models.User> MedicalHistory { get; set; }
    }
}
