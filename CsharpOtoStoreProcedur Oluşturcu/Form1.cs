using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
namespace CsharpOtoStoreProcedur_Oluşturcu
{
    public partial class Form1 : MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }
        StreamReader sr;
        string se = string.Empty;
        int kolon = 0;
        private void metroButton1_Click(object sender, EventArgs e)
        {
            sqlbgl sb = new sqlbgl();
            sb.ShowDialog();
        }
        private void metroButton3_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1 .Text != "" )
                {
                    metroGrid1.Rows.Add();
                    metroGrid1.Rows[kolon].Cells[0].Value = textBox1.Text;
                    kolon++;
                    textBox1.Text = "";
                    label1.Text = kolon + " Store Procedür";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message ,"");
            }
        }
        private void metroButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (metroGrid1 .Rows.Count.ToString () !=null & metroGrid1.Rows .Count.ToString () !="0")
                {
                    if (baglanti.datababes_ismi == string .Empty )
                    {
                        MessageBox.Show("Lütfen Database ekleyiniz...", "Ebubekir Bastama.com");
                    }
                    else
                    {
                        for (int i = 0; i < metroGrid1.Rows.Count; i++)
                        {
                            baglanti.proc_olustur(metroGrid1.Rows[i].Cells[0].Value.ToString());
                        }
                        baglanti.temizle(metroGrid1);
                        MessageBox.Show("Store Procedurler oluşturuldu...", "Ebubekir Bastama.com");

                    }
                    
                                        
                }
                else
                {
                    MessageBox.Show("Lütfen Store Procedur Ekleyiniz","Ebubekir Bastama.com");
                }
            }
            catch ( Exception ex)
            {
                MessageBox.Show(ex.Message ,"Ebubekir Bastama.com");
            }
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("www.ebubekirbastama.com","Ebubekir Bastama.com");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form2 f1 = new Form2();
            f1.ShowDialog();
        }
    }
}
