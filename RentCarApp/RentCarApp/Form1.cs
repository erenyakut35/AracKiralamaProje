using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentCarApp
{
    public partial class loginForm : Form
    {
        
        public loginForm()
        {
            InitializeComponent();
        }
       SqlConnection baglanti=new SqlConnection
            ("Data Source=KeremYakut\\SQLEXPRESS;Initial Catalog=RentCarDB;Integrated Security=True;Encrypt=False");
        private void loginForm_Load(object sender, EventArgs e)
        {

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM Kullanicilar WHERE KullaniciAdi=@p1 AND Sifre=@p2",baglanti);
            komut.Parameters.AddWithValue("@p1", textBox1.Text);
            komut.Parameters.AddWithValue("@p2", textBox2.Text);
            SqlDataReader read = komut.ExecuteReader();

            if (read.Read())
            {
                string kullaniciAdi = textBox1.Text; // giriş yapan kullanıcı

                AnaSayfaForm frm = new AnaSayfaForm();
                frm.GirisYapanKullanici = kullaniciAdi; // özelliği set et
                frm.Show();
                this.Hide();
            }
            else if (read.Read())
            {
                // Giriş başarılı
                AnaSayfaForm anaform = new AnaSayfaForm();
                anaform.Show();
                this.Hide();
            }
             
            else { 
                    
                MessageBox.Show("Hatalı kullanıcı adı veya şifre", "Giriş Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
                baglanti.Close();
            }





            //baglanti.Close();
            //baglanti.Open();
            // SqlCommand cmd = new SqlCommand("SELECT * FROM Kullanicilar WHERE KullaniciAdi=@p1 AND Sifre=@p2", baglanti);
            //cmd.Parameters.AddWithValue("@p1", textBox1.Text);
            //cmd.Parameters.AddWithValue("@p2", textBox2.Text);
            //SqlDataReader rd = cmd.ExecuteReader();
            //if (rd.Read())
            //{
            //    string kullaniciAdi = textBox1.Text; // giriş yapan kullanıcı

            //    AnaSayfaForm frm = new AnaSayfaForm();
            //    frm.GirisYapanKullanici = kullaniciAdi; // özelliği set et
            //    frm.Show();
            //    this.Hide();
            //}
            //baglanti.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UyeOlForm uye = new UyeOlForm();
            uye.Show();
            this.Hide();
        }

        private void loginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
