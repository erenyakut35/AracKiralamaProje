using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentCarApp
{
    public partial class AnaSayfaForm : Form
    {
        public string GirisYapanKullanici { get; set; }

        public AnaSayfaForm()
        {
            InitializeComponent();
            timer1.Start();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
         
        }

        private void aracYntBtn_Click(object sender, EventArgs e)
        {
            AracForm aracForm = new AracForm();
            aracForm.Show();
        }

        private void musteriBtn_Click(object sender, EventArgs e)
        {
            MusteriForm musteriForm=new MusteriForm();
            musteriForm.Show();
        }

        private void kiralamaBtn_Click(object sender, EventArgs e)
        {
            KiralamaForm kiralamaForm=new KiralamaForm();
            kiralamaForm.Show();
        }

        private void cikisBtn_Click(object sender, EventArgs e)
        {
            
             
            loginForm loginForm=new loginForm();
            loginForm.Show();
            this.Hide();
        }
        int sayac = 0;
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            sayac++;
            sureLbl.Text = sayac.ToString();
        }

        private void AnaSayfaForm_Load(object sender, EventArgs e)
        {
            if (GirisYapanKullanici == "administrator")
            {
                yetkiLbl.Text = "Yonetici";
                 
            }
            else
            {
                yetkiLbl.Text = "Kullanici"; 
            }
            if (yetkiLbl.Text == "Yonetici")
            {
                MessageBox.Show("Hogseldiniz Yonetici");
                aracYntBtn.Enabled = true;
                musteriBtn.Enabled = true;
            }
            kullaniciLbl.Text=GirisYapanKullanici;
        }

        private void AnaSayfaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            
              Application.Exit();
                // Evet derse form zaten kapanır, ekstra işlem gerekmez.
            

            /*
            DialogResult result = MessageBox.Show("Çıkmak istediğinizden emin misiniz?", "Uyarı", MessageBoxButtons.YesNo);

            if (result == DialogResult.No)
            {
                e.Cancel = true; // Kapatmayı engeller
            }
            else
            {
                Application.Exit(); // Uygulama tamamen kapanır
            }
            */
        }
    }
}
