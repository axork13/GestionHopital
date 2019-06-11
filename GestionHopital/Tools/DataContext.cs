using GestionHopital.Models.DAO.Traitements;
using GestionHopital.Models.DTO;
using GestionHopital.Models.DTO.Traitements;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionHopital.Tools
{
    public class DataContext : DbContext
    {
        private static object _lock = new object();
        private static DataContext _instance = null;
        private static readonly string connectionString = @"";

        public static DataContext Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                        _instance = new DataContext();
                    return _instance;
                }
            }
        }

        private DataContext() : base (connectionString)
        {

        }

        public DbSet<Consultation> Consultations { get; set; }
        public DbSet<Traitement> Traitements { get; set; }
        public DbSet<Chirurgie> Chirurgies { get; set; }
        public DbSet<Examen_biologique> Examen_biologiques { get; set; }
        public DbSet<Examen_radiologique> Examen_radiologiques { get; set; }
        public DbSet<Facture> Factures { get; set; }
        public DbSet<Hospitalisation> Hospitalisations { get; set; } 
        public DbSet<Medecin> Medecins { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Rendez_vous> Rendez_vouss { get; set; }
    }
}
