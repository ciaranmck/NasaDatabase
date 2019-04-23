using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Common.Models
{
    public class NasaFireballData
    {
        public NasaSignature Signature { get; set; }
        public int Count { get; set; }
        public string[] Fields { get; set; }
        public string[][] Data { get; set; }
    }
}