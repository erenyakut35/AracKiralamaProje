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
    public partial class AracForm : Form
    {
        public AracForm()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=KeremYakut\\SQLEXPRESS;Initial Catalog=RentCarDB;Integrated Security=True;Encrypt=False");
        private void AracForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'rentCarDBDataSet5.Araclar' table. You can move, or remove it, as needed.
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.araclarTableAdapter.Fill(this.rentCarDBDataSet5.Araclar);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            textBox1.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            textBox7.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();

        }

        private void ekleBtn_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("INSERT INTO Araclar (Marka, Model, Yil, Plaka, FiyatGunluk, Durum) VALUES (@Marka, @Model, @Yil, @Plaka, @FiyatGunluk, @Durum)", baglanti);
            komut.Parameters.AddWithValue("@Marka", textBox2.Text);
            komut.Parameters.AddWithValue("@Model", textBox3.Text);
            komut.Parameters.AddWithValue("@Yil", int.Parse(textBox4.Text));
            komut.Parameters.AddWithValue("@Plaka", textBox5.Text);
            komut.Parameters.AddWithValue("@FiyatGunluk", decimal.Parse(textBox6.Text));
            komut.Parameters.AddWithValue("@Durum",textBox7.Text); 
            baglanti.Open();
            komut.ExecuteNonQuery();
            MessageBox.Show("Kayit Basarili Bir Sekilde Eklendi");
            baglanti.Close();
        }

        private void guncelleBtn_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("UPDATE Araclar SET Marka=@Marka, Model=@Model, Yil=@Yil, Plaka=@Plaka, FiyatGunluk=@FiyatGunluk, Durum=@Durum WHERE AracID=@AracID", baglanti);
            komut.Parameters.AddWithValue("@AracID", int.Parse(textBox1.Text));
            komut.Parameters.AddWithValue("@Marka", textBox2.Text);
            komut.Parameters.AddWithValue("@Model", textBox3.Text);
            komut.Parameters.AddWithValue("@Yil", int.Parse(textBox4.Text));
            komut.Parameters.AddWithValue("@Plaka", textBox5.Text);
            komut.Parameters.AddWithValue("@FiyatGunluk", decimal.Parse(textBox6.Text));
            komut.Parameters.AddWithValue("@Durum", textBox7.Text);
            baglanti.Open();
            komut.ExecuteNonQuery();
            MessageBox.Show("Kayit Basarili Sekilde Guncellendi");
            baglanti.Close();
        }

        private void silBtn_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("DELETE FROM Araclar WHERE AracID = @AracID", baglanti);
            komut.Parameters.AddWithValue("@AracID", int.Parse(textBox1.Text));
            baglanti.Open();
            komut.ExecuteNonQuery();
            MessageBox.Show("Kayit Basarili Bir Sekilde Silindi");
            baglanti.Close();
        }

        private void temizleBtn_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox2.Focus(); 
        }
    }
}
