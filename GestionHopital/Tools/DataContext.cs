using GestionHopital.Models.DTO;
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
    }
}
