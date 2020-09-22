using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CaffeBarDataLayer;
using CaffeBarDataLayer.QueryEntities;

namespace CaffeBar
{
    public partial class Main : Form
    {
       private DrinkFoodKolicina dfk;
       private List<DrinkFoodKolicina> zaRacun=new List<DrinkFoodKolicina>();
       public static List<DrinkFoodKolicina> zr=new List<DrinkFoodKolicina>();
       
        public Main()
        {
            InitializeComponent();
            listView1.FullRowSelect = true;
            listView2.FullRowSelect = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNapici_Click(object sender, EventArgs e)
        {
          
            panelNapici.Visible = true;
            panelJelovnik.Visible = false;
       
             PopulateInfos1();
            
        }

        private void Main_Load(object sender, EventArgs e)
        {
            panelMain.Visible = true;
            panelNapici.Visible = false;
            panelJelovnik.Visible = false;
           

           
        }
        private void PopulateInfos1()
        {
            listView1.Items.Clear();
            List<Drinks> drinks = DataProvider.GetDrinks();
            foreach (Drinks d in drinks)
            {
                ListViewItem item = new ListViewItem(new string[] { d.Naziv, d.Vrsta, d.Cena.ToString() });

                listView1.Items.Add(item);
            }
            listView1.Refresh();
        }

        private void PopulateInfos2()
        {
            listView2.Items.Clear();
            List<Food> foods = DataProvider.GetFoods();
            foreach (Food f in foods)
            {
                ListViewItem item = new ListViewItem(new string[] { f.Naziv, f.Tip_jela, f.Cena.ToString() });

                listView2.Items.Add(item);
            }
            listView1.Refresh();
        }

        private void btnDrinkRacun_Click(object sender, EventArgs e)
        {
            if (numDrink.Value > 0 && listView1.SelectedItems!=null)
            {
                String n = listView1.SelectedItems[0].SubItems[0].Text;
                int c =Int32.Parse(listView1.SelectedItems[0].SubItems[2].Text);
                int k =Int32.Parse(numDrink.Value.ToString());
                dfk = new DrinkFoodKolicina();
                dfk.Naziv = n; dfk.Cena = c;
                dfk.Kolicina = k;
                zaRacun.Add(dfk);
           
            }
        }



     

       

        private void btnHrana_Click(object sender, EventArgs e)
        {
            panelJelovnik.Visible = true;
            PopulateInfos2();
         
           
        }

        private void btnFoodRacun_Click(object sender, EventArgs e)
        {
            if (numDrink.Value > 0 && listView1.SelectedItems != null)
            {
                String n = listView2.SelectedItems[0].SubItems[0].Text;
                int c = Int32.Parse(listView2.SelectedItems[0].SubItems[2].Text);
                int k = Int32.Parse(numDrink.Value.ToString());
                dfk = new DrinkFoodKolicina();
                dfk.Naziv = n; dfk.Cena = c;
                dfk.Kolicina = k;
                zaRacun.Add(dfk);

            }
        }

        private void btnRacun_Click(object sender, EventArgs e)
        {
            //foreach (DrinkFoodKolicina dfk in zaRacun)
            //    MessageBox.Show(dfk.Naziv + " " + dfk.Kolicina + " " + dfk.Cena);
           
            zr = zaRacun;
            zaRacun = new List<DrinkFoodKolicina>();
            RacunForm r = new RacunForm();
            r.Show();
        }



 

  

       

        //private void button1_Click_1(object sender, EventArgs e)
        //{
        //    if (zaRacun != null)
        //    {
        //        foreach (DrinkFoodKolicina dk in zaRacun)
        //        {
        //            MessageBox.Show(dk.Naziv + " " + dk.Cena.ToString() + " RSD " + dk.Kolicina.ToString());
        //        }
        //    }
        //}

       



    }
}
