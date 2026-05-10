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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RentCarApp
{
    public partial class MusteriForm : Form
    {
        public MusteriForm()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection
           ("Data Source=KeremYakut\\SQLEXPRESS;Initial Catalog=RentCarDB;Integrated Security=True;Encrypt=False");
        private void MusteriForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'rentCarDBDataSet3.Kullanicilar' table. You can move, or remove it, as needed.
            

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void listeleBtn_Click(object sender, EventArgs e)
        {
            this.kullanicilarTableAdapter.Fill(this.rentCarDBDataSet3.Kullanicilar);
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
           textBox1.Text= dataGridView1.Rows[secilen].Cells[0].Value.ToString();
           textBox2.Text= dataGridView1.Rows[secilen].Cells[1].Value.ToString();
           textBox3.Text= dataGridView1.Rows[secilen].Cells[2].Value.ToString();
           maskedTextBox1.Text= dataGridView1.Rows[secilen].Cells[3].Value.ToString();
           textBox4.Text= dataGridView1.Rows[secilen].Cells[4].Value.ToString();
           maskedTextBox2.Text= dataGridView1.Rows[secilen].Cells[5].Value.ToString();
           textBox5.Text= dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            if (textBox1.Text == "1")
            {
                guncelleBtn.Enabled = false;
                ekleBtn.Enabled = false;
                silBtn.Enabled = false;
            }
            else
            {
                guncelleBtn.Enabled = true;
                ekleBtn.Enabled = true;
                silBtn.Enabled = true;
            }

        }

        private void ekleBtn_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("INSERT INTO Kullanicilar (KullaniciAdi, KullaniciSoyadi, Telefon, Eposta, TcNo, Sifre) VALUES (@Adi, @Soyadi, @Telefon, @Eposta, @TcNo, @Sifre)", baglanti);
            komut.Parameters.AddWithValue("@Adi", textBox2.Text);
            komut.Parameters.AddWithValue("@Soyadi", textBox3.Text);
            komut.Parameters.AddWithValue("@Telefon", maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@Eposta", textBox4.Text);
            komut.Parameters.AddWithValue("@TcNo", maskedTextBox2.Text);
            komut.Parameters.AddWithValue("@Sifre", textBox5.Text);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kullanıcı eklendi.");
        }

        private void guncelleBtn_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("UPDATE Kullanicilar SET KullaniciAdi=@Adi, KullaniciSoyadi=@Soyadi, Telefon=@Telefon, Eposta=@Eposta, TcNo=@TcNo, Sifre=@Sifre WHERE KullaniciID=@ID", baglanti);
            komut.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));
            komut.Parameters.AddWithValue("@Adi", textBox2.Text);
            komut.Parameters.AddWithValue("@Soyadi", textBox3.Text);
            komut.Parameters.AddWithValue("@Telefon", maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@Eposta", textBox4.Text);
            komut.Parameters.AddWithValue("@TcNo", maskedTextBox2.Text);
            komut.Parameters.AddWithValue("@Sifre", textBox5.Text);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kullanıcı güncellendi.");
        }

        private void silBtn_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("DELETE FROM Kullanicilar WHERE KullaniciID=@ID", baglanti);
            komut.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kullanıcı silindi.");
        }

        private void temizleBtn_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            maskedTextBox1.Clear();
            textBox4.Clear();
            maskedTextBox2.Clear();
            textBox5.Clear();
            textBox2.Focus();
        }
    }
}
