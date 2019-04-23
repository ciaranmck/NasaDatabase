using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NasaDatabase.Models
{
    public class Fireball
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Energy { get; set; }
        public decimal ImpactE { get; set; }
        public decimal Lat { get; set; }
        public string LatDir { get; set; }
        public decimal Lon { get; set; }
        public string LonDir { get; set; }
        public decimal Alt { get; set; }
        public decimal Vel { get; set; }
    }
}