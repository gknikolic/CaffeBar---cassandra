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
    public partial class Form1 : Form
    {

        public static string radnik;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrijava_Click(object sender, EventArgs e)
        {
            //npr Milena Stojanovic - SIFRA : caffecaffe1

            List<Zaposleni> radnici = DataProvider.GetZaposleni();
            int p = 0;
            foreach (Zaposleni z in radnici)
                if(z.ime+" "+z.prezime==tbxRadnik.Text && z.password==tbxSifra.Text)
            
                {
                    p = 1;

                }
            if (p == 1)
            {
                this.Hide();
                Main f = new Main();
                f.FormClosed += (s, args) => this.Close();
                radnik = tbxRadnik.Text;
                f.Show();
            }
            else
                
                tbxRadnik.ForeColor = Color.Red;
                tbxRadnik.Text = "Neispravno ime ili lozinka!";

        }

        private void tbxRadnik_MouseHover(object sender, EventArgs e)
        {
            tbxRadnik.Text = "";
            tbxRadnik.ForeColor = Color.Black;
        }

        private void tbxSifra_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                btnPrijava_Click(sender, e);
            }
        }

       

      



     
        
    
    }
}
