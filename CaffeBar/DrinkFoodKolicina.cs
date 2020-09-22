using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaffeBar
{
    public class DrinkFoodKolicina
    {
        private string naziv;
        private int cena;
        private int kolicina;

        public String Naziv
        {
          get 
          {
              return naziv;
          }
          set
          {
              naziv=value;
          }
        }
        public int Cena
        {
             get 
          {
              return cena;
          }
          set
          {
              cena=value;
          }
        }
        public int Kolicina
        {
             get 
          {
              return kolicina;
          }
          set
          {
              kolicina=value;
          }
        }

    }
}
