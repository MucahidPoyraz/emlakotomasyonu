using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace _emlakotomasyonu
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        private void veriler(string veri)// data gride verileri sql cümleciklerine göre basma fonksiyonu
        {
            baglan.Open();
            SqlDataAdapter ver = new SqlDataAdapter(veri, baglan);
            DataSet ds = new DataSet();
            ver.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglan.Close();

        }
        SqlConnection baglan = new SqlConnection("Data Source=LAPTOP-QJLFJN8E;Initial Catalog=emlak;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            String secilenev = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            MessageBox.Show(" " + textBox1.Text + " kulllanıcı adlı  " + label4.Text + " silindi");
            baglan.Open();
            SqlCommand veris = new SqlCommand("delete from " + label4.Text + " where kullanıcıadı=@adi ", baglan);
            veris.Parameters.AddWithValue("@adi", textBox1.Text);
            veris.ExecuteNonQuery();
            baglan.Close();
            veriler("select kullanıcıadı,eposta,telefon  from " + label4.Text + "");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string a = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            string b = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            string c = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();



            textBox1.Text = a;
            textBox2.Text = b;
            textBox3.Text = c;


        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                baglan.Open();
                String secilenTel = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                SqlCommand ve = new SqlCommand("update " + label4.Text + " set kullanıcıadı = '" + textBox1.Text.ToString() + "',eposta = '" + textBox2.Text.ToString() + "',telefon = '" + textBox3.Text.ToString() + "' where kullanıcıadı like @h ", baglan);
                ve.Parameters.AddWithValue("@h", secilenTel);
                ve.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show("" + label4.Text + "  güncellendi");
                veriler("select kullanıcıadı,eposta,telefon  from " + label4.Text + "");
            }
            catch(Exception f)
            {
                MessageBox.Show("hata veri güncelleme hatası\n"+f.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            veriler("select kullanıcıadı,eposta,telefon  from yonetici");
            label4.Text = "yonetici";
            button2.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            veriler("select kullanıcıadı,eposta,telefon  from kullanıcı");
            label4.Text = "kullanıcı";
            button2.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String secilenTel = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
           
            baglan.Open();
            SqlCommand veris = new SqlCommand("select * from kullanıcı where telefon=@adi ", baglan);
            veris.Parameters.AddWithValue("@adi", secilenTel);
            veris.ExecuteNonQuery();
            SqlDataReader g = veris.ExecuteReader();

            while (g.Read())
            {
                label5.Text = g["kullanıcıadı"].ToString();
                label6.Text = g["eposta"].ToString();
                label7.Text = g["telefon"].ToString();
                label8.Text = g["sifre"].ToString();

            }
            baglan.Close();
            baglan.Open();
            SqlCommand t = new SqlCommand("insert into yonetici(kullanıcıadı,eposta,sifre,telefon)values(@a,@b,@c,@d)", baglan);
            t.Parameters.AddWithValue("@a", label5.Text);
            t.Parameters.AddWithValue("@b", label6.Text);
            t.Parameters.AddWithValue("@c", label8.Text);
            t.Parameters.AddWithValue("@d", label7.Text);
            t.ExecuteNonQuery();
            baglan.Close();
            baglan.Open();

            SqlCommand v = new SqlCommand("delete from kullanıcı where telefon=@adi ", baglan);
            v.Parameters.AddWithValue("@adi", secilenTel);
            v.ExecuteNonQuery();
            baglan.Close();
            veriler("select kullanıcıadı,eposta,telefon  from " + label4.Text + "");
            MessageBox.Show("yetki verildi");
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
