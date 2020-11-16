using __emlakotomasyonu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _emlakotomasyonu
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            Form1.k = "yonetici";
        }
     
        private void sayfa_getir(Form frm)
        {
            panel1.Controls.Clear();
            bool k = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == frm.Text)
                {
                    k = true;
                    f.Focus();
                    panel1.Controls.Add(f);
                    break;


                }

            }
            if (k == false)
            {
                panel1.Controls.Clear();

                frm.MdiParent = this;
                frm.FormBorderStyle = FormBorderStyle.None;
                panel1.Controls.Add(frm);
                frm.Show();
            }
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form1.k = "yonetici";
            Form2 t = new Form2();
            sayfa_getir(t);

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Form6 t = new Form6();
            sayfa_getir(t);
        }

        private void tümSayfalarıKapatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            foreach (Form f in this.MdiChildren)
            {


                f.Visible = false;
                f.Dispose();

            }
        }

        private void cıkısYapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            statusBar2.Panels[0].Text = DateTime.Today.Date.ToString("[dd:MM:yyyy]") + DateTime.Now.ToString("[HH:mm:ss]");

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Form7 t = new Form7();
            sayfa_getir(t);
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
