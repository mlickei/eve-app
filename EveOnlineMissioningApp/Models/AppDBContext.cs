using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EveOnlineMissioningApp.Models
{
    public class AppDBContext : DbContext
    {

        public DbSet<Salt> Salts { get; set; }
        public DbSet<PasswordCredential> PasswordCredentials { get; set; }
        public DbSet<MissionCapture> MissionCaptures { get; set; }
        public DbSet<Account> Accounts { get; set; }

    }
}