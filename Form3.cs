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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent(); 
            verileri_ekle("select * from  evler");

        }
        SqlConnection bagla = new SqlConnection("Data Source=LAPTOP-QJLFJN8E;Initial Catalog=emlak;Integrated Security=True");
        private void verileri_ekle(string veri)//gelen sql cümlelerine göre datagride ekleme işlemi yapar
        {
            SqlDataAdapter da = new SqlDataAdapter(veri, bagla);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ed = textBox1.Text;
            string a = comboBox1.Text;
            string b = comboBox3.Text;
            string c = comboBox2.Text;
            SqlDataAdapter verir = new SqlDataAdapter("select * from evler where adres like '%" + ed + "%' and il like '%" + a + "%' and ev_tipi like '%" + b + "%'and bulundugu_kat like '%" + c + "%'", bagla);

            DataSet ds = new DataSet();

            verir.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
