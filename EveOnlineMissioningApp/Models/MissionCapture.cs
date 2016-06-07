using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EveOnlineMissioningApp.Models
{

    public class MissionCapture
    {

        [Key]
        public int id { get; set; }

        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public string title { get; set; }
        public float income { get; set; }
        public float expenses { get; set; }
        public float profit { get; set; }

        public MissionCapture() { }

        public MissionCapture(string title)
        {
            this.title = title;
        }

        /**
         * Finds the difference between the start and end time as startTime - endTime.
         **/
        public TimeSpan getTimeDifference()
        {
            return startTime.Subtract(endTime);
        }

        /**
         * Finds the difference between the income and expenses, which equals profit.
         **/
        public float calculateProfit()
        {
            return income - expenses;
        }

    }

}