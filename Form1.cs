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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timer1.Enabled = true;
            this.Text="16010011056 MUCAHİD ARDICI";
           
        } 
        static public string k = "kullanıcı";
    
        SqlConnection baglan = new SqlConnection("Data Source=LAPTOP-QJLFJN8E;Initial Catalog=emlak;Integrated Security=True");
        int kontrol = 0;
        int kontrol1 = 1;
        private void verileri_oku()
        {
            baglan.Open();
            SqlCommand yonetici = new SqlCommand("select * from yonetici",baglan);
            SqlDataReader oku = yonetici.ExecuteReader();
            while (oku.Read())
            {
                if (textBox1.Text == oku["kullanıcıadı"].ToString())
                {
                    if (textBox2.Text == oku["sifre"].ToString())
                    {
                        kontrol = 1;
                        Form1.k = "yonetici";
                    }
                }
            }
            baglan.Close();
        }
        private void kullanıcı_oku()
        {
            baglan.Open();
            SqlCommand yonetici = new SqlCommand("select * from kullanıcı",baglan);
            SqlDataReader oku = yonetici.ExecuteReader();
            while (oku.Read())
            {
                if (textBox1.Text == oku["kullanıcıadı"].ToString())
                {
                    if (textBox2.Text == oku["sifre"].ToString())
                    {
                        kontrol = 1;
                        Form1.k = "kullanıcı";
                    }
                }
            }
            baglan.Close();
        }
        private void yeniKayıtToolStripMenuItem_Click(object sender, EventArgs e)//tekrar tooltexboxları doldurma işlemi
        {
            toolStripTextBox1.Text = "adısoyadı";
            toolStripTextBox2.Text = "eposta";
            toolStripTextBox3.Text = "kullanıcı adı";
            toolStripTextBox4.Text = "sifre";
            toolStripTextBox5.Text = "telefon";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(comboBox1.Text=="yönetici girisi")
            {
                verileri_oku();
                if (kontrol == 1)
                {
                    Form5 gec = new Form5();
                    gec.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show(" hatalı giris");
                }
            }else
                if (comboBox1.Text == "kullanıcı girisi")
            {
                kullanıcı_oku();
                if (kontrol == 1)
                {
                    Form4 ge = new Form4();
                    ge.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show(" hatalı giris");
                }
            }
            else
            {
                MessageBox.Show("combobox dan secim yapınız");
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
            if ( toolStripTextBox1.Text == "" || toolStripTextBox2.Text == "" || toolStripTextBox3.Text == "" || toolStripTextBox4.Text == "" || toolStripTextBox5.Text == ""
                 || toolStripTextBox1.Text == "adısoyadı"|| toolStripTextBox2.Text == "eposta" || toolStripTextBox2.Text == "kullanıcı adı" || toolStripTextBox2.Text == "telefon")
            {
                MessageBox.Show("hata hiçbir öğe boş bırakılamaz");
                toolStripTextBox1.Text = "adısoyadı";
                toolStripTextBox2.Text = "eposta";
                toolStripTextBox3.Text = "kullanıcı adı";
                toolStripTextBox4.Text = "sifre";
                toolStripTextBox5.Text = "telefon";
            }
            else
            {
               
                baglan.Open();
                SqlCommand sde = new SqlCommand("select kullanıcıadı from kullanıcı", baglan);
                SqlDataReader ad = sde.ExecuteReader();
                while (ad.Read())
                {
                    if (toolStripTextBox3.Text == ad["kullanıcıadı"].ToString()||toolStripTextBox3.Text=="kullanıcı adı")
                    {
                        kontrol1 = 0;
                        MessageBox.Show("kullanıcı adı sistemde mevcut veya hatalı kullanıcı ismi girdiniz");
                        break;
                    }
                }
                baglan.Close();
                if (kontrol1 == 1)
                {

                    baglan.Open();
                    SqlCommand ss = new SqlCommand("insert into kullanıcı(adısoyadı,eposta,kullanıcıadı,sifre,telefon)values('" + toolStripTextBox1.Text.ToString() + "','" + toolStripTextBox2.Text.ToString() + "','" + toolStripTextBox3.Text.ToString() + "','" + toolStripTextBox4.Text.ToString() + "','" + toolStripTextBox5.Text.ToString() + "')", baglan);
                    ss.ExecuteNonQuery();
                    toolStripTextBox1.Text = "";
                    toolStripTextBox2.Text = "";
                    toolStripTextBox3.Text = "";
                    toolStripTextBox4.Text = "";
                    toolStripTextBox5.Text = "";
                    baglan.Close();
                    MessageBox.Show("başarılı");
                }
            }
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            toolStripTextBox1.Clear();
        }

        private void toolStripTextBox2_Click(object sender, EventArgs e)
        {
            toolStripTextBox2.Clear();
        }

        private void toolStripTextBox3_Click(object sender, EventArgs e)
        {
            toolStripTextBox3.Clear();
        }

        private void toolStripTextBox4_Click(object sender, EventArgs e)
        {
            toolStripTextBox4.Clear();
        }

        private void toolStripTextBox5_Click(object sender, EventArgs e)
        {
            toolStripTextBox5.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            toolStripTextBox1.Text = "adısoyadı";
            toolStripTextBox2.Text = "eposta";
            toolStripTextBox3.Text = "kullanıcı adı";
            toolStripTextBox4.Text = "sifre";
            toolStripTextBox5.Text = "telefon";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            statusBar1.Panels[0].Text = DateTime.Today.Date.ToString("[dd:MM:yyyy]") + DateTime.Now.ToString("[HH:mm:ss]");
        }

        private void statusBar1_PanelClick(object sender, StatusBarPanelClickEventArgs e)
        {

        }

        private void form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = this.CreateGraphics();
            Pen kalem = new Pen(Color.Red, 4);
            Font yazi = new Font("Arial", 20, FontStyle.Bold);
            Brush firca = new SolidBrush(Color.Black);

            g.DrawString("55 MUCAHİD POYRAZ", yazi, firca, 300, 50);
        }
    }
}
