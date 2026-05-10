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
    public partial class KiralamaForm : Form
    {
        public KiralamaForm()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection
            ("Data Source=KeremYakut\\SQLEXPRESS;Initial Catalog=RentCarDB;Integrated Security=True;Encrypt=False");
        private void KiralamaForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'rentCarDBDataSet4.Araclar' table. You can move, or remove it, as needed.
            

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ListeleBtn_Click(object sender, EventArgs e)
        {
            this.araclarTableAdapter.Fill(this.rentCarDBDataSet4.Araclar);
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            textBox1.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            textBox7.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();

            if (textBox7.Text == "True")
            {
                kiralaBtn.Enabled = false;
                teslimBtn.Enabled = true;
            }
            else if (textBox7.Text == "False")
            {
                kiralaBtn.Enabled = true;
                teslimBtn.Enabled = false;
            }
            else
            {
                // Garanti olsun diye ikisini de kapatalım
                kiralaBtn.Enabled = false;
                teslimBtn.Enabled = false;
            }

        }

        private void kiralaBtn_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("UPDATE Araclar SET Durum = 'True' WHERE AracID = @AracID", baglanti);
            komut.Parameters.AddWithValue("@AracID", int.Parse(textBox1.Text));

            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show("Araç başarıyla kiralandı.");
            textBox7.Text = "True";
            kiralaBtn.Enabled = false;
            teslimBtn.Enabled = true;
        }

        private void teslimBtn_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("UPDATE Araclar SET Durum = 'False' WHERE AracID = @AracID", baglanti);
            komut.Parameters.AddWithValue("@AracID", int.Parse(textBox1.Text));

            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show("Araç başarıyla teslim edildi.");
            textBox7.Text = "False";
            kiralaBtn.Enabled = true;
            teslimBtn.Enabled = false;
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
            
            
        }
    }
}
