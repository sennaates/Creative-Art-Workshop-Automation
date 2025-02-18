using DevExpress.XtraBars.Docking2010.Views;
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
using System.Windows.Forms.DataVisualization.Charting;

namespace FionerArt.Forms
{
    public partial class FrmYoneticiCharts : Form
    {
        SqlBaglantisi bgl = new SqlBaglantisi();
        public FrmYoneticiCharts()
        {
            InitializeComponent();
        }


        private void FrmYoneticiCharts_Load(object sender, EventArgs e)
        {
            ChartlariDoldur();
        }
        private void ChartlariDoldur()
        {
            // pasta dilimi doldur

            string query = "SELECT Kategori, COUNT(*) AS KategoriAdet FROM Tbl_Malzeme GROUP BY Kategori";

            SqlCommand command = new SqlCommand(query, bgl.Baglanti());
            SqlDataReader dr = command.ExecuteReader(); // Verileri oku

            // Pasta grafiğe veri ekle
            while (dr.Read())
            {
                string kategori = dr["Kategori"].ToString();              // Kategori adı
                int kategoriAdet = Convert.ToInt32(dr["KategoriAdet"]);    // Kategoriye ait adet

                // Grafiğe veri ekle
                chartControl1.Series["Kategoriler"].Points.AddPoint(kategori, kategoriAdet);
            }
            dr.Close();

            // Etiketleri göster
            chartControl1.Series["Kategoriler"].Label.TextPattern = "{A}: {V} adet"; // Kategori ve Adet
            chartControl1.Series["Kategoriler"].Label.Font = new Font("Arial", 10); // Etiket fontu ayarı
            chartControl1.Series["Kategoriler"].Label.Visible = true; // Etiketleri göster

            // Tooltip ayarları
            chartControl1.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True; // Legend görünürlüğü

            // sütun grafiği doldur
            
            string query2 = "SELECT KursAdi, Kontenjan FROM Tbl_Kurslar";

            SqlCommand command2 = new SqlCommand(query2, bgl.Baglanti());
            SqlDataReader dr2 = command2.ExecuteReader();

            while (dr2.Read())
            {
                // SQL'den gelen veriyi okuma
                string KursAdi = dr2["KursAdi"].ToString(); // Kurs adı sütunu
                int Kontenjan = Convert.ToInt32(dr2["Kontenjan"]); // Kontenjan sütunu

                // Chart kontrolüne veri ekleme
                chartControl2.Series["Kontenjan"].Points.AddPoint(KursAdi, Kontenjan);
            }

            dr2.Close();
        }

        private void labelControl3_Click(object sender, EventArgs e)
        {

        }
    }
}
