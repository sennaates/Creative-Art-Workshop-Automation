using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FionerArt
{
    class MailSender
    {
        public void MailYollamaIslemi(string mailAddres, string faturaPath)
        {
            try
            {
                // Gönderenin bilgileri
                string senderEmail = "235542010@firat.edu.tr";
                string senderPassword = "esbs vlgr fiju borc";

                // Alıcının e-posta adresi
                string recipientEmail = mailAddres;

                // E-posta ayarları
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(senderEmail);
                mail.To.Add(recipientEmail);
                mail.Subject = "Fioner Kurs Ödeme İşlemi Faturanız";
                mail.Body = "Fioner Kursa kaydolma işlemi için faturanız: " + faturaPath;
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
        public void MailYollamaIslemiBizeUlasin(string kullanicinIletisi)
        {
            try
            {
                // Gönderenin bilgileri
                string senderEmail = "235542010@firat.edu.tr";
                string senderPassword = "esbs vlgr fiju borc";

                // Alıcının e-posta adresi
                string recipientEmail = "sena18ates@gmail.com";

                // E-posta ayarları
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(senderEmail);
                mail.To.Add(recipientEmail);
                mail.Subject = "Fioner Bize Ulaşın";
                mail.Body = "Müşterinin iletisi: " + kullanicinIletisi;
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
    }
}
