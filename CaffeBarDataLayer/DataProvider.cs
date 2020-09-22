using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cassandra;
using CaffeBarDataLayer.QueryEntities;

namespace CaffeBarDataLayer
{
   public static class DataProvider
   {
       #region Zaposleni
       public static List<Zaposleni> GetZaposleni()
       {
           ISession session = SessionManager.GetSession();
           List<Zaposleni> radnici = new List<Zaposleni>();


           if (session == null)
               return null;

           var zaposleniData = session.Execute("select * from zaposleni");


           foreach (var zData in zaposleniData)
           {
               Zaposleni zaposleni = new Zaposleni();
               zaposleni.zaposleni_id = (int)zData["zaposleni_id"];
               zaposleni.ime = zData["ime"] != null ? zData["ime"].ToString() : string.Empty;
               zaposleni.prezime = zData["prezime"] != null ? zData["prezime"].ToString() : string.Empty;
               zaposleni.password = zData["password"] != null ? zData["password"].ToString() : string.Empty;


               radnici.Add(zaposleni);
           }



           return radnici;
       }
     #endregion

       #region Drinks
       public static List<Drinks> GetDrinks()
       {
           ISession session = SessionManager.GetSession();
           List<Drinks> drinks = new List<Drinks>();


           if (session == null)
               return null;

           var drinksData = session.Execute("select * from drinks");


           foreach (var dData in drinksData)
           {
               Drinks d = new Drinks();
              // d.zaposleni_id = (int)zData["zaposleni_id"];
               d.Naziv = dData["naziv"] != null ? dData["naziv"].ToString() : string.Empty;
               d.Vrsta = dData["vrsta"] != null ? dData["vrsta"].ToString() : string.Empty;
               d.Cena = (int)dData["cena"];
              


               drinks.Add(d);
           }



           return drinks;
       }

       #endregion

       #region Food
       public static List<Food> GetFoods()
       {
           ISession session = SessionManager.GetSession();
           List<Food> foods = new List<Food>();


           if (session == null)
               return null;

           var foodsData = session.Execute("select * from jelovnik");


           foreach (var fData in foodsData)
           {
               Food f= new Food();
               // d.zaposleni_id = (int)zData["zaposleni_id"];
               f.Naziv = fData["naziv"] != null ? fData["naziv"].ToString() : string.Empty;
               f.Tip_jela = fData["tip_jela"] != null ? fData["tip_jela"].ToString() : string.Empty;
               f.Cena = (int)fData["cena"];



               foods.Add(f);
           }



           return foods;
       }

       #endregion
       #region Racun

       public static void AddRacun(Guid id,int c,string radnik)
       {
           ISession session = SessionManager.GetSession();

           if (session == null)
               return;
           
           RowSet racunData = session.Execute("insert into racun (racun_id,racun, radnik) values ("+ id + ", " + c + ", '"+radnik.ToString()+"');");

       }

     



       //public static Racun GetRacunSaNajvecimId()
       //{
       //    ISession session = SessionManager.GetSession();
       //    Racun r = new Racun();

       //    if (session == null)
       //        return null;

       //    Row rData = session.Execute("SELECT MAX(racun_id) FROM racun;").FirstOrDefault();

       //    if (rData != null)
       //    {
       //        r.Racun_id = (int)rData["racun_id"];
       //        r.Racun_cena = (int)rData["racun"];
       //        r.Radnik = rData["radnik"] != null ? rData["radnik"].ToString() : string.Empty;
         
       //    }

       //    return r;
       }
       #endregion

   }

