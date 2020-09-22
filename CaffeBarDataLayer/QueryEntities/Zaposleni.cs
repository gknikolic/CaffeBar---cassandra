using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaffeBarDataLayer.QueryEntities
{
    public class Zaposleni
    {
        public int zaposleni_id {get; set; }
        public string ime{get; set; }
        public string prezime {get; set;}
        public string password { get; set; }

    }
}
