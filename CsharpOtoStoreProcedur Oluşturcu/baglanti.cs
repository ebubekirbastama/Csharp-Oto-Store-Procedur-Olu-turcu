using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MetroFramework.Controls;

namespace CsharpOtoStoreProcedur_Oluşturcu
{
    class baglanti
    {
       public  static string yol=@"C:\ayar.txt";
        static string server_name;
        static bool deger = true;
       public  static string datababes_ismi=string .Empty ;
        string s;
        StreamReader sr;
        public void ayr()
        {

            sr = File.OpenText(yol);
            s = sr.ReadLine();
            datababes_ismi = s;
            sr.Close();
        }
        public static SqlConnection baglantim()
        {
            //ebubekirbastama
            SqlConnection con = new SqlConnection(@"Server=" + server_name + "; Integrated Security=true;");

            if (con.State == ConnectionState.Closed) // System.Data.SqlClient.ConnectionState using System.Data; kütüphanesinden gelir
            {
                con.Open();
            }
            return con;
        }
        public static SqlConnection baglantimi()
        {
            SqlConnection con = new SqlConnection(@"Server=" + server_name + "; Integrated Security=true; Database=" + datababes_ismi + "");
            if (datababes_ismi!="")
            {
                //ebubekirbastama
                if (con.State == ConnectionState.Closed) // System.Data.SqlClient.ConnectionState using System.Data; kütüphanesinden gelir
                {
                    con.Open();
                }                
            }
            else
            {
                deger = false;
                MessageBox.Show("Lütfen Database ekleyiniz...","Ebubekir Bastama.com");
            }
            return con;
        }       
        public static void  proc_olustur(string sqlcümle)
        {
            try
            {
                SqlConnection con = baglantimi();
                if (deger !=false)
                {
                    SqlCommand kmt = new SqlCommand(sqlcümle, con);
                    kmt.ExecuteNonQuery();
                    con.Close();
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message ,"Ebubekir Bastama.com");
            }
        }
        public static SqlDataReader Reader1(string sqlcumle, ComboBox kombo, string kolon_ismi)
        {
            using ( SqlCommand komut = new SqlCommand("" + sqlcumle + "", baglantim()))
            {
                SqlDataReader rdr = komut.ExecuteReader();
                kombo.Items.Clear();
                try
                {
                    while (rdr.Read())
                    {
                        kombo.Items.Add(rdr[kolon_ismi].ToString());
                    }
                    kombo.Text = kombo.Items[0].ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ebubekir Stok Takip otomasyonu Otomasyon");
                }
                return rdr;
            }
           
        }
        public static void  temizle(MetroGrid grid)
        {
            foreach (DataGridViewCell oneCell in grid.SelectedCells)
            {
                if (oneCell.Selected)
                {
                    grid.Rows.RemoveAt(oneCell.RowIndex);
                }
            }
        }
    }
}
