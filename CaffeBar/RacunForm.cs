using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CaffeBarDataLayer.QueryEntities;
using CaffeBarDataLayer;

namespace CaffeBar
{
    public partial class RacunForm : Form
    {
        private List<DrinkFoodKolicina> zaRacun=Main.zr;


        
        public RacunForm()
        {
            InitializeComponent();
        }

        private void RacunForm_Load(object sender, EventArgs e)
        {
            PopulateInfos1();
        }
        
         private void PopulateInfos1()
        {
            listView1.Items.Clear();
      
            foreach (DrinkFoodKolicina dfk in zaRacun)
            {
            
                ListViewItem item = new ListViewItem(new string[] { dfk.Naziv, dfk.Kolicina.ToString(), dfk.Cena.ToString() });

                listView1.Items.Add(item);
            }

            listView1.Refresh();
            
        }

         private void button1_Click(object sender, EventArgs e)
         {   
             int c=0;
            
             foreach (ListViewItem item in listView1.Items)
	       {
		     c +=Int32.Parse(item.SubItems[2].Text);
	       }
        
             DataProvider.AddRacun(Guid.NewGuid(), c, Form1.radnik);
             listView1.Items.Clear();
             MessageBox.Show("Racun izdat cena je: " + c);
          
         
         }

         private void btnClose_Click(object sender, EventArgs e)
         {
             
             zaRacun = new List<DrinkFoodKolicina>();
             this.Close();
         }


    }
}
