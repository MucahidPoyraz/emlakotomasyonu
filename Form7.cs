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
namespace __emlakotomasyonu
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
            verileri_ekle("select * from evler where id_numarası=0000");//boş ev sayfası gelmesini sağlar
        }
        SqlConnection bagla = new SqlConnection("Data Source=LAPTOP-QJLFJN8E;Initial Catalog=emlak;Integrated Security=True");
        int kontrol1 = 1;
        private void verileri_ekle(string veri)//gelen sql cümlelerine göre datagride ekleme işlemi yapar
        {
            SqlDataAdapter da = new SqlDataAdapter(veri, bagla);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
        private void button1_Click(object sender, EventArgs e)
        {

            int i = 0;

            for (i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                kontrol1 = 1;
                bagla.Open();
                SqlCommand sde = new SqlCommand("select id_numarası from evler", bagla);
                SqlDataReader ad = sde.ExecuteReader();
                while (ad.Read())
                {
                    if (dataGridView1.Rows[i].Cells["id_numarası"].Value.ToString() == ad["id_numarası"].ToString())
                    {
                        kontrol1 = 0;
                        MessageBox.Show(ad["id_numarası"].ToString() + "adı sistemde mevcut");
                        break;
                    }
                }
                ad.Close();
                if (kontrol1 == 1)
                {

                    SqlCommand ss = new SqlCommand("insert into evler(adres,id_numarası,il,bulundugu_kat,ev_tipi,fiyat)values(@a,@b,@c,@d,@f,@g)", bagla);
                    ss.Parameters.AddWithValue("@a", dataGridView1.Rows[i].Cells["adres"].Value.ToString());
                    ss.Parameters.AddWithValue("@b", dataGridView1.Rows[i].Cells["id_numarası"].Value);
                    ss.Parameters.AddWithValue("@c", dataGridView1.Rows[i].Cells["il"].Value.ToString());
                    ss.Parameters.AddWithValue("@d", dataGridView1.Rows[i].Cells["bulundugu_kat"].Value);
                    ss.Parameters.AddWithValue("@f", dataGridView1.Rows[i].Cells["ev_tipi"].Value.ToString());
                    ss.Parameters.AddWithValue("@g", dataGridView1.Rows[i].Cells["fiyat"].Value);
                    ss.ExecuteNonQuery();

                }
                bagla.Close();
            }
            if (kontrol1 == 1)
            {
                MessageBox.Show("veriler eklendi");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            verileri_ekle("select * from evler");
            /* bagla.Open();// tüm verileri silme
             SqlCommand ss = new SqlCommand("delete from evler", bagla);
             ss.ExecuteNonQuery();
             bagla.Close();*/
        }

        private void button3_Click(object sender, EventArgs e)
        {
            verileri_ekle("select * from evler where id_numarası=0000");//boş ev sayfası gelmesini sağlar
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }
    }
}
