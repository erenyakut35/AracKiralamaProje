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
    
    public partial class UyeOlForm : Form
    {
        
        
        public UyeOlForm()
        {
            InitializeComponent();
            
    }
        SqlConnection baglanti=new SqlConnection("Data Source=KeremYakut\\SQLEXPRESS;Initial Catalog=RentCarDB;Integrated Security=True;Encrypt=False");
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            loginForm login = new loginForm();
            login.Show();
            this.Hide();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            string temizTc = maskedTextBox2.Text.Trim();
            bool telefonBos = string.IsNullOrWhiteSpace(maskedTextBox1.Text.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", ""));

            bool tcBos = string.IsNullOrWhiteSpace(maskedTextBox2.Text) || maskedTextBox2.Text.Length != 11;
            // Tüm alanlar dolu mu kontrol et
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||  // Kullanıcı Adı
                string.IsNullOrWhiteSpace(textBox2.Text) ||  // Kullanıcı Soyadı
                string.IsNullOrWhiteSpace(maskedTextBox1.Text) ||  // Telefon
                string.IsNullOrWhiteSpace(textBox3.Text) ||  // Eposta
                string.IsNullOrWhiteSpace(maskedTextBox2.Text) ||  // TcNo
                string.IsNullOrWhiteSpace(textBox4.Text))     // Şifre
            {
                if (tcBos){
                    MessageBox.Show("Lütfen tüm alanları eksiksiz doldurun!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (telefonBos)
                {
                    MessageBox.Show("Lütfen tüm alanları eksiksiz doldurun!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                MessageBox.Show("Lütfen tüm alanları eksiksiz doldurun!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (temizTc.Length == 1 && int.TryParse(temizTc, out int tekTc))
            {
                if (tekTc % 2 == 1)
                {
                    MessageBox.Show("Geçersiz TC Kimlik Numarası girdiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }


            // TC No 11 haneli mi kontrol et (isteğe bağlı ama mantıklı olur)
            if (maskedTextBox2.Text.Length != 11)
            {
                MessageBox.Show("TC Kimlik Numarası 11 haneli olmalıdır!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            baglanti.Open();
            SqlCommand cmd = new SqlCommand
         ("insert into Kullanicilar(KullaniciAdi, KullaniciSoyadi, Telefon, Eposta, TcNo, Sifre)" + "values (@p1, @p2, @p3, @p4, @p5, @p6)",baglanti);
            cmd.Parameters.AddWithValue("@p1",textBox1.Text);
            cmd.Parameters.AddWithValue("@p2",textBox2.Text);
            cmd.Parameters.AddWithValue("@P3",maskedTextBox1.Text);
            cmd.Parameters.AddWithValue("@p4",textBox3.Text);
            cmd.Parameters.AddWithValue("@p5",maskedTextBox2.Text);
            cmd.Parameters.AddWithValue("@p6",textBox4.Text);
            cmd.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kaydiniz Basarili Sekilde Yapilmistir");
            
        }

        private void UyeOlForm_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void UyeOlForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
