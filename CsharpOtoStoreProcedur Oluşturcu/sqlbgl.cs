using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CsharpOtoStoreProcedur_Oluşturcu
{
    public partial class sqlbgl : MetroForm
    {
        public sqlbgl()
        {
            InitializeComponent();
        }
        baglanti bgl = new baglanti();
        private void sqlbgl_Load(object sender, EventArgs e)
        {
            try
            {
                servarname.Items.Add(Environment.MachineName);
                servarname.Text = servarname.Items[0].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Ebubekir Bastama.com");
            }
        }
        private void metroButton2_Click(object sender, EventArgs e)
        {
            try
            {
                // True ya da False Döndürür.
                bool durum = File.Exists(baglanti.yol);
                if (durum != false)
                {
                    using (StreamWriter sw = new StreamWriter(baglanti.yol))
                    {
                        sw.WriteLine(cm_1 .Text );
                    }
                    MessageBox.Show("Server Name Kaydedildi", "Ebubekir Bastama");

                    bgl.ayr();
                }
                else
                {
                    MessageBox.Show("Ayar Dosyası Silinmiş", "Ebubekir Bastama.com");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ebubekir Bastama.com");
            }           
        }
        private void cm_1_MouseUp(object sender, MouseEventArgs e)
        {
            baglanti.Reader1("select s.name from sys.databases s", cm_1, "name"); 
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form2 f1 = new Form2();
            f1.ShowDialog();
        }
    }
}
