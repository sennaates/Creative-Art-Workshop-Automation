using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FionerArt.Forms
{
    public partial class FrmOgrenciCizimFikirleri : Form
    {
        public FrmOgrenciCizimFikirleri()
        {
            InitializeComponent();
        }
        public int kursiyerID;
        private void ımageSlider2_Click(object sender, EventArgs e)
        {

        }
        SqlBaglantisi bgl = new SqlBaglantisi();
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("UPDATE Tbl_CizimFikri SET FikirAlmaSayisi = FikirAlmaSayisi + @p1 WHERE KursiyerID=@p2", bgl.Baglanti());
            komut.Parameters.AddWithValue("@p1", 1);
            komut.Parameters.AddWithValue("@p2", kursiyerID);
            komut.ExecuteNonQuery();
            bgl.Baglanti().Close();

            string prompt = richTextBox1.Text;
            string encodedPrompt = Uri.EscapeDataString(prompt);
            string baseUrl = "https://monica.im/home/image?key=imageGenerator&payload=";
            string payload = $"{{\"imageCount\":1,\"prompt\":\"{encodedPrompt}\",\"modelType\":\"sdxl\",\"aspectRatio\":\"1:1\",\"imageStyle\":\"auto\"}}";
            string fullUrl = $"{baseUrl}{Uri.EscapeDataString(payload)}";

            Process.Start(new ProcessStartInfo
            {
                FileName = fullUrl,
                UseShellExecute = true
            });
        }
    }
}
