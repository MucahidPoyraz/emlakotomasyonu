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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            verileri_ekle("select * from  evler");
            timer1.Enabled = true;
    
        }
        SqlConnection bagla = new SqlConnection("Data Source=LAPTOP-QJLFJN8E;Initial Catalog=emlak;Integrated Security=True");
        int kontrol = 0;
       
        private void verileri_ekle(string veri)//gelen sql cümlelerine göre datagride ekleme işlemi yapar
        {
            SqlDataAdapter da = new SqlDataAdapter(veri, bagla);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

     
      

        private void button1_Click(object sender, EventArgs e)
        {
            
            bagla.Open();
            SqlCommand da = new SqlCommand("select id_numarası from evler", bagla);
            SqlDataReader ka= da.ExecuteReader();
            while (ka.Read())
            {
                if (textBox2.Text.ToString() == ka["id_numarası"].ToString())
                {
                    kontrol = 1;
                    MessageBox.Show("hata farklı id giriniz");
                }
            }
            bagla.Close();
           
            
            
            if (kontrol == 0&& textBox2.Text != "" && int.Parse(textBox2.Text.ToString())>0)
            {
                bagla.Open();
                SqlCommand ss = new SqlCommand("insert into evler(adres,id_numarası,il,bulundugu_kat,ev_tipi,fiyat)values('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + comboBox1.Text.ToString() + "','" + comboBox2.Text.ToString() + "','" + comboBox3.Text.ToString() + "','" + textBox3.Text.ToString() + "')", bagla);
                ss.ExecuteNonQuery();
                bagla.Close();
                if (textBox2.Text != "")
                    MessageBox.Show("yeni ev eklendi");
            }
            else { MessageBox.Show("hata farklı id giriniz \n id numarasını boş bırakmayınız ve 0 ve negatif sayılar girmeyin"); }
            verileri_ekle("select * from  evler");
            kontrol = 0;
       
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
            
                bagla.Open();
                SqlCommand f = new SqlCommand("update evler set adres='" + textBox1.Text.ToString() + "',id_numarası='" + textBox2.Text.ToString() + "',il='" + comboBox1.Text.ToString() + "',bulundugu_kat='" + comboBox2.Text.ToString() + "',ev_tipi='" + comboBox3.Text.ToString() + "',fiyat='" + textBox3.Text.ToString() + "'where id_numarası=@a", bagla);
                f.Parameters.AddWithValue("@a", textBox2.Text);
                f.ExecuteNonQuery();
                bagla.Close();
                verileri_ekle("select * from  evler");
            if (textBox2.Text != "")
                MessageBox.Show("güncelleme yapıldı");


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
                string a = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                string b = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                string c= dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                string d = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                string ge =  dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                string f =  dataGridView1.SelectedRows[0].Cells[5].Value.ToString();

                //int l= dataGridView1.SelectedCells[0].RowIndex;
                /* string a = dataGridView1.Rows[l].Cells[0].Value.ToString();
                 string b = dataGridView1.Rows[l].Cells[1].Value.ToString();
                 string c = dataGridView1.Rows[l].Cells[2].Value.ToString();
                 string d = dataGridView1.Rows[l].Cells[3].Value.ToString();
                 string ge = dataGridView1.Rows[l].Cells[4].Value.ToString();
                 string f = dataGridView1.Rows[l].Cells[5].Value.ToString();
                 */

                textBox1.Text = a;
                comboBox1.Text = b;
                textBox2.Text = c;
                comboBox2.Text = ge;
                comboBox3.Text = d;
                textBox3.Text = f;
            
    

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

          
            
                bagla.Open();
                SqlCommand la = new SqlCommand("delete from evler where id_numarası=@ar ", bagla);
                la.Parameters.AddWithValue("@ar", textBox2.Text.ToString());
                la.ExecuteNonQuery();
                bagla.Close();
                verileri_ekle("select * from  evler");
            if(textBox2.Text!="")
                MessageBox.Show("gayrimenkul silindi");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string ed = textBox1.Text;
            string a = comboBox1.Text;
            string b = comboBox3.Text;
            string c = comboBox2.Text;
            string d = textBox2.Text;
            string f = textBox3.Text;
            SqlDataAdapter verir = new SqlDataAdapter("select * from evler where id_numarası like '%" + d + "%' and fiyat like '%" + f + "%' and adres like '%" + ed + "%' and il like '%" + a + "%' and ev_tipi like '%" + b + "%'and bulundugu_kat like '%" + c + "%'", bagla);

            DataSet ds = new DataSet();

            verir.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Form1.k == "kullanıcı")
            {
                button4.Visible = false;
                button2.Visible = false;
                button3.Visible = false;

            }
            else if (Form1.k == "yonetici")
            {
                button4.Visible = true;
                button2.Visible = true;
                button3.Visible = true;
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
