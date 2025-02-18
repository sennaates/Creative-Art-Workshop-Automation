using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FionerArt.Forms
{
    public partial class FrmSifremiUnuttum : Form
    {
        public FrmSifremiUnuttum()
        {
            InitializeComponent();
        }

        private void WhatappMesajiYolla(string kullaniciAdi)
        {
            if (kullaniciAdi != "")
            {
                object telefonNo = GetTelefonNo(kullaniciAdi);

                if (telefonNo != null)
                {
                    string telefon = telefonNo.ToString();
                    try
                    {
                        string yeniParola = UpdatePassword(kullaniciAdi);
                        string mesaj = $"Bu, Windows Forms uygulamasından gönderilen bir test e-postasıdır. Fioner için yeni şifreniz: {yeniParola}. Güvenliğiniz için lütfen şifreyi değiştiriniz.";
                        System.Diagnostics.Process.Start($"https://api.whatsapp.com/send?phone=" + telefon + "&text=" + mesaj);
                    }
                    catch (Exception ex)
                    {

                    }
                }
                else
                {
                    Console.WriteLine("Kullanıcı bulunamadı.");
                }
            }
            else
            {
                MessageBox.Show("Kullanıcı adi giriniz!");
            }
        }
        private void MailYolla(string kullaniciAdi)
        {
            if (kullaniciAdi != "")
            {
                object mailAddres = GetEposta(kullaniciAdi);
                MailYollamaIslemi(mailAddres.ToString(), kullaniciAdi);
            }
            else
            {
                MessageBox.Show("Kullanıcı adi giriniz!");
            }

        }
        private string GetTelefonNo(string kullaniciAdi)
        {
            SqlBaglantisi conn = new SqlBaglantisi();
            string sorgu = @"
                SELECT k.Telefon
                FROM Tbl_KursiyerSifre ks
                INNER JOIN Tbl_Kursiyerler k ON ks.KursiyerID = k.KursiyerID
                WHERE ks.KullaniciAdi = @KullaniciAdi;";
            SqlCommand command = new SqlCommand(sorgu, conn.Baglanti());
            command.Parameters.AddWithValue("@KullaniciAdi", kullaniciAdi);

            string telefonNo = command.ExecuteScalar().ToString(); // Tek bir değer dönecek.
            return telefonNo;
        }
        private object GetEposta(string kullaniciAdi)
        {
            SqlBaglantisi conn = new SqlBaglantisi();
            string sorgu = @"
                SELECT k.Email
                FROM Tbl_KursiyerSifre ks
                INNER JOIN Tbl_Kursiyerler k ON ks.KursiyerID = k.KursiyerID
                WHERE ks.KullaniciAdi = @KullaniciAdi;";
            SqlCommand command = new SqlCommand(sorgu, conn.Baglanti());
            command.Parameters.AddWithValue("@KullaniciAdi", kullaniciAdi);

            object ePosta = command.ExecuteScalar(); // Tek bir değer dönecek.
            return ePosta;
        }
        public static string UpdatePassword(string kullaniciAdi)
        {
            SqlBaglantisi conn = new SqlBaglantisi();
            // 7 haneli rastgele sayı üret
            Random random = new Random();
            string yeniParola = random.Next(1000000, 10000000).ToString(); // 7 haneli sayı üret

            // SQL sorgusu
            string query = "UPDATE Tbl_KursiyerSifre SET Sifre = @YeniParola WHERE KullaniciAdi = @KullaniciAdi";

            SqlCommand command = new SqlCommand(query, conn.Baglanti());
            // Parametreleri ekle
            command.Parameters.AddWithValue("@YeniParola", yeniParola);
            command.Parameters.AddWithValue("@KullaniciAdi", kullaniciAdi);

            // Sorguyu çalıştır
            command.ExecuteNonQuery();
            return yeniParola;
        }
        private void MailYollamaIslemi(string ePostaAdresi, string kullaniciAdi)
        {
            try
            {
                // Gönderenin bilgileri
                string senderEmail = "235542010@firat.edu.tr";
                string senderPassword = "esbs vlgr fiju borc";

                // Alıcının e-posta adresi
                string recipientEmail = ePostaAdresi;
                //sifre üret
                string yeniParola = UpdatePassword(kullaniciAdi);
                // E-posta ayarları
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(senderEmail);
                mail.To.Add(recipientEmail);
                mail.Subject = "Fioner Art Şifre Değişikliği";
                mail.Body = "Bu, Windows Forms uygulamasından gönderilen bir test e-postasıdır. Fioner Art için yeni şifreniz: " + yeniParola + ". ";
                mail.IsBodyHtml = false; // Eğer HTML formatında göndermek istiyorsanız true yapabilirsiniz.

                // SMTP ayarları
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential(senderEmail, senderPassword);
                smtp.EnableSsl = true; // Gmail için SSL gereklidir.
                smtp.Send(mail);

                MessageBox.Show("E-posta başarıyla gönderildi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"E-posta gönderilirken bir hata oluştu:\n{ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnWhatsApp_Click(object sender, EventArgs e)
        {
            WhatappMesajiYolla(TxtKullaniciAdi.Text);
        }

        private void BtnEposta_Click(object sender, EventArgs e)
        {
            MailYolla(TxtKullaniciAdi.Text);
        }
    }
}
