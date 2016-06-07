using EveOnlineMissioningApp.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace EveOnlineMissioningApp.Models
{

    public class Account
    {

        [Key]
        public int id { get; set; }
        public PasswordCredential credential { get; set; }
        public IEnumerable<MissionCapture> missionCaptures { get; set; }

    }

}