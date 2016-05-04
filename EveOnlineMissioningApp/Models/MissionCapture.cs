using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EveOnlineMissioningApp.Models
{

    public class MissionCapture
    {

        public int id { get; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public string title { get; set; }

    }

}