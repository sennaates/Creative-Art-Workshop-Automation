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

namespace FionerArt
{
    public partial class Baslangic : Form
    {
        public Baslangic()
        {
            InitializeComponent();
        }
        int KursiyerID;
        private void BtnOgrenciGirisi_Click(object sender, EventArgs e)
        {
            string username = TxtKullaniciAdi.Text;
            string password = TxtSifre.Text;
            SqlBaglantisi conn = new SqlBaglantisi();
            try
            {
                // SQL komutunu oluştur
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Tbl_KursiyerSifre WHERE KullaniciAdi=@username AND Sifre=@password", conn.Baglanti());
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                // Sorguyu çalıştır ve sonuçları al
                int result = (int)cmd.ExecuteScalar(); // COUNT(*) değeri dönecek

                // Sonuç kontrolü (0 ise kullanıcı adı veya şifre yanlış)
                if (result > 0)
                {

                    MessageBox.Show("Giriş başarılı!");// Ana sayfaya geçiş veya diğer işlemler burada yapılabilir
                    SqlCommand cmd2 = new SqlCommand("SELECT KursiyerID FROM Tbl_KursiyerSifre WHERE KullaniciAdi=@username AND Sifre=@password", conn.Baglanti());
                    cmd2.Parameters.AddWithValue("@username", username);
                    cmd2.Parameters.AddWithValue("@password", password);
                    FrmOgrenciGirisi frm = new FrmOgrenciGirisi();
                    KursiyerID = Convert.ToInt32(cmd2.ExecuteScalar());
                    frm.kursiyerID = KursiyerID;
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı veya şifre hatalı.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                conn.Baglanti().Close();
            }

        }

        private void BtnYoneticiGirisi_Click(object sender, EventArgs e)
        {
            string username = TxtKullaniciAdi.Text;
            string password = TxtSifre.Text;
            SqlBaglantisi conn = new SqlBaglantisi();
            try
            {
                // SQL komutunu oluştur
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Tbl_AdminSifre WHERE KullaniciAdi=@username AND Sifre=@password", conn.Baglanti());
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                // Sorguyu çalıştır ve sonuçları al
                int result = (int)cmd.ExecuteScalar(); // COUNT(*) değeri dönecek

                // Sonuç kontrolü (0 ise kullanıcı adı veya şifre yanlış)
                if (result > 0)
                {
                    MessageBox.Show("Giriş başarılı!");// Ana sayfaya geçiş veya diğer işlemler burada yapılabilir
                    FrmYoneticiGirisi frm = new FrmYoneticiGirisi();
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı veya şifre hatalı.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                conn.Baglanti().Close();
            }

        }

        private void BtnSifreGoster_MouseUp(object sender, MouseEventArgs e)
        {
            TxtSifre.Properties.PasswordChar = '*';
        }

        private void BtnSifreGoster_MouseDown(object sender, MouseEventArgs e)
        {
            TxtSifre.Properties.PasswordChar = '\0';
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Forms.FrmSifremiUnuttum fr = new Forms.FrmSifremiUnuttum();
            
            fr.Show();
        }
    }
}
